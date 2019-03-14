using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using System.Runtime.InteropServices;
using System.IO;



namespace HalControl
{
    /// <summary>
    /// halcon窗口，带draw功能
    /// </summary>
    public partial class HalconWinControl_Draw : UserControl
    {
        #region 系统api
        //[DllImport("user32.dll")]
        //public static extern int GetFocus();
        #endregion

        #region  全局变量

        #region   有图片标志
        /// <summary>
        /// 有图片标志
        /// </summary>
        bool exit_Image;
        #endregion

        #region  图片的数据
        /// <summary>
        /// 图片的数据
        /// </summary>
        private HObject _ho_Image = null;
        #endregion

        #region 鼠标的数据状态 在窗口的坐标 窗口控件数据
        /// <summary>
        /// 记录鼠标按下或松开
        /// </summary>       
        private bool _b_leftButton, _b_rightButton;
        /// <summary>
        /// 记录鼠标当前的位置
        /// </summary>
        private double _start_positionX = 0, _start_positionY = 0;
        /// <summary>
        ///  设定图像的窗口显示部分
        /// </summary>
        private int zoom_beginRow, zoom_beginCol, zoom_endRow, zoom_endCol;
        /// <summary>
        /// 获取图像的当前显示部分
        /// </summary>
        private int current_beginRow = 0, current_beginCol = 0, current_endRow = 0, current_endCol = 0;

        #endregion

        #region halcon窗口HWindow
        /// <summary>
        /// halcon窗口HWindow
        /// </summary>
        private HWindow _halconWindow1;
        #endregion

        #region   委托，事件
        /// <summary>
        /// 绘图委托
        /// </summary>
        /// <param name="_halconWindow1"></param>
        public delegate void repaint(HWindow _halconWindow1);

        /// <summary>
        /// 绘图触发事件
        /// </summary>
        public event repaint Repaint;
        #endregion

        #endregion

        #region 属性
        /// <summary>
        /// 图片的数据
        /// </summary>
        public HObject Ho_Image
        {
            get
            {
                return _ho_Image;
            }

            set
            {
                _ho_Image = value;
                if (_ho_Image != null)
                {
                    if (exit_Image == false)
                    {
                        exit_Image = true;
                    }
                    hWindowControl1.HalconWindow.DispObj(_ho_Image);
                }

            }
        }

        /// <summary>
        /// halcon窗口HWindow
        /// </summary>
        public HWindow HalconWindow1
        {
            get
            {
                return _halconWindow1;
            }

            set
            {
                _halconWindow1 = value;
            }
        }

        #region  有图片标志
        /// <summary>
        /// 有图片标志
        /// </summary>
        public bool Exit_Image()
        {
            return exit_Image;
        }
        #endregion

        #endregion

        #region  初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public HalconWinControl_Draw()
        {
            InitializeComponent();
        }

        /// <summary>
        ///初始化控件image，和_halconWindow,及窗口设置的颜色
        /// </summary>
        /// <returns></returns>
        public bool init()
        {
            bool ok = false;

            exit_Image = false;

            _halconWindow1 = hWindowControl1.HalconWindow;

            _halconWindow1.SetColor("red");

            HOperatorSet.GenEmptyObj(out _ho_Image);
            _ho_Image.Dispose();

            ok = true;
            return ok;
        }
        #endregion

        #region  适应窗口
        private void bnt_fit_window_Click(object sender, EventArgs e)
        {
            DispImageFit();
        }
        #endregion

        #region  刷新窗口
        private void bnt_repaint_window_Click(object sender, EventArgs e)
        {
            refreshWindow();
        }
        #endregion

        #region  保存图片
        private void bnt_save_image_Click(object sender, EventArgs e)
        {
            SaveWindowDumpDialog();
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        private void SaveWindowDumpDialog()
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                //string imgFileName;

                sfd.Filter = "PNG图像|*.png|BMP图像|*.bmp|JPEG图像|*.jpg|所有文件|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (String.IsNullOrEmpty(sfd.FileName))
                        return;
                    HOperatorSet.WriteImage(Ho_Image, Path.GetExtension(sfd.FileName).Substring(1), 0, sfd.FileName);

                    //  hv_image.WriteImage(Path.GetExtension(sfd.FileName).Substring(1), 0, sfd.FileName);
                    //imgFileName = sfd.FileName;
                    //SaveWindowDump(imgFileName, new Size(1280, 1024));
                }
            }
            catch (Exception ex)
            {
                StatusMessage.Text = ex.Message;
            }

        }

        #endregion

        #region  设置窗口显示的颜色
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = com_show_color.Text;

            _halconWindow1.SetColor(str);
        }

        /// <summary>
        /// 设置窗口颜色
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool set_color(string color)
        {
            bool ok = false;

            if (color != null)
            {
                _halconWindow1.SetColor(color);
            }
            ok = true;
            return ok;
        }
        #endregion

        #region halcon 控件函数

        #region 鼠标移动时发生
        private void hWindowControl1_HMouseMove(object sender, HMouseEventArgs e)
        {
            if (_ho_Image.IsInitialized())
            {
                try
                {
                    int button_state;
                    double positionX, positionY;
                    string str_value;
                    string str_position;
                    bool _isXOut = true, _isYOut = true;
                    HTuple channel_count;//元素

                    HOperatorSet.CountChannels(_ho_Image, out channel_count);//计算图片的通道

                    hWindowControl1.HalconWindow.GetMpositionSubPix(out positionY, out positionX, out button_state);//得到亚像素组成 取得坐标，及鼠标的状态
                    str_position = String.Format("X: {0:0000.0}, Y: {1:0000.0}", positionX, positionY);//把坐标转成字符格式

                    HTuple width, height;
                    HOperatorSet.GetImageSize(_ho_Image, out width, out height);
                    _isXOut = (positionX < 0 || positionX >= (double)width);//判断是否超出范围，超出为1
                    _isYOut = (positionY < 0 || positionY >= (double)height);//判断是否超出范围，超出为1

                    if (!_isXOut && !_isYOut)
                    {
                        if ((int)channel_count == 1)
                        {
                            HTuple grayval;
                            HOperatorSet.GetGrayval(_ho_Image, (HTuple)positionY, (HTuple)positionX, out grayval);
                            str_value = String.Format("灰度值: {0:000.0}", (double)grayval);//显示出去
                        }
                        else
                        {
                            if ((int)channel_count == 3)
                            {
                                str_value = "";
                                HTuple grayValRed, grayValGreen, grayValBlue;
                                HObject _RedChannel, _GreenChannel, _BlueChannel;
                                HOperatorSet.GenEmptyObj(out _RedChannel);
                                HOperatorSet.GenEmptyObj(out _GreenChannel);
                                HOperatorSet.GenEmptyObj(out _BlueChannel);
                                HOperatorSet.AccessChannel(_ho_Image, out _RedChannel, 1);
                                HOperatorSet.AccessChannel(_ho_Image, out _GreenChannel, 2);
                                HOperatorSet.AccessChannel(_ho_Image, out _BlueChannel, 3);

                                HOperatorSet.GetGrayval(_RedChannel, (HTuple)positionY, (HTuple)positionX, out grayValRed);
                                HOperatorSet.GetGrayval(_GreenChannel, (HTuple)positionY, (HTuple)positionX, out grayValGreen);
                                HOperatorSet.GetGrayval(_BlueChannel, (HTuple)positionY, (HTuple)positionX, out grayValBlue);

                                _RedChannel.Dispose();
                                _GreenChannel.Dispose();
                                _BlueChannel.Dispose();

                                str_value = String.Format("Val: ({0:000.0}, {1:000.0}, {2:000.0})", (double)grayValRed, (double)grayValGreen, (double)grayValBlue);//显示3个通道的灰度值

                            }
                            else
                            {
                                str_value = "";
                            }
                        }
                        StatusMessage.Text = str_position + "    " + str_value;
                    }

                    switch (button_state)
                    {
                        case 0:
                            this.Cursor = System.Windows.Forms.Cursors.Default;//显示鼠标类型为手型
                            break;
                        case 1:
                            this.Cursor = System.Windows.Forms.Cursors.Hand;//显示鼠标类型为手型
                            hWindowControl1.HalconWindow.ClearWindow();//清空窗体类容
                            hWindowControl1.HalconWindow.SetPaint(new HTuple("default"));//设置显示默认
                            //              保持图像显示比例

                            zoom_beginRow -= (int)(positionY - _start_positionY);
                            zoom_beginCol -= (int)(positionX - _start_positionX);
                            zoom_endRow -= (int)(positionY - _start_positionY);

                            #region  无用代码
                            //if (zoom_endRow == zoom_beginRow)
                            //{
                            //    //HOperatorSet.GetImageSize(_ho_Image);
                            //    zoom_endRow = 2000;
                            //}
                            #endregion

                            zoom_endCol -= (int)(positionX - _start_positionX);

                            if ((zoom_endCol == zoom_beginCol) || (zoom_endRow == zoom_beginRow))
                            {
                                HTuple w, h;
                                HOperatorSet.GetImageSize(_ho_Image, out w, out h);
                                zoom_endCol = (int)w;
                                zoom_endRow = (int)h;
                            }

                            hWindowControl1.HalconWindow.SetPart(zoom_beginRow, zoom_beginCol, zoom_endRow, zoom_endCol);
                            //hWindowControl1.HalconWindow.SetPart(1, 1, 1, 1);
                            hWindowControl1.HalconWindow.DispObj(_ho_Image);//显示图片
                            break;
                    }

                }
                catch (Exception ex)
                {
                    StatusMessage.Text = ex.Message;
                }
            }
        }
        #endregion

        #region 鼠标释放时发生
        private void hWindowControl1_HMouseUp(object sender, HMouseEventArgs e)
        {
            try
            {
                switch (e.Button)
                {
                    case MouseButtons.Left://左键
                        this.Cursor = System.Windows.Forms.Cursors.Default;//变回默认
                        _b_leftButton = false;//设置按钮状态
                        break;
                    case MouseButtons.Right://右键
                        _b_rightButton = false;//设置按钮状态
                        break;
                    case MouseButtons.Middle:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                StatusMessage.Text = ex.Message;
            }
        }
        #endregion

        #region 图片滚轮放大缩小
        private void hWindowControl1_HMouseWheel(object sender, HMouseEventArgs e)
        {
            if (_ho_Image.IsInitialized())
            {

                double mposition_row = 0, mposition_col = 0;
                int button_state;

                HWindow hv_window = hWindowControl1.HalconWindow;

                try
                {
                    hv_window.GetMpositionSubPix(out mposition_row, out mposition_col, out button_state);
                    hv_window.GetPart(out current_beginRow, out current_beginCol, out current_endRow, out current_endCol);
                }
                catch (Exception ex)
                {
                    StatusMessage.Text = ex.Message;
                }

                if (e.Delta > 0)                 // 放大图像
                {
                    zoom_beginRow = (int)(current_beginRow + (mposition_row - current_beginRow) * 0.300d);
                    zoom_beginCol = (int)(current_beginCol + (mposition_col - current_beginCol) * 0.300d);
                    zoom_endRow = (int)(current_endRow - (current_endRow - mposition_row) * 0.300d);
                    zoom_endCol = (int)(current_endCol - (current_endCol - mposition_col) * 0.300d);

                }
                else                // 缩小图像
                {
                    zoom_beginRow = (int)(mposition_row - (mposition_row - current_beginRow) / 0.700d);
                    zoom_beginCol = (int)(mposition_col - (mposition_col - current_beginCol) / 0.700d);
                    zoom_endRow = (int)(mposition_row + (current_endRow - mposition_row) / 0.700d);
                    zoom_endCol = (int)(mposition_col + (current_endCol - mposition_col) / 0.700d);
                }

                try
                {
                    int hw_width, hw_height;
                    hw_width = hWindowControl1.Size.Width;
                    hw_height = hWindowControl1.Size.Height;

                    HTuple width, height;
                    HOperatorSet.GetImageSize(_ho_Image, out width, out height);

                    bool _isOutOfArea = true;
                    bool _isOutOfSize = true;
                    bool _isOutOfPixel = true; //避免像素过大

                    _isOutOfArea = zoom_beginRow >= (int)height || zoom_endRow <= 0 || zoom_beginCol >= (int)width || zoom_endCol < 0;
                    _isOutOfSize = (zoom_endRow - zoom_beginRow) > (int)height * 20 || (zoom_endCol - zoom_beginCol) > (int)width * 20;
                    _isOutOfPixel = hw_height / (zoom_endRow - zoom_beginRow) > 500 || hw_width / (zoom_endCol - zoom_beginCol) > 500;

                    if (_isOutOfArea || _isOutOfSize)
                    {
                        HOperatorSet.SetPart(hWindowControl1.HalconWindow, 0, 0, height - 1, width - 1);
                        hWindowControl1.HalconWindow.DispObj(_ho_Image);
                    }
                    else if (!_isOutOfPixel)
                    {
                        hWindowControl1.HalconWindow.ClearWindow();
                        zoom_endCol = zoom_beginCol + (zoom_endRow - zoom_beginRow) * hw_width / hw_height;

                        hv_window.SetPart(zoom_beginRow, zoom_beginCol, zoom_endRow, zoom_endCol);
                        hv_window.DispObj(_ho_Image);

                    }
                }
                catch (Exception ex)
                {
                    DispImageFit();
                    StatusMessage.Text = ex.Message;
                }
            }
        }
        #endregion

        #region 鼠标按下时发生
        private void hWindowControl1_HMouseDown(object sender, HMouseEventArgs e)
        {
            int temp_button_state;
            try
            {
                switch (e.Button)
                {
                    case MouseButtons.Left://鼠标左键按下检测
                        this.Cursor = System.Windows.Forms.Cursors.Hand;//把鼠标显示为手型
                        hWindowControl1.HalconWindow.GetMpositionSubPix(out _start_positionY, out _start_positionX, out temp_button_state);//得到亚像素组成 取得坐标，及鼠标的状态
                        _b_leftButton = true;//记录鼠标的状态
                        break;
                    case MouseButtons.Right:
                        _b_rightButton = true;//记录鼠标的状态
                        this.Cursor = System.Windows.Forms.Cursors.Default;//把鼠标显示为手型
                        break;
                    case MouseButtons.Middle://鼠标中间按钮按下
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                StatusMessage.Text = ex.Message;//显示的运行错误
            }

        }
        #endregion

        #region   刷新halcon控件
        /// <summary>
        /// 刷新控件
        /// </summary>
        public void refreshWindow()
        {
            hWindowControl1.HalconWindow.ClearWindow();
            if (_ho_Image.IsInitialized())
            {
                hWindowControl1.HalconWindow.DispObj(_ho_Image);

            }

            if (Repaint != null)
            {
                Repaint(hWindowControl1.HalconWindow);
            }

        }
        #endregion

        #region   屏蔽halcon控件的鼠标事件
        /// <summary>
        /// 屏蔽鼠标事件
        /// </summary>
        public void ShieldMouseEvent()
        {
            // hWindowControl1.ContextMenuStrip = null;

            //this.hWindowControl1.HMouseDown -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
            //this.hWindowControl1.HMouseUp -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);
            //hWindowControl1.HMouseMove -= hWindowControl1_HMouseMove;
            //hWindowControl1.HMouseWheel -= hWindowControl1_HMouseWheel;
            this.hWindowControl1.HMouseMove -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseMove);
            this.hWindowControl1.HMouseDown -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
            this.hWindowControl1.HMouseUp -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);
            this.hWindowControl1.HMouseWheel -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseWheel);
        }
        #endregion

        #region 重新加载halcon控件　鼠标事件
        /// <summary>
        /// 重新加载　鼠标事件
        /// </summary>
        public void ReloadMouseEvent()
        {
            //  hWindowControl1.ContextMenuStrip = contextMenuStrip_halcon;
            //this.hWindowControl1.HMouseDown += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
            //this.hWindowControl1.HMouseUp += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);
            //hWindowControl1.HMouseMove += hWindowControl1_HMouseMove;
            //hWindowControl1.HMouseWheel += hWindowControl1_HMouseWheel;
            this.hWindowControl1.HMouseMove += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseMove);
            this.hWindowControl1.HMouseDown += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
            this.hWindowControl1.HMouseUp += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);
            this.hWindowControl1.HMouseWheel += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseWheel);
        }
        #endregion

        #region    屏蔽halcon控件的鼠标事件,但不屏蔽滚轮事件
        /// <summary>
        ///   屏蔽halcon控件的鼠标事件,但不屏蔽滚轮事件
        /// </summary>
        public void ti_qu_model_shi_ShieldMouseEvent()
        {
            hWindowControl1.ContextMenuStrip = null;

            //this.hWindowControl1.HMouseDown -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
            //this.hWindowControl1.HMouseUp -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);
            //hWindowControl1.HMouseMove -= hWindowControl1_HMouseMove;
            //hWindowControl1.HMouseWheel -= hWindowControl1_HMouseWheel;
            this.hWindowControl1.HMouseMove -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseMove);
            this.hWindowControl1.HMouseDown -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
            this.hWindowControl1.HMouseUp -= new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);
        }
        #endregion

        #region  重新加载halcon控件　鼠标事件但不加载滚轮事件
        /// <summary>
        ///重新加载halcon控件　鼠标事件但不加载滚轮事件
        /// </summary>
        public void ti_qu_model_shi_ReloadMouseEvent()
        {
            // hWindowControl1.ContextMenuStrip = contextMenuStrip_halcon;
            //this.hWindowControl1.HMouseDown += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
            //this.hWindowControl1.HMouseUp += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);
            //hWindowControl1.HMouseMove += hWindowControl1_HMouseMove;
            //hWindowControl1.HMouseWheel += hWindowControl1_HMouseWheel;
            this.hWindowControl1.HMouseMove += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseMove);
            this.hWindowControl1.HMouseDown += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown);
            this.hWindowControl1.HMouseUp += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp);

        }
        #endregion

        #region   清空窗体
        public bool clear_Window()
        {
            bool ok = false;

            hWindowControl1.HalconWindow.ClearWindow();

            ok = true;
            return ok;
        }
        #endregion

        #region 适应窗口
        /// <summary>
        /// 让图片适应窗口显示
        /// </summary>
        void DispImageFit()
        {
            try
            {
                if (_ho_Image.IsInitialized())
                {
                    hWindowControl1.HalconWindow.ClearWindow();
                    HTuple width, height;
                    HOperatorSet.GetImageSize(_ho_Image, out width, out height);
                    HOperatorSet.SetPart(hWindowControl1.HalconWindow, 0, 0, height - 1, width - 1);
                    hWindowControl1.HalconWindow.DispObj(_ho_Image);

                    //if (_xld!=null)
                    //{
                    //    hWindowControl1.HalconWindow.DispObj(_xld);
                    //}
                }

            }
            catch (Exception ex)
            {
                StatusMessage.Text = ex.Message;
            }
        }
        #endregion
      
        #endregion

        #region  绘制
        #region 在图像中绘制矩形区域
        /// <summary>
        ///  在图像中绘制矩形区域
        /// </summary>
        /// <param name="rowBegin"></param>
        /// <param name="colBegin"></param>
        /// <param name="rowEnd"></param>
        /// <param name="colEnd"></param>
        public void DrawRectangle1(string color, out double rowBegin, out double colBegin, out double rowEnd, out double colEnd)
        {
            try
            {
                Double _rowBegin, _colBegin, _rowEnd, _colEnd;

                ShieldMouseEvent();

                hWindowControl1.Focus();

                #region 无用代码
                //IntPtr handle = (IntPtr)GetFocus();
                //if (handle == null)
                //{
                //    this.FindForm().KeyPreview = true;
                //}
                //else
                //{
                //    Control c = Control.FromHandle(handle);//这就是
                //}
                #endregion

                hWindowControl1.HalconWindow.SetColor(color);
                hWindowControl1.HalconWindow.DrawRectangle1(out _rowBegin, out _colBegin, out _rowEnd, out _colEnd);
                // hv_window.SetColor(color);
                //  hv_window.DrawRectangle1(out _rowBegin, out _colBegin, out _rowEnd, out _colEnd);


                HRegion rectangle = new HRegion();
                rectangle.GenRectangle1(_rowBegin, _colBegin, _rowEnd, _colEnd);
                rectangle.GenContourRegionXld("border").DispObj(hWindowControl1.HalconWindow);

                //  rectangle.DispObj(hWindowControl1.HalconWindow);
                rectangle.Dispose();

                ReloadMouseEvent();

                rowBegin = _rowBegin;
                colBegin = _colBegin;
                rowEnd = _rowEnd;
                colEnd = _colEnd;
            }
            catch (System.Exception ex)
            {
                rowBegin = 0.0;
                colBegin = 0.0;
                rowEnd = 0.0;
                colEnd = 0.0;
                status_message.Text = ex.Message;
            }
        }
        #endregion

        #region 在图像中绘制矩形区域
        /// <summary>
        ///  在图像中绘制矩形区域
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="phi"></param>
        /// <param name="length1"></param>
        /// <param name="length2"></param>
        public void DrawRectangle2(string color, out double row, out double column, out double phi, out double length1, out double length2)
        {
            try
            {
                Double _row, _column, _phi, _length1, _length2;
                ShieldMouseEvent();
                hWindowControl1.Focus();
                hWindowControl1.HalconWindow.SetColor(color);
                hWindowControl1.HalconWindow.DrawRectangle2(out _row, out _column, out _phi, out _length1, out _length2);
                HRegion rectangle = new HRegion();
                rectangle.GenRectangle2(_row, _column, _phi, _length1, _length2);
                rectangle.GenContourRegionXld("border").DispObj(hWindowControl1.HalconWindow);

                //   rectangle.DispObj(hWindowControl1.HalconWindow);
                rectangle.Dispose();
                ReloadMouseEvent();
                row = _row;
                column = _column;
                phi = _phi;
                length1 = _length1;
                length2 = _length2;
            }
            catch (System.Exception ex)
            {
                row = 0.0;
                column = 0.0;
                phi = 0.0;
                length1 = 0.0;
                length2 = 0.0;
                status_message.Text = ex.Message;
            }
        }
        #endregion

        #region   在图像中绘制圆形区域
        /// <summary>
        /// 在图像中绘制圆形区域
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="radius"></param>
        public void DrawCircle(string color, out double row, out double column, out double radius)
        {
            try
            {
                Double _row, _column, _radius;
                ShieldMouseEvent();

                hWindowControl1.Focus();
                hWindowControl1.HalconWindow.SetColor(color);
                hWindowControl1.HalconWindow.DrawCircle(out _row, out _column, out _radius);

                HRegion circle = new HRegion();
                circle.GenCircle(_row, _column, _radius);

                circle.GenContourRegionXld("border").DispObj(hWindowControl1.HalconWindow);

                // circle.DispObj(hWindowControl1.HalconWindow);
                circle.Dispose();
                ReloadMouseEvent();

                row = _row;
                column = _column;
                radius = _radius;

            }
            catch (Exception ex)
            {
                row = 0.0;
                column = 0.0;
                radius = 0.0;
                status_message.Text = ex.Message;
            }
        }
        #endregion

        #region   在图像中绘制直线
        /// <summary>
        /// 在图像中绘制直线
        /// </summary>
        /// <param name="color"></param>
        /// <param name="beginRow"></param>
        /// <param name="beginCol"></param>
        /// <param name="endRow"></param>
        /// <param name="endCol"></param>
        public void DrawLine(string color, out double beginRow, out double beginCol, out double endRow, out double endCol)
        {
            try
            {
                Double _beginRow, _beginCol, _endRow, _endCol;
                ShieldMouseEvent();

                hWindowControl1.Focus();
                hWindowControl1.HalconWindow.SetColor(color);
                hWindowControl1.HalconWindow.DrawLine(out _beginRow, out _beginCol, out _endRow, out _endCol);

                hWindowControl1.HalconWindow.DispLine(_beginRow, _beginCol, _endRow, _endCol);
                ReloadMouseEvent();

                beginRow = _beginRow;
                beginCol = _beginCol;
                endRow = _endRow;
                endCol = _endCol;

            }
            catch (Exception ex)
            {
                beginRow = 0.0;
                beginCol = 0.0;
                endRow = 0.0;
                endCol = 0.0;
                status_message.Text = ex.Message;
            }
        }
        #endregion

        #region  在图像中绘制椭圆形区域
        /// <summary>
        /// 在图像中绘制椭圆形区域
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="radius"></param>
        public void DrawEllipse(string color, out double row, out double column, out double phi, out double radius1, out double radius2)
        {
            try
            {

                Double _row, _column, _phi, _radius1, _radius2;
                ShieldMouseEvent();


                hWindowControl1.Focus();
                hWindowControl1.HalconWindow.SetColor(color);
                hWindowControl1.HalconWindow.DrawEllipse(out _row, out _column, out _phi, out _radius1, out _radius2);

                HRegion ellipse = new HRegion();
                ellipse.GenEllipse(_row, _column, _phi, _radius1, _radius2);

                ellipse.GenContourRegionXld("border").DispObj(hWindowControl1.HalconWindow);
                // ellipse.DispObj(hWindowControl1.HalconWindow);
                ellipse.Dispose();
                ReloadMouseEvent();

                row = _row;
                column = _column;
                phi = _phi;
                radius1 = _radius1;
                radius2 = _radius2;

            }
            catch (Exception ex)
            {
                row = 0.0;
                column = 0.0;
                phi = 0.0;
                radius1 = 0.0;
                radius2 = 0.0;
                status_message.Text = ex.Message;
            }
        }
        #endregion

        #endregion
    }
}
