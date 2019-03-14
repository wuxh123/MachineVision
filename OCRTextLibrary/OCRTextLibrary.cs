using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalControl;
using HalconDotNet;
using System.Windows.Forms;
using System.IO;



namespace OCRTextLibrary
{
    #region  数据
    /// <summary>
    /// ocr文本数据
    /// </summary>
   [Serializable]
    public class OCRTextShuJu : MultTree.ToolDateFather, IOCRTextShuJu
    {
        #region 全局变量

        #region   外部接口
        /// <summary>
        /// 外部接口
        /// </summary>
       [NonSerialized]
       HalControl.ROI.Rectangle2.IOutsideRectangle2ROI _iOutSide = null;
        #endregion

        #region  创建文本时的参数
        /// <summary>
        /// 文本的读取模式
        /// </summary>
       [NonSerialized]
       HTuple _mode;

       #region  无用代码
       // /// <summary>
       // /// 读取ocr的mlp网络
       // /// </summary>
       // [NonSerialized]
       //HTuple _ocrClassifierMLP;
       #endregion

       /// <summary>
        /// 文本的指针
        /// </summary>
        [NonSerialized] 
       HTuple _textMode;
        #endregion

        #region  ocr字库的名称
        /// <summary>
        /// ocr字库的名称
        /// </summary>
        private string hv_FileName = null;       
        #endregion

        #region  获取结果的格式
        /// <summary>
        /// 获取结果的格式
        /// </summary>
        [NonSerialized] 
       HTuple _resultName;
        #endregion
        
        #region   结果
        /// <summary>
        /// 结果
        /// </summary>
         [NonSerialized]
        public OCRTextShuJu_Result _result = new OCRTextShuJu_Result();
        #endregion

        #endregion

        #region   属性

        #region   外部接口
        /// <summary>
        /// 外部接口
        /// </summary>
        public HalControl.ROI.Rectangle2.IOutsideRectangle2ROI IOutSide
        {
            get
            {
                if (_iOutSide == null)
                {
                    _iOutSide = new HalControl.ROI.Rectangle2.OutsideRectangle2ROI();
                    this._iOutSide.Len1 = 100;
                    this._iOutSide.Len2 = 100;
                    this._iOutSide.Phi = 0;
                    this._iOutSide.Mid_col_x = 100;
                    this._iOutSide.Mid_row_y = 100;
                }
                return _iOutSide;
            }
            set { _iOutSide = value; }
        }
        #endregion

        #region  创建文本时的参数
        /// <summary>
        /// 文本的读取模式
        /// </summary>
        public HTuple Mode
        {
            get
            {
                if (_mode == null)
                {
                    _mode = "auto";
                }
                return _mode;
            }
            set { _mode = value; }
        }

        #region  无用代码
        ///// <summary>
        ///// 读取ocr的mlp网络
        ///// </summary>
        //public HTuple OcrClassifierMLP
        //{
        //    get
        //    {
        //        if (_ocrClassifierMLP == null)
        //        {
        //            _ocrClassifierMLP = "Industrial_Rej";
        //        }
        //        return _ocrClassifierMLP;
        //    }
        //    set { _ocrClassifierMLP = value; }
        //}
        #endregion

        /// <summary>
        /// 文本的指针
        /// </summary>
        public HTuple TextMode
        {
            get
            {
                if (_textMode == null)
                {
                    HOperatorSet.CreateTextModelReader(this.Mode, (HTuple)(AppDomain.CurrentDomain.BaseDirectory + @"Ocr\" + this.Hv_FileName + ".omc"), out this._textMode);
                }
                return _textMode;
            }
            set { _textMode = value; }
        }
        #endregion

        #region  获取结果的格式
        /// <summary>
        /// 获取结果的格式
        /// </summary>
        public HTuple ResultName
        {
            get
            {
                if (_resultName == null)
                {
                    _resultName = "all_lines";
                }
                return _resultName;
            }
            set { _resultName = value; }
        }
        #endregion

        #region  ocr字库的名称
        /// <summary>
        /// ocr字库的名称
        /// </summary>
        public string Hv_FileName
        {
            get {
                if (hv_FileName == null)
                {
                    hv_FileName = "Document_0-9_NoRej";
                }
                return hv_FileName; }
            set { hv_FileName = value; }
        }
        #endregion

        #endregion

        #region   序列化

        #region  提取ocv检测的region 点位       
        /// <summary>
        /// 
        /// </summary>
        Object mid_row_y_1;
        /// <summary>
        /// 
        /// </summary>
        Object mid_col_x_1;
        /// <summary>
        /// 
        /// </summary>
        Object len1_1;
        /// <summary>
        /// 
        /// </summary>
        Object len2_1;
        /// <summary>
        /// 
        /// </summary>
        Object angle_1;
        #endregion

        #region  创建文本时的参数
        /// <summary>
        /// 文本的读取模式
        /// </summary>        
        object _mode_1;
        #endregion

        #region  获取结果的格式
        /// <summary>
        /// 获取结果的格式
        /// </summary>
        object _resultName_1;
        #endregion

        #endregion

        #region   构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public OCRTextShuJu()
        {
            #region  实例化结果类
            _result = new OCRTextShuJu_Result();
            #endregion

            #region 创建ocr字库
            HOperatorSet.CreateTextModelReader(this.Mode, this.Hv_FileName + ".omc", out this._textMode);
            #endregion
        }
#endregion

        #region   初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public override void init()
        {
            base.init();

            #region  实例化结果类
            _result = new OCRTextShuJu_Result();
            #endregion

            #region 读取ocr字库
            HOperatorSet.CreateTextModelReader(this.Mode, this.Hv_FileName + ".omc", out this._textMode);
            #endregion

            #region  提取ocv检测的region 点位
            this.IOutSide.Mid_col_x = (HTuple)this.mid_col_x_1;
            this.IOutSide.Mid_row_y = (HTuple)this.mid_row_y_1;
            this.IOutSide.Len1 = (HTuple)this.len1_1;
            this.IOutSide.Len2 = (HTuple)this.len2_1;
            this.IOutSide.Phi = (HTuple)this.angle_1;
            #endregion

            #region  创建文本时的参数
            this.Mode = (HTuple)_mode_1;
            #endregion

            #region  获取结果的格式
            this.ResultName=(HTuple)_resultName_1;
            #endregion
        }
        #endregion

        #region  保存
        /// <summary>
        /// 保存
        /// </summary>
        public override void save()
        {
            base.save();

            #region  提取ocv检测的region 点位
            this.mid_col_x_1 = this.IOutSide.Mid_col_x;
            this.mid_row_y_1 = this.IOutSide.Mid_row_y;
            this.len1_1 = this.IOutSide.Len1;
            this.len2_1 = this.IOutSide.Len2;
            this.angle_1 = this.IOutSide.Phi;
            #endregion

            #region  创建文本时的参数
            _mode_1=this.Mode;
            #endregion

            #region  获取结果的格式
            _resultName_1=this.ResultName;
            #endregion

        }
        #endregion

        #region  检测
        public override bool analyze_show(HWindow hwin, string Key, ref Dictionary<string, object> _dictionary_resulte)
        {
            bool ok = false;
            /*********************************************处理***********************************************/
            HObject ho_ImageReduced_;
            HOperatorSet.GenEmptyObj(out ho_ImageReduced_);
            HTuple hv_ModMat2D_;
            HObject ho_Rectangle_;
            HOperatorSet.GenEmptyObj(out ho_Rectangle_);
            ho_Rectangle_.Dispose();
            HOperatorSet.GenRectangle2(out ho_Rectangle_, IOutSide.Mid_row_y, IOutSide.Mid_col_x, -IOutSide.Phi, IOutSide.Len1, IOutSide.Len2);
            if (IrectShuJuPianYi != null)
            {
                HOperatorSet.VectorAngleToRigid(GenSuiDian_Y_Row, GeuSuiDian_X_Col, GenSuiDian_A, IrectShuJuPianYi.Row, IrectShuJuPianYi.Column, IrectShuJuPianYi.Angle, out hv_ModMat2D_);
                HOperatorSet.AffineTransRegion(ho_Rectangle_, out ho_Rectangle_, hv_ModMat2D_, "nearest_neighbor");
            }
            HOperatorSet.ReduceDomain(this.ImageFather.Ho_image, ho_Rectangle_, out ho_ImageReduced_);
            HOperatorSet.FindText(ho_ImageReduced_, this.TextMode, out this._result.TextResult);

            this._result.TextLines.Dispose();
            HOperatorSet.GetTextObject(out this._result.TextLines, this._result.TextResult, this.ResultName);
            HOperatorSet.GetTextResult(this._result.TextResult, "class", out this._result.SingleCharacters);

            /**************************数据保存及数据分析**************************************/

            Key = "OCRWenBen_" + Key;
            this._result._tolatName = Key;

            if (this._result.SingleCharacters.Length > 0)
            {                
                this._result._tolatResult = true;
                ok = true;
            }
            else
            {
                this._result._tolatResult = false;            
            }

            _dictionary_resulte.Add(Key, this._result);
            
            /****************显示*******************/
            show(hwin);

            return ok;
        }
        #endregion
        
        #region  显示
        public override bool show(HWindow hwin)
        {
            bool ok = false;
            HTuple hv_modMat2D;
            HObject hr_;
            HOperatorSet.GenEmptyRegion(out hr_);
            HOperatorSet.GenRectangle2(out hr_, this.IOutSide.Mid_row_y, this.IOutSide.Mid_col_x, this.IOutSide.Phi, this.IOutSide.Len1, this.IOutSide.Len2);

            if (IrectShuJuPianYi != null)
            {
                HOperatorSet.VectorAngleToRigid(GenSuiDian_Y_Row, GeuSuiDian_X_Col, GenSuiDian_A, IrectShuJuPianYi.Row, IrectShuJuPianYi.Column, IrectShuJuPianYi.Angle, out hv_modMat2D);
                HOperatorSet.AffineTransRegion(hr_, out hr_, hv_modMat2D, "nearest_neighbor");
            }

            if (this._result.TolatResult)
            {
                int num = this._result.SingleCharacters.Length;

                HTuple row1,row2,col1,col2,TextLineCharacters;
                HOperatorSet.SmallestRectangle1(this._result.TextLines,out row1,out col1,out row2,out col2);
                HOperatorSet.TupleSum(this._result.SingleCharacters, out TextLineCharacters);

                for (int i = 0;i<num ;i++ )
                {
                    HOperatorSet.SetTposition(hwin, row1[i] + 10, col1[i]);
                    HOperatorSet.WriteString(hwin, this._result.SingleCharacters[i]);
                }

                hwin.DispObj(this._result.TextLines);
                hwin.DispObj(hr_);
            }
            else
            {
                hwin.SetColor("red");
                hwin.DispObj(hr_);
                hwin.SetColor("green");
            }
            hr_.Dispose();


            return ok;
        }
        #endregion

        #region   显示结果
        /// <summary>
        /// 显示结果
        /// </summary>
        /// <param name="toolResult_"></param>
        /// <returns></returns>
        public override bool outResult(out string[] toolResult_)
        {
            bool ok = false;
            _result.showResult(out toolResult_);
            ok = true;
            return ok;
        }
        #endregion
    }
    #endregion

    #region    ocr文本数据接口
    /// <summary>
    /// ocr文本数据接口
    /// </summary>
    public interface IOCRTextShuJu : MultTree.IToolDateFather, HalControl.ROI.Rectangle2.IOutsideRectangle2
    {
        #region   属性

        #region   外部接口
        /// <summary>
        /// 外部接口
        /// </summary>
        HalControl.ROI.Rectangle2.IOutsideRectangle2ROI IOutSide
        {
            get
           ;
            set;
        }
        #endregion

        #region  创建文本时的参数
        /// <summary>
        /// 文本的读取模式
        /// </summary>
        HTuple Mode
        {
            get;
            set;
        }

        /// <summary>
        /// 文本的指针
        /// </summary>
        HTuple TextMode
        {
            get;
            set;
        }
        #endregion

        #region  获取结果的格式
        /// <summary>
        /// 获取结果的格式
        /// </summary>
        HTuple ResultName
        {
            get;
            set;
        }
        #endregion

        #region  ocr字库的名称
        /// <summary>
        /// ocr字库的名称
        /// </summary>
         string Hv_FileName
        {
            get;
            set;
        }
        #endregion

        #endregion

        #region  初始化init
        /// <summary>
        /// 初始化
        /// </summary>
         void init();
        #endregion

        #region  保存
        /// <summary>
        /// 保存
        /// </summary>
         void save();
        #endregion
    }
    #endregion

    #region  结果
    /// <summary>
    /// 结果
    /// </summary>
    public class OCRTextShuJu_Result : MultTree.ClassResultFather
    {
        #region  结果数据
        /// <summary>
        /// 
        /// </summary>
        public HTuple SingleCharacters = new HTuple();
        /// <summary>
        /// 文本读取到ocr的结果
        /// </summary>
        public HTuple TextResult = new HTuple();
        /// <summary>
        /// 读取到字符的region
        /// </summary>
        public HObject TextLines = new HObject();
        #endregion

        #region  构造函数
        public OCRTextShuJu_Result()
        {
            HOperatorSet.GenEmptyObj(out TextLines);
            TextLines.Dispose();
        }
        #endregion

        #region 显示结果数据   
        /// <summary>
        /// 显示结果数据
        /// </summary>
        /// <param name="str_array"></param>
        /// <returns></returns>
        public override bool showResult(out string[] str_array)
        {
            bool ok = false;
            str_array=new string[2];
            str_array[0] = this.TolatName;
            if (this.TolatResult)
            {
                HTuple TextLineCharacters;
                HOperatorSet.TupleSum(this.SingleCharacters, out TextLineCharacters);
                str_array[1] = TextLineCharacters.ToString();
            }
            else
            {
                str_array[1] = "检测失败";
            }
            ok = true;            
            return ok;        
        
        }
        #endregion

        #region  显示结果数据
        public override bool showResult(out string str)
        {
            return base.showResult(out str);
        }
        #endregion

    }

    #endregion

    #region   设置器
    /// <summary>
    /// 设置器
    /// </summary>
    public class Set_OCRTextLibrary
    {
        #region   更换字库
        /// <summary>
        /// 更换字库
        /// </summary>
        /// <param name="iOCRText"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Set_GengHuanZiKu(IOCRTextShuJu iOCRText,string name)
        {
            bool ok = false;

            iOCRText.Hv_FileName = name;
            string path= AppDomain.CurrentDomain.BaseDirectory + @"Ocr\" + iOCRText.Hv_FileName + ".omc";
            HTuple OCRHandle;
            //HOperatorSet.ClearOcrClassMlp(iOCRText.TextMode);
            HOperatorSet.ClearTextModel(iOCRText.TextMode);
            HOperatorSet.CreateTextModelReader(iOCRText.Mode, iOCRText.Hv_FileName, out OCRHandle);
            //HOperatorSet.ReadOcrClassMlp(path, out OCRHandle);
            iOCRText.TextMode = OCRHandle;

            ok = true;
            return ok;
        }
        #endregion
        
        #region   初始化参数
        /// <summary>
        /// 初始化参数
        /// </summary>
        /// <param name="iOCRText"></param>
        /// <param name="control"></param>
        /// <param name="halconWinControl_"></param>
        public void Set_showParameterHalconWinControl(IOCRTextShuJu iOCRText, Control.ControlCollection control, HalControl.HalconWinControl_ROI halconWinControl_)
        {
            if (halconWinControl_ != null)
            {
                halconWinControl_.DrawRectangle2(iOCRText.IOutSide.Mid_col_x, iOCRText.IOutSide.Mid_row_y, iOCRText.IOutSide.Phi, iOCRText.IOutSide.Len1, iOCRText.IOutSide.Len2, iOCRText.IOutSide);
            }
            Set_ShowOCVParameter(iOCRText, control);
        }

        /// <summary>
        /// 显示参数
        /// </summary>
        /// <param name="iOCRText"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        bool Set_ShowOCVParameter(IOCRTextShuJu iOCRText, Control.ControlCollection control)
        {
            bool ok = false;
            foreach (Control con in control)
            {
                string name = con.Name;
                if ((con is ComboBox) || (con is TextBox) || (con is RichTextBox) || (con is Label))
                {
                    switch (name)
                    {
                        #region  加载字库
                        case "Hv_FileName":                                  
                         List<string> str_name;
                            find_all_omc(out str_name);
                            ComboBox com = con as ComboBox;
                            if (com != null)
                            {
                                foreach (string filename in str_name)
                                {
                                    com.Items.Add(filename.Replace(".omc", ""));
                                }
                            }
                            con.Text = iOCRText.Hv_FileName;
                            break;
                        #endregion
                            
                        #region  默认
                        default:
                            break;
                        #endregion
                    }
                }
                if (con.Controls.Count > 0)
                {
                    Set_ShowOCVParameter(iOCRText, con.Controls);
                }
            }
            ok = true;
            return ok;
        }        
        #endregion

        #region  查找默认路径下的字库文件
        /// <summary>
        /// 查找默认路径下的字库文件
        /// </summary>
        /// <param name="str_name">集合</param>
        public void find_all_omc(out List<string> str_name)
        {
            str_name = new List<string>();

            #region 确保目录存在
            DirectoryInfo dirInfo = new DirectoryInfo(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory + @"Ocr\"));
            var dir = dirInfo;
            Stack<DirectoryInfo> needCreatedDirs = new Stack<DirectoryInfo>();
            while (!dir.Exists)
            {
                needCreatedDirs.Push(dir);
                dir = dir.Parent;
            }
            while (needCreatedDirs.Count > 0)
            {
                needCreatedDirs.Pop().Create();
            }
            #endregion

            foreach (FileInfo file in dirInfo.GetFiles("*.omc"))
            {
                str_name.Add(file.Name);
            }

        }
        #endregion

        #region  刷新定位点
        /// <summary>
        /// 刷新定位点
        /// </summary>
        /// <param name="IOCR"></param>
        /// <returns></returns>
        public bool Set_ShuaXinDingWeiDian(IOCRTextShuJu iOCRText)
        {
            bool ok = false;
            if (iOCRText.IrectShuJuPianYi != null)
            {
                iOCRText.GeuSuiDian_X_Col = iOCRText.IrectShuJuPianYi.Column;
                iOCRText.GenSuiDian_Y_Row = iOCRText.IrectShuJuPianYi.Row;
                iOCRText.GenSuiDian_A = iOCRText.IrectShuJuPianYi.Angle;
            }
            ok = true;
            return ok;
        }
        #endregion

    }

#endregion
}
