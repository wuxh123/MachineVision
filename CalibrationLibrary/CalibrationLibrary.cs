using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;





namespace CalibrationLibrary
{
    #region  标定数据
    /// <summary>
    /// 标定数据
    /// </summary>
    [Serializable]
    public class CalibrationShuJu : MultTree.ToolDateFather, ICalibrationShuJu
    {
        #region  9标定数据

        #region   像素坐标
        /// <summary>
        /// 像素坐标  y
        /// </summary>
        [NonSerialized]
        HTuple calrow_pixel_y = new HTuple();

        /// <summary>
        /// 像素坐标  x
        /// </summary>
        [NonSerialized]
        HTuple calcol_pixel_x = new HTuple();
        #endregion

        #region  世界坐标
        /// <summary>
        /// 世界坐标  x
        /// </summary>
        [NonSerialized]
        HTuple calcol_world_x = new HTuple();

        /// <summary>
        ///  世界坐标  y
        /// </summary>
        [NonSerialized]
        HTuple calrow_world_y = new HTuple();
        #endregion

        #endregion

        #region  标定工具
        /// <summary>
        /// 标定工具
        /// </summary>
        List<string> _cal_tool_path = null;
        #endregion

        #region   防射变换
        /// <summary>
        /// 防射变换
        /// </summary>
        [NonSerialized]
        HTuple homMat2D = null;
        #endregion

        #region  序列化数据

        #region  像素坐标
        /// <summary>
        /// 像素坐标 y
        /// </summary>
        List<double> calrow_pixel_y_1 = new List<double>();

        /// <summary>
        /// 像素坐标 x
        /// </summary>
        List<double> calcol_pixel_x_1 = new List<double>();
        #endregion

        #region  世界坐标
        /// <summary>
        /// 世界坐标 x
        /// </summary>
        List<double> calcol_world_x_1 = new List<double>();

        /// <summary>
        /// 世界坐标 y
        /// </summary>
        List<double> calrow_world_y_1 = new List<double>();
        #endregion

        #region   仿射变换
        /// <summary>
        /// 仿射变换
        /// </summary>       
        Object homMat2D_1;
        #endregion

        #endregion

        #region  保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        public override void save()
        {
            base.save();

            calrow_pixel_y_1.Clear();
            calcol_pixel_x_1.Clear();
            calcol_world_x_1.Clear();
            calrow_world_y_1.Clear();
            for (int i = 0; i < 9; i++)
            {
                //calrow_pixel_y_1[i] = calrow_pixel_y[i];
                //calcol_pixel_x_1[i] = calcol_pixel_x[i];
                //calcol_world_x_1[i] = calcol_world_x[i];
                //calrow_world_y_1[i] = calrow_world_y[i];
                calrow_pixel_y_1.Add(calrow_pixel_y[i].D);
                calcol_pixel_x_1.Add(calcol_pixel_x[i].D);
                calcol_world_x_1.Add(calcol_world_x[i].D);
                calrow_world_y_1.Add(calrow_world_y[i].D);
            }

            homMat2D_1 = this.HomMat2D;
        }
        #endregion

        #region  初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        public override void init()
        {
            base.init();

            calrow_pixel_y = new HTuple();
            calcol_pixel_x = new HTuple();
            calcol_world_x = new HTuple();
            calrow_world_y = new HTuple();

            for (int i = 0; i < 9; i++)
            {
                calrow_pixel_y[i] = calrow_pixel_y_1[i];
                calcol_pixel_x[i] = calcol_pixel_x_1[i];

                calcol_world_x[i] = calcol_world_x_1[i];
                calrow_world_y[i] = calrow_world_y_1[i];
            }

            this.HomMat2D = (HTuple)homMat2D_1;
        }
        #endregion

        #region  属性

        #region   像素坐标
        /// <summary>
        /// 像素坐标  y
        /// </summary>
        public HTuple Calrow_pixel_y
        {
            get { return calrow_pixel_y; }
            set { calrow_pixel_y = value; }
        }

        /// <summary>
        /// 像素坐标  x
        /// </summary>
        public HTuple Calcol_pixel_x
        {
            get { return calcol_pixel_x; }
            set { calcol_pixel_x = value; }
        }
        #endregion

        #region  世界坐标
        /// <summary>
        /// 世界坐标  x
        /// </summary>
        public HTuple Calcol_world_x
        {
            get { return calcol_world_x; }
            set { calcol_world_x = value; }
        }

        /// <summary>
        ///  世界坐标  y
        /// </summary>
        public HTuple Calrow_world_y
        {
            get { return calrow_world_y; }
            set { calrow_world_y = value; }
        }
        #endregion

        #region   防射变化
        /// <summary>
        /// 防射变换
        /// </summary>
        public HTuple HomMat2D
        {
            get { return homMat2D; }
            set { homMat2D = value; }
        }
        #endregion

        #region  标定工具
        /// <summary>
        /// 标定工具
        /// </summary>
        public List<string> _Cal_tool_path
        {
            get
            {
                if (_cal_tool_path == null)
                {
                    _cal_tool_path = new List<string>();
                }
                return _cal_tool_path;
            }
            set { _cal_tool_path = value; }
        }
        #endregion

        #endregion

        #region  检测
        public override bool analyze_show( HWindow hwin, string Key, ref Dictionary<string, object> _dictionary_resulte)
        {
            bool ok = false;
            Calibration_Result Result_ = new Calibration_Result();
            Key = "Calibration_" + Key;
            Result_._tolatName = Key;
            Result_._tolatResult = true;
            _dictionary_resulte.Add(Key, Result_);
            ok = true;
            return ok;
        }
        #endregion

    }
    #endregion

    #region   数据接口
    /// <summary>
    /// 数据接口
    /// </summary>
    public interface ICalibrationShuJu : IHomMat2D, MultTree.IToolDateFather
    {
        #region  属性

        #region   像素坐标
        /// <summary>
        /// 像素坐标  y
        /// </summary>
        HTuple Calrow_pixel_y
        {
            get;
            set;
        }

        /// <summary>
        /// 像素坐标  x
        /// </summary>
        HTuple Calcol_pixel_x
        {
            get;
            set;
        }
        #endregion

        #region  世界坐标
        /// <summary>
        /// 世界坐标  x
        /// </summary>
        HTuple Calcol_world_x
        {
            get;
            set;
        }

        /// <summary>
        ///  世界坐标  y
        /// </summary>
        HTuple Calrow_world_y
        {
            get;
            set;
        }
        #endregion

        #region   标定工具
        /// <summary>
        /// 标定工具
        /// </summary>
        List<string> _Cal_tool_path
        {
            get
           ;
            set;
        }
        #endregion

        //#region   防射变化
        ///// <summary>
        ///// 防射变换
        ///// </summary>
        //HTuple HomMat2D
        //{
        //    get;
        //    set;
        //}
        //#endregion

        #endregion

        #region  保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        void save();
        #endregion

        #region  初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        void init();
        #endregion
    }

    /// <summary>
    /// 防射变化接口
    /// </summary>
    public interface IHomMat2D
    {
        #region   防射变化
        /// <summary>
        /// 防射变换
        /// </summary>
        HTuple HomMat2D
        {
            get;
            set;
        }
        #endregion
    }

    /// <summary>
    /// 防射变化接口
    /// </summary>
    public interface ICalibrationHomMat2D
    {
        /// <summary>
        /// 标定
        /// </summary>
        IHomMat2D _ICalibration
        {
            get;
            set;
        }
    }
    #endregion
    
    #region   数据设置器
    /// <summary>
    /// 数据设置器
    /// </summary>
    public class SetCalibrationShuJu:MultTree.SetFather
    {
        #region  设置世界坐标  像素坐标
        /// <summary>
        /// 9点标定
        /// </summary>
        /// <param name="ICal_"></param>
        /// <param name="calcol_pixel_x"></param>
        /// <param name="calrow_pixel_y"></param>
        /// <param name="calcol_world_x"></param>
        /// <param name="calrow_world_y"></param>
        /// <returns></returns>
        public bool Set_Cal_pixel_world_9Calibration(ICalibrationShuJu ICal_, ref double[] calcol_pixel_x, ref double[] calrow_pixel_y, ref double[] calcol_world_x, ref double[] calrow_world_y)
        {
            bool ok = false;

            int calcol_pixel_x_num = calcol_pixel_x.Length;
            int calrow_pixel_y_num = calrow_pixel_y.Length;

            int calcol_world_x_num = calcol_world_x.Length;
            int calrow_world_y_num = calrow_world_y.Length;

            if (calcol_pixel_x.Length != 9)
            {
                MessageBox.Show("数据出错");
                return false;
            }

            if (calrow_pixel_y.Length != 9)
            {
                MessageBox.Show("数据出错");
                return false;
            }

            if (calcol_world_x.Length != 9)
            {
                MessageBox.Show("数据出错");
                return false;
            }

            if (calrow_world_y.Length != 9)
            {
                MessageBox.Show("数据出错");
                return false;
            }

            #region   x像素
            /*1*/
            ICal_.Calcol_pixel_x[0] = (HTuple)calcol_pixel_x[0];
            /*2*/
            ICal_.Calcol_pixel_x[1] = (HTuple)calcol_pixel_x[1];
            /*3*/
            ICal_.Calcol_pixel_x[2] = (HTuple)calcol_pixel_x[2];
            /*4*/
            ICal_.Calcol_pixel_x[3] = (HTuple)calcol_pixel_x[3];
            /*5*/
            ICal_.Calcol_pixel_x[4] = (HTuple)calcol_pixel_x[4];
            /*6*/
            ICal_.Calcol_pixel_x[5] = (HTuple)calcol_pixel_x[5];
            /*7*/
            ICal_.Calcol_pixel_x[6] = (HTuple)calcol_pixel_x[6];
            /*8*/
            ICal_.Calcol_pixel_x[7] = (HTuple)calcol_pixel_x[7];
            /*9*/
            ICal_.Calcol_pixel_x[8] = (HTuple)calcol_pixel_x[8];
            #endregion

            #region  y像素
            /****1***/
            ICal_.Calrow_pixel_y[0] = (HTuple)calrow_pixel_y[0];
            /****2***/
            ICal_.Calrow_pixel_y[1] = (HTuple)calrow_pixel_y[1];
            /****3***/
            ICal_.Calrow_pixel_y[2] = (HTuple)calrow_pixel_y[2];
            /****4***/
            ICal_.Calrow_pixel_y[3] = (HTuple)calrow_pixel_y[3];
            /****5***/
            ICal_.Calrow_pixel_y[4] = (HTuple)calrow_pixel_y[4];
            /****6***/
            ICal_.Calrow_pixel_y[5] = (HTuple)calrow_pixel_y[5];
            /****7***/
            ICal_.Calrow_pixel_y[6] = (HTuple)calrow_pixel_y[6];
            /****8***/
            ICal_.Calrow_pixel_y[7] = (HTuple)calrow_pixel_y[7];
            /****9***/
            ICal_.Calrow_pixel_y[8] = (HTuple)calrow_pixel_y[8];

            #endregion

            #region   x世界
            /****1****/
            ICal_.Calcol_world_x[0] = (HTuple)calcol_world_x[0];
            /****2****/
            ICal_.Calcol_world_x[1] = (HTuple)calcol_world_x[1];
            /****3****/
            ICal_.Calcol_world_x[2] = (HTuple)calcol_world_x[2];
            /****4****/
            ICal_.Calcol_world_x[3] = (HTuple)calcol_world_x[3];
            /****5****/
            ICal_.Calcol_world_x[4] = (HTuple)calcol_world_x[4];
            /****6****/
            ICal_.Calcol_world_x[5] = (HTuple)calcol_world_x[5];
            /****7****/
            ICal_.Calcol_world_x[6] = (HTuple)calcol_world_x[6];
            /****8****/
            ICal_.Calcol_world_x[7] = (HTuple)calcol_world_x[7];
            /****9****/
            ICal_.Calcol_world_x[8] = (HTuple)calcol_world_x[8];
            #endregion

            #region   y世界
            /****1****/
            ICal_.Calrow_world_y[0] = (HTuple)calrow_world_y[0];
            /****2****/
            ICal_.Calrow_world_y[1] = (HTuple)calrow_world_y[1];
            /****3****/
            ICal_.Calrow_world_y[2] = (HTuple)calrow_world_y[2];
            /****4****/
            ICal_.Calrow_world_y[3] = (HTuple)calrow_world_y[3];
            /****5****/
            ICal_.Calrow_world_y[4] = (HTuple)calrow_world_y[4];
            /****6****/
            ICal_.Calrow_world_y[5] = (HTuple)calrow_world_y[5];
            /****7****/
            ICal_.Calrow_world_y[6] = (HTuple)calrow_world_y[6];
            /****8****/
            ICal_.Calrow_world_y[7] = (HTuple)calrow_world_y[7];
            /****9****/
            ICal_.Calrow_world_y[8] = (HTuple)calrow_world_y[8];
            #endregion

            #region  无用代码
            ////像素坐标
            //HTuple hv_xiangsu_x = new HTuple();
            //hv_xiangsu_x[0] = calcol_pixel_x[0];
            //hv_xiangsu_x[1] = calcol_pixel_x[1];
            //hv_xiangsu_x[2] = calcol_pixel_x[2];
            //hv_xiangsu_x[3] = calcol_pixel_x[3];
            //hv_xiangsu_x[4] = calcol_pixel_x[4];
            //hv_xiangsu_x[5] = calcol_pixel_x[5];
            //hv_xiangsu_x[6] = calcol_pixel_x[6];
            //hv_xiangsu_x[7] = calcol_pixel_x[7];
            //hv_xiangsu_x[8] = calcol_pixel_x[8];

            //HTuple hv_xiangsu_y = new HTuple();
            //hv_xiangsu_y[0] = calrow_pixel_y[0];
            //hv_xiangsu_y[1] = calrow_pixel_y[1];
            //hv_xiangsu_y[2] = calrow_pixel_y[2];
            //hv_xiangsu_y[3] = calrow_pixel_y[3];
            //hv_xiangsu_y[4] = calrow_pixel_y[4];
            //hv_xiangsu_y[5] = calrow_pixel_y[5];
            //hv_xiangsu_y[6] = calrow_pixel_y[6];
            //hv_xiangsu_y[7] = calrow_pixel_y[7];
            //hv_xiangsu_y[8] = calrow_pixel_y[8];



            ////世界坐标
            //HTuple hv_calcol_world_x = new HTuple();
            //hv_calcol_world_x[0] = calcol_world_x[0];
            //hv_calcol_world_x[1] = calcol_world_x[1];
            //hv_calcol_world_x[2] = calcol_world_x[2];
            //hv_calcol_world_x[3] = calcol_world_x[3];
            //hv_calcol_world_x[4] = calcol_world_x[4];
            //hv_calcol_world_x[5] = calcol_world_x[5];
            //hv_calcol_world_x[6] = calcol_world_x[6];
            //hv_calcol_world_x[7] = calcol_world_x[7];
            //hv_calcol_world_x[8] = calcol_world_x[8];

            //HTuple hv_calrow_world_y = new HTuple();
            //hv_calrow_world_y[0] = calrow_world_y[0];
            //hv_calrow_world_y[1] = calrow_world_y[1];
            //hv_calrow_world_y[2] = calrow_world_y[2];
            //hv_calrow_world_y[3] = calrow_world_y[3];
            //hv_calrow_world_y[4] = calrow_world_y[4];
            //hv_calrow_world_y[5] = calrow_world_y[5];
            //hv_calrow_world_y[6] = calrow_world_y[6];
            //hv_calrow_world_y[7] = calrow_world_y[7];
            //hv_calrow_world_y[8] = calrow_world_y[8];

            //HTuple hv_HomMat2D2, hv_Qx1, hv_Qy1, hv_RowTrans, hv_ColTrans;
            #endregion

            HTuple hv_HomMat2D2;

            HOperatorSet.VectorToHomMat2d(ICal_.Calcol_pixel_x, ICal_.Calrow_pixel_y, ICal_.Calcol_world_x,
               ICal_.Calrow_world_y, out hv_HomMat2D2);

            ICal_.HomMat2D = hv_HomMat2D2;

            #region  无用代码
            //HOperatorSet.AffineTransPixel(hv_HomMat2D2, 1117.8735, 1067.1712, out hv_RowTrans,
            //    out hv_ColTrans);
            //HOperatorSet.AffineTransPoint2d(ICal_.HomMat2D, 1029.6871, 979.107, out hv_Qx1,
            //    out hv_Qy1);
            //Set_Calibration(ICal_);
            #endregion

            ok = true;
            return ok;
        }
        #endregion

        #region  设置标定像素坐标数据
        /// <summary>
        /// 设置标定像素坐标数据
        /// </summary>
        /// <param name="ICal"></param>
        /// <param name="calrow_pixel_y"></param>
        /// <param name="calcol_pixel_x"></param>
        /// <returns></returns>
        public bool Set_Cal_pixel(ICalibrationShuJu ICal_, ref List<double> calrow_pixel_y, ref List<double> calcol_pixel_x)
        {
            bool ok = false;
            int num1 = calrow_pixel_y.Count;
            int num2 = calcol_pixel_x.Count;
            if ((num1 == 9) && (num2 == 9))
            {
                for (int i = 0; i < num1; i++)
                {
                    ICal_.Calcol_pixel_x[i] = (HTuple)calcol_pixel_x[i];
                    ICal_.Calrow_pixel_y[i] = (HTuple)calrow_pixel_y[i];
                }
            }
            ok = true;
            return ok;
        }
        #endregion

        #region   设置世界坐标数据
        /// <summary>
        /// 设置世界坐标数据
        /// </summary>
        /// <param name="ICal_"></param>
        /// <param name="calcol_world_x"></param>
        /// <param name="calrow_world_y"></param>
        /// <returns></returns>
        public bool Set_Cal_world(ICalibrationShuJu ICal_, ref List<double> calcol_world_x, ref List<double> calrow_world_y)
        {
            bool ok = false;
            int num1 = calcol_world_x.Count;
            int num2 = calrow_world_y.Count;
            if ((num1 == 9) && (num2 == 9))
            {
                for (int i = 0; i < num1; i++)
                {
                    ICal_.Calcol_world_x[i] = (HTuple)calcol_world_x[i];
                    ICal_.Calrow_world_y[i] = (HTuple)calrow_world_y[i];
                }
            }
            ok = true;
            return ok;
        }

        #endregion

        #region  标定
        /// <summary>
        ///  标定
        /// </summary>
        /// <param name="ICal_"></param>
        /// <returns></returns>
        public bool Set_Calibration(ICalibrationShuJu ICal_)
        {
            bool ok = false;
            HTuple HomMat2D;

            HOperatorSet.VectorToHomMat2d(ICal_.Calcol_pixel_x, ICal_.Calrow_pixel_y, ICal_.Calcol_world_x, ICal_.Calrow_world_y, out HomMat2D);

            ICal_.HomMat2D = HomMat2D;

            ok = true;
            return ok;
        }


        #endregion

        #region   输出参数
        /// <summary>
        /// 输出参数
        /// </summary>
        /// <param name="Ical_"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public bool Set_show_row_col(ICalibrationShuJu Ical_, Control.ControlCollection control)
        {
            bool ok = false;

            foreach (Control con in control)
            {
                string name = con.Name;
                if ((con is ComboBox) || (con is TextBox) || (con is RichTextBox))
                {
                    switch (name)
                    {
                        #region   像素坐标

                        #region  1
                        case "txt_pixel_col_x1":
                            con.Text = Ical_.Calcol_pixel_x[0].D.ToString().Replace("\"", "");
                            break;

                        case "txt_pixel_row_y1":
                            con.Text = Ical_.Calrow_pixel_y[0].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region 2
                        case "txt_pixel_col_x2":
                            con.Text = Ical_.Calcol_pixel_x[1].D.ToString().Replace("\"", "");
                            break;

                        case "txt_pixel_row_y2":
                            con.Text = Ical_.Calrow_pixel_y[1].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region 3
                        case "txt_pixel_col_x3":
                            con.Text = Ical_.Calcol_pixel_x[2].D.ToString().Replace("\"", "");
                            break;

                        case "txt_pixel_row_y3":
                            con.Text = Ical_.Calrow_pixel_y[2].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region 4
                        case "txt_pixel_col_x4":
                            con.Text = Ical_.Calcol_pixel_x[3].D.ToString().Replace("\"", "");
                            break;

                        case "txt_pixel_row_y4":
                            con.Text = Ical_.Calrow_pixel_y[3].D.ToString().Replace("\"", "");
                            break;

                        #endregion

                        #region  5
                        case "txt_pixel_col_x5":
                            con.Text = Ical_.Calcol_pixel_x[4].D.ToString().Replace("\"", "");
                            break;

                        case "txt_pixel_row_y5":
                            con.Text = Ical_.Calrow_pixel_y[4].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region  6
                        case "txt_pixel_col_x6":
                            con.Text = Ical_.Calcol_pixel_x[5].D.ToString().Replace("\"", "");
                            break;

                        case "txt_pixel_row_y6":
                            con.Text = Ical_.Calrow_pixel_y[5].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region  7
                        case "txt_pixel_col_x7":
                            con.Text = Ical_.Calcol_pixel_x[6].D.ToString().Replace("\"", "");
                            break;

                        case "txt_pixel_row_y7":
                            con.Text = Ical_.Calrow_pixel_y[6].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region  8
                        case "txt_pixel_col_x8":
                            con.Text = Ical_.Calcol_pixel_x[7].D.ToString().Replace("\"", "");
                            break;

                        case "txt_pixel_row_y8":
                            con.Text = Ical_.Calrow_pixel_y[7].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region  9
                        case "txt_pixel_col_x9":
                            con.Text = Ical_.Calcol_pixel_x[8].D.ToString().Replace("\"", "");
                            break;

                        case "txt_pixel_row_y9":
                            con.Text = Ical_.Calrow_pixel_y[8].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #endregion

                        #region   世界坐标

                        #region  1
                        case "txt_world_col_x1":
                            con.Text = Ical_.Calcol_world_x[0].D.ToString().Replace("\"", "");
                            break;

                        case "txt_world_row_y1":
                            con.Text = Ical_.Calrow_world_y[0].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region  2
                        case "txt_world_col_x2":
                            con.Text = Ical_.Calcol_world_x[1].D.ToString().Replace("\"", "");
                            break;

                        case "txt_world_row_y2":
                            con.Text = Ical_.Calrow_world_y[1].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region  3
                        case "txt_world_col_x3":
                            con.Text = Ical_.Calcol_world_x[2].D.ToString().Replace("\"", "");
                            break;

                        case "txt_world_row_y3":
                            con.Text = Ical_.Calrow_world_y[2].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region  4
                        case "txt_world_col_x4":
                            con.Text = Ical_.Calcol_world_x[3].D.ToString().Replace("\"", "");
                            break;

                        case "txt_world_row_y4":
                            con.Text = Ical_.Calrow_world_y[3].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region  5
                        case "txt_world_col_x5":
                            con.Text = Ical_.Calcol_world_x[4].D.ToString().Replace("\"", "");
                            break;

                        case "txt_world_row_y5":
                            con.Text = Ical_.Calrow_world_y[4].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region  6
                        case "txt_world_col_x6":
                            con.Text = Ical_.Calcol_world_x[5].D.ToString().Replace("\"", "");
                            break;

                        case "txt_world_row_y6":
                            con.Text = Ical_.Calrow_world_y[5].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region  7
                        case "txt_world_col_x7":
                            con.Text = Ical_.Calcol_world_x[6].D.ToString().Replace("\"", "");
                            break;

                        case "txt_world_row_y7":
                            con.Text = Ical_.Calrow_world_y[6].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region  8
                        case "txt_world_col_x8":
                            con.Text = Ical_.Calcol_world_x[7].D.ToString().Replace("\"", "");
                            break;

                        case "txt_world_row_y8":
                            con.Text = Ical_.Calrow_world_y[7].D.ToString().Replace("\"", "");
                            break;
                        #endregion


                        #region  9
                        case "txt_world_col_x9":
                            con.Text = Ical_.Calcol_world_x[8].D.ToString().Replace("\"", "");
                            break;

                        case "txt_world_row_y9":
                            con.Text = Ical_.Calrow_world_y[8].D.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #endregion
                    }
                }
                if (con.Controls.Count > 0)
                {
                    Set_show_row_col(Ical_, con.Controls);
                }
            }
                       

            ok = true;
            return ok;
        }
        #endregion

        #region  测试标定
        /// <summary>
        /// 测试标定
        /// </summary>
        /// <returns></returns>
        public bool ceShiBiaoDing(ICalibrationShuJu Ical_, ref string col_pixel_x, ref string row_pixel_y)
        {
            bool ok = false;

            if (Ical_.HomMat2D == null)
            {
                return false;
            }

            if ((col_pixel_x == "") || (row_pixel_y == ""))
            {
                return false;
            }
            double x = Convert.ToDouble(col_pixel_x);
            double y = Convert.ToDouble(row_pixel_y);
            HTuple hv_col_x, hv_row_y, hv_x_col_out, hv_y_row_out;
            hv_col_x = x;
            hv_row_y = y;

            //HOperatorSet.AffineTransPixel(Ical_.HomMat2D, hv_col_x, hv_row_y, out hv_x_col_out, out hv_y_row_out);

            HOperatorSet.AffineTransPoint2d(Ical_.HomMat2D, hv_col_x, hv_row_y, out hv_x_col_out, out hv_y_row_out);

            col_pixel_x = hv_x_col_out.D.ToString();
            row_pixel_y = hv_y_row_out.D.ToString();

            ok = true;
            return ok;
        }
        #endregion

        #region   验证9点标定的精度
        /// <summary>
        /// 验证9点标定的精度
        /// </summary>
        /// <param name="Ical_"></param>
        /// <param name="cal_wu_cha"></param>
        /// <returns></returns>
        public bool Set_YanZhengJingDu(ICalibrationShuJu Ical_, ref string cal_wu_cha)
        {
            bool ok = false;
            /************求取放射变化数据与实际值的误差***************/
            HTuple[] x_col_wu_cha = new HTuple[9];
            HTuple[] y_row_wu_cha = new HTuple[9];

            HTuple hv_x_col, hv_y_row;

            #region 1
            HOperatorSet.AffineTransPoint2d(Ical_.HomMat2D, Ical_.Calcol_pixel_x[0], Ical_.Calrow_pixel_y[0], out hv_x_col, out hv_y_row);

            x_col_wu_cha[0] = Ical_.Calcol_world_x[0] - hv_x_col;
            y_row_wu_cha[0] = Ical_.Calrow_world_y[0] - hv_y_row;
            #endregion

            #region  2
            HOperatorSet.AffineTransPoint2d(Ical_.HomMat2D, Ical_.Calcol_pixel_x[1], Ical_.Calrow_pixel_y[1], out hv_x_col, out hv_y_row);

            x_col_wu_cha[1] = Ical_.Calcol_world_x[1] - hv_x_col;
            y_row_wu_cha[1] = Ical_.Calrow_world_y[1] - hv_y_row;
            #endregion

            #region  3
            HOperatorSet.AffineTransPoint2d(Ical_.HomMat2D, Ical_.Calcol_pixel_x[2], Ical_.Calrow_pixel_y[2], out hv_x_col, out hv_y_row);

            x_col_wu_cha[2] = Ical_.Calcol_world_x[2] - hv_x_col;
            y_row_wu_cha[2] = Ical_.Calrow_world_y[2] - hv_y_row;
            #endregion

            #region 4
            HOperatorSet.AffineTransPoint2d(Ical_.HomMat2D, Ical_.Calcol_pixel_x[3], Ical_.Calrow_pixel_y[3], out hv_x_col, out hv_y_row);

            x_col_wu_cha[3] = Ical_.Calcol_world_x[3] - hv_x_col;
            y_row_wu_cha[3] = Ical_.Calrow_world_y[3] - hv_y_row;
            #endregion

            #region  5
            HOperatorSet.AffineTransPoint2d(Ical_.HomMat2D, Ical_.Calcol_pixel_x[4], Ical_.Calrow_pixel_y[4], out hv_x_col, out hv_y_row);

            x_col_wu_cha[4] = Ical_.Calcol_world_x[4] - hv_x_col;
            y_row_wu_cha[4] = Ical_.Calrow_world_y[4] - hv_y_row;
            #endregion

            #region  6
            HOperatorSet.AffineTransPoint2d(Ical_.HomMat2D, Ical_.Calcol_pixel_x[5], Ical_.Calrow_pixel_y[5], out hv_x_col, out hv_y_row);

            x_col_wu_cha[5] = Ical_.Calcol_world_x[5] - hv_x_col;
            y_row_wu_cha[5] = Ical_.Calrow_world_y[5] - hv_y_row;
            #endregion

            #region  7
            HOperatorSet.AffineTransPoint2d(Ical_.HomMat2D, Ical_.Calcol_pixel_x[6], Ical_.Calrow_pixel_y[6], out hv_x_col, out hv_y_row);

            x_col_wu_cha[6] = Ical_.Calcol_world_x[6] - hv_x_col;
            y_row_wu_cha[6] = Ical_.Calrow_world_y[6] - hv_y_row;
            #endregion

            #region  8
            HOperatorSet.AffineTransPoint2d(Ical_.HomMat2D, Ical_.Calcol_pixel_x[7], Ical_.Calrow_pixel_y[7], out hv_x_col, out hv_y_row);

            x_col_wu_cha[7] = Ical_.Calcol_world_x[7] - hv_x_col;
            y_row_wu_cha[7] = Ical_.Calrow_world_y[7] - hv_y_row;
            #endregion

            #region  9
            HOperatorSet.AffineTransPoint2d(Ical_.HomMat2D, Ical_.Calcol_pixel_x[8], Ical_.Calrow_pixel_y[8], out hv_x_col, out hv_y_row);

            x_col_wu_cha[8] = Ical_.Calcol_world_x[8] - hv_x_col;
            y_row_wu_cha[8] = Ical_.Calrow_world_y[8] - hv_y_row;
            #endregion

            HTuple zhong_jian_bian_liang_x, zhong_jian_bian_liang_y;

            zhong_jian_bian_liang_x = 0;
            zhong_jian_bian_liang_y = 0;

            for (int i = 0; i < 9; i++)
            {
                HTuple x_1;

                HOperatorSet.TupleAbs(x_col_wu_cha[i], out x_1);

                if (zhong_jian_bian_liang_x < x_1)
                {
                    zhong_jian_bian_liang_x = x_1;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                HTuple y_1;

                HOperatorSet.TupleAbs(y_row_wu_cha[i], out y_1);

                if (zhong_jian_bian_liang_y < y_1)
                {
                    zhong_jian_bian_liang_y = y_1;
                }
            }


            if (zhong_jian_bian_liang_x > zhong_jian_bian_liang_y)
            {
                cal_wu_cha = zhong_jian_bian_liang_x.D.ToString();
            }
            else
            {
                cal_wu_cha = zhong_jian_bian_liang_y.D.ToString();
            }

            ok = true;
            return ok;
        }


        #endregion

        #region  显示标定工具
        /// <summary>
        /// 显示标定工具
        /// </summary>
        public void Set_showTool(ICalibrationShuJu Ical_,ListBox list_One)
        {
            Ical_._Cal_tool_path = this.ShuaXinToolJiHe(Ical_._Cal_tool_path);
            list_One.Items.Clear();
            
            foreach (string str in Ical_._Cal_tool_path)
            {
                list_One.Items.Add(str);
            }
        }
        #endregion

    }
    #endregion

    #region  标定的结果类
    /// <summary>
    /// 标定的结果类
    /// </summary>
    public class Calibration_Result : MultTree.ClassResultFather
    {

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="str_array"></param>
        /// <returns></returns>
        public override bool showResult(out string[] str_array)
        {
            bool ok = false;

            str_array = new string[2];
            str_array[0] = this._tolatName;
            str_array[1] = this._tolatResult.ToString();

            ok = true;
            return ok;
        }

    }
    #endregion

}
