using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HalconDotNet;
using System.Windows.Forms;
using RectLibrary;
using CalibrationLibrary;
using MultTree;
using HalControl.ROI.Rectangle2;





namespace TemplateHalconLibrary
{
    #region 模板的数据
    /// <summary>
    /// 模板的数据
    /// </summary>
    [Serializable]
    public class TemplateShuJu : MultTree.ToolDateFather, ITemplateShuJu/*,IRectShuJuPianYi*/
    {
        #region  全局变量

        #region  创建模板时的数据
        /// <summary>
        /// 创建模板时的数据
        /// </summary>
        ITemplateCreateShuJu _iTemplateCreate = null;
        #endregion

        #region  模板提取器
        /// <summary>
        /// 模板提取器数据
        /// </summary>
        IExtractModelShuJu _iExtractModel = null;
        #endregion

        #region  外部接口
        /// <summary>
        /// 外部接口
        /// </summary>       
        IOutsideRectangle2ROI _iOutSide;
        #endregion

        #region  查找模板的参数
        /// <summary>
        /// 查找模板的开始角度
        /// </summary>
        [NonSerialized]
        HTuple findAngleStart = null;

        /// <summary>
        /// 查找模板的结束角度
        /// </summary>
        [NonSerialized]
        HTuple findAngleExtent = null;

        /// <summary>
        /// 查找模板的最小分数
        /// </summary>
        [NonSerialized]
        HTuple findMinScore = null;

        /// <summary>
        /// 查找模板的匹配个数
        /// </summary>
        [NonSerialized]
        HTuple findNumMatches = null;

        /// <summary>
        /// FindMaxOverlap
        /// </summary>
        [NonSerialized]
        HTuple findMaxOverlap = null;

        /// <summary>
        /// 极性
        /// </summary>
        [NonSerialized]
        HTuple findSubPixel = null;

        /// <summary>
        /// 查找模板的层数
        /// </summary>
        [NonSerialized]
        HTuple findNumLevels = null;

        /// <summary>
        /// findGreediness
        /// </summary>
        [NonSerialized]
        HTuple findGreediness = null;
        #endregion

        #region 模板的轮廓
        /// <summary>
        /// 模板的轮廓
        /// </summary>
        [NonSerialized]
        HObject modelContours = null;

        #endregion

        #region   模板的路径
        /// <summary>
        /// 模板路径
        /// </summary>
        string modelFilePaht = null;
        #endregion

        #region   查找模板的指针
        /// <summary>
        ///  查找模板的指针
        /// </summary>
        [NonSerialized]
        HTuple findModelID = null;
        #endregion

        #region   输出的模板数据

        /// <summary>
        /// 查找到的分数
        /// </summary>
        [NonSerialized]
        HTuple score = null;

        /// <summary>
        /// 模板查找后输出的轮廓
        /// </summary>
        [NonSerialized]
        HObject contoursAffinTrans = null;
        #endregion

        #region   模板的名称
        /// <summary>
        /// 模板的名称
        /// </summary>
        string modelName = null;
        #endregion

        #region   模板点的xld
        /// <summary>
        /// 模板点的xld
        /// </summary>
        [NonSerialized]
        HObject _centerPointXLD = null;
        #endregion

        #region   结果
        /// <summary>
        /// 结果
        /// </summary>
        [NonSerialized]
        Template_Result _result;
        #endregion

        #endregion

        #region  属性

        #region 创建模板时的数据
        /// <summary>
        /// 创建模板时的数据
        /// </summary>
        public ITemplateCreateShuJu ITemplateCreate
        {
            get
            {
                if (_iTemplateCreate == null)
                {
                    _iTemplateCreate = new TemplateCreate();
                }
                return _iTemplateCreate;
            }
            set { _iTemplateCreate = value; }
        }
        #endregion

        #region 模板提取器数据
        /// <summary>
        /// 模板提取器数据
        /// </summary>
        public IExtractModelShuJu IExtractModel
        {
            get
            {
                if (_iExtractModel == null)
                {
                    _iExtractModel = new ExtractModel();
                }
                return _iExtractModel;
            }
            set { _iExtractModel = value; }
        }
        #endregion

        #region   外部接口
        /// <summary>
        /// 外部接口
        /// </summary>
        public IOutsideRectangle2ROI IOutSide
        {
            get
            {
                if (_iOutSide == null)
                {
                    _iOutSide = new OutsideRectangle2ROI();
                    _iOutSide.Phi = 0;
                    _iOutSide.Len1 = 100;
                    _iOutSide.Len2 = 100;
                    _iOutSide.Mid_col_x = 100;
                    _iOutSide.Mid_row_y = 100;
                }
                return _iOutSide;
            }
            set { _iOutSide = value; }
        }


        #endregion

        #region  查找模板的参数
        /// <summary>
        /// 查找模板的开始角度
        /// </summary>
        public HTuple FindAngleStart
        {
            get
            {
                if (findAngleStart == null)
                {
                    findAngleStart = 0;
                }
                return findAngleStart;
            }
            set { findAngleStart = value; }
        }

        /// <summary>
        /// 查找模板的结束角度
        /// </summary>
        public HTuple FindAngleExtent
        {
            get
            {
                if (findAngleExtent == null)
                {
                    findAngleExtent = 0.78;
                }
                return findAngleExtent;
            }
            set { findAngleExtent = value; }
        }

        /// <summary>
        /// 查找模板的最小分数
        /// </summary>
        public HTuple FindMinScore
        {
            get
            {
                if (findMinScore == null)
                {
                    findMinScore = 0.5;
                }
                return findMinScore;
            }
            set { findMinScore = value; }
        }

        /// <summary>
        /// 查找模板的匹配个数
        /// </summary>
        public HTuple FindNumMatches
        {
            get
            {
                if (findNumMatches == null)
                {
                    findNumMatches = 1;
                }
                return findNumMatches;
            }
            set { findNumMatches = value; }
        }

        /// <summary>
        /// FindMaxOverlap
        /// </summary>
        public HTuple FindMaxOverlap
        {
            get
            {
                if (findMaxOverlap == null)
                {
                    findMaxOverlap = 0.5;
                }
                return findMaxOverlap;
            }
            set { findMaxOverlap = value; }
        }

        /// <summary>
        /// 极性
        /// </summary>
        public HTuple FindSubPixel
        {
            get
            {
                if (findSubPixel == null)
                {
                    findSubPixel = "least_squares";
                }
                return findSubPixel;
            }
            set { findSubPixel = value; }
        }

        /// <summary>
        /// 查找模板的层数
        /// </summary>
        public HTuple FindNumLevels
        {
            get
            {
                if (findNumLevels == null)
                {
                    findNumLevels = 0;
                }
                return findNumLevels;
            }
            set { findNumLevels = value; }
        }

        /// <summary>
        /// findGreediness
        /// </summary>
        public HTuple FindGreediness
        {
            get
            {
                if (findGreediness == null)
                {
                    findGreediness = 0.9;
                }
                return findGreediness;
            }
            set { findGreediness = value; }
        }
        #endregion

        #region 查找模板的指针
        /// <summary>
        /// 查找模板的指针
        /// </summary>
        public HTuple FindModelID
        {
            get { return findModelID; }
            set
            {
                findModelID = value;
                HOperatorSet.GetShapeModelContours(out modelContours, findModelID, 1);
            }
        }
        #endregion

        #region 输出的模板数据
        ///// <summary>
        ///// 查找到的中心点,y
        ///// </summary>
        //public HTuple Row
        //{
        //    get { return row; }
        //    set { row = value; }
        //}

        ///// <summary>
        ///// 查找到的中心点,x
        ///// </summary>
        //public HTuple Column
        //{
        //    get { return column; }
        //    set { column = value; }
        //}

        ///// <summary>
        ///// 查找到的角度
        ///// </summary>
        //public HTuple Angle
        //{
        //    get { return angle; }
        //    set { angle = value; }
        //}

        /// <summary>
        /// 查找到的分数
        /// </summary>
        public HTuple Score
        {
            get { return score; }
            set { score = value; }
        }

        /// <summary>
        /// 模板查找后输出的轮廓
        /// </summary>
        public HObject ContoursAffinTrans
        {
            get { return contoursAffinTrans; }
            set { contoursAffinTrans = value; }
        }
        #endregion

        #region   模板路径
        /// <summary>
        /// 模板路径
        /// </summary>
        public string ModelFilePaht
        {
            get
            {
                if (modelFilePaht == null)
                {
                    string str = AppDomain.CurrentDomain.BaseDirectory + @"Model\" + ModelName + ".shm";
                    return str;
                }
                return modelFilePaht;
            }
            set { modelFilePaht = value; }
        }
        #endregion

        #region  模板的名称
        /// <summary>
        /// 模板的名称
        /// </summary>
        public string ModelName
        {
            get
            {
                if (modelName == null)
                {
                    return "A";
                }
                return modelName;
            }
            set { modelName = value; }
        }
        #endregion

        #region  模板的轮廓
        /// <summary>
        /// 模板的轮廓
        /// </summary>
        public HObject ModelContours
        {
            get
            {
                if (modelContours == null)
                {
                    HOperatorSet.GenEmptyObj(out modelContours);
                    modelContours.Dispose();
                }
                return modelContours;
            }
            set { modelContours = value; }
        }
        #endregion

        #region  模板点的xld
        /// <summary>
        /// 模板点的xld
        /// </summary>
        public HObject CenterPointXLD
        {
            get
            {
                if (_centerPointXLD == null)
                {
                    HOperatorSet.GenEmptyObj(out _centerPointXLD);
                    _centerPointXLD.Dispose();
                }
                return _centerPointXLD;
            }
            set { _centerPointXLD = value; }
        }
        #endregion

        //#region  标定数据
        ///// <summary>
        ///// 标定数据
        ///// </summary>
        //public IHomMat2D _ICalibration
        //{
        //    get { return _iCalibration; }
        //    set { _iCalibration = value; }
        //}
        //#endregion

        #endregion

        #region   序列化的数据

        #region  查找模板的参数
        /// <summary>
        /// 查找模板的开始角度
        /// </summary>
        Object findAngleStart_1;

        /// <summary>
        /// 查找模板的结束角度
        /// </summary>
        Object findAngleExtent_1;

        /// <summary>
        /// 查找模板的最小分数
        /// </summary>
        Object findMinScore_1;

        /// <summary>
        /// 查找模板的匹配个数
        /// </summary>
        Object findNumMatches_1;

        /// <summary>
        /// FindMaxOverlap
        /// </summary>
        Object findMaxOverlap_1;

        /// <summary>
        /// 极性
        /// </summary>
        Object findSubPixel_1;

        /// <summary>
        /// 查找模板的层数
        /// </summary>
        Object findNumLevels_1;

        /// <summary>
        /// findGreediness
        /// </summary>
        Object findGreediness_1;
        #endregion

        #region   Rectangle2ROI对接外部的接口

        Object mid_row_y_1;

        Object mid_col_x_1;

        Object len1_1;

        Object len2_1;

        Object phi_1;

        #endregion

        #endregion

        #region   初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        public TemplateShuJu()
        {
            HOperatorSet.GenEmptyObj(out contoursAffinTrans);
            contoursAffinTrans.Dispose();

            HOperatorSet.GenEmptyObj(out modelContours);
            modelContours.Dispose();

            _result = new Template_Result();

        }
        #endregion

        #region  初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        public override void init()
        {
            base.init();

            #region  查找模板的参数
            findAngleStart = (HTuple)findAngleStart_1;

            findAngleExtent = (HTuple)findAngleExtent_1;

            findMinScore = (HTuple)findMinScore_1;

            findNumMatches = (HTuple)findNumMatches_1;

            findMaxOverlap = (HTuple)findMaxOverlap_1;

            findSubPixel = (HTuple)findSubPixel_1;

            findNumLevels = (HTuple)findNumLevels_1;

            findGreediness = (HTuple)findGreediness_1;
            #endregion

            #region 初始化 HObject
            HOperatorSet.GenEmptyObj(out contoursAffinTrans);
            contoursAffinTrans.Dispose();

            HOperatorSet.GenEmptyObj(out modelContours);
            modelContours.Dispose();
            #endregion

            #region   Rectangle2ROI对接外部的接口

            this.IOutSide.Mid_row_y = (HTuple)mid_row_y_1;

            this.IOutSide.Mid_col_x = (HTuple)mid_col_x_1;

            this.IOutSide.Len1 = (HTuple)len1_1;

            this.IOutSide.Len2 = (HTuple)len2_1;

            this.IOutSide.Phi = (HTuple)phi_1;

            #endregion

            #region  初始化指针
            HOperatorSet.ReadShapeModel(ModelFilePaht, out findModelID);
            HOperatorSet.GetShapeModelContours(out modelContours, findModelID, 1);
            #endregion

            _result = new Template_Result();

            // _iTemplateCreate = new TemplateCreate();
            _iTemplateCreate.init();

            // _iExtractModel = new ExtractModel();
            _iExtractModel.init();
        }
        #endregion

        #region   保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        public override void save()
        {
            base.save();

            #region  查找模板的参数
            findAngleStart_1 = findAngleStart;

            findAngleExtent_1 = findAngleExtent;

            findMinScore_1 = findMinScore;

            findNumMatches_1 = findNumMatches;

            findMaxOverlap_1 = findMaxOverlap;

            findSubPixel_1 = findSubPixel;

            findNumLevels_1 = findNumLevels;

            findGreediness_1 = findGreediness;
            #endregion

            #region   Rectangle2ROI对接外部的接口

            mid_row_y_1 = this.IOutSide.Mid_row_y;

            mid_col_x_1 = this.IOutSide.Mid_col_x;

            len1_1 = this.IOutSide.Len1;

            len2_1 = this.IOutSide.Len2;

            phi_1 = this.IOutSide.Phi;

            #endregion

            _iTemplateCreate.save();

            _iExtractModel.save();

        }
        #endregion

        #region  检测

        public override bool analyze_show(HWindow hwin, string Key, ref Dictionary<string, object> _dictionary_resulte)
        {
            bool ok = false;

            /*********************************处理*************************************************/
            HTuple hv_Row_ = null, hv_Column_ = null, hv_Angle_ = null, hv_Score1_ = null;
            HObject ho_ContoursAffinTrans_;
            
            /*************截取roi*****************/
            HObject ho_Region_;
            HOperatorSet.GenEmptyObj(out ho_Region_);

            HOperatorSet.GenRectangle2(out ho_Region_, IOutSide.Mid_row_y, IOutSide.Mid_col_x, -IOutSide.Phi, IOutSide.Len1, IOutSide.Len2);

            /**********判断有无定位****************/
            if (IrectShuJuPianYi != null)
            {
                HTuple hv_homMat2D;
                HOperatorSet.VectorAngleToRigid(GenSuiDian_Y_Row, GeuSuiDian_X_Col, GenSuiDian_A, IrectShuJuPianYi.Row, IrectShuJuPianYi.Column, IrectShuJuPianYi.Angle, out hv_homMat2D);
                HOperatorSet.AffineTransRegion(ho_Region_, out ho_Region_, hv_homMat2D, "nearest_neighbor");
            }

            HOperatorSet.ReduceDomain(this.ImageFather.Ho_image, ho_Region_, out ho_Region_);

            find_model(ho_Region_, ModelContours, out ho_ContoursAffinTrans_,
      FindModelID, FindAngleStart, FindAngleExtent, FindMinScore,
      FindNumMatches, FindMaxOverlap, FindSubPixel, FindNumLevels,
     FindGreediness, out hv_Row_, out hv_Column_, out hv_Angle_,
      out hv_Score1_);

            /*********清空缓存***************/
            ho_Region_.Dispose();


            HObject ho_cro;
            HOperatorSet.GenEmptyObj(out ho_cro);
            ho_cro.Dispose();
            if (hv_Row_.Length >= 1)
            {
                HOperatorSet.GenCrossContourXld(out ho_cro, hv_Row_, hv_Column_, 60, hv_Angle_);
            }
            CenterPointXLD.Dispose();
            CenterPointXLD = ho_cro;

            ContoursAffinTrans.Dispose();
            ContoursAffinTrans = ho_ContoursAffinTrans_;
            Score = hv_Score1_;
            Angle = hv_Angle_;
            Row = hv_Row_;
            Column = hv_Column_;

            /******************分析数据***************************/
            Key = "Template_" + Key;
            //Template_Result re = new Template_Result();
            _result.TolatName = Key;

            if (Row.Length > 0)
            {
                _result.Hv_Row1 = Row;
                _result.Hv_Column1 = Column;
                _result.TolatResult = true;
                _result._AllResult = true;
                _result.Hv_Angle1 = Angle;
                _result.Hv_Score1 = Score;

                if (_ICalibration != null)//判断有无标定
                {
                    this.Cal(_ICalibration.HomMat2D, ref _result.Hv_Row1, ref  _result.Hv_Column1);
                }
            }
            else
            {
                _result.TolatResult = false;
                _result._AllResult = false;
                _result.Hv_Angle1 = 0;
                _result.Hv_Column1 = 0;
                _result.Hv_Row1 = 0;
                _result.Hv_Score1 = 0;
            }

            _dictionary_resulte.Add(Key, _result);

            show(hwin);

            if (_result._AllResult)
            {
                ok = true;
            }

            return ok;
        }

        #endregion

        #region  检测
        /// <summary>
        /// 查找模板
        /// </summary>
        /// <param name="ho_Image">查找的图片</param>
        /// <param name="ho_ModelContours1">模板轮廓</param>
        /// <param name="ho_ContoursAffinTrans">装换的轮廓</param>
        /// <param name="hv_ModelID1">模板句柄</param>
        /// <param name="hv_AngleStar"></param>
        /// <param name="hv_AngleExtent"></param>
        /// <param name="hv_MinScore"></param>
        /// <param name="hv_NumMatches"></param>
        /// <param name="hv_MaxOverlap"></param>
        /// <param name="hv_SubPixel"></param>
        /// <param name="hv_Numlevels"></param>
        /// <param name="hv_Greendiness"></param>
        /// <param name="hv_Row1"></param>
        /// <param name="hv_Column1"></param>
        /// <param name="hv_Angle1"></param>
        /// <param name="hv_Score1"></param>
        void find_model(HObject ho_Image, HObject ho_ModelContours1, out HObject ho_ContoursAffinTrans,
    HTuple hv_ModelID1, HTuple hv_AngleStar, HTuple hv_AngleExtent, HTuple hv_MinScore,
    HTuple hv_NumMatches, HTuple hv_MaxOverlap, HTuple hv_SubPixel, HTuple hv_Numlevels,
    HTuple hv_Greendiness, out HTuple hv_Row1, out HTuple hv_Column1, out HTuple hv_Angle1,
    out HTuple hv_Score1)
        {
            #region
            //  hv_AngleStar = 0;
            //    hv_AngleExtent = (new HTuple(30)).TupleRad();
            //    hv_MinScore = 0.5;
            //    hv_NumMatches = 1;
            //    hv_MaxOverlap = 0.5;
            //    hv_SubPixel = "least_squares";
            //    hv_Numlevels = 0;
            //    hv_Greendiness = 0.9;
            #endregion
            // Local control variables 

            // HTuple hv_Row = null, hv_Column = null, hv_Angle = null;
            HTuple hv_HomMat2D = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ContoursAffinTrans);
            ho_ContoursAffinTrans.Dispose();
            hv_Row1 = new HTuple();
            hv_Column1 = new HTuple();
            hv_Angle1 = new HTuple();
            hv_Score1 = new HTuple();
            if (hv_ModelID1 == null)
            {
                HOperatorSet.GenEmptyObj(out ho_ContoursAffinTrans);

                return;
            }
            HOperatorSet.FindShapeModel(ho_Image, hv_ModelID1, hv_AngleStar, hv_AngleExtent,
                hv_MinScore, hv_NumMatches, hv_MaxOverlap, hv_SubPixel, hv_Numlevels, hv_Greendiness,
                out hv_Row1, out hv_Column1, out hv_Angle1, out hv_Score1);

            if ((int)(new HTuple((new HTuple(hv_Row1.TupleLength())).TupleNotEqual(0))) != 0)
            {
                //作者qq1756192667
                int num = hv_Row1.Length;

                for (int i = 0; i < num; i++)
                {
                    HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_Row1[i], hv_Column1[i], hv_Angle1[i], out hv_HomMat2D);
                    ho_ContoursAffinTrans.Dispose();
                    HOperatorSet.AffineTransContourXld(ho_ModelContours1, out ho_ContoursAffinTrans,
                        hv_HomMat2D);
                }
                //    HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_Row1, hv_Column1, hv_Angle1, out hv_HomMat2D);
                //ho_ContoursAffinTrans.Dispose();
                //HOperatorSet.AffineTransContourXld(ho_ModelContours1, out ho_ContoursAffinTrans,
                //    hv_HomMat2D);
                if (HDevWindowStack.IsOpen())
                {
                    //dev_display (Image)
                }
                if (HDevWindowStack.IsOpen())
                {
                    //dev_display (ContoursAffinTrans)
                }
                //disp_message (3600, 'XLD轮廓做模板', 'image', 20, 20, 'black', 'true')
                //disp_message (3600, '视频和代码请加qq1756192667', 'image', 100, 20, 'black', 'true')
            }
            else
            {

            }
            return;
        }
        #endregion

        #region  显示
        public override bool show(HWindow hwin)
        {
            bool ok = false;
            if (!_result._tolatResult)
            {
                hwin.SetColor("red");
                HObject ho_Region1;
                HOperatorSet.GenEmptyObj(out ho_Region1);

                HOperatorSet.GenRectangle2ContourXld(out ho_Region1, IOutSide.Mid_row_y, IOutSide.Mid_col_x, IOutSide.Phi, IOutSide.Len1, IOutSide.Len2);

                /**********判断有无定位****************/
                if (IrectShuJuPianYi != null)
                {
                    HTuple hv_homMat2D1;
                    HOperatorSet.VectorAngleToRigid(GenSuiDian_Y_Row, GeuSuiDian_X_Col, GenSuiDian_A, IrectShuJuPianYi.Row, IrectShuJuPianYi.Column, IrectShuJuPianYi.Angle, out hv_homMat2D1);
                    HOperatorSet.AffineTransContourXld(ho_Region1, out ho_Region1, hv_homMat2D1);
                }
                hwin.DispObj(ho_Region1);
                hwin.SetColor("green");

            }
            else
            {
                hwin.DispObj(ContoursAffinTrans);
                if (CenterPointXLD.IsInitialized())
                {
                    hwin.DispObj(CenterPointXLD);
                }
            }
            return ok;
        }
        #endregion

        #region  显示结果
        /// <summary>
        /// 显示结果
        /// </summary>
        /// <param name="toolResult_"></param>
        /// <returns></returns>
        public override bool outResult(out string[] toolResult_)
        {
            bool ok = false;
            this._result.showResult(out toolResult_);
            ok = true;
            return ok;
        }

        #endregion

    }
    #endregion

    #region  模板数据接口
    /// <summary>
    /// 模板数据接口
    /// </summary>
    public interface ITemplateShuJu : MultTree.IToolDateFather, IOutsideRectangle2
    {
        #region  属性
        #region 创建模板时的数据
        /// <summary>
        /// 创建模板时的数据
        /// </summary>
        ITemplateCreateShuJu ITemplateCreate
        {
            get;
            set;
        }
        #endregion

        #region 模板提取器数据
        /// <summary>
        /// 模板提取器数据
        /// </summary>
        IExtractModelShuJu IExtractModel
        {
            get;
            set;
        }
        #endregion

        #region  查找模板的参数
        /// <summary>
        /// 查找模板的开始角度  弧度
        /// </summary>
        HTuple FindAngleStart
        {
            get
           ;
            set;
        }

        /// <summary>
        /// 查找模板的结束角度   弧度
        /// </summary>
        HTuple FindAngleExtent
        {
            get
            ;
            set;
        }

        /// <summary>
        /// 查找模板的最小分数
        /// </summary>
        HTuple FindMinScore
        {
            get
          ;
            set;
        }

        /// <summary>
        /// 查找模板的匹配个数
        /// </summary>
        HTuple FindNumMatches
        {
            get
           ;
            set;
        }

        /// <summary>
        /// FindMaxOverlap
        /// </summary>
        HTuple FindMaxOverlap
        {
            get
           ;
            set;
        }

        /// <summary>
        /// 极性
        /// </summary>
        HTuple FindSubPixel
        {
            get
           ;
            set;
        }

        /// <summary>
        /// 查找模板的层数
        /// </summary>
        HTuple FindNumLevels
        {
            get
          ;
            set;
        }

        /// <summary>
        /// findGreediness
        /// </summary>
        HTuple FindGreediness
        {
            get
            ;
            set;
        }
        #endregion

        #region 查找模板的指针
        /// <summary>
        /// 查找模板的指针
        /// </summary>
        HTuple FindModelID
        {
            get;
            set;
        }
        #endregion

        #region 输出的模板数据

        ///// <summary>
        ///// 查找到的中心点,y
        ///// </summary>
        //HTuple Row
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 查找到的中心点,x
        ///// </summary>
        //HTuple Column
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 查找到的角度
        ///// </summary>
        //HTuple Angle
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// 查找到的分数
        /// </summary>
        HTuple Score
        {
            get;
            set;
        }

        /// <summary>
        /// 模板查找后输出的轮廓
        /// </summary>
        HObject ContoursAffinTrans
        {
            get;
            set;
        }
        #endregion

        #region   模板路径
        /// <summary>
        /// 模板路径
        /// </summary>
        string ModelFilePaht
        {
            get
            ;
            set;
        }
        #endregion

        #region  模板的名称
        /// <summary>
        /// 模板的名称
        /// </summary>
        string ModelName
        {
            get
           ;
            set;
        }
        #endregion

        #region  模板的轮廓
        /// <summary>
        /// 模板的轮廓
        /// </summary>
        HObject ModelContours
        {
            get;
            set;
        }
        #endregion

        #region  模板点的xld
        /// <summary>
        /// 模板点的xld
        /// </summary>
        HObject CenterPointXLD
        {
            get;
            set;
        }
        #endregion

        #endregion

        #region  初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <returns></returns>
        void init();
        #endregion

        #region   保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        void save();
        #endregion
    }
    #endregion

    #region 设置模板接口数据
    /// <summary>
    /// 设置模板接口数据
    /// </summary>
    public class SetTemplateShuJu
    {
        #region 全局变量

        #region 创建模板工具
        /// <summary>
        /// 模板创建工具
        /// </summary>
        public ITemplateCreateTool _ITemplateCreate = new TemplateCreate();
        #endregion

        #region   模板提取器工具
        /// <summary>
        ///  模板提取器工具
        /// </summary>
        public IExtractModelTool _IExtractModel = new ExtractModel();
        #endregion

        #endregion

        #region  查找模板的参数
        /// <summary>
        /// 查找模板的参数
        /// </summary>
        /// <param name="ITemplate"></param>
        /// <param name="Hv_AngleStart1"></param>
        /// <param name="Hv_AngleExtent"></param>
        /// <param name="Hv_MinScore"></param>
        /// <param name="Hv_NumMatches"></param>
        /// <param name="Hv_MaxOverlap"></param>
        /// <param name="Hv_SubPixel"></param>
        /// <param name="Hv_Numlevels"></param>
        /// <param name="Hv_Greendiness"></param>
        /// <returns></returns>
        public bool Set_FindModelParameter(ITemplateShuJu ITemplate, string Hv_AngleStart1, string Hv_AngleExtent, string Hv_MinScore,
            string Hv_NumMatches, string Hv_MaxOverlap, string Hv_SubPixel, string Hv_Numlevels, string Hv_Greendiness)
        {
            bool ok = false;
            try
            {
                if (Hv_AngleStart1 != null)
                {
                    double num = Convert.ToDouble(Hv_AngleStart1);

                    num = num = (Math.PI / 180) * num;

                    ITemplate.FindAngleStart = num;

                }

                if (Hv_AngleExtent != null)
                {
                    double num = Convert.ToDouble(Hv_AngleExtent);

                    num = (Math.PI / 180) * num;

                    ITemplate.FindAngleExtent = num;
                }

                if (Hv_MinScore != null)
                {
                    double num = Convert.ToDouble(Hv_MinScore);
                    ITemplate.FindMinScore = num;
                }

                if (Hv_NumMatches != null)
                {
                    double num = Convert.ToInt32(Hv_NumMatches);
                    ITemplate.FindNumMatches = num;
                }

                if (Hv_MaxOverlap != null)
                {
                    double num = Convert.ToDouble(Hv_MaxOverlap);
                    ITemplate.FindMaxOverlap = num;
                }

                if (Hv_SubPixel != null)
                {
                    ITemplate.FindSubPixel = Hv_SubPixel;
                }

                if (Hv_Numlevels != null)
                {
                    double num = Convert.ToDouble(Hv_Numlevels);
                    ITemplate.FindNumLevels = num;
                }

                if (Hv_Greendiness != null)
                {
                    double num = Convert.ToDouble(Hv_Greendiness);
                    ITemplate.FindGreediness = num;
                }
                ok = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.ToString());
            }
            return ok;
        }
        #endregion

        #region   保存模板
        /// <summary>
        /// 保存模板
        /// </summary>
        /// <param name="ITemplate">传入数据接口</param>
        /// <param name="Name">模板名</param>
        /// <returns>返回true表示OK</returns>
        public bool WriteShapeModel(ITemplateShuJu ITemplate)
        {
            bool ok = false;
            HOperatorSet.WriteShapeModel(ITemplate.FindModelID, ITemplate.ModelFilePaht);
            ok = true;
            return ok;
        }
        #endregion

        #region   显示图片
        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="image">传入接口数据</param>
        /// <param name="hwin">窗口句柄</param>
        /// <returns>返回true为OK</returns>
        public bool ShowHoject(HObject image, HWindow hwin)
        {
            bool ok = false;

            hwin.DispObj(image);

            ok = true;
            return ok;
        }

        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="image"></param>
        /// <param name="hwin"></param>
        /// <returns></returns>
        public bool ShowHoject(HObject image, HalControl.HalconWinControl_Draw hwin)
        {
            bool ok = false;

            hwin.HalconWindow1.ClearWindow();
            hwin.HalconWindow1.DispObj(image);
            hwin.Ho_Image = image;

            ok = true;
            return ok;
        }
        #endregion

        #region  清空模板
        /// <summary>
        /// 清空模板
        /// </summary>
        /// <param name="ITemplate">数据接口</param>
        /// <returns></returns>
        public bool clear_model(ITemplateShuJu ITemplate)
        {
            bool ok = false;
            //****清空模板
            HOperatorSet.ClearShapeModel(ITemplate.FindModelID);
            ok = true;
            return ok;
        }
        #endregion

        #region  参数输出
        /// <summary>
        /// 参数输出
        /// </summary>
        /// <param name="ITemplate"></param>
        /// <param name="control"></param>
        /// <param name="halconWinControl_"></param>
        /// <returns></returns>
        public bool Show_parameter_HalconWinControl(ITemplateShuJu ITemplate, Control.ControlCollection control, HalControl.HalconWinControl_ROI halconWinControl_)
        {
            bool ok = false;

            if (halconWinControl_ != null)
            {
                halconWinControl_.DrawRectangle2(ITemplate.IOutSide.Mid_col_x, ITemplate.IOutSide.Mid_row_y, ITemplate.IOutSide.Phi, ITemplate.IOutSide.Len1, ITemplate.IOutSide.Len2, ITemplate.IOutSide);
            }
            output_parameter(ITemplate, control);

            ok = true;
            return ok;
        }

        /// <summary>
        /// 输出模板查找参数
        /// </summary>
        /// <param name="ITemplate"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        bool output_parameter(ITemplateShuJu ITemplate, Control.ControlCollection control)
        {
            bool ok = false;
            try
            {
                //IEnumerator enumerator=control.GetEnumerator();
                //Control con1 = enumerator.Current as Control;        
                //  while (enumerator.MoveNext())

                foreach (Control con in control)
                {
                    string name = con.Name;
                    if ((con is ComboBox) || (con is TextBox) || (con is Label) || (con is NumericUpDown))
                    {
                        switch (name)
                        {
                            #region  find paramter
                            case "numericUpDown_FindAngleStart":

                                double num = ITemplate.FindAngleStart.D;
                                num = num * 180 / Math.PI;
                                //con.Text = ITemplate.FindAngleStart.ToString().Replace("\"", "");
                                con.Text = num.ToString();
                                break;

                            case "numericUpDown_FindAngleExtent":

                                double num1 = ITemplate.FindAngleExtent.D;
                                num1 = num1 * 180 / Math.PI;
                                con.Text = num1.ToString();
                                break;

                            case "numericUpDown_FindMinScore":
                                con.Text = ITemplate.FindMinScore.ToString().Replace("\"", "");
                                break;

                            case "numericUpDown_FindNumMatches":
                                con.Text = ITemplate.FindNumMatches.ToString().Replace("\"", "");
                                break;

                            case "numericUpDown_FindMaxOverlap":
                                con.Text = ITemplate.FindMaxOverlap.ToString().Replace("\"", "");
                                break;
                            case "FindSubPixel":
                                con.Text = ITemplate.FindSubPixel.ToString().Replace("\"", "");

                                break;

                            case "numericUpDown_FindNumLevels":
                                con.Text = ITemplate.FindNumLevels.ToString().Replace("\"", "");
                                break;

                            case "numericUpDown_FindGreediness":
                                con.Text = ITemplate.FindGreediness.ToString().Replace("\"", "");
                                break;
                            #endregion

                            #region   模板的名称
                            case "Label_ModelName":
                                con.Text = ITemplate.ModelName.ToString().Replace("\"", "");
                                break;
                            #endregion

                            #region   创建模板时的数据
                            case "TextBox_Create_ModelName":
                                con.Text = ITemplate.ITemplateCreate.ModelName.ToString().Replace("\"", "");
                                break;

                            case "comboBox_CreateNumLevels":
                                con.Text = ITemplate.ITemplateCreate.CreateNumLevels.ToString().Replace("\"", "");
                                break;

                            case "numericUpDown_CreateAngleStart":
                                double num2 = ITemplate.ITemplateCreate.CreateAngleStart.D;
                                num2 = num2 * 180 / Math.PI;
                                //con.Text = ITemplate.ITemplateCreate.CreateAngleStart.ToString().Replace("\"", "");
                                con.Text = num2.ToString();
                                break;

                            case "numericUpDown_CreateAngleExtent":

                                double num3 = ITemplate.ITemplateCreate.CreateAngleExtent.D;
                                num3 = num3 * 180 / Math.PI;
                                //con.Text = ITemplate.ITemplateCreate.CreateAngleExtent.ToString().Replace("\"", "");
                                con.Text = num3.ToString();
                                break;

                            case "comboBox_CreateAngleStep":

                                string str = ITemplate.ITemplateCreate.CreateAngleStep.ToString().Replace("\"", "");
                                if (str == "auto")
                                {
                                    con.Text = ITemplate.ITemplateCreate.CreateAngleStep.ToString().Replace("\"", "");
                                }
                                else
                                {
                                    double num4 = Convert.ToDouble(str);
                                    num4 = num4 * 180 / Math.PI;
                                    con.Text = num4.ToString();
                                }

                                break;

                            case "comboBox_CreateOptimization":
                                con.Text = ITemplate.ITemplateCreate.CreateOptimization.ToString().Replace("\"", "");
                                break;

                            case "comboBox_CreateMetric":
                                con.Text = ITemplate.ITemplateCreate.CreateMetric.ToString().Replace("\"", "");
                                break;

                            case "numericUpDown_CreateMinContrast":
                                con.Text = ITemplate.ITemplateCreate.CreateMinContrast.ToString().Replace("\"", "");
                                break;
                            #endregion

                            #region  模板提取器数据
                            case "numericUpDown_PrintScreen_R":
                                con.Text = ITemplate.IExtractModel.PrintScreen_R.ToString().Replace("\"", "");
                                break;

                            case "comboBox_Fiter":
                                con.Text = ITemplate.IExtractModel.Fiter.ToString().Replace("\"", "");
                                break;

                            case "numericUpDown_Aplha":
                                con.Text = ITemplate.IExtractModel.Aplha.ToString().Replace("\"", "");
                                break;

                            case "comboBox_Low":
                                con.Text = ITemplate.IExtractModel.Low.ToString().Replace("\"", "");
                                break;

                            case "comboBox_High":
                                con.Text = ITemplate.IExtractModel.High.ToString().Replace("\"", "");
                                break;

                            case "comboBox_Feature":
                                con.Text = ITemplate.IExtractModel.Feature.ToString().Replace("\"", "");
                                break;

                            case "numericUpDown_Min1":
                                con.Text = ITemplate.IExtractModel.Min1.ToString().Replace("\"", "");
                                break;

                            case "numericUpDown_Max1":
                                con.Text = ITemplate.IExtractModel.Max1.ToString().Replace("\"", "");
                                break;

                            case "numericUpDown_Min2":
                                con.Text = ITemplate.IExtractModel.Min2.ToString().Replace("\"", "");
                                break;

                            case "numericUpDown_Max2":
                                con.Text = ITemplate.IExtractModel.Max2.ToString().Replace("\"", "");
                                break;
                            #endregion

                            default:
                                break;
                        }
                    }

                    if (con.Controls.Count > 0)
                    {
                        output_parameter(ITemplate, con.Controls);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.ToString());
            }
            ok = true;
            return ok;
        }
        #endregion

        #region 训练模板
        /// <summary>
        /// 训练模板
        /// </summary>
        /// <param name="ITemplate_"></param>
        /// <returns></returns>
        public bool Set_TemplateCreate(ITemplateShuJu ITemplate_, string TemplateName_)
        {
            bool ok = false;
            HTuple modelID = null;

            if (ITemplate_.IExtractModel.SelectedContours.IsInitialized())
            {
                ITemplate_.ITemplateCreate.ModelName = TemplateName_;

                ITemplate_.ITemplateCreate.CreateContour = ITemplate_.IExtractModel.SelectedContours;

                if (_ITemplateCreate.CreateShapeModeXLD(ITemplate_.ITemplateCreate, out modelID))
                {
                    if (ITemplate_.FindModelID != null)
                    {
                        HOperatorSet.ClearShapeModel(ITemplate_.FindModelID);
                    }
                    ITemplate_.FindModelID = modelID;
                    ITemplate_.ModelName = ITemplate_.ITemplateCreate.ModelName;
                    ok = true;
                }
            }

            return ok;
        }
        #endregion

        #region  刷新定位点
        /// <summary>
        /// 刷新定位点
        /// </summary>
        /// <param name="ITemplate_"></param>
        /// <returns></returns>
        public bool Set_ShuaXinDingWeiDian(ITemplateShuJu ITemplate_)
        {
            bool ok = false;
            if (ITemplate_.IrectShuJuPianYi != null)
            {
                ITemplate_.GenSuiDian_A = ITemplate_.IrectShuJuPianYi.Angle;
                ITemplate_.GenSuiDian_Y_Row = ITemplate_.IrectShuJuPianYi.Row;
                ITemplate_.GeuSuiDian_X_Col = ITemplate_.IrectShuJuPianYi.Column;
            }

            ok = true;
            return ok;

        }
        #endregion

    }
    #endregion

    //#region   数据处理器
    ///// <summary>
    ///// 模板匹配对象，数据处理器
    ///// </summary>
    //public class Template : MultTree.ToolFather
    //{
    //    #region  查找模板
    //    /// <summary>
    //    /// 查找模板
    //    /// </summary>
    //    /// <param name="ITemplate_">数据接口</param>
    //    public void find_mode(ITemplateShuJu ITemplate_, HObject Ho_Image)
    //    {
    //        HTuple hv_Row = null, hv_Column = null, hv_Angle = null, hv_Score1 = null;
    //        HObject ho_ContoursAffinTrans;


    //        /*************截取roi*****************/
    //        HObject ho_Region;
    //        HOperatorSet.GenEmptyObj(out ho_Region);

    //        HOperatorSet.GenRectangle2(out ho_Region, ITemplate_.IOutSide.Mid_row_y, ITemplate_.IOutSide.Mid_col_x, ITemplate_.IOutSide.Phi, ITemplate_.IOutSide.Len1, ITemplate_.IOutSide.Len2);

    //        /**********判断有无定位****************/
    //        if (ITemplate_.IrectShuJuPianYi != null)
    //        {
    //            HTuple hv_homMat2D;
    //            HOperatorSet.VectorAngleToRigid(ITemplate_.GenSuiDian_Y_Row, ITemplate_.GeuSuiDian_X_Col, ITemplate_.GenSuiDian_A, ITemplate_.IrectShuJuPianYi.Row, ITemplate_.IrectShuJuPianYi.Column, ITemplate_.IrectShuJuPianYi.Angle, out hv_homMat2D);
    //            HOperatorSet.AffineTransRegion(ho_Region, out ho_Region, hv_homMat2D, "nearest_neighbor");
    //        }

    //        HOperatorSet.ReduceDomain(Ho_Image, ho_Region, out ho_Region);

    //        find_model(ho_Region, ITemplate_.ModelContours, out ho_ContoursAffinTrans,
    //  ITemplate_.FindModelID, ITemplate_.FindAngleStart, ITemplate_.FindAngleExtent, ITemplate_.FindMinScore,
    //  ITemplate_.FindNumMatches, ITemplate_.FindMaxOverlap, ITemplate_.FindSubPixel, ITemplate_.FindNumLevels,
    //  ITemplate_.FindGreediness, out hv_Row, out hv_Column, out hv_Angle,
    //  out hv_Score1);



    //        HObject ho_cro;
    //        HOperatorSet.GenEmptyObj(out ho_cro);
    //        ho_cro.Dispose();
    //        if (hv_Row.Length >= 1)
    //        {
    //            HOperatorSet.GenCrossContourXld(out ho_cro, hv_Row, hv_Column, 60, hv_Angle);
    //        }
    //        ITemplate_.CenterPointXLD.Dispose();
    //        ITemplate_.CenterPointXLD = ho_cro;

    //        ITemplate_.ContoursAffinTrans.Dispose();
    //        ITemplate_.ContoursAffinTrans = ho_ContoursAffinTrans;

    //        ITemplate_.Score = hv_Score1;
    //        ITemplate_.Angle = hv_Angle;

    //        /****************判断有无标定***********************/
    //        if (ITemplate_._ICalibration != null)
    //        {
    //            this.Cal(ITemplate_._ICalibration.HomMat2D, ref hv_Row, ref hv_Column);
    //        }
    //        else
    //        {
    //            ITemplate_.Row = hv_Row;
    //            ITemplate_.Column = hv_Column;
    //        }

    //        /**********清空缓存*******************/
    //        ho_Region.Dispose();

    //    }

    //    /// <summary>
    //    /// 查找模板
    //    /// </summary>
    //    /// <param name="ho_Image">查找的图片</param>
    //    /// <param name="ho_ModelContours1">模板轮廓</param>
    //    /// <param name="ho_ContoursAffinTrans">装换的轮廓</param>
    //    /// <param name="hv_ModelID1">模板句柄</param>
    //    /// <param name="hv_AngleStar"></param>
    //    /// <param name="hv_AngleExtent"></param>
    //    /// <param name="hv_MinScore"></param>
    //    /// <param name="hv_NumMatches"></param>
    //    /// <param name="hv_MaxOverlap"></param>
    //    /// <param name="hv_SubPixel"></param>
    //    /// <param name="hv_Numlevels"></param>
    //    /// <param name="hv_Greendiness"></param>
    //    /// <param name="hv_Row1"></param>
    //    /// <param name="hv_Column1"></param>
    //    /// <param name="hv_Angle1"></param>
    //    /// <param name="hv_Score1"></param>
    //    void find_model(HObject ho_Image, HObject ho_ModelContours1, out HObject ho_ContoursAffinTrans,
    //HTuple hv_ModelID1, HTuple hv_AngleStar, HTuple hv_AngleExtent, HTuple hv_MinScore,
    //HTuple hv_NumMatches, HTuple hv_MaxOverlap, HTuple hv_SubPixel, HTuple hv_Numlevels,
    //HTuple hv_Greendiness, out HTuple hv_Row1, out HTuple hv_Column1, out HTuple hv_Angle1,
    //out HTuple hv_Score1)
    //    {
    //        #region
    //        //  hv_AngleStar = 0;
    //        //    hv_AngleExtent = (new HTuple(30)).TupleRad();
    //        //    hv_MinScore = 0.5;
    //        //    hv_NumMatches = 1;
    //        //    hv_MaxOverlap = 0.5;
    //        //    hv_SubPixel = "least_squares";
    //        //    hv_Numlevels = 0;
    //        //    hv_Greendiness = 0.9;
    //        #endregion
    //        // Local control variables 

    //        // HTuple hv_Row = null, hv_Column = null, hv_Angle = null;
    //        HTuple hv_HomMat2D = new HTuple();
    //        // Initialize local and output iconic variables 
    //        HOperatorSet.GenEmptyObj(out ho_ContoursAffinTrans);
    //        ho_ContoursAffinTrans.Dispose();
    //        hv_Row1 = new HTuple();
    //        hv_Column1 = new HTuple();
    //        hv_Angle1 = new HTuple();

    //        HOperatorSet.FindShapeModel(ho_Image, hv_ModelID1, hv_AngleStar, hv_AngleExtent,
    //            hv_MinScore, hv_NumMatches, hv_MaxOverlap, hv_SubPixel, hv_Numlevels, hv_Greendiness,
    //            out hv_Row1, out hv_Column1, out hv_Angle1, out hv_Score1);

    //        if ((int)(new HTuple((new HTuple(hv_Row1.TupleLength())).TupleNotEqual(0))) != 0)
    //        {
    //            //作者qq1756192667
    //            int num = hv_Row1.Length;

    //            for (int i = 0; i < num; i++)
    //            {
    //                HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_Row1[i], hv_Column1[i], hv_Angle1[i], out hv_HomMat2D);
    //                ho_ContoursAffinTrans.Dispose();
    //                HOperatorSet.AffineTransContourXld(ho_ModelContours1, out ho_ContoursAffinTrans,
    //                    hv_HomMat2D);
    //            }
    //            //    HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_Row1, hv_Column1, hv_Angle1, out hv_HomMat2D);
    //            //ho_ContoursAffinTrans.Dispose();
    //            //HOperatorSet.AffineTransContourXld(ho_ModelContours1, out ho_ContoursAffinTrans,
    //            //    hv_HomMat2D);
    //            if (HDevWindowStack.IsOpen())
    //            {
    //                //dev_display (Image)
    //            }
    //            if (HDevWindowStack.IsOpen())
    //            {
    //                //dev_display (ContoursAffinTrans)
    //            }
    //            //disp_message (3600, 'XLD轮廓做模板', 'image', 20, 20, 'black', 'true')
    //            //disp_message (3600, '视频和代码请加qq1756192667', 'image', 100, 20, 'black', 'true')
    //        }
    //        else
    //        {

    //        }
    //        return;
    //    }
    //    #endregion

    //    #region  显示
    //    /// <summary>
    //    /// 显示找到的模板
    //    /// </summary>
    //    /// <param name="ITemplate">数据接口</param>
    //    /// <param name="hwin">显示的窗口</param>
    //    public void show_template(ITemplateShuJu ITemplate_, HWindow hwin)
    //    {
    //        if (!ITemplate_.ContoursAffinTrans.IsInitialized())
    //        {
    //            hwin.SetColor("red");
    //            HObject ho_Region1;
    //            HOperatorSet.GenEmptyObj(out ho_Region1);

    //            HOperatorSet.GenRectangle2ContourXld(out ho_Region1, ITemplate_.IOutSide.Mid_row_y, ITemplate_.IOutSide.Mid_col_x, ITemplate_.IOutSide.Phi, ITemplate_.IOutSide.Len1, ITemplate_.IOutSide.Len2);

    //            /**********判断有无定位****************/
    //            if (ITemplate_.IrectShuJuPianYi != null)
    //            {
    //                HTuple hv_homMat2D1;
    //                HOperatorSet.VectorAngleToRigid(ITemplate_.GenSuiDian_Y_Row, ITemplate_.GeuSuiDian_X_Col, ITemplate_.GenSuiDian_A, ITemplate_.IrectShuJuPianYi.Row, ITemplate_.IrectShuJuPianYi.Column, ITemplate_.IrectShuJuPianYi.Angle, out hv_homMat2D1);
    //                HOperatorSet.AffineTransContourXld(ho_Region1, out ho_Region1, hv_homMat2D1);
    //            }
    //            hwin.DispObj(ho_Region1);
    //            hwin.SetColor("green");
    //            return;
    //        }
    //        hwin.DispObj(ITemplate_.ContoursAffinTrans);
    //        hwin.DispObj(ITemplate_.CenterPointXLD);
    //    }
    //    #endregion

    //    #region  数据分析
    //    /// <summary>
    //    /// 数据分析
    //    /// </summary>
    //    /// <param name="Key"></param>
    //    /// <param name="ITemplate"></param>
    //    /// <param name="_dictionary_resulte"></param>
    //    public void Result_Analyisis(ITemplateShuJu ITemplate, ref  Template_Result re)
    //    {
    //        //Template_Result re = new Template_Result();
    //        if (ITemplate.Row.Length > 0)
    //        {
    //            if (ITemplate._ICalibration != null)
    //            {
    //                HTuple hv_Row, hv_Column;
    //                hv_Row = ITemplate.Row;
    //                hv_Column = ITemplate.Column;

    //                this.Cal(ITemplate._ICalibration.HomMat2D, ref hv_Row, ref hv_Column);
    //                ITemplate.Row = hv_Row;
    //                ITemplate.Column = hv_Column;
    //            }

    //            re.TolatResult = true;
    //            re._AllResult = true;
    //            re.Hv_Angle1 = ITemplate.Angle;
    //            re.Hv_Row1 = ITemplate.Row;
    //            re.Hv_Column1 = ITemplate.Column;
    //            re.Hv_Score1 = ITemplate.Score;
    //        }
    //        else
    //        {
    //            re.TolatResult = false;
    //            re._AllResult = false;
    //            re.Hv_Angle1 = 0;
    //            re.Hv_Column1 = 0;
    //            re.Hv_Row1 = 0;
    //            re.Hv_Score1 = 0;
    //        }
    //    }
    //    #endregion

    //    #region   查找 ，显示 ，保存
    //    /// <summary>
    //    ///  查找 ，显示 ，保存
    //    /// </summary>
    //    /// <param name="Ho_Image"></param>
    //    /// <param name="ITemplate_"></param>
    //    /// <param name="hwin"></param>
    //    /// <param name="Key"></param>
    //    /// <param name="_dictionary_resulte"></param>
    //    /// <returns></returns>
    //    public bool Find_Show_Out(HObject Ho_Image, ITemplateShuJu ITemplate_, HWindow hwin, string Key, ref Dictionary<string, Object> _dictionary_resulte)
    //    {
    //        bool ok = false;
    //        /*********************************处理*************************************************/
    //        HTuple hv_Row = null, hv_Column = null, hv_Angle = null, hv_Score1 = null;
    //        HObject ho_ContoursAffinTrans;


    //        /*************截取roi*****************/
    //        HObject ho_Region;
    //        HOperatorSet.GenEmptyObj(out ho_Region);

    //        HOperatorSet.GenRectangle2(out ho_Region, ITemplate_.IOutSide.Mid_row_y, ITemplate_.IOutSide.Mid_col_x, ITemplate_.IOutSide.Phi, ITemplate_.IOutSide.Len1, ITemplate_.IOutSide.Len2);

    //        /**********判断有无定位****************/
    //        if (ITemplate_.IrectShuJuPianYi != null)
    //        {
    //            HTuple hv_homMat2D;
    //            HOperatorSet.VectorAngleToRigid(ITemplate_.GenSuiDian_Y_Row, ITemplate_.GeuSuiDian_X_Col, ITemplate_.GenSuiDian_A, ITemplate_.IrectShuJuPianYi.Row, ITemplate_.IrectShuJuPianYi.Column, ITemplate_.IrectShuJuPianYi.Angle, out hv_homMat2D);
    //            HOperatorSet.AffineTransRegion(ho_Region, out ho_Region, hv_homMat2D, "nearest_neighbor");
    //        }

    //        HOperatorSet.ReduceDomain(Ho_Image, ho_Region, out ho_Region);


    //        find_model(ho_Region, ITemplate_.ModelContours, out ho_ContoursAffinTrans,
    //  ITemplate_.FindModelID, ITemplate_.FindAngleStart, ITemplate_.FindAngleExtent, ITemplate_.FindMinScore,
    //  ITemplate_.FindNumMatches, ITemplate_.FindMaxOverlap, ITemplate_.FindSubPixel, ITemplate_.FindNumLevels,
    //  ITemplate_.FindGreediness, out hv_Row, out hv_Column, out hv_Angle,
    //  out hv_Score1);

    //        /*********清空缓存***************/
    //        ho_Region.Dispose();


    //        HObject ho_cro;
    //        HOperatorSet.GenEmptyObj(out ho_cro);
    //        ho_cro.Dispose();
    //        if (hv_Row.Length >= 1)
    //        {
    //            HOperatorSet.GenCrossContourXld(out ho_cro, hv_Row, hv_Column, 60, hv_Angle);
    //        }
    //        ITemplate_.CenterPointXLD.Dispose();
    //        ITemplate_.CenterPointXLD = ho_cro;

    //        ITemplate_.ContoursAffinTrans.Dispose();
    //        ITemplate_.ContoursAffinTrans = ho_ContoursAffinTrans;
    //        ITemplate_.Score = hv_Score1;
    //        ITemplate_.Angle = hv_Angle;
    //        ITemplate_.Row = hv_Row;
    //        ITemplate_.Column = hv_Column;


    //        /******************分析数据***************************/
    //        Key = "Template_" + Key;
    //        Template_Result _result = new Template_Result();
    //        _result.TolatName = Key;
    //        Result_Analyisis(ITemplate_, ref _result);
    //        _dictionary_resulte.Add(Key, _result);

    //        /**************************************显示****************************************************/
    //        if (_result._AllResult)
    //        {
    //            hwin.DispObj(ITemplate_.ContoursAffinTrans);
    //            hwin.DispObj(ITemplate_.CenterPointXLD);
    //            ok = true;
    //        }
    //        else
    //        {
    //            hwin.SetColor("red");
    //            HObject ho_Region1;
    //            HOperatorSet.GenEmptyObj(out ho_Region1);
    //            HOperatorSet.GenRectangle2ContourXld(out ho_Region1, ITemplate_.IOutSide.Mid_row_y, ITemplate_.IOutSide.Mid_col_x, ITemplate_.IOutSide.Phi, ITemplate_.IOutSide.Len1, ITemplate_.IOutSide.Len2);

    //            /**********判断有无定位****************/
    //            if (ITemplate_.IrectShuJuPianYi != null)
    //            {
    //                HTuple hv_homMat2D1;
    //                HOperatorSet.VectorAngleToRigid(ITemplate_.GenSuiDian_Y_Row, ITemplate_.GeuSuiDian_X_Col, ITemplate_.GenSuiDian_A, ITemplate_.IrectShuJuPianYi.Row, ITemplate_.IrectShuJuPianYi.Column, ITemplate_.IrectShuJuPianYi.Angle, out hv_homMat2D1);
    //                HOperatorSet.AffineTransContourXld(ho_Region1, out ho_Region1, hv_homMat2D1);
    //            }

    //            hwin.DispObj(ho_Region1);

    //            ho_Region1.Dispose();

    //            hwin.SetColor("green");
    //            //hwin.WriteString("没有找到模板");
    //        }

    //        #region  无用代码
    //        //if (ITemplate.ContoursAffinTrans == null)
    //        //{
    //        //    hwin.WriteString("没有找到模板");
    //        //    _result.Hv_Row1 = 0;
    //        //    _result.Hv_Column1 = 0;
    //        //    _result.Hv_Angle1 = 0;
    //        //    _result.Hv_Score1 = 0;
    //        //    _result._tolatResult = true;
    //        //    _dictionary_resulte.Add(Key, _result);

    //        //}
    //        //else
    //        //{
    //        //    hwin.DispObj(ITemplate.ContoursAffinTrans);
    //        //    /**************************************保存*******************************************************/
    //        //    if (ITemplate._ICalibration != null)
    //        //    {
    //        //        _Calibration.Cal(ITemplate._ICalibration.HomMat2D, ref hv_Row, ref hv_Column);
    //        //    }
    //        //    _result.Hv_Row1 = hv_Row;
    //        //    _result.Hv_Column1 = hv_Column;
    //        //    _result.Hv_Angle1 = hv_Angle;
    //        //    _result.Hv_Score1 = hv_Score1;
    //        //    _result._tolatResult = true;
    //        //    _dictionary_resulte.Add(Key, _result);
    //        //    ok = true;
    //        //}
    //        #endregion

    //        return ok;

    //    }
    //    #endregion
    //}

    //#region  无用代码
    /////// <summary>
    /////// 模板匹配对象，数据处理器接口
    /////// </summary>
    ////public interface ITemplate
    ////{
    ////    /// <summary>
    ////    /// 查找模板
    ////    /// </summary>
    ////    void find_mode(ITemplateShuJu ITemplate, HObject Ho_Image);
    ////    /// <summary>
    ////    /// 显示
    ////    /// </summary>
    ////    void show_template(ITemplateShuJu ITemplate, HWindow hwin);

    ////}
    //#endregion

    //#endregion

    #region   结果的类
    /// <summary>
    /// 结果的结构体
    /// </summary>
    public class Template_Result : ClassResultFather
    {
        /// <summary>
        /// 匹配到的模板中心y
        /// </summary>
        public HTuple Hv_Row1 = new HTuple();
        /// <summary>
        /// 匹配到的模板中心x
        /// </summary>
        public HTuple Hv_Column1 = new HTuple();
        /// <summary>
        /// 匹配到的模板中心A
        /// </summary>
        public HTuple Hv_Angle1 = new HTuple();
        /// <summary>
        /// 匹配到的模板中心score
        /// </summary>
        public HTuple Hv_Score1 = new HTuple();
        /// <summary>
        /// 模板工具的总体结果
        /// </summary>
        public bool _AllResult = false;

        /// <summary>
        /// 显示数据结果
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public override bool showResult(out string str)
        {
            bool ok = false;
            str = this.TolatName.ToString() + ":" + "x--" + Hv_Column1.ToString() + "__y--" + Hv_Row1.ToString() + "__a--" + Hv_Angle1.ToString() + "__score--" + Hv_Score1.ToString();
            return ok;
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="str_array"></param>
        /// <returns></returns>
        public override bool showResult(out string[] str_array)
        {
            bool ok = false;

            str_array = new string[6];

            str_array[0] = this.TolatName;
            str_array[1] = this.TolatResult.ToString();
            str_array[2] = "x：" + this.Hv_Column1.ToString();
            str_array[3] = "y：" + this.Hv_Row1.ToString();
            str_array[4] = "a：" + this.Hv_Angle1.ToString();
            str_array[5] = "score：" + this.Hv_Score1.ToString();

            ok = true;
            return ok;
        }

    }
    #endregion

    #region   模板创建
    /// <summary>
    /// 模板创建工具
    /// </summary>
    [Serializable]
    public class TemplateCreate : ITemplateCreateShuJu, ITemplateCreateTool
    {
        #region  全局变量

        #region   创建模板的参数

        #region  创建模板的轮廓
        /// <summary>
        ///  创建模板的轮廓
        /// </summary>
        [NonSerialized]
        HObject createContour = null;
        #endregion

        #region  创建模板的层数
        /// <summary>
        /// 创建模板的层数
        /// </summary>
        [NonSerialized]
        HTuple createNumLevels = null;
        #endregion

        #region  创建的开始角度
        /// <summary>
        /// 创建的开始角度
        /// </summary>
        [NonSerialized]
        HTuple createAngleStart = null;
        #endregion

        #region  创建的结束角度
        /// <summary>
        /// 创建的结束角度
        /// </summary>
        [NonSerialized]
        HTuple createAngleExtent = null;
        #endregion

        #region   创建的步长
        /// <summary>
        ///  创建的步长
        /// </summary>
        [NonSerialized]
        HTuple createAngleStep = null;
        #endregion

        #region   优化的算法
        /// <summary>
        ///  优化的算法
        /// </summary>
        [NonSerialized]
        HTuple createOptimization = null;
        #endregion

        #region   极性
        /// <summary>
        /// 极性
        /// </summary>
        [NonSerialized]
        HTuple createMetric = null;
        #endregion

        #region   最小对比度
        /// <summary>
        ///  最小对比度
        /// </summary>
        [NonSerialized]
        HTuple createMinContrast = null;
        #endregion

        #endregion

        #region  modelName 模板名称
        /// <summary>
        /// 模板名称
        /// </summary>
        string modelName = null;
        #endregion

        #region  保存模板的路径
        /// <summary>
        /// 保存模板的路径
        /// </summary>
        [NonSerialized]
        string createFileName = null;
        #endregion

        #region   创建后输出的指针
        /// <summary>
        /// 创建后输出的指针
        /// </summary>
        [NonSerialized]
        HTuple createModelID = null;
        #endregion

        #endregion

        #region  属性

        #region  创建模板的参数
        /// <summary>
        ///  创建模板的轮廓
        /// </summary>
        public HObject CreateContour
        {
            get { return createContour; }
            set { createContour = value; }
        }

        /// <summary>
        /// 创建模板的层数
        /// </summary>
        public HTuple CreateNumLevels
        {
            get
            {
                if (createNumLevels == null)
                {
                    createNumLevels = "auto";
                }
                return createNumLevels;
            }
            set { createNumLevels = value; }
        }

        /// <summary>
        /// 创建的开始角度
        /// </summary>
        public HTuple CreateAngleStart
        {
            get
            {
                if (createAngleStart == null)
                {
                    createAngleStart = 0;
                }
                return createAngleStart;
            }
            set { createAngleStart = value; }
        }

        /// <summary>
        /// 创建的结束角度
        /// </summary>
        public HTuple CreateAngleExtent
        {
            get
            {
                if (createAngleExtent == null)
                {
                    createAngleExtent = 0.78;
                }
                return createAngleExtent;
            }
            set { createAngleExtent = value; }
        }

        /// <summary>
        ///  创建的步长
        /// </summary>
        public HTuple CreateAngleStep
        {
            get
            {
                if (createAngleStep == null)
                {
                    createAngleStep = "auto";
                }
                return createAngleStep;
            }
            set { createAngleStep = value; }
        }

        /// <summary>
        ///  优化的算法
        /// </summary>
        public HTuple CreateOptimization
        {
            get
            {
                if (createOptimization == null)
                {
                    createOptimization = "auto";
                }
                return createOptimization;
            }
            set { createOptimization = value; }
        }

        /// <summary>
        /// 极性
        /// </summary>
        public HTuple CreateMetric
        {
            get
            {
                if (createMetric == null)
                {
                    createMetric = "ignore_local_polarity";
                }
                return createMetric;
            }
            set { createMetric = value; }
        }

        /// <summary>
        ///  最小对比度
        /// </summary>
        public HTuple CreateMinContrast
        {
            get
            {
                if (createMinContrast == null)
                {
                    createMinContrast = 5;
                }
                return createMinContrast;
            }
            set { createMinContrast = value; }
        }
        #endregion

        #region 保存模板的路径
        /// <summary>
        /// 保存模板的路径
        /// </summary>
        public string CreateFileName
        {
            get
            {
                if (createFileName == null)
                {
                    string str = AppDomain.CurrentDomain.BaseDirectory + @"Model\" + ModelName + ".shm";
                    return str;
                }
                return createFileName;
            }
            set { createFileName = value; }
        }
        #endregion

        #region   模板名称
        /// <summary>
        /// 模板名称
        /// </summary>
        public string ModelName
        {
            get
            {
                if (modelName == null)
                {
                    modelName = "A";
                }
                return modelName;
            }
            set { modelName = value; }
        }
        #endregion

        #region  创建后输出的指针
        /// <summary>
        /// 创建后输出的指针
        /// </summary>
        public HTuple CreateModelID
        {
            get { return createModelID; }
            set { createModelID = value; }
        }
        #endregion

        #endregion

        #region   序列化数据
        #region   创建模板的参数

        #region  创建模板的轮廓
        /// <summary>
        ///  创建模板的轮廓
        /// </summary>
        object createContour_1;
        #endregion

        #region  创建模板的层数
        /// <summary>
        /// 创建模板的层数
        /// </summary>
        object createNumLevels_1;
        #endregion

        #region  创建的开始角度
        /// <summary>
        /// 创建的开始角度
        /// </summary>
        object createAngleStart_1;
        #endregion

        #region  创建的结束角度
        /// <summary>
        /// 创建的结束角度
        /// </summary>
        object createAngleExtent_1;

        #endregion

        #region   创建的步长
        /// <summary>
        ///  创建的步长
        /// </summary>
        object createAngleStep_1;

        #endregion

        #region   优化的算法
        /// <summary>
        ///  优化的算法
        /// </summary>
        object createOptimization_1;

        #endregion

        #region   极性
        /// <summary>
        /// 极性
        /// </summary>
        object createMetric_1;
        #endregion

        #region   最小对比度
        /// <summary>
        ///  最小对比度
        /// </summary>
        object createMinContrast_1;
        #endregion
        #endregion

        #endregion

        #region   初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <returns></returns>
        public bool init()
        {
            bool ok = false;

            #region   创建模板的参数

            #region  创建模板的轮廓
            //HOperatorSet.GenEmptyObj(out createContour);
            //createContour.Dispose();
            CreateContour = (HObject)createContour_1;
            #endregion

            #region  创建模板的层数
            CreateNumLevels = (HTuple)createNumLevels_1;
            #endregion

            #region  创建的开始角度
            CreateAngleStart = (HTuple)createAngleStart_1;
            #endregion

            #region  创建的结束角度
            CreateAngleExtent = (HTuple)createAngleExtent_1;
            #endregion

            #region   创建的步长
            CreateAngleStep = (HTuple)createAngleStep_1;
            #endregion

            #region   优化的算法
            CreateOptimization = (HTuple)createOptimization_1;
            #endregion

            #region   极性
            CreateMetric = (HTuple)createMetric_1;
            #endregion

            #region   最小对比度
            CreateMinContrast = (HTuple)createMinContrast_1;
            #endregion

            #endregion

            ok = true;
            return ok;
        }
        #endregion

        #region  保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        public bool save()
        {
            bool ok = false;

            #region   创建模板的参数

            #region  创建模板的轮廓
            createContour_1 = CreateContour;
            #endregion

            #region  创建模板的层数
            createNumLevels_1 = CreateNumLevels;
            #endregion

            #region  创建的开始角度
            createAngleStart_1 = CreateAngleStart;
            #endregion

            #region  创建的结束角度
            createAngleExtent_1 = CreateAngleExtent;
            #endregion

            #region   创建的步长
            createAngleStep_1 = CreateAngleStep;
            #endregion

            #region   优化的算法
            createOptimization_1 = CreateOptimization;
            #endregion

            #region   极性
            createMetric_1 = CreateMetric;
            #endregion

            #region   最小对比度
            createMinContrast_1 = CreateMinContrast;
            #endregion

            #endregion

            ok = true;
            return ok;
        }
        #endregion

        #region  构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public TemplateCreate()
        {
            HOperatorSet.GenEmptyObj(out createContour);
            createContour.Dispose();
        }
        #endregion

        #region   创建模板
        /// <summary>
        /// 创建模板
        /// </summary>
        /// <returns></returns>
        public bool CreateShapeModeXLD(ITemplateCreateShuJu ITemplateCreate, out HTuple ModelID)
        {
            bool ok = false;

            if (!ITemplateCreate.CreateContour.IsInitialized())
            {
                MessageBox.Show("没有创建的模板轮廓，创建失败");
                ModelID = null;
                return false;
            }

            HTuple createModelID = null;

            HOperatorSet.CreateShapeModelXld(ITemplateCreate.CreateContour, ITemplateCreate.CreateNumLevels, ITemplateCreate.CreateAngleStart, ITemplateCreate.CreateAngleExtent,
           ITemplateCreate.CreateAngleStep, ITemplateCreate.CreateOptimization, ITemplateCreate.CreateMetric, ITemplateCreate.CreateMinContrast, out createModelID);
            ModelID = createModelID;

            ok = true;
            return ok;
        }

        #region  无用代码
        //    void CreateShapeModeXLD(HObject ho_Contour, HTuple hv_NumLevels, HTuple hv_AngleStart,
        //HTuple hv_AngleExtent, HTuple hv_AngleStep, HTuple hv_Optimization, HTuple hv_Metric,
        //HTuple hv_MinContrast, out HTuple hv_ModelID)
        //    {
        //        // Initialize local and output iconic variables 

        //        HOperatorSet.CreateShapeModelXld(ho_Contour, hv_NumLevels, hv_AngleStart, hv_AngleExtent,
        //            hv_AngleStep, hv_Optimization, hv_Metric, hv_MinContrast, out hv_ModelID);
        //        return;
        //    }
        #endregion

        #endregion

        #region   写入模板
        /// <summary>
        /// 保存模板
        /// </summary>
        /// <param name="path1"></param>
        /// <returns></returns>
        public bool WriteShapeModel(HTuple CreateModelID, string path1)
        {
            bool ok = false;
            if (CreateModelID == null)
            {
                MessageBox.Show("模板指针是空的，保存失败");
                return false;
            }
            HOperatorSet.WriteShapeModel(CreateModelID, path1);
            ok = true;
            return ok;
        }
        #endregion

        #region  设置参数
        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="ITemplate"></param>
        /// <param name="Create_ModelName"></param>
        /// <param name="CreateNumLevels"></param>
        /// <param name="CreateAngleStart"></param>
        /// <param name="CreateAngleExtent"></param>
        /// <param name="CreateAngleStep"></param>
        /// <param name="CreateOptimization"></param>
        /// <param name="CreateMetric"></param>
        /// <param name="CreateMinContrast"></param>
        /// <returns></returns>
        public bool Set_TemplateCreate(ITemplateCreateShuJu ITemplate, string Create_ModelName, string CreateNumLevels, string CreateAngleStart, string CreateAngleExtent, string CreateAngleStep, string CreateOptimization, string CreateMetric, string CreateMinContrast)
        {
            bool ok = false;
            if (Create_ModelName != null)
            {
                ITemplate.ModelName = Create_ModelName;
            }

            if (CreateNumLevels != null)
            {
                if (CreateNumLevels == "auto")
                {
                    ITemplate.CreateNumLevels = CreateNumLevels;
                }
                else
                {
                    double num = Convert.ToDouble(CreateNumLevels);


                    ITemplate.CreateNumLevels = num;
                }
            }

            if (CreateAngleStart != null)
            {
                double num = Convert.ToDouble(CreateAngleStart);
                num = (Math.PI / 180) * num;
                ITemplate.CreateAngleStart = num;
            }

            if (CreateAngleExtent != null)
            {
                double num = Convert.ToDouble(CreateAngleExtent);
                num = (Math.PI / 180) * num;
                ITemplate.CreateAngleExtent = num;
            }

            if (CreateAngleStep != null)
            {
                if (CreateAngleStep == "auto")
                {
                    ITemplate.CreateAngleStep = CreateAngleStep;
                }
                else
                {
                    double num = Convert.ToDouble(CreateAngleStep);
                    num = (Math.PI / 180) * num;
                    ITemplate.CreateAngleStep = num;
                }
            }

            if (CreateOptimization != null)
            {
                ITemplate.CreateOptimization = CreateOptimization;
            }

            if (CreateMetric != null)
            {
                ITemplate.CreateMetric = CreateMetric;
            }

            if (CreateMinContrast != null)
            {
                double num = Convert.ToDouble(CreateMinContrast);
                ITemplate.CreateMinContrast = num;
            }
            ok = true;
            return ok;

        }
        #endregion
    }

    /// <summary>
    /// 模板创建工具数据接口数据
    /// </summary>
    public interface ITemplateCreateShuJu
    {
        #region  创建模板的参数
        /// <summary>
        ///  创建模板的轮廓
        /// </summary>
        HObject CreateContour
        {
            get;
            set;
        }

        /// <summary>
        /// 创建模板的层数
        /// </summary>
        HTuple CreateNumLevels
        {
            get
            ;
            set;
        }

        /// <summary>
        /// 创建的开始角度
        /// </summary>
        HTuple CreateAngleStart
        {
            get
          ;
            set;
        }

        /// <summary>
        /// 创建的结束角度
        /// </summary>
        HTuple CreateAngleExtent
        {
            get
          ;
            set;
        }

        /// <summary>
        ///  创建的步长
        /// </summary>
        HTuple CreateAngleStep
        {
            get
           ;
            set;
        }

        /// <summary>
        ///  优化的算法
        /// </summary>
        HTuple CreateOptimization
        {
            get
           ;
            set;
        }

        /// <summary>
        /// 极性
        /// </summary>
        HTuple CreateMetric
        {
            get
          ;
            set;
        }

        /// <summary>
        ///  最小对比度
        /// </summary>
        HTuple CreateMinContrast
        {
            get
          ;
            set;
        }
        #endregion

        #region   模板名称
        /// <summary>
        /// 模板名称
        /// </summary>
        string ModelName
        {
            get
            ;
            set;
        }
        #endregion

        #region  初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <returns></returns>
        bool init();
        #endregion

        #region  保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        bool save();
        #endregion

    }

    /// <summary>
    /// 模板创建工具数据工具
    /// </summary>
    public interface ITemplateCreateTool
    {
        /// <summary>
        /// 创建模板
        /// </summary>
        /// <returns></returns>
        bool CreateShapeModeXLD(ITemplateCreateShuJu ITemplateCreate, out HTuple ModelID);

        /// <summary>
        /// 保存模板
        /// </summary>
        /// <param name="path1"></param>
        /// <returns></returns>
        bool WriteShapeModel(HTuple CreateModelID, string path1);

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="ITemplate"></param>
        /// <param name="Create_ModelName"></param>
        /// <param name="CreateNumLevels"></param>
        /// <param name="CreateAngleStart"></param>
        /// <param name="CreateAngleExtent"></param>
        /// <param name="CreateAngleStep"></param>
        /// <param name="CreateOptimization"></param>
        /// <param name="CreateMetric"></param>
        /// <param name="CreateMinContrast"></param>
        /// <returns></returns>
        bool Set_TemplateCreate(ITemplateCreateShuJu ITemplate, string Create_ModelName, string CreateNumLevels, string CreateAngleStart, string CreateAngleExtent, string CreateAngleStep, string CreateOptimization, string CreateMetric, string CreateMinContrast);
    }
    #endregion

    #region  模板提取器
    /// <summary>
    /// 模板提取器
    /// </summary>
    [Serializable]
    public class ExtractModel : IExtractModelShuJu, IExtractModelTool
    {
        #region 全局变量

        #region   printscreen画笔大小
        /// <summary>
        ///  printscreen画笔大小
        /// </summary>
        [NonSerialized]
        HTuple printScreen_R = null;
        #endregion

        #region   截取的region集合
        /// <summary>
        /// 截取的region集合
        /// </summary>
        [NonSerialized]
        List<HObject> printScreenRegion = null;
        #endregion

        #region  截取到region后region合成的集合
        /// <summary>
        ///  截取到region后region合成的集合
        /// </summary>
        [NonSerialized]
        HObject printScreenRegionUnion = null;
        #endregion

        #region  截取到region后region合成的集合XLD
        /// <summary>
        ///  截取到region后region合成的集合XLD
        /// </summary>
        [NonSerialized]
        HObject printScreenRegionXLD = null;
        #endregion

        #region    截取到region后的图片
        /// <summary>
        /// 截取到region后的图片
        /// </summary>
        [NonSerialized]
        HObject printScreenImage = null;
        #endregion

        #region    edges_sub_pix 参数
        /// <summary>
        /// edges_sub_pix 算法
        /// </summary>
        [NonSerialized]
        HTuple fiter = null;

        /// <summary>
        /// edges_sub_pix 因子
        /// </summary>
        [NonSerialized]
        HTuple aplha = null;

        /// <summary>
        ///  edges_sub_pix 最低
        /// </summary>
        [NonSerialized]
        HTuple low = null;

        /// <summary>
        ///  edges_sub_pix 最高
        /// </summary>
        [NonSerialized]
        HTuple high = null;

        #endregion

        #region   筛选xld的参数
        /// <summary>
        /// 筛选xld的特征
        /// </summary>
        [NonSerialized]
        HTuple feature = null;

        /// <summary>
        /// 第一个特征的最小值
        /// </summary>
        [NonSerialized]
        HTuple min1 = null;

        /// <summary>
        /// 第一个特征的最大值
        /// </summary>
        [NonSerialized]
        HTuple max1 = null;

        /// <summary>
        /// 第二个特征的最小值
        /// </summary>
        [NonSerialized]
        HTuple min2 = null;

        /// <summary>
        /// 第二个特征的最大值
        /// </summary>
        [NonSerialized]
        HTuple max2 = null;

        /// <summary>
        /// 筛选输出的轮廓
        /// </summary>
        [NonSerialized]
        HObject selectedContours = null;
        #endregion

        #region  输出的xld
        /// <summary>
        /// 输出的xld
        /// </summary>
        [NonSerialized]
        HObject edges = null;
        #endregion

        #endregion

        #region   序列化数据

        #region   printscreen画笔大小
        /// <summary>
        ///  printscreen画笔大小
        /// </summary>
        object printScreen_R_1;
        #endregion

        #region  截取到region后region合成的集合
        /// <summary>
        ///  截取到region后region合成的集合
        /// </summary>
        object printScreenRegionUnion_1;
        #endregion

        #region  截取到region后region合成的集合XLD
        /// <summary>
        ///  截取到region后region合成的集合XLD
        /// </summary>
        object printScreenRegionXLD_1;
        #endregion

        #region    截取到region后的图片
        /// <summary>
        /// 截取到region后的图片
        /// </summary>
        object printScreenImage_1;
        #endregion

        #region    edges_sub_pix 参数
        /// <summary>
        /// edges_sub_pix 算法
        /// </summary>
        object fiter_1;

        /// <summary>
        /// edges_sub_pix 因子
        /// </summary>
        object aplha_1;

        /// <summary>
        ///  edges_sub_pix 最低
        /// </summary>
        object low_1;

        /// <summary>
        ///  edges_sub_pix 最高
        /// </summary>
        object high_1;

        #endregion

        #region   筛选xld的参数
        /// <summary>
        /// 筛选xld的特征
        /// </summary>
        object feature_1;

        /// <summary>
        /// 第一个特征的最小值
        /// </summary>
        object min1_1;

        /// <summary>
        /// 第一个特征的最大值
        /// </summary>
        object max1_1;

        /// <summary>
        /// 第二个特征的最小值
        /// </summary>
        object min2_1;

        /// <summary>
        /// 第二个特征的最大值
        /// </summary>
        object max2_1;

        /// <summary>
        /// 筛选输出的轮廓
        /// </summary>
        object selectedContours_1;
        #endregion

        #region  输出的xld
        /// <summary>
        /// 输出的xld
        /// </summary>
        object edges_1;
        #endregion

        #endregion

        #region  属性

        #region  edges_sub_pix 参数
        /// <summary>
        /// edges_sub_pix 算法
        /// </summary>
        public HTuple Fiter
        {
            get
            {
                if (fiter == null)
                {
                    fiter = "canny";
                }
                return fiter;
            }
            set { fiter = value; }
        }

        /// <summary>
        /// edges_sub_pix 因子
        /// </summary>
        public HTuple Aplha
        {
            get
            {
                if (aplha == null)
                {
                    aplha = 1;
                }
                return aplha;
            }
            set { aplha = value; }
        }

        /// <summary>
        ///  edges_sub_pix 最低
        /// </summary>
        public HTuple Low
        {
            get
            {
                if (low == null)
                {
                    low = 20;
                }
                return low;
            }
            set { low = value; }
        }

        /// <summary>
        ///  edges_sub_pix 最高
        /// </summary>
        public HTuple High
        {
            get
            {
                if (high == null)
                {
                    high = 40;
                }
                return high;
            }
            set { high = value; }
        }
        #endregion

        #region  输出的xld
        /// <summary>
        /// 输出的xld
        /// </summary>
        public HObject Edges
        {
            get
            {
                if (edges == null)
                {
                    HOperatorSet.GenEmptyObj(out edges);
                    edges.Dispose();
                }
                return edges;
            }
            set { edges = value; }
        }
        #endregion

        #region  筛选xld的参数
        /// <summary>
        /// 筛选xld的特征
        /// </summary>
        public HTuple Feature
        {
            get
            {
                if (feature == null)
                {
                    feature = "contour_length";
                }
                return feature;
            }
            set { feature = value; }
        }

        /// <summary>
        /// 第一个特征的最小值
        /// </summary>
        public HTuple Min1
        {
            get
            {
                if (min1 == null)
                {
                    min1 = 0.5;
                }
                return min1;
            }
            set { min1 = value; }
        }

        /// <summary>
        /// 第一个特征的最大值
        /// </summary>
        public HTuple Max1
        {
            get
            {
                if (max1 == null)
                {
                    max1 = 200;
                }
                return max1;
            }
            set { max1 = value; }
        }

        /// <summary>
        /// 第二个特征的最小值
        /// </summary>
        public HTuple Min2
        {
            get
            {
                if (min2 == null)
                {
                    min2 = -0.5;
                }
                return min2;
            }
            set { min2 = value; }
        }

        /// <summary>
        /// 第二个特征的最大值
        /// </summary>
        public HTuple Max2
        {
            get
            {
                if (max2 == null)
                {
                    max2 = 0.5;
                }
                return max2;
            }
            set { max2 = value; }
        }

        /// <summary>
        /// 筛选输出的轮廓
        /// </summary>
        public HObject SelectedContours
        {
            get
            {
                if (selectedContours == null)
                {
                    HOperatorSet.GenEmptyObj(out selectedContours);
                    selectedContours.Dispose();
                }
                return selectedContours;
            }
            set { selectedContours = value; }
        }

        #endregion

        #region 截取的region集合
        /// <summary>
        /// 截取的region集合
        /// </summary>
        public List<HObject> PrintScreenRegion
        {
            get
            {
                if (printScreenRegion == null)
                {
                    printScreenRegion = new List<HObject>();
                }
                return printScreenRegion;
            }
            set { printScreenRegion = value; }
        }
        #endregion

        #region   printscreen画笔大小
        /// <summary>
        ///  printscreen画笔大小
        /// </summary>
        public HTuple PrintScreen_R
        {
            get
            {
                if (printScreen_R == null)
                {
                    printScreen_R = 20;
                }
                return printScreen_R;
            }
            set { printScreen_R = value; }
        }
        #endregion

        #region  截取到region后截取到的region
        /// <summary>
        /// 截取到region后截取到的region
        /// </summary>
        public HObject PrintScreenRegionUnion
        {
            get
            {
                if (printScreenRegionUnion == null)
                {
                    HOperatorSet.GenEmptyObj(out printScreenRegionUnion);
                    printScreenRegionUnion.Dispose();
                }
                return printScreenRegionUnion;
            }
            set { printScreenRegionUnion = value; }
        }
        #endregion

        #region   截取到region后的图片
        /// <summary>
        /// 截取到region后的图片
        /// </summary>
        public HObject PrintScreenImage
        {
            get
            {
                if (printScreenImage == null)
                {
                    HOperatorSet.GenEmptyObj(out printScreenImage);
                    printScreenImage.Dispose();
                }
                return printScreenImage;
            }
            set { printScreenImage = value; }
        }
        #endregion

        #region   截取到region后region合成的集合XLD
        /// <summary>
        ///  截取到region后region合成的集合XLD
        /// </summary>
        public HObject PrintScreenRegionXLD
        {
            get
            {
                if (printScreenRegionXLD == null)
                {
                    HOperatorSet.GenEmptyObj(out printScreenRegionXLD);
                    printScreenRegionXLD.Dispose();
                }
                return printScreenRegionXLD;
            }
            set { printScreenRegionXLD = value; }
        }
        #endregion

        #endregion

        #region    初始化序列数据
        /// <summary>
        ///  初始化序列数据
        /// </summary>
        /// <returns></returns>
        public bool init()
        {
            bool ok = false;

            #region   printscreen画笔大小
            PrintScreen_R = (HTuple)printScreen_R_1;
            #endregion

            #region  截取到region后region合成的集合
            //HOperatorSet.GenEmptyObj(out printScreenRegionUnion);
            //printScreenRegionUnion.Dispose();
            PrintScreenRegionUnion = (HObject)printScreenRegionUnion_1;
            #endregion

            #region  截取到region后region合成的集合XLD
            //HOperatorSet.GenEmptyObj(out printScreenRegionXLD);
            //printScreenRegionXLD.Dispose();
            PrintScreenRegionXLD = (HObject)printScreenRegionXLD_1;

            PrintScreenRegion.Add(printScreenRegionXLD);
            #endregion

            #region    截取到region后的图片
            //HOperatorSet.GenEmptyObj(out printScreenImage);
            //printScreenImage.Dispose();
            PrintScreenImage = (HObject)printScreenImage_1;
            #endregion

            #region    edges_sub_pix 参数

            Fiter = (HTuple)fiter_1;


            Aplha = (HTuple)aplha_1;

            Low = (HTuple)low_1;

            High = (HTuple)high_1;

            #endregion

            #region   筛选xld的参数
            Feature = (HTuple)feature_1;

            Min1 = (HTuple)min1_1;

            Max1 = (HTuple)max1_1;

            Min2 = (HTuple)min2_1;

            Max2 = (HTuple)max2_1;

            //HOperatorSet.GenEmptyObj(out selectedContours);
            //selectedContours.Dispose();

            SelectedContours = (HObject)selectedContours_1;
            #endregion

            ok = true;
            return ok;
        }
        #endregion

        #region   保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        public bool save()
        {
            bool ok = false;

            #region   printscreen画笔大小
            printScreen_R_1 = PrintScreen_R;
            #endregion

            #region  截取到region后region合成的集合

            printScreenRegionUnion_1 = PrintScreenRegionUnion;
            #endregion

            #region  截取到region后region合成的集合XLD

            printScreenRegionXLD_1 = PrintScreenRegionXLD;
            #endregion

            #region    截取到region后的图片

            printScreenImage_1 = PrintScreenImage;
            #endregion

            #region    edges_sub_pix 参数

            fiter_1 = Fiter;


            aplha_1 = Aplha;

            low_1 = Low;

            high_1 = High;

            #endregion

            #region   筛选xld的参数
            feature_1 = Feature;

            min1_1 = Min1;

            max1_1 = Max1;

            min2_1 = Min2;

            max2_1 = Max2;

            selectedContours_1 = SelectedContours;
            #endregion

            ok = true;
            return ok;
        }
        #endregion

        #region  edges_sub_pix
        /// <summary>
        /// edges_sub_pix
        /// </summary>
        /// <returns></returns>
        bool EdgesSubPix(HObject Ho_Image, IExtractModelShuJu IExtract)
        {
            bool ok = false;

            HObject edges1;
            HOperatorSet.GenEmptyObj(out edges1);

            if (Ho_Image.IsInitialized())
            {
                HOperatorSet.EdgesSubPix(Ho_Image, out edges1, IExtract.Fiter, IExtract.Aplha, IExtract.Low, IExtract.High);
                IExtract.Edges.Dispose();
                IExtract.Edges = edges1;
                ok = true;
            }
            else
            {
                MessageBox.Show("还没有画取训练区域");
            }

            return ok;
        }

        /// <summary>
        /// edges_sub_pix
        /// </summary>
        /// <param name="Ho_Image"></param>
        /// <param name="hwin"></param>
        /// <param name="IExtract"></param>
        /// <returns></returns>
        public bool EdgesSubPix(HWindow hwin, IExtractModelShuJu IExtract)
        {
            bool ok = false;

            if (EdgesSubPix(IExtract.PrintScreenImage, IExtract))
            {

                hwin.DispObj(IExtract.Edges);
                ok = true;
            }

            return ok;
        }
        #endregion

        #region   筛选xld
        /// <summary>
        /// 筛选xld
        /// </summary>
        /// <returns></returns>
        public bool SelectXLD(HObject ho_Image, HWindow hv_WindowHandle, IExtractModelShuJu IExtract)
        {
            bool ok = false;

            if (ho_Image != null)
            {
                hv_WindowHandle.ClearWindow();
                hv_WindowHandle.DispObj(ho_Image);
            }

            HObject selectcontours;
            HOperatorSet.GenEmptyObj(out selectcontours);
            if (IExtract.Edges.IsInitialized())
            {
                HOperatorSet.SelectContoursXld(IExtract.Edges, out selectcontours, IExtract.Feature, IExtract.Min1, IExtract.Max1, IExtract.Min2, IExtract.Max2);

                IExtract.SelectedContours.Dispose();
                IExtract.SelectedContours = selectcontours;
                hv_WindowHandle.DispObj(selectcontours);

                ok = true;
            }
            return ok;
        }
        #endregion

        #region   截图工具
        /// <summary>
        ///   截图工具
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <param name="hv_WindowHandle"></param>
        /// <returns></returns>
        public bool PrintScreenTool(HObject ho_Image, HWindow hv_WindowHandle, IExtractModelShuJu IExtract)
        {
            bool ok = false;
            printscreen(ho_Image, hv_WindowHandle, IExtract);
            ok = true;
            return ok;
        }

        #region    截图
        // Local procedures 
        void printscreen(HObject ho_Image, HWindow hv_WindowHandle, IExtractModelShuJu IExtract)
        {

            HSystem sys = new HSystem();

            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_EmptyRegion, ho_Circle = null, ho_RegionBorder = null;

            // Local control variables 

            HTuple hv_Width = null, hv_Height = null;

            HTuple hv_Button;
            HTuple hv_Row, hv_Column;
            HTuple hv_Number = new HTuple();

            // Initialize local and output iconic variables 
            //HOperatorSet.GenEmptyObj(out printscreenregion);
            //HOperatorSet.GenEmptyObj(out ho_ImageReduced1);
            HOperatorSet.GenEmptyObj(out ho_EmptyRegion);


            HOperatorSet.GenEmptyObj(out ho_Circle);
            HOperatorSet.GenEmptyObj(out ho_RegionBorder);
            try
            {

                if (HDevWindowStack.IsOpen())
                {
                    HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
                }

                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);

                //****接取图片
                ho_EmptyRegion.Dispose();
                HOperatorSet.GenEmptyRegion(out ho_EmptyRegion);

                //**鼠标返回赋值
                hv_Button = 0;
                //**循环直到鼠标点击右键结束
                while ((int)(new HTuple(hv_Button.TupleNotEqual(4))) != 0)
                {
                    //**对鼠标位置的坐标赋初值=1
                    hv_Row = 1;
                    hv_Column = -1;
                    //**设置算子错误的处理方式  忽略错误 默认的是调出异常
                    // (dev_)set_check ("~give_error")
                    //**获得鼠标位置和状态
                    try
                    {
                        HOperatorSet.GetMposition((HTuple)hv_WindowHandle, out hv_Row, out hv_Column, out hv_Button);
                        // hv_WindowHandle.GetMposition(out hv_Row, out hv_Column, out hv_Button);
                    }
                    catch (HalconException e)
                    {
                        int error = e.GetErrorCode();
                        if (error < 0)
                            throw e;
                    }
                    //**设置算子错误的处理方式-- 诺错误调出异常
                    // (dev_)set_check ("~give_error")
                    //**关闭窗口刷新操作
                    try
                    {
                        HOperatorSet.SetSystem("flush_graphic", "false");
                    }
                    catch (HalconException e)
                    {
                        int error = e.GetErrorCode();
                        if (error < 0)
                            throw e;
                    }

                    hv_WindowHandle.DispObj(ho_Image);

                    //**设置文本光标位置
                    try
                    {
                        // HOperatorSet.SetTposition(hv_WindowHandle, hv_Height, 4);
                        hv_WindowHandle.SetTposition((int)hv_Height / 6, 4);
                    }
                    catch (HalconException e)
                    {
                        int error = e.GetErrorCode();
                        if (error < 0)
                            throw e;
                    }
                    //***检测鼠标是否移植窗口里面
                    if ((int)((new HTuple(hv_Row.TupleGreaterEqual(0))).TupleAnd(new HTuple(hv_Column.TupleGreaterEqual(
                        0)))) != 0)
                    {
                        //***以鼠标为圆心画圆
                        try
                        {
                            ho_Circle.Dispose();
                            HOperatorSet.GenCircle(out ho_Circle, hv_Row, hv_Column, IExtract.PrintScreen_R);


                        }
                        catch (HalconException e)
                        {
                            int error = e.GetErrorCode();
                            if (error < 0)
                                throw e;
                        }

                        //**打开最新操作
                        try
                        {
                            HOperatorSet.SetSystem("flush_graphic", "true");
                        }
                        catch (HalconException e)
                        {
                            int error = e.GetErrorCode();
                            if (error < 0)
                                throw e;
                        }
                        //***屏幕打印文本 按下鼠标左键执行滤波算子操作 右键退出
                        try
                        {
                            //HOperatorSet.WriteString(hv_WindowHandle, "按下鼠标左键执行截图，右键退出");

                            hv_WindowHandle.WriteString("按下鼠标左键执行截图，右键退出");
                        }
                        catch (HalconException e)
                        {
                            int error = e.GetErrorCode();
                            if (error < 0)
                                throw e;
                        }
                        //**如果为鼠标左键
                        if ((int)(new HTuple(hv_Button.TupleEqual(1))) != 0)
                        {
                            //**合拼图片
                            try
                            {
                                {
                                    HObject ExpTmpOutVar_0;
                                    HOperatorSet.Union2(ho_EmptyRegion, ho_Circle, out ExpTmpOutVar_0);
                                    ho_EmptyRegion.Dispose();
                                    ho_EmptyRegion = ExpTmpOutVar_0;
                                }
                            }
                            catch (HalconException e)
                            {
                                int error = e.GetErrorCode();
                                if (error < 0)
                                    throw e;
                            }
                        }
                        //**求取region个数
                        try
                        {
                            HOperatorSet.CountObj(ho_EmptyRegion, out hv_Number);
                        }
                        catch (HalconException e)
                        {
                            int error = e.GetErrorCode();
                            if (error < 0)
                                throw e;
                        }
                        //**大于零显示边界
                        if ((int)(new HTuple(hv_Number.TupleGreater(0))) != 0)
                        {
                            try
                            {
                                ho_RegionBorder.Dispose();
                                HOperatorSet.Boundary(ho_EmptyRegion, out ho_RegionBorder, "inner");
                            }
                            catch (HalconException e)
                            {
                                int error = e.GetErrorCode();
                                if (error < 0) ;
                            }

                            //if (IExtract.PrintScreenRegionXLD == null)
                            //{
                            //    hv_WindowHandle.DispObj(IExtract.PrintScreenRegionXLD);
                            //}

                            hv_WindowHandle.DispObj(ho_RegionBorder);
                        }
                    }
                    else
                    {
                        //**如果鼠标在窗口外
                        //**打开刷新操作
                        try
                        {
                            HOperatorSet.SetSystem("flush", "true");
                        }
                        catch (HalconException e)
                        {
                            int error = e.GetErrorCode();
                            if (error < 0)
                                throw e;
                        }
                        //**屏幕打印文件 请把鼠标光标放在窗口内
                        try
                        {
                            // HOperatorSet.WriteString(hv_WindowHandle, "请把鼠标光标放在窗口内");

                            hv_WindowHandle.WriteString("请把鼠标光标放在窗口内");
                        }
                        catch (HalconException e)
                        {
                            int error = e.GetErrorCode();
                            if (error < 0)
                                throw e;
                        }
                    }
                }
                hv_WindowHandle.ClearWindow();
                try
                {
                    HObject ho_union;
                    HOperatorSet.GenEmptyObj(out ho_union);

                    IExtract.PrintScreenRegion.Add(ho_EmptyRegion);


                    foreach (HObject ho in IExtract.PrintScreenRegion)
                    {
                        HOperatorSet.Union2(ho, ho_union, out ho_union);
                    }

                    HObject imageReduced;
                    HOperatorSet.GenEmptyObj(out imageReduced);
                    HOperatorSet.ReduceDomain(ho_Image, ho_union, out imageReduced);

                    IExtract.PrintScreenRegionUnion.Dispose();
                    IExtract.PrintScreenRegionUnion = ho_union;
                    IExtract.PrintScreenImage = imageReduced;

                    HObject contour;
                    HOperatorSet.GenEmptyObj(out contour);

                    HOperatorSet.Boundary(ho_union, out contour, "inner");

                    IExtract.PrintScreenRegionXLD.Dispose();
                    IExtract.PrintScreenRegionXLD = contour;

                    hv_WindowHandle.DispObj(IExtract.PrintScreenImage);

                    #region   无用代码
                    //printscreenregion.Dispose();
                    //printscreenregion = ho_EmptyRegion;

                    //ho_ImageReduced1.Dispose();
                    //HOperatorSet.ReduceDomain(ho_Image, ho_EmptyRegion, out ho_ImageReduced1);
                    #endregion
                }
                catch (HalconException e)
                {
                    int error = e.GetErrorCode();
                    if (error < 0)
                        throw e;
                }

                #region  无用代码
                //**显示图像
                //if (HDevWindowStack.IsOpen())
                //{
                //    //  HOperatorSet.DispObj(ho_ImageReduced1, HDevWindowStack.GetActive());

                //    hv_WindowHandle.DispObj(ho_ImageReduced1);
                //}
                #endregion

                // ho_EmptyRegion.Dispose();
                ho_Circle.Dispose();
                ho_RegionBorder.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_EmptyRegion.Dispose();
                ho_Circle.Dispose();
                ho_RegionBorder.Dispose();
                throw HDevExpDefaultException;
            }
        }
        #endregion
        #endregion

        #region  提取模板的xld
        /// <summary>
        /// 提取模板的xld
        /// </summary>
        /// <returns></returns>
        public bool ExtractModelXLD(HObject ho_Image, HWindow hv_WindowHandle, IExtractModelShuJu IExtract)
        {
            bool ok = false;

            if (ho_Image != null)
            {
                hv_WindowHandle.ClearWindow();
                hv_WindowHandle.DispObj(ho_Image);
            }

            EdgesSubPix(IExtract.PrintScreenImage, IExtract);

            SelectXLD(ho_Image, hv_WindowHandle, IExtract);
            //hv_WindowHandle.DispObj(IExtract.Edges);
            ok = true;
            return ok;
        }
        #endregion

        #region  清空模板轮廓
        /// <summary>
        /// 清空模板轮廓 
        /// </summary>
        /// <param name="IExtract"></param>
        /// <returns></returns>
        public bool ClearExtractModel(HObject Ho_Image, HWindow hwin, IExtractModelShuJu IExtract)
        {
            bool ok = false;
            IExtract.PrintScreenImage.Dispose();
            IExtract.PrintScreenImage = null;

            IExtract.PrintScreenRegion.Clear();

            IExtract.PrintScreenRegionUnion.Dispose();
            IExtract.PrintScreenRegionUnion = null;

            IExtract.PrintScreenRegionXLD.Dispose();
            IExtract.PrintScreenRegionXLD = null;

            IExtract.SelectedContours.Dispose();
            IExtract.SelectedContours = null;

            hwin.DispObj(Ho_Image);

            ok = true;
            return ok;
        }

        #endregion

        #region   设置参数
        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="IExtract"></param>
        /// <param name="PrintScreen_R_"></param>
        /// <param name="Fiter_"></param>
        /// <param name="Aplha_"></param>
        /// <param name="Low_"></param>
        /// <param name="High_"></param>
        /// <param name="Feature_"></param>
        /// <param name="Min1_"></param>
        /// <param name="Max1_"></param>
        /// <param name="Min2_"></param>
        /// <param name="Max2_"></param>
        /// <returns></returns>
        public bool Set_ExtractModel(IExtractModelShuJu IExtract, string PrintScreen_R_, string Fiter_, string Aplha_, string Low_, string High_, string Feature_, string Min1_, string Max1_, string Min2_, string Max2_)
        {
            bool ok = false;
            if (PrintScreen_R_ != null)
            {
                double num = Convert.ToDouble(PrintScreen_R_);
                IExtract.PrintScreen_R = num;
            }

            if (Fiter_ != null)
            {
                IExtract.Fiter = Fiter_;
            }

            if (Aplha_ != null)
            {
                double num = Convert.ToDouble(Aplha_);
                IExtract.Aplha = num;
            }

            if (Low_ != null)
            {
                double num = Convert.ToDouble(Low_);
                IExtract.Low = num;
            }

            if (High_ != null)
            {
                double num = Convert.ToDouble(High_);
                IExtract.High = num;
            }

            if (Feature_ != null)
            {
                IExtract.Feature = Feature_;
            }

            if (Min1_ != null)
            {
                double num = Convert.ToDouble(Min1_);
                IExtract.Min1 = num;
            }

            if (Max1_ != null)
            {
                double num = Convert.ToDouble(Max1_);
                IExtract.Max1 = num;
            }

            if (Min2_ != null)
            {
                double num = Convert.ToDouble(Min2_);
                IExtract.Min2 = num;
            }

            if (Max2_ != null)
            {
                double num = Convert.ToDouble(Max2_);
                IExtract.Max2 = num;
            }
            ok = true;
            return ok;
        }
        #endregion
    }

    /// <summary>
    /// 模板提取器数据
    /// </summary>
    public interface IExtractModelShuJu
    {
        #region  属性

        #region  edges_sub_pix 参数
        /// <summary>
        /// edges_sub_pix 算法
        /// </summary>
        HTuple Fiter
        {
            get;
            set;
        }

        /// <summary>
        /// edges_sub_pix 因子
        /// </summary>
        HTuple Aplha
        {
            get;
            set;
        }

        /// <summary>
        ///  edges_sub_pix 最低
        /// </summary>
        HTuple Low
        {
            get;
            set;
        }

        /// <summary>
        ///  edges_sub_pix 最高
        /// </summary>
        HTuple High
        {
            get;
            set;
        }
        #endregion

        #region  输出的xld
        /// <summary>
        /// 输出的xld
        /// </summary>
        HObject Edges
        {
            get
            ;
            set;
        }
        #endregion

        #region  筛选xld的参数
        /// <summary>
        /// 筛选xld的特征
        /// </summary>
        HTuple Feature
        {
            get;
            set;
        }

        /// <summary>
        /// 第一个特征的最小值
        /// </summary>
        HTuple Min1
        {
            get;
            set;
        }

        /// <summary>
        /// 第一个特征的最大值
        /// </summary>
        HTuple Max1
        {
            get;
            set;
        }

        /// <summary>
        /// 第二个特征的最小值
        /// </summary>
        HTuple Min2
        {
            get;
            set;
        }

        /// <summary>
        /// 第二个特征的最大值
        /// </summary>
        HTuple Max2
        {
            get;
            set;
        }

        /// <summary>
        /// 筛选输出的轮廓
        /// </summary>
        HObject SelectedContours
        {
            get;
            set;
        }

        #endregion

        #region 截取的region集合
        /// <summary>
        /// 截取的region集合
        /// </summary>
        List<HObject> PrintScreenRegion
        {
            get;
            set;
        }
        #endregion

        #region   printscreen画笔大小
        /// <summary>
        ///  printscreen画笔大小
        /// </summary>
        HTuple PrintScreen_R
        {
            get
           ;
            set;
        }
        #endregion

        #region  截取到region后截取到的region
        /// <summary>
        /// 截取到region后截取到的region
        /// </summary>
        HObject PrintScreenRegionUnion
        {
            get
             ;
            set;
        }
        #endregion

        #region   截取到region后的图片
        /// <summary>
        /// 截取到region后的图片
        /// </summary>
        HObject PrintScreenImage
        {
            get;
            set;
        }
        #endregion

        #region   截取到region后region合成的集合XLD
        /// <summary>
        ///  截取到region后region合成的集合XLD
        /// </summary>
        HObject PrintScreenRegionXLD
        {
            get;
            set;
        }
        #endregion

        #endregion

        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <returns></returns>
        bool init();
        #endregion

        #region   保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        bool save();
        #endregion

    }

    /// <summary>
    /// 模板提取器工具
    /// </summary>
    public interface IExtractModelTool
    {
        /// <summary>
        /// 筛选xld
        /// </summary>
        /// <returns></returns>
        bool SelectXLD(HObject ho_Image, HWindow hv_WindowHandle, IExtractModelShuJu IExtract);

        /// <summary>
        ///   截图工具
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <param name="hv_WindowHandle"></param>
        /// <returns></returns>
        bool PrintScreenTool(HObject ho_Image, HWindow hv_WindowHandle, IExtractModelShuJu IExtract);

        /// <summary>
        /// EdgesSubPix
        /// </summary>
        /// <param name="Ho_Image"></param>
        /// <param name="hwin"></param>
        /// <param name="IExtract"></param>
        /// <returns></returns>
        bool EdgesSubPix(HWindow hwin, IExtractModelShuJu IExtract);

        /// <summary>
        /// 提取模板的xld
        /// </summary>
        /// <returns></returns>
        bool ExtractModelXLD(HObject ho_Image, HWindow hv_WindowHandle, IExtractModelShuJu IExtract);

        /// <summary>
        ///  清空模板轮廓
        /// </summary>
        /// <param name="Ho_Image"></param>
        /// <param name="hwin"></param>
        /// <param name="IExtract"></param>
        /// <returns></returns>
        bool ClearExtractModel(HObject Ho_Image, HWindow hwin, IExtractModelShuJu IExtract);

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="IExtract"></param>
        /// <param name="PrintScreen_R_"></param>
        /// <param name="Fiter_"></param>
        /// <param name="Aplha_"></param>
        /// <param name="Low_"></param>
        /// <param name="High_"></param>
        /// <param name="Feature_"></param>
        /// <param name="Min1_"></param>
        /// <param name="Max1_"></param>
        /// <param name="Min2_"></param>
        /// <param name="Max2_"></param>
        /// <returns></returns>
        bool Set_ExtractModel(IExtractModelShuJu IExtract, string PrintScreen_R_, string Fiter_, string Aplha_, string Low_, string High_, string Feature_, string Min1_, string Max1_, string Min2_, string Max2_);

    }
    #endregion
}
