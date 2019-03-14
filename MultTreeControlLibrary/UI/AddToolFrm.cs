using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MultTreeControlLibrary;
using System.Windows.Forms;
using HalconDotNet;
using ReadImageHalconLibrary;
using BarCodeHalconLibrary;
using OCRLibrary;
using OCVLibrary;
using TemplateHalconLibrary;
using RectLibrary;
using CircleLibrary;
using LineLibrary;
using CalibrationLibrary;
using DataCodeLibrary;
using VersionConfigLibrary;
using BlobLibrary;
using BackGroundCheckHalconLibrary;
using DistanceTwoPointLibrary;
using DistancePointToLineLibrary;
using OCRTextLibrary;






namespace MultTreeControlLibrary
{
    public partial class AddToolFrm : Form
    {
        #region 全局变量
        /// <summary>
        /// 向那个方向插入
        /// </summary>
        public string _insert_direction;
        /// <summary>
        /// 插入那个工具
        /// </summary>
        public string _insert_tool;
        /// <summary>
        /// 工具的文本名称
        /// </summary>
        public string _tool_text;
        /// <summary>
        /// 当前的节点数据
        /// </summary>
        tool_treeview_struct _tool_Treeview_struct;

        /// <summary>
        /// 工具的结构体数据
        /// </summary>
        public object _tag;

        #region  无用代码
        /// <summary>
        /// 窗体的句柄
        /// </summary>
        //public HWindow _hwin;
        #endregion

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="toolTreeviewStruct">传入当前的节点数据</param>
        public AddToolFrm(tool_treeview_struct toolTreeviewStruct)
        {
            InitializeComponent();
            _tool_Treeview_struct = toolTreeviewStruct;
        }
        #endregion

        #region  判断显示页面
        /// <summary>
        /// 判断显示页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_toolfrm_Load(object sender, EventArgs e)
        {
            if (MultTree.TreeStatic.Mult_Tree_Node_Picture == null)
            {
                ng_return();
            }

            #region   设置显示工具

            #endregion

            #region  无用代码
            //#region  detection 检测
            //if (_tool_Treeview_struct.Current_Nodes_Name.Contains("detection"))
            //{
            //    if (_insert_direction == "插入工具")//允许添加的工具
            //    {
            //        Detection.Parent = null;
            //        Analyst.Parent = null;
            //        Preprocessing.Parent = null;
            //        Aquire.Parent = tabControl1;
            //        return;
            //    }
            //    else
            //    {
            //        Detection.Parent = tabControl1;
            //        Analyst.Parent = null;
            //        Preprocessing.Parent = null;
            //        Aquire.Parent = null;
            //        return;
            //    }
            //}
            //#endregion
            #endregion

            #region   acquire
            if (_tool_Treeview_struct.Current_Nodes_Name.Contains("acquire"))
            {
                if (_insert_direction == "插入工具")//允许添加的工具
                {
                    Detection.Parent = null;
                    Analyst.Parent = tabControl1;
                    Preprocessing.Parent = tabControl1;
                    Aquire.Parent = null;
                    return;
                }
                else
                {
                    Detection.Parent = null;
                    Analyst.Parent = null;
                    Preprocessing.Parent = null;
                    Aquire.Parent = null;
                    return;
                }
            }
            #endregion

            #region  无用代码
            //#region   template
            //if (_tool_Treeview_struct.Current_Nodes_Name.Contains("Template"))
            //{
            //    if (_insert_direction == "插入工具")//允许添加的工具
            //    {
            //        Detection.Parent = null;
            //        Analyst.Parent = tabControl1;
            //        Preprocessing.Parent = null;
            //        Aquire.Parent = null;
            //        return;
            //    }
            //    else
            //    {
            //        Detection.Parent = null;
            //        Analyst.Parent = tabControl1;
            //        Preprocessing.Parent = null;
            //        Aquire.Parent = null;
            //        return;
            //    }
            //}
            //#endregion

            //#region  rect
            //if (_tool_Treeview_struct.Current_Nodes_Name.Contains("Rect"))
            //{
            //    if (_insert_direction == "插入工具")//允许添加的工具
            //    {
            //        Detection.Parent = null;
            //        Analyst.Parent = tabControl1;
            //        Preprocessing.Parent = null;
            //        Aquire.Parent = null;
            //        return;
            //    }
            //    else
            //    {
            //        Detection.Parent = null;
            //        Analyst.Parent = tabControl1;
            //        Preprocessing.Parent = null;
            //        Aquire.Parent = null;
            //        return;
            //    }
            //}
            //#endregion
            #endregion

            #region  默认
            Analyst.Parent = null;
            Preprocessing.Parent = null;
            Aquire.Parent = null;
            Detection.Parent = null;
            #endregion
        }
        #endregion

        #region   添加一个取图
        /// <summary>
        /// 添加一个取图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lab_acquire_Click(object sender, EventArgs e)
        {
            _tool_text = lab_acquire.Text;
            _insert_tool = "acquire";

            //生成结构体数据
            //  Mai.Structrue.acquire_struct acquire = new Structrue.acquire_struct(Enum.Acq_Image_enum.Enum_document,null);

            ReadShuJu re = new ReadShuJu();
            _tag = re;
            ok_returen();
        }
        #endregion

        #region  添加工具窗体关闭
        /// <summary>
        /// 添加工具窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_toolfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.DialogResult = DialogResult.No;
        }
        #endregion

        #region   添加一个图片检测
        /// <summary>
        /// 添加一个图片检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lab_detection_Click(object sender, EventArgs e)
        {
            _tool_text = lab_detection.Text;
            _insert_tool = "detection";

            //生成结构体数据
            //  Mai.Structrue.detection_struct detection = new Structrue.detection_struct();

            //detection.Image_resolutionRatio = "2592*1944";

            //  _tag = detection;

            ok_returen();
        }
        #endregion

        #region  寻找模板
        /// <summary>
        /// 寻找模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lab_seekTemplate_Click(object sender, EventArgs e)
        {

            _tool_text = lab_seekTemplate.Text;
            _insert_tool = "Template";
            //生成结构体数据
            TemplateShuJu teshuju = new TemplateShuJu();
            teshuju.ImageFather = (IImageFather)MultTree.TreeStatic.Mult_Tree_Node_Picture.Obj;
            _tag = teshuju;
            ok_returen();
        }
        #endregion

        #region   颜色分析
        /// <summary>
        /// 颜色分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lab_colorAnalyst_Click(object sender, EventArgs e)
        {
            _tool_text = lab_colorAnalyst.Text;
            _insert_tool = "colorAnalyst";

            //生成结构体数据
            //  Mai.Structrue.color_analyst_struct color_analyst = new Structrue.color_analyst_struct();

            #region 初始化默认值
            //color_analyst._row1 = 289.5;
            //color_analyst._col1 = 469.5;
            // color_analyst._row2 = 364.5;
            //color_analyst._col2 = 534.5;

            //color_analyst._low = 0;
            //color_analyst._tall = 100;
            #endregion

            //   _tag = color_analyst;

            ok_returen();
        }
        #endregion

        #region  添加旋转图片工具
        /// <summary>
        /// 添加旋转图片工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lab_rotateImage_Click(object sender, EventArgs e)
        {
            _tool_text = lab_rotateImage.Text;
            _insert_tool = "rotateImage";

            //生成结构体数据
            //   Mai.Structrue.rotate_image_struct ratate_image = new Structrue.rotate_image_struct();

            #region 初始化结构体
            //ratate_image._ModelRow = 0;
            //ratate_image._ModelColumn = 0;

            //ratate_image._Angle = 0;
            //ratate_image._Column = 0;
            //ratate_image._Row = 0;

            #endregion

            //  _tag = ratate_image;

            ok_returen();
        }
        #endregion

        #region   拟合圆工具
        private void lab_circle_Click(object sender, EventArgs e)
        {
            _tool_text = lab_circle.Text;
            _insert_tool = "Circle";

            //生成结构体数据
            CircleShuJu circleshuju = new CircleShuJu();
            circleshuju.ImageFather = (IImageFather)MultTree.TreeStatic.Mult_Tree_Node_Picture.Obj;
            _tag = circleshuju;
            ok_returen();
        }
        #endregion

        #region    放射定位
        private void lab_rect_location_Click(object sender, EventArgs e)
        {
            _tool_text = lab_rect_location.Text;
            _insert_tool = "Rect";

            RectShuJu rectshuju = new RectShuJu();
            _tag = rectshuju;

            ok_returen();
        }
        #endregion

        #region  读取一维码
        private void lab_BarCode_Click(object sender, EventArgs e)
        {
            _tool_text = lab_BarCode.Text;
            _insert_tool = "BarCode";
            BarCodeShuJu bar = new BarCodeShuJu();
            bar.ImageFather = (IImageFather)MultTree.TreeStatic.Mult_Tree_Node_Picture.Obj;
            _tag = bar;
            ok_returen();
        }
        #endregion

        #region  ocr
        private void lab_OCR_Click(object sender, EventArgs e)
        {
            _tool_text = lab_OCR.Text;
            _insert_tool = "OCR";
            OCRShuJu oc = new OCRShuJu();
            oc.ImageFather = (IImageFather)MultTree.TreeStatic.Mult_Tree_Node_Picture.Obj;
            _tag = oc;
            ok_returen();
        }
        #endregion

        #region  ocv
        private void lab_OCV_Click(object sender, EventArgs e)
        {
            _tool_text = lab_OCV.Text;
            _insert_tool = "OCV";
            OCVShuJu ocv = new OCVShuJu();
            _tag = ocv;
            ok_returen();
        }
        #endregion

        #region 拟合直线
        private void lab_line_Click(object sender, EventArgs e)
        {
            _tool_text = lab_line.Text;
            _insert_tool = "Line";
            LineShuJu li_ = new LineShuJu();
            li_.ImageFather = (IImageFather)MultTree.TreeStatic.Mult_Tree_Node_Picture.Obj;
            _tag = li_;
            ok_returen();
        }
        #endregion

        #region  标定
        private void lab_calibration_Click(object sender, EventArgs e)
        {
            _tool_text = lab_calibration.Text;
            _insert_tool = "Calibration";

            CalibrationShuJu cal_ = new CalibrationShuJu();
          
            _tag = cal_;

            ok_returen();
        }
        #endregion

        #region  二维码识别
        private void lab_dataCode_Click(object sender, EventArgs e)
        {
            _tool_text = lab_dataCode.Text;
            _insert_tool = "DataCode";
            DataCodeShuJu dataCode_ = new DataCodeShuJu();
            dataCode_.ImageFather = (IImageFather)MultTree.TreeStatic.Mult_Tree_Node_Picture.Obj;
            _tag = dataCode_;
            ok_returen();
        }
        #endregion

        #region  背景检测
        private void lab_BackGround_Click(object sender, EventArgs e)
        {
            _tool_text = lab_BackGround.Text;
            _insert_tool = "BackGround";

            BackGroundCheckHalconLibrary.BackGroundShuJu backGround = new BackGroundShuJu();
            backGround.ImageFather = (IImageFather)MultTree.TreeStatic.Mult_Tree_Node_Picture.Obj;
            _tag = backGround;

            ok_returen();
        }
        #endregion

        #region  两点的距离
        private void lab_distanceTwoPoint_Click(object sender, EventArgs e)
        {
            _tool_text = lab_distanceTwoPoint.Text;
            _insert_tool = "DistanceTwoPoint";

            DistanceTwoPointLibrary.DistanceTwoPointShuJu distanceTwoPoint = new DistanceTwoPointLibrary.DistanceTwoPointShuJu();
            distanceTwoPoint.ImageFather = (IImageFather)MultTree.TreeStatic.Mult_Tree_Node_Picture.Obj;
            
            _tag = distanceTwoPoint;

            ok_returen();
        }
        #endregion

        #region  点到线的距离
        private void lab_DistancePointToLine_Click(object sender, EventArgs e)
        {
            _tool_text = lab_DistancePointToLine.Text;
            _insert_tool = "DistancePointToLine";

            DistancePointToLineShuJu distanceToLine = new DistancePointToLineShuJu();
            distanceToLine.ImageFather = (IImageFather)MultTree.TreeStatic.Mult_Tree_Node_Picture.Obj;
            
            _tag = distanceToLine;
            ok_returen();
        }
        #endregion

        #region   两线距离
        private void lab_DistanceTwoLine_Click(object sender, EventArgs e)
        {
            _tool_text = lab_DistanceTwoLine.Text;
            _insert_tool = "DistanceTwoLine";

            DistanceTwoLineLibrary.DistanceTwoLineShuJu distanceTwoLine = new DistanceTwoLineLibrary.DistanceTwoLineShuJu();
            distanceTwoLine.ImageFather = (IImageFather)MultTree.TreeStatic.Mult_Tree_Node_Picture.Obj;
            
            _tag = distanceTwoLine;
            ok_returen();
        }
        #endregion

        #region 斑点
        private void lab_Blob_Click(object sender, EventArgs e)
        {
            _tool_text = lab_Blob.Text;
            _insert_tool = "Blob";

            BlobLibrary.BlobShuJu blob_ = new BlobShuJu();
            blob_.ImageFather = (IImageFather)MultTree.TreeStatic.Mult_Tree_Node_Picture.Obj;

            _tag = blob_;
            ok_returen();
        }
        #endregion

        #region  ocr文本
        private void lab_OCRWenBen_Click(object sender, EventArgs e)
        {
            _tool_text = lab_OCRWenBen.Text;
            _insert_tool = "OCRWenBen";
            OCRTextShuJu ocrText_ = new OCRTextShuJu();
            ocrText_.ImageFather = (IImageFather)MultTree.TreeStatic.Mult_Tree_Node_Picture.Obj;
            _tag = ocrText_;
            ok_returen();
        }
        #endregion

        #region   ok返回
        /// <summary>
        /// ok返回
        /// </summary>
        void ok_returen()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region   ng返回
        /// <summary>
        /// ng返回
        /// </summary>
        void ng_return()
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        #endregion
             
    }
}
