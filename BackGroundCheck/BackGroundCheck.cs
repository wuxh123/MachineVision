using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using MultTree;
using HalControl.ROI.Rectangle2;
using RectLibrary;





namespace BackGroundCheckHalconLibrary
{
    #region 数据
    /// <summary>
    /// 背景检测的数据
    /// </summary>
    [Serializable]
    public class BackGroundShuJu : MultTree.ToolDateFather, IBackGroundShuJu
    {
        #region  全局变量

        #region   对错
        /// <summary>
        /// 对错
        /// </summary>
        bool _beiJingJianCeDuiCuo = false;

        #endregion

        #region   外部接口数据
        /// <summary>
        /// 外部接口数据
        /// </summary>
        [NonSerialized]
        HalControl.ROI.Rectangle2.IOutsideRectangle2ROI _iOutSide = null;
        #endregion

        #region   模板掩盖的参数
        /// <summary>
        /// 模板掩盖的参数 最小灰度值
        /// </summary>
        [NonSerialized]
        HTuple _minGray = null;

        /// <summary>
        /// 模板掩盖的参数 最大灰度值
        /// </summary>
        [NonSerialized]
        HTuple _maxGray = null;

        /// <summary>
        /// 模板掩盖的参数 膨胀半径
        /// </summary>
        [NonSerialized]
        HTuple _dilationRadius = null;

        /// <summary>
        /// 遮掩的区域
        /// </summary>
        [NonSerialized]
        HObject _coverUpRegion = null;
        #endregion

        #region  模板图片

        /// <summary>
        /// 模板图片
        /// </summary>
        [NonSerialized]
        HObject _modelImage = null;

        /// <summary>
        /// 是否存在模板图片
        /// </summary>
        bool _exit_Model_Image = false;

        #endregion

        #region   动态阈值参数  背景参数
        /// <summary>
        /// 动态阈值参数  背景参数   阈值参数
        /// </summary>
        [NonSerialized]
        HTuple _offset = null;

        /// <summary>
        /// 动态阈值参数  背景参数   查找的背景  提取的是黑色，还是白色
        /// </summary>
        [NonSerialized]
        HTuple _lightDark = null;

        /// <summary>
        /// 分割对的特征
        /// </summary>
        [NonSerialized]
        HTuple _hv_Features = null;

        /// <summary>
        /// 分割特征的逻辑运算
        /// </summary>
        [NonSerialized]
        HTuple _hv_Operation = null;

        /// <summary>
        /// 特征的最小值
        /// </summary>
        [NonSerialized]
        HTuple _hv_Min = null;

        /// <summary>
        /// 特征的最大值
        /// </summary>
        [NonSerialized]
        HTuple _hv_Max = null;
        #endregion

        #region   处理到的污点
        /// <summary>
        /// 处理到的污点
        /// </summary>
        [NonSerialized]
        HObject ho_RegionDynThresh = null;
        #endregion

        #region   处理到污点的个数
        /// <summary>
        /// 处理到污点的个数
        /// </summary>
        [NonSerialized]
        HTuple hv_EulerNumber = null;

        #endregion

        #region   结果
        /// <summary>
        /// 结果
        /// </summary>
        [NonSerialized]
        BackGround_Result _resutle = new BackGround_Result();
        #endregion

        #endregion

        #region   属性

        #region   模板掩盖的参数
        /// <summary>
        /// 模板掩盖的参数 最小灰度值
        /// </summary>
        public HTuple MinGray
        {
            get
            {
                if (_minGray == null)
                {
                    _minGray = 0;
                }
                return _minGray;
            }
            set { _minGray = value; }
        }

        /// <summary>
        /// 模板掩盖的参数 最大灰度值
        /// </summary>
        public HTuple MaxGray
        {
            get
            {
                if (_maxGray == null)
                {
                    _maxGray = 80;
                }
                return _maxGray;
            }
            set { _maxGray = value; }
        }

        /// <summary>
        /// 模板掩盖的参数 膨胀半径
        /// </summary>
        public HTuple DilationRadius
        {
            get
            {
                if (_dilationRadius == null)
                {
                    _dilationRadius = 6;
                }
                return _dilationRadius;
            }
            set { _dilationRadius = value; }
        }

        /// <summary>
        /// 遮掩的区域
        /// </summary>
        public HObject CoverUpRegion
        {
            get
            {
                if (_coverUpRegion == null)
                {
                    HOperatorSet.GenEmptyObj(out _coverUpRegion);
                    _coverUpRegion.Dispose();
                }
                return _coverUpRegion;
            }
            set { _coverUpRegion = value; }
        }
        #endregion

        #region     模板图片
        /// <summary>
        /// 模板图片
        /// </summary>
        public HObject ModelImage
        {
            get
            {
                if (_modelImage == null)
                {
                    HOperatorSet.GenEmptyObj(out _modelImage);
                    _modelImage.Dispose();
                }
                return _modelImage;
            }
            set
            {
                this._exit_Model_Image = true;
                _modelImage = value;
            }
        }
        #endregion

        #region   动态阈值参数  背景参数
        /// <summary>
        /// 动态阈值参数  背景参数   阈值参数
        /// </summary>
        public HTuple Offset
        {
            get
            {
                if (_offset == null)
                {
                    _offset = 5;
                }
                return _offset;
            }
            set { _offset = value; }
        }

        /// <summary>
        /// 动态阈值参数  背景参数   查找的背景  提取的是黑色，还是白色
        /// </summary>
        public HTuple LightDark
        {
            get
            {
                if (_lightDark == null)
                {
                    this._lightDark = "light";
                }
                return _lightDark;
            }
            set { _lightDark = value; }
        }

        /// <summary>
        /// 分割对的特征
        /// </summary>
        public HTuple Hv_Features
        {
            get
            {
                if (_hv_Features == null)
                {
                    _hv_Features = "area";
                }
                return _hv_Features;
            }
            set { _hv_Features = value; }
        }

        /// <summary>
        /// 分割特征的逻辑运算
        /// </summary>
        public HTuple Hv_Operation
        {
            get
            {
                if (_hv_Operation == null)
                {
                    _hv_Operation = "and";
                }
                return _hv_Operation;
            }
            set { _hv_Operation = value; }
        }

        /// <summary>
        /// 特征的最小值
        /// </summary>
        public HTuple Hv_Min
        {
            get
            {
                if (_hv_Min == null)
                {
                    _hv_Min = 0;
                }
                return _hv_Min;
            }
            set { _hv_Min = value; }
        }

        /// <summary>
        /// 特征的最大值
        /// </summary>
        public HTuple Hv_Max
        {
            get
            {
                if (_hv_Max == null)
                {
                    _hv_Max = 90000000;
                }
                return _hv_Max;
            }
            set { _hv_Max = value; }
        }

        #endregion

        #region   是否存在模板图片
        /// <summary>
        /// 是否存在模板图片
        /// </summary>
        public bool Exit_Model_Image
        {
            get { return _exit_Model_Image; }
            set { _exit_Model_Image = value; }
        }
        #endregion

        #region  外部接口数据
        /// <summary>
        /// 外部接口数据
        /// </summary>
        public HalControl.ROI.Rectangle2.IOutsideRectangle2ROI IOutSide
        {
            get
            {
                if (_iOutSide == null)
                {
                    //this._iOutSide = new HalControl.ROI.Rectangle2.IOutsideRectangle2ROI();
                    //this._iOutSide.Row_y1 = 100;
                    //this._iOutSide.Col_x1 = 100;
                    //this._iOutSide.Row_y2 = 200;
                    //this._iOutSide.Col_x2 = 200;
                    _iOutSide = new OutsideRectangle2ROI();
                    _iOutSide.Mid_col_x = 100;
                    _iOutSide.Mid_row_y = 100;
                    _iOutSide.Phi = 0;
                    _iOutSide.Len1 = 100;
                    _iOutSide.Len2 = 100;
                }
                return _iOutSide;
            }
            set
            {
                if (_iOutSide == null)
                {
                    _iOutSide = new OutsideRectangle2ROI();
                    _iOutSide.Mid_col_x = 100;
                    _iOutSide.Mid_row_y = 100;
                    _iOutSide.Phi = 0;
                    _iOutSide.Len1 = 100;
                    _iOutSide.Len2 = 100;
                }
                _iOutSide = value;
            }
        }
        #endregion

        #region   处理到的污点
        /// <summary>
        /// 处理到的污点
        /// </summary>
        public HObject Ho_RegionDynThresh
        {
            get
            {
                if (ho_RegionDynThresh == null)
                {
                    HOperatorSet.GenEmptyObj(out ho_RegionDynThresh);
                    ho_RegionDynThresh.Dispose();
                }
                return ho_RegionDynThresh;
            }
            set
            {
                if (ho_RegionDynThresh == null)
                {
                    HOperatorSet.GenEmptyObj(out ho_RegionDynThresh);
                    ho_RegionDynThresh.Dispose();
                }
                ho_RegionDynThresh = value;
            }
        }
        #endregion

        #region  处理到污点的个数
        /// <summary>
        /// 处理到污点的个数
        /// </summary>
        public HTuple Hv_EulerNumber
        {
            get { return hv_EulerNumber; }
            set { hv_EulerNumber = value; }
        }
        #endregion

        //#region   结果类
        ///// <summary>
        ///// 结果类
        ///// </summary>
        //public BackGroundTrained_Class BackGroundTrained
        //{
        //    get
        //    {
        //        if (_backGroundTrained == null)
        //        {
        //            _backGroundTrained = new BackGroundTrained_Class();
        //        }
        //        return _backGroundTrained;
        //    }
        //    set
        //    {
        //        if (_backGroundTrained == null)
        //        {
        //            _backGroundTrained = new BackGroundTrained_Class();
        //        }
        //        _backGroundTrained = value;
        //    }
        //}
        //#endregion

        #endregion

        #region   序列化数据

        #region roi信息
        /// <summary>
        /// 截取roi的中心坐标， 行 y
        /// </summary>
        Object hv_Row1;
        /// <summary>
        /// 截取roi的中心坐标， 列 x
        /// </summary>
        Object hv_Column1;
        /// <summary>
        /// 截取roi的角度
        /// </summary>
        Object hv_Phi1;
        /// <summary>
        /// 截取roi的width
        /// </summary>
        Object hv_Length11;
        /// <summary>
        /// 截取roi的high
        /// </summary>
        Object hv_Length21;
        #endregion

        #region   模板掩盖的参数
        /// <summary>
        /// 模板掩盖的参数 最小灰度值
        /// </summary>
        Object MinGray1;
        /// <summary>
        /// 模板掩盖的参数 最大灰度值
        /// </summary>
        Object MaxGray1;
        /// <summary>
        /// 模板掩盖的参数 膨胀半径
        /// </summary>
        Object DilationRadius1;
        /// <summary>
        /// 检测的图片
        /// </summary>
        Object CoverUpRegion1;
        #endregion

        #region  模板图片
        /// <summary>
        /// 模板图片
        /// </summary>
        Object ModelImage1;
        #endregion

        #region   动态阈值参数  背景参数

        /// <summary>
        /// 动态阈值参数  背景参数   阈值参数
        /// </summary>
        Object _offset_1 = null;

        /// <summary>
        /// 动态阈值参数  背景参数   查找的背景  提取的是黑色，还是白色
        /// </summary>
        Object _lightDark_1 = null;

        /// <summary>
        /// 分割对的特征
        /// </summary>
        Object _hv_Features_1 = null;

        /// <summary>
        /// 分割特征的逻辑运算
        /// </summary>
        Object _hv_Operation_1 = null;

        /// <summary>
        /// 特征的最小值
        /// </summary>
        Object _hv_Min_1 = null;

        /// <summary>
        /// 特征的最大值
        /// </summary>
        Object _hv_Max_1 = null;



        #endregion

        #endregion

        #region    构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public BackGroundShuJu()
        {
            HOperatorSet.GenEmptyObj(out _modelImage);
            _modelImage.Dispose();

            //HOperatorSet.GenEmptyObj(out _checkImage);
            //_checkImage.Dispose();

            HOperatorSet.GenEmptyObj(out _coverUpRegion);
            _coverUpRegion.Dispose();
        }
        #endregion

        #region   保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        public override void save()
        {
            base.save();

            #region   截取region的点位保存
            this.hv_Row1 = this.IOutSide.Mid_row_y;
            this.hv_Column1 = this.IOutSide.Mid_col_x;
            this.hv_Phi1 = this.IOutSide.Phi;
            this.hv_Length11 = this.IOutSide.Len1;
            this.hv_Length21 = this.IOutSide.Len2;
            #endregion

            #region   模板掩盖的参数
            MinGray1 = this.MinGray;
            MaxGray1 = this.MaxGray;
            DilationRadius1 = this.DilationRadius;
            CoverUpRegion1 = this.CoverUpRegion;
            #endregion

            #region  模板图片
            ModelImage1 = this.ModelImage;
            #endregion

            #region   动态阈值参数  背景参数
            _offset_1 = Offset;

            _lightDark_1 = LightDark;

            _hv_Features_1 = Hv_Features;

            _hv_Operation_1 = Hv_Operation;

            _hv_Min_1 = Hv_Min;

            _hv_Max_1 = Hv_Max;

            #endregion

        }
        #endregion

        #region    初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        public override void init()
        {
            base.init();

            #region   截取region的点位保存
            this.IOutSide.Mid_col_x = (HTuple)this.hv_Column1;

            this.IOutSide.Mid_row_y = (HTuple)this.hv_Row1;
            this.IOutSide.Phi = (HTuple)this.hv_Phi1;
            this.IOutSide.Len1 = (HTuple)this.hv_Length11;
            this.IOutSide.Len2 = (HTuple)this.hv_Length21;
            #endregion

            #region   模板掩盖的参数
            this.MinGray = (HTuple)this.MinGray1;
            this.MaxGray = (HTuple)this.MaxGray1;
            this.DilationRadius = (HTuple)this.DilationRadius;

            if (this._coverUpRegion == null)
            {
                HOperatorSet.GenEmptyObj(out _coverUpRegion);
                _coverUpRegion.Dispose();
            }

            this.CoverUpRegion = (HObject)this.CoverUpRegion1;

            #endregion

            #region  模板图片
            if (this._modelImage == null)
            {
                HOperatorSet.GenEmptyObj(out _modelImage);
                _modelImage.Dispose();
            }
            this.ModelImage = (HObject)this.ModelImage1;
            #endregion

            #region   动态阈值参数  背景参数
            Offset = (HTuple)_offset_1;

            LightDark = (HTuple)_lightDark_1;

            Hv_Features = (HTuple)_hv_Features_1;

            Hv_Operation = (HTuple)_hv_Operation_1;

            Hv_Min = (HTuple)_hv_Min_1;

            Hv_Max = (HTuple)_hv_Max_1;

            #endregion

            _resutle = new BackGround_Result();

        }
        #endregion

        #region   检测
        /// <summary>
        /// 检测
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <param name="hwin"></param>
        /// <param name="Key"></param>
        /// <param name="_dictionary_resulte"></param>
        /// <returns></returns>
        public override bool analyze_show(HWindow hwin, string Key, ref Dictionary<string, object> _dictionary_resulte)
        {
            bool ok = false;

            HTuple Hv_EulerNumber_;

            HTuple Hv_homMat2D_ = null;

            HObject ImageAffineTrans_;
            HObject CoverUpRegion_;

            HObject ho_Rectangle_;
            HOperatorSet.GenEmptyObj(out ho_Rectangle_);
            ho_Rectangle_.Dispose();

            HObject ho_RegionDynThresh_;
            HOperatorSet.GenEmptyObj(out ho_RegionDynThresh_);
            ho_RegionDynThresh_.Dispose();

            HOperatorSet.GenEmptyObj(out CoverUpRegion_);
            CoverUpRegion_.Dispose();

            HOperatorSet.GenEmptyObj(out ImageAffineTrans_);
            ImageAffineTrans_.Dispose();

            /***********************截取检测的region***********************/
            //HOperatorSet.GenRectangle1(out ho_Rectangle, IBack_.IOutSide.Row_y1, IBack_.IOutSide.Col_x1, IBack_.IOutSide.Row_y2, IBack_.IOutSide.Col_x2);

            HOperatorSet.GenRectangle2(out ho_Rectangle_, IOutSide.Mid_row_y, IOutSide.Mid_col_x, -IOutSide.Phi, IOutSide.Len1, IOutSide.Len2);

            if (IrectShuJuPianYi != null)
            {
                //HOperatorSet.VectorAngleToRigid(IBack_.GeuSuiDian_X_Col, IBack_.GenSuiDian_Y_Row, IBack_.GenSuiDian_A, IBack_.IrectShuJuPianYi.Row, IBack_.IrectShuJuPianYi.Column, IBack_.IrectShuJuPianYi.Angle, out Hv_homMat2D);
                HOperatorSet.VectorAngleToRigid(GenSuiDian_Y_Row, GeuSuiDian_X_Col, GenSuiDian_A, IrectShuJuPianYi.Row, IrectShuJuPianYi.Column, IrectShuJuPianYi.Angle, out Hv_homMat2D_);

                HOperatorSet.AffineTransRegion(ho_Rectangle_, out ho_Rectangle_, Hv_homMat2D_, "nearest_neighbor");
                HOperatorSet.AffineTransRegion(CoverUpRegion, out CoverUpRegion_, Hv_homMat2D_, "nearest_neighbor");
                HOperatorSet.AffineTransImage(ModelImage, out ImageAffineTrans_, Hv_homMat2D_, "constant", "false");
            }
            else
            {
                HOperatorSet.CopyImage(ModelImage, out ImageAffineTrans_);
                //CoverUpRegion_ = CoverUpRegion;
                HOperatorSet.CopyObj(CoverUpRegion, out CoverUpRegion_, 1, 1);
                //ImageAffineTrans_ = ModelImage;
            }

            Arithmetic(ho_Rectangle_, CoverUpRegion_, ImageAffineTrans_, this.ImageFather.Ho_image, out ho_RegionDynThresh_, Offset, LightDark, Hv_Features, Hv_Operation, Hv_Min, Hv_Max, out Hv_EulerNumber_);

            CoverUpRegion_.Dispose();
            ImageAffineTrans_.Dispose();

            Ho_RegionDynThresh.Dispose();
            Ho_RegionDynThresh = ho_RegionDynThresh_;
            Hv_EulerNumber = Hv_EulerNumber_;
            GenSuiDianYuDingWeiDianDeBianHuanRegion.Dispose();
            GenSuiDianYuDingWeiDianDeBianHuanRegion = ho_Rectangle_;
            GenSuiDianWei_Hv_HomMat2D = Hv_homMat2D_;

            /****************数据分析****************/
            //BackGround_Result backGroundResult_ = new BackGround_Result();
            Key = "BackGround_" + Key;
            _resutle._tolatName = Key;
            double num1 = Hv_EulerNumber.D;
            if (num1 > 0)
            {
                _resutle._tolatResult = false;
            }
            else
            {
                _resutle._tolatResult = true;
                ok = true;
            }
            _dictionary_resulte.Add(Key, _resutle);
            show(hwin);
            return ok;
        }

        #endregion

        #region  显示
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="hwin"></param>
        /// <returns></returns>
        public override bool show(HWindow hwin)
        {
            bool ok = false;

            if (GenSuiDianYuDingWeiDianDeBianHuanRegion.IsInitialized())
            {
                HObject ho_Rectangle_;
                HOperatorSet.GenEmptyObj(out ho_Rectangle_);

                //HOperatorSet.GenContourRegionXld(GenSuiDianYuDingWeiDianDeBianHuanRegion, out ho_Rectangle_, "border");
                if (_resutle._tolatResult)
                {
                    hwin.DispObj(GenSuiDianYuDingWeiDianDeBianHuanRegion);
                    ok = true;
                }
                else
                {
                    /************************显示结果***************************/

                    hwin.SetColor("red");
                    hwin.DispObj(Ho_RegionDynThresh);
                    hwin.DispObj(GenSuiDianYuDingWeiDianDeBianHuanRegion);
                    hwin.SetColor("green");
                }
                ho_Rectangle_.Dispose();
            }

            return ok;
        }
        #endregion

        #region  处理算法
        void Arithmetic(HObject ho_Rectangle, HObject ho_RegionUnion, HObject ho_modelImage,
    HObject ho_checkImage, out HObject ho_SelectedRegions, HTuple hv_Offset, HTuple hv_LightDark,
    HTuple hv_Features, HTuple hv_Operation, HTuple hv_Min, HTuple hv_Max, out HTuple hv_EulerNumber)
        {
            // Local iconic variables 
            HTuple area, row_y, col_x;

            HObject ho_RegionDifference, ho_modelImageReduced;
            HObject ho_checkImageReduced, ho_modelImagePart, ho_checkImagePart;
            HObject ho_RegionDynThresh, ho_ConnectedRegions;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_RegionDifference);
            HOperatorSet.GenEmptyObj(out ho_modelImageReduced);
            HOperatorSet.GenEmptyObj(out ho_checkImageReduced);
            HOperatorSet.GenEmptyObj(out ho_modelImagePart);
            HOperatorSet.GenEmptyObj(out ho_checkImagePart);
            HOperatorSet.GenEmptyObj(out ho_RegionDynThresh);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            try
            {

                ho_RegionDifference.Dispose();
                HOperatorSet.Difference(ho_Rectangle, ho_RegionUnion, out ho_RegionDifference
                    );
                ho_modelImageReduced.Dispose();
                HOperatorSet.ReduceDomain(ho_modelImage, ho_RegionDifference, out ho_modelImageReduced
                    );
                ho_checkImageReduced.Dispose();
                HOperatorSet.ReduceDomain(ho_checkImage, ho_RegionDifference, out ho_checkImageReduced
                    );

                //ho_modelImagePart.Dispose();
                //HOperatorSet.CropDomain(ho_modelImageReduced, out ho_modelImagePart);
                //ho_checkImagePart.Dispose();
                //HOperatorSet.CropDomain(ho_checkImageReduced, out ho_checkImagePart);
                ho_RegionDynThresh.Dispose();
                HOperatorSet.DynThreshold(ho_modelImageReduced, ho_checkImageReduced, out ho_RegionDynThresh,
                    hv_Offset, hv_LightDark);

                ho_ConnectedRegions.Dispose();
                HOperatorSet.Connection(ho_RegionDynThresh, out ho_ConnectedRegions);

                ho_SelectedRegions.Dispose();
                HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, hv_Features,
                    hv_Operation, hv_Min, hv_Max);

                //HOperatorSet.EulerNumber(ho_SelectedRegions, out hv_EulerNumber);

                //HOperatorSet.CountObj(ho_SelectedRegions, out hv_EulerNumber);
                HOperatorSet.AreaCenter(ho_SelectedRegions, out area, out row_y, out col_x);

                if (area.Length > 0)
                {
                    hv_EulerNumber = area.I;
                }
                else
                {
                    hv_EulerNumber = area.Length;
                }

                ho_RegionDifference.Dispose();
                ho_modelImageReduced.Dispose();
                ho_checkImageReduced.Dispose();
                ho_modelImagePart.Dispose();
                ho_checkImagePart.Dispose();
                ho_RegionDynThresh.Dispose();
                ho_ConnectedRegions.Dispose();

                return;

            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_RegionDifference.Dispose();
                ho_modelImageReduced.Dispose();
                ho_checkImageReduced.Dispose();
                ho_modelImagePart.Dispose();
                ho_checkImagePart.Dispose();
                ho_RegionDynThresh.Dispose();
                ho_ConnectedRegions.Dispose();

                throw HDevExpDefaultException;
            }
        }
        #endregion
    }
    #endregion

    #region   数据接口
    /// <summary>
    /// 数据接口
    /// </summary>
    public interface IBackGroundShuJu : HalControl.ROI.Rectangle2.IOutsideRectangle2, MultTree.IToolDateFather
    {
        #region   属性

        #region   模板掩盖的参数
        /// <summary>
        /// 模板掩盖的参数 最小灰度值
        /// </summary>
        HTuple MinGray
        {
            get
          ;
            set;
        }

        /// <summary>
        /// 模板掩盖的参数 最大灰度值
        /// </summary>
        HTuple MaxGray
        {
            get
           ;
            set;
        }

        /// <summary>
        /// 模板掩盖的参数 膨胀半径
        /// </summary>
        HTuple DilationRadius
        {
            get
          ;
            set;
        }

        /// <summary>
        /// 遮掩的区域
        /// </summary>
        HObject CoverUpRegion
        {
            get
          ;
            set;
        }

        #endregion

        #region     模板图片
        /// <summary>
        /// 模板图片
        /// </summary>
        HObject ModelImage
        {
            get
           ;
            set
           ;
        }
        #endregion

        //#region  检测的图片
        ///// <summary>
        ///// 检测的图片
        ///// </summary>
        //HObject CheckImage
        //{
        //    get;
        //    set;
        //}
        //#endregion

        #region   动态阈值参数  背景参数
        /// <summary>
        /// 动态阈值参数  背景参数   阈值参数
        /// </summary>
        HTuple Offset
        {
            get
          ;
            set;
        }

        /// <summary>
        /// 动态阈值参数  背景参数   查找的背景  提取的是黑色，还是白色
        /// </summary>
        HTuple LightDark
        {
            get
          ;
            set;
        }


        /// <summary>
        /// 分割对的特征
        /// </summary>
        HTuple Hv_Features
        {
            get
          ;
            set;
        }

        /// <summary>
        /// 分割特征的逻辑运算
        /// </summary>
        HTuple Hv_Operation
        {
            get
           ;
            set;
        }

        /// <summary>
        /// 特征的最小值
        /// </summary>
        HTuple Hv_Min
        {
            get
          ;
            set;
        }

        /// <summary>
        /// 特征的最大值
        /// </summary>
        HTuple Hv_Max
        {
            get;
            set;
        }

        #endregion

        #region   是否存在模板图片
        /// <summary>
        /// 是否存在模板图片
        /// </summary>
        bool Exit_Model_Image
        {
            get;
            set;
        }
        #endregion

        #region   处理到的污点
        /// <summary>
        /// 处理到的污点
        /// </summary>
        HObject Ho_RegionDynThresh
        {
            get
          ;
            set
           ;
        }
        #endregion

        #region  处理到污点的个数
        /// <summary>
        /// 处理到污点的个数
        /// </summary>
        HTuple Hv_EulerNumber
        {
            get;
            set;
        }
        #endregion

        //#region   结果类
        ///// <summary>
        ///// 结果类
        ///// </summary>
        //BackGroundTrained_Class BackGroundTrained
        //{
        //    get
        //  ;
        //    set
        //   ;
        //}
        //#endregion

        #endregion

        #region   保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        void save();
        #endregion

        #region   初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        void init();
        #endregion
    }
    #endregion

    //#region  背景检测的工具
    ///// <summary>
    ///// 背景检测的工具
    ///// </summary>
    //public class BackkGroundTool
    //{
    //    #region   图片算法
    //    /// <summary>
    //    /// 图片算法
    //    /// </summary>
    //    /// <param name="IBack_"></param>
    //    /// <param name="ho_Image"></param>
    //    /// <returns></returns>
    //    public bool ImageArithmetic(IBackGroundShuJu IBack_, HObject ho_Image)
    //    {
    //        bool ok = false;
    //        HTuple Hv_EulerNumber_;
    //        HTuple Hv_homMat2D_ = null;
    //        HObject CoverUpRegion_;
    //        HObject ho_Rectangle_;
    //        HObject ImageAffineTrans_;
    //        HOperatorSet.GenEmptyObj(out ho_Rectangle_);
    //        ho_Rectangle_.Dispose();
    //        HOperatorSet.GenEmptyObj(out CoverUpRegion_);
    //        CoverUpRegion_.Dispose();
    //        HOperatorSet.GenEmptyObj(out ImageAffineTrans_);
    //        ImageAffineTrans_.Dispose();

    //        HObject ho_RegionDynThresh_;
    //        HOperatorSet.GenEmptyObj(out ho_RegionDynThresh_);
    //        ho_RegionDynThresh_.Dispose();

    //        /***********************截取检测的region***********************/
    //        //HOperatorSet.GenRectangle1(out ho_Rectangle, IBack_.IOutSide.Row_y1, IBack_.IOutSide.Col_x1, IBack_.IOutSide.Row_y2, IBack_.IOutSide.Col_x2);

    //        HOperatorSet.GenRectangle2(out ho_Rectangle_, IBack_.IOutSide.Mid_row_y, IBack_.IOutSide.Mid_row_y, IBack_.IOutSide.Phi, IBack_.IOutSide.Len1, IBack_.IOutSide.Len2);

    //        if (IBack_.IrectShuJuPianYi != null)
    //        {
    //            //HOperatorSet.VectorAngleToRigid(IBack_.GeuSuiDian_X_Col, IBack_.GenSuiDian_Y_Row, IBack_.GenSuiDian_A, IBack_.IrectShuJuPianYi.Row, IBack_.IrectShuJuPianYi.Column, IBack_.IrectShuJuPianYi.Angle, out Hv_homMat2D_);
    //            HOperatorSet.VectorAngleToRigid(IBack_.GenSuiDian_Y_Row, IBack_.GeuSuiDian_X_Col, IBack_.GenSuiDian_A, IBack_.IrectShuJuPianYi.Row, IBack_.IrectShuJuPianYi.Column, IBack_.IrectShuJuPianYi.Angle, out Hv_homMat2D_);

    //            HOperatorSet.AffineTransRegion(ho_Rectangle_, out ho_Rectangle_, Hv_homMat2D_, "nearest_neighbor");
    //            HOperatorSet.AffineTransRegion(IBack_.CoverUpRegion, out CoverUpRegion_, Hv_homMat2D_, "nearest_neighbor");
    //            HOperatorSet.AffineTransImage(IBack_.ModelImage, out ImageAffineTrans_, Hv_homMat2D_, "constant", "false");
    //        }
    //        else
    //        {
    //            CoverUpRegion_ = IBack_.CoverUpRegion;
    //            ImageAffineTrans_ = IBack_.ModelImage;
    //        }

    //        Arithmetic(ho_Rectangle_, CoverUpRegion_, ImageAffineTrans_, ho_Image, out ho_RegionDynThresh_, IBack_.Offset, IBack_.LightDark, IBack_.Hv_Features, IBack_.Hv_Operation, IBack_.Hv_Min, IBack_.Hv_Max, out Hv_EulerNumber_);

    //        IBack_.Ho_RegionDynThresh.Dispose();
    //        IBack_.Ho_RegionDynThresh = ho_RegionDynThresh_;
    //        IBack_.Hv_EulerNumber = Hv_EulerNumber_;
    //        IBack_.GenSuiDianYuDingWeiDianDeBianHuanRegion.Dispose();
    //        IBack_.GenSuiDianYuDingWeiDianDeBianHuanRegion = ho_Rectangle_;
    //        IBack_.GenSuiDianWei_Hv_HomMat2D = Hv_homMat2D_;

    //        /***********************结果分析****************************/
    //        BackGround_Result _backGroundResult = new BackGround_Result();
    //        this.Result_Analyisis(IBack_, ref _backGroundResult);

    //        ok = true;
    //        return ok;

    //    }

    //    void Arithmetic(HObject ho_Rectangle, HObject ho_RegionUnion, HObject ho_modelImage,
    // HObject ho_checkImage, out HObject ho_SelectedRegions, HTuple hv_Offset, HTuple hv_LightDark,
    // HTuple hv_Features, HTuple hv_Operation, HTuple hv_Min, HTuple hv_Max, out HTuple hv_EulerNumber)
    //    {
    //        // Local iconic variables 
    //        HTuple area, row_y, col_x;

    //        HObject ho_RegionDifference, ho_modelImageReduced;
    //        HObject ho_checkImageReduced, ho_modelImagePart, ho_checkImagePart;
    //        HObject ho_RegionDynThresh, ho_ConnectedRegions;
    //        // Initialize local and output iconic variables 
    //        HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
    //        HOperatorSet.GenEmptyObj(out ho_RegionDifference);
    //        HOperatorSet.GenEmptyObj(out ho_modelImageReduced);
    //        HOperatorSet.GenEmptyObj(out ho_checkImageReduced);
    //        HOperatorSet.GenEmptyObj(out ho_modelImagePart);
    //        HOperatorSet.GenEmptyObj(out ho_checkImagePart);
    //        HOperatorSet.GenEmptyObj(out ho_RegionDynThresh);
    //        HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
    //        try
    //        {

    //            ho_RegionDifference.Dispose();
    //            HOperatorSet.Difference(ho_Rectangle, ho_RegionUnion, out ho_RegionDifference
    //                );
    //            ho_modelImageReduced.Dispose();
    //            HOperatorSet.ReduceDomain(ho_modelImage, ho_RegionDifference, out ho_modelImageReduced
    //                );
    //            ho_checkImageReduced.Dispose();
    //            HOperatorSet.ReduceDomain(ho_checkImage, ho_RegionDifference, out ho_checkImageReduced
    //                );

    //            ho_modelImagePart.Dispose();
    //            HOperatorSet.CropDomain(ho_modelImageReduced, out ho_modelImagePart);
    //            ho_checkImagePart.Dispose();
    //            HOperatorSet.CropDomain(ho_checkImageReduced, out ho_checkImagePart);
    //            ho_RegionDynThresh.Dispose();
    //            HOperatorSet.DynThreshold(ho_modelImagePart, ho_checkImagePart, out ho_RegionDynThresh,
    //                hv_Offset, hv_LightDark);

    //            ho_ConnectedRegions.Dispose();
    //            HOperatorSet.Connection(ho_RegionDynThresh, out ho_ConnectedRegions);

    //            ho_SelectedRegions.Dispose();
    //            HOperatorSet.SelectShape(ho_RegionDynThresh, out ho_SelectedRegions, hv_Features,
    //                hv_Operation, hv_Min, hv_Max);

    //            //HOperatorSet.EulerNumber(ho_SelectedRegions, out hv_EulerNumber);

    //            //HOperatorSet.CountObj(ho_SelectedRegions, out hv_EulerNumber);
    //            HOperatorSet.AreaCenter(ho_SelectedRegions, out area, out row_y, out col_x);

    //            if (area.Length > 0)
    //            {
    //                hv_EulerNumber = area.I;
    //            }
    //            else
    //            {
    //                hv_EulerNumber = area.Length;
    //            }

    //            ho_RegionDifference.Dispose();
    //            ho_modelImageReduced.Dispose();
    //            ho_checkImageReduced.Dispose();
    //            ho_modelImagePart.Dispose();
    //            ho_checkImagePart.Dispose();
    //            ho_RegionDynThresh.Dispose();
    //            ho_ConnectedRegions.Dispose();

    //            return;

    //        }
    //        catch (HalconException HDevExpDefaultException)
    //        {
    //            ho_RegionDifference.Dispose();
    //            ho_modelImageReduced.Dispose();
    //            ho_checkImageReduced.Dispose();
    //            ho_modelImagePart.Dispose();
    //            ho_checkImagePart.Dispose();
    //            ho_RegionDynThresh.Dispose();
    //            ho_ConnectedRegions.Dispose();

    //            throw HDevExpDefaultException;
    //        }
    //    }

    //    #endregion

    //    #region   显示
    //    /// <summary>
    //    /// 显示
    //    /// </summary>
    //    /// <param name="IBack_"></param>
    //    /// <param name="hwin"></param>
    //    /// <returns></returns>
    //    public bool ShowBackkGround(IBackGroundShuJu IBack_, HWindow hwin)
    //    {
    //        bool ok = false;

    //        /************************显示结果***************************/
    //        hwin.DispObj(IBack_.Ho_RegionDynThresh);

    //        /*************************显示对错*****************************/
    //        HObject ho_Rectangle;
    //        HOperatorSet.GenEmptyObj(out ho_Rectangle);
    //        //HOperatorSet.GenRectangle1(out ho_Rectangle, IBack_.IOutSide.Row_y1, IBack_.IOutSide.Col_x1, IBack_.IOutSide.Row_y2, IBack_.IOutSide.Col_x2);
    //        HOperatorSet.GenRectangle2(out ho_Rectangle, IBack_.IOutSide.Mid_row_y, IBack_.IOutSide.Mid_col_x, IBack_.IOutSide.Phi, IBack_.IOutSide.Len1, IBack_.IOutSide.Len2);

    //        if (IBack_.IrectShuJuPianYi != null)
    //        {
    //            HTuple hv_homMat2D;
    //            HOperatorSet.VectorAngleToRigid(IBack_.GenSuiDian_Y_Row, IBack_.GeuSuiDian_X_Col, IBack_.GenSuiDian_A, IBack_.IrectShuJuPianYi.Row, IBack_.IrectShuJuPianYi.Column, IBack_.IrectShuJuPianYi.Angle, out hv_homMat2D);
    //            HOperatorSet.AffineTransRegion(ho_Rectangle, out ho_Rectangle, hv_homMat2D, "nearest_neighbor");

    //        }

    //        HOperatorSet.GenContourRegionXld(ho_Rectangle, out ho_Rectangle, "border");

    //        if (IBack_.BackGroundTrained._allResult)
    //        {
    //            hwin.DispObj(ho_Rectangle);
    //        }
    //        else
    //        {
    //            hwin.SetColor("red");
    //            hwin.DispObj(ho_Rectangle);
    //            hwin.SetColor("green");
    //        }

    //        ho_Rectangle.Dispose();

    //        ok = true;
    //        return ok;
    //    }
    //    #endregion

    //    #region   处理，显示
    //    /// <summary>
    //    /// 处理，显示
    //    /// </summary>
    //    /// <param name="IBack_"></param>
    //    /// <param name="ho_Image"></param>
    //    /// <param name="hwin"></param>
    //    /// <param name="Key"></param>
    //    /// <param name="_dictionary_resulte"></param>
    //    /// <returns></returns>
    //    public bool ImageArithmetic_ShowBackkGround(IBackGroundShuJu IBack_, HObject ho_Image, HWindow hwin, string Key, ref Dictionary<string, Object> _dictionary_resulte)
    //    {
    //        bool ok = false;

    //        HTuple Hv_EulerNumber;

    //        HTuple Hv_homMat2D = null;

    //        HObject ImageAffineTrans;
    //        HObject CoverUpRegion;

    //        HObject ho_Rectangle;
    //        HOperatorSet.GenEmptyObj(out ho_Rectangle);
    //        ho_Rectangle.Dispose();

    //        HObject ho_RegionDynThresh;
    //        HOperatorSet.GenEmptyObj(out ho_RegionDynThresh);
    //        ho_RegionDynThresh.Dispose();

    //        HOperatorSet.GenEmptyObj(out CoverUpRegion);
    //        CoverUpRegion.Dispose();

    //        HOperatorSet.GenEmptyObj(out ImageAffineTrans);
    //        ImageAffineTrans.Dispose();

    //        /***********************截取检测的region***********************/
    //        //HOperatorSet.GenRectangle1(out ho_Rectangle, IBack_.IOutSide.Row_y1, IBack_.IOutSide.Col_x1, IBack_.IOutSide.Row_y2, IBack_.IOutSide.Col_x2);

    //        HOperatorSet.GenRectangle2(out ho_Rectangle, IBack_.IOutSide.Mid_row_y, IBack_.IOutSide.Mid_col_x, IBack_.IOutSide.Phi, IBack_.IOutSide.Len1, IBack_.IOutSide.Len2);

    //        if (IBack_.IrectShuJuPianYi != null)
    //        {
    //            //HOperatorSet.VectorAngleToRigid(IBack_.GeuSuiDian_X_Col, IBack_.GenSuiDian_Y_Row, IBack_.GenSuiDian_A, IBack_.IrectShuJuPianYi.Row, IBack_.IrectShuJuPianYi.Column, IBack_.IrectShuJuPianYi.Angle, out Hv_homMat2D);
    //            HOperatorSet.VectorAngleToRigid(IBack_.GenSuiDian_Y_Row, IBack_.GeuSuiDian_X_Col, IBack_.GenSuiDian_A, IBack_.IrectShuJuPianYi.Row, IBack_.IrectShuJuPianYi.Column, IBack_.IrectShuJuPianYi.Angle, out Hv_homMat2D);

    //            HOperatorSet.AffineTransRegion(ho_Rectangle, out ho_Rectangle, Hv_homMat2D, "nearest_neighbor");
    //            HOperatorSet.AffineTransRegion(IBack_.CoverUpRegion, out CoverUpRegion, Hv_homMat2D, "nearest_neighbor");
    //            HOperatorSet.AffineTransImage(IBack_.ModelImage, out ImageAffineTrans, Hv_homMat2D, "constant", "false");
    //        }
    //        else
    //        {
    //            CoverUpRegion = IBack_.CoverUpRegion;
    //            ImageAffineTrans = IBack_.ModelImage;
    //        }

    //        Arithmetic(ho_Rectangle, CoverUpRegion, ImageAffineTrans, ho_Image, out ho_RegionDynThresh, IBack_.Offset, IBack_.LightDark, IBack_.Hv_Features, IBack_.Hv_Operation, IBack_.Hv_Min, IBack_.Hv_Max, out Hv_EulerNumber);

    //        IBack_.Ho_RegionDynThresh.Dispose();
    //        IBack_.Ho_RegionDynThresh = ho_RegionDynThresh;
    //        IBack_.Hv_EulerNumber = Hv_EulerNumber;
    //        IBack_.GenSuiDianYuDingWeiDianDeBianHuanRegion.Dispose();
    //        IBack_.GenSuiDianYuDingWeiDianDeBianHuanRegion = ho_Rectangle;
    //        IBack_.GenSuiDianWei_Hv_HomMat2D = Hv_homMat2D;

    //        /***********************结果分析****************************/
    //        BackGround_Result _backGroundResult = new BackGround_Result();
    //        this.Result_Analyisis(IBack_, ref _backGroundResult);

    //        /************************保存结果****************************/
    //        Key = "BackkGround_" + Key;
    //        _backGroundResult._tolatName = Key;

    //        _dictionary_resulte.Add(Key, _backGroundResult);

    //        /************************显示对错********************/
    //        HOperatorSet.GenContourRegionXld(ho_Rectangle, out ho_Rectangle, "border");
    //        if (IBack_.BackGroundTrained._allResult)
    //        {
    //            hwin.DispObj(ho_Rectangle);
    //            ok = true;
    //        }
    //        else
    //        {
    //            /************************显示结果***************************/
    //            hwin.DispObj(IBack_.Ho_RegionDynThresh);

    //            hwin.SetColor("red");
    //            hwin.DispObj(ho_Rectangle);
    //            hwin.SetColor("green");
    //        }
    //        ho_Rectangle.Dispose();
    //        return ok;
    //    }
    //    #endregion

    //    #region   结果分析类
    //    /// <summary>
    //    /// 结果分析类
    //    /// </summary>
    //    /// <param name="IOCV"></param>
    //    /// <param name="backGroundResult_"></param>
    //    void Result_Analyisis(IBackGroundShuJu IBack_, ref BackGround_Result backGroundResult_)
    //    {
    //        double num1 = IBack_.Hv_EulerNumber.D;
    //        if (num1 > 0)
    //        {
    //            IBack_.BackGroundTrained._allResult = false;
    //            backGroundResult_._result = false;
    //            backGroundResult_._tolatResult = false;
    //        }
    //        else
    //        {
    //            IBack_.BackGroundTrained._allResult = true;
    //            backGroundResult_._result = true;
    //            backGroundResult_._tolatResult = true;
    //        }
    //    }
    //    #endregion
    //}
    //#endregion

    #region  设置参数
    /// <summary>
    /// 设置参数
    /// </summary>
    public class Set_BackGroundShuJu
    {
        #region   模板提取掩盖区域
        /// <summary>
        /// 模板提取掩盖区域
        /// </summary>
        /// <param name="IBack_"></param>
        /// <param name="ho_Image"></param>
        /// <returns></returns>
        public bool grindQuYu(IBackGroundShuJu IBack_, HObject ho_Image, HWindow hwin)
        {
            bool ok = false;

            HObject ho_Rectangle;
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            ho_Rectangle.Dispose();
            HObject ho_ImageReduced;
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            ho_ImageReduced.Dispose();



            /***********************截取检测的region***********************/
            //HOperatorSet.GenRectangle1(out ho_Rectangle, IBack_.IOutSide.Row_y1, IBack_.IOutSide.Col_x1, IBack_.IOutSide.Row_y2, IBack_.IOutSide.Col_x2);
            HOperatorSet.GenRectangle2(out ho_Rectangle, IBack_.IOutSide.Mid_row_y, IBack_.IOutSide.Mid_col_x, IBack_.IOutSide.Phi, IBack_.IOutSide.Len1, IBack_.IOutSide.Len2);

            //ho_Rectangle.Dispose();
            HOperatorSet.ReduceDomain(ho_Image, ho_Rectangle, out ho_ImageReduced);

            /*************************提取掩盖的区域****************************************/
            HObject ho_RegionUnion;
            HOperatorSet.GenEmptyObj(out ho_RegionUnion);
            ho_RegionUnion.Dispose();
            GrindQuYu(ho_ImageReduced, out ho_RegionUnion, IBack_.MinGray, IBack_.MaxGray, IBack_.DilationRadius);
            IBack_.CoverUpRegion.Dispose();
            IBack_.CoverUpRegion = ho_RegionUnion;

            /********************显示掩盖的区域***********************/
            hwin.SetDraw("fill");
            hwin.DispObj(IBack_.CoverUpRegion);
            hwin.SetDraw("margin");


            /******************清空创建后无用的缓存******************/
            ho_Rectangle.Dispose();
            ho_ImageReduced.Dispose();

            ok = true;
            return ok;
        }

        /// <summary>
        /// 模板提取掩盖区域
        /// </summary>
        /// <param name="ho_ImageReduced"></param>
        /// <param name="ho_RegionUnion"></param>
        /// <param name="hv_MinGray"></param>
        /// <param name="hv_MaxGray"></param>
        /// <param name="hv_DilationRadius"></param>
        void GrindQuYu(HObject ho_ImageReduced, out HObject ho_RegionUnion, HTuple hv_MinGray,
     HTuple hv_MaxGray, HTuple hv_DilationRadius)
        {
            // Local iconic variables 

            HObject ho_Region, ho_ConnectedRegions, ho_RegionDilation;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_RegionUnion);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_RegionDilation);

            ho_Region.Dispose();
            HOperatorSet.Threshold(ho_ImageReduced, out ho_Region, hv_MinGray, hv_MaxGray);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_Region, out ho_ConnectedRegions);
            ho_RegionDilation.Dispose();
            HOperatorSet.DilationCircle(ho_ConnectedRegions, out ho_RegionDilation, hv_DilationRadius);
            ho_RegionUnion.Dispose();
            HOperatorSet.Union1(ho_RegionDilation, out ho_RegionUnion);
            ho_Region.Dispose();
            ho_ConnectedRegions.Dispose();
            ho_RegionDilation.Dispose();

            return;
        }
        #endregion

        #region   模板掩盖的参数
        /// <summary>
        /// 模板掩盖的参数
        /// </summary>
        /// <param name="IBack_"></param>
        /// <param name="minGray_"></param>
        /// <param name="maxGray_"></param>
        /// <param name="dilationRadius_"></param>
        /// <returns></returns>
        public bool Set_CoverUp(IBackGroundShuJu IBack_, string minGray_, string maxGray_, string dilationRadius_)
        {
            bool ok = false;

            if (minGray_ != null)
            {
                double num = Convert.ToDouble(minGray_);
                IBack_.MinGray = num;
            }

            if (maxGray_ != null)
            {
                double num = Convert.ToDouble(maxGray_);
                IBack_.MaxGray = num;
            }

            if (dilationRadius_ != null)
            {
                double num = Convert.ToDouble(dilationRadius_);
                IBack_.DilationRadius = num;
            }

            ok = true;
            return ok;

        }

        #endregion

        #region   设置模板图片
        /// <summary>
        /// 设置模板图片
        /// </summary>
        /// <param name="IBack_"></param>
        /// <param name="ho_Image"></param>
        /// <returns></returns>
        public bool Set_modelImage(IBackGroundShuJu IBack_, HObject ho_Image)
        {
            bool ok = false;
            HObject Image;
            HOperatorSet.GenEmptyObj(out Image);
            Image.Dispose();
            HOperatorSet.CopyImage(ho_Image, out Image);
            IBack_.ModelImage.Dispose();
            IBack_.ModelImage = Image;

            ok = true;
            return ok;
        }
        #endregion

        #region   动态阈值参数  背景参数
        /// <summary>
        /// 动态阈值参数  背景参数
        /// </summary>
        /// <param name="IBack_"></param>
        /// <param name="offset_"></param>
        /// <param name="lightDark_"></param>
        /// <returns></returns>
        public bool Set_dynParameter(IBackGroundShuJu IBack_, string offset_, string lightDark_, string featrues_, string operation_, string min_, string max_)
        {
            bool ok = false;
            if (offset_ != null)
            {
                double num = Convert.ToDouble(offset_);
                IBack_.Offset = num;
            }

            if (lightDark_ != null)
            {
                IBack_.LightDark = lightDark_;
            }

            if (featrues_ != null)
            {
                IBack_.Hv_Features = featrues_;
            }

            if (operation_ != null)
            {
                IBack_.Hv_Operation = operation_;
            }

            if (min_ != null)
            {
                double num = Convert.ToDouble(min_);
                IBack_.Hv_Min = num;
            }

            if (max_ != null)
            {
                double num = Convert.ToDouble(max_);
                IBack_.Hv_Max = num;
            }
            ok = true;
            return ok;
        }
        #endregion

        #region    重新刷新定位点
        /// <summary>
        /// 重新刷新定位点
        /// </summary>
        /// <param name="IBack_"></param>
        public void Set_ChongXinShuaXinDingWeiDian(IBackGroundShuJu IBack_)
        {
            if (IBack_.IrectShuJuPianYi != null)
            {
                IBack_.GenSuiDian_A = IBack_.IrectShuJuPianYi.Angle;
                IBack_.GenSuiDian_Y_Row = IBack_.IrectShuJuPianYi.Row;
                IBack_.GeuSuiDian_X_Col = IBack_.IrectShuJuPianYi.Column;
            }
        }
        #endregion

        #region  显示参数
        /// <summary>
        /// 显示参数
        /// </summary>
        /// <param name="IBack_"></param>
        /// <param name="control"></param>
        /// <param name="halconWinControl_"></param>
        /// <returns></returns>
        public bool Set_showBackGroundHalconWinControl(IBackGroundShuJu IBack_, Control.ControlCollection control, HalControl.HalconWinControl_ROI halconWinControl_)
        {
            bool ok = false;

            if (halconWinControl_ != null)
            {
                //halconWinControl_.DrawRectangle1(IBack_.IOutSide.Col_x1, IBack_.IOutSide.Row_y1, IBack_.IOutSide.Col_x2, IBack_.IOutSide.Row_y2, IBack_.IOutSide);
                halconWinControl_.DrawRectangle2(IBack_.IOutSide.Mid_col_x, IBack_.IOutSide.Mid_row_y, IBack_.IOutSide.Phi, IBack_.IOutSide.Len1, IBack_.IOutSide.Len2, IBack_.IOutSide);
            }
            Set_showBackGround(IBack_, control);

            ok = true;
            return ok;
        }

        /// <summary>
        /// 显示参数
        /// </summary>
        /// <param name="IBack_"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        bool Set_showBackGround(IBackGroundShuJu IBack_, Control.ControlCollection control)
        {
            bool ok = false;
            foreach (Control con in control)
            {
                string name = con.Name;
                if ((con is ComboBox) || (con is TextBox) || (con is RichTextBox) || (con is Label) || (con is NumericUpDown))
                {
                    switch (name)
                    {
                        #region    掩盖参数
                        case "numericUpDown_MinGray":
                            con.Text = IBack_.MinGray.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_MaxGray":
                            con.Text = IBack_.MaxGray.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_DilationRadius":
                            con.Text = IBack_.DilationRadius.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region    图片对比参数
                        case "numericUpDown_Offset":
                            con.Text = IBack_.Offset.ToString().Replace("\"", "");
                            break;

                        case "LightDark":
                            con.Text = IBack_.LightDark.ToString().Replace("\"", "");
                            break;

                        #endregion

                        #region   特征参数
                        case "com_Features":
                            con.Text = IBack_.Hv_Features.ToString().Replace("\"", "");
                            break;

                        case "numericUpDown_txt_Max":
                            con.Text = IBack_.Hv_Max.ToString().Replace("\"", "");

                            break;

                        case "numericUpDown_txt_Min":
                            con.Text = IBack_.Hv_Min.ToString().Replace("\"", "");
                            break;
                        #endregion

                        #region   默认处理
                        default:
                            break;
                        #endregion
                    }
                }

                if (con.Controls.Count > 0)
                {
                    Set_showBackGround(IBack_, con.Controls);
                }
            }
            ok = true;
            return ok;

        }
        #endregion
    }
    #endregion

    #region  背景检测对比的结果
    /// <summary>
    /// 背景检测对比的结果
    /// </summary>
    [Serializable]
    public class BackGroundTrained_Class
    {
        /// <summary>
        /// 整体的结果
        /// </summary>
        public bool _allResult = true;
    }
    #endregion

    #region    背景检测的结果类
    /// <summary>
    /// 背景检测的结果类
    /// </summary>
    public class BackGround_Result : MultTree.ClassResultFather
    {
        /// <summary>
        /// 整体的结果
        /// </summary>
        public bool _result = true;

        /// <summary>
        /// 显示结果
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public override bool showResult(out string str)
        {
            bool ok = false;
            if (this._tolatResult)
            {
                str = this._tolatName + ":检测成功。";
            }
            else
            {
                str = this._tolatName + ":检测失败。";
            }
            ok = true;
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
            str_array = new string[2];

            str_array[0] = this._tolatName;

            str_array[1] = this._tolatResult.ToString();

            ok = true;

            return ok;
        }
    }
    #endregion
}
