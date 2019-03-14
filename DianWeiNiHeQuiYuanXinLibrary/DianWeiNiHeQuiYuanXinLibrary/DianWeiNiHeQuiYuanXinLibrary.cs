using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;




namespace DianWeiNiHeQuiYuanXinLibrary
{

    #region  拟合圆心的数据
    /// <summary>
    /// 拟合圆心的数据
    /// </summary>
    public class DianWeiData : IDianWeiData
    {
        #region  全局变量

        #region   x_column点位
        /// <summary>
        ///  x_column点位
        /// </summary>
        List<string> _x_column = null;
        #endregion

        #region   _y_row点位
        /// <summary>
        /// _y_row点位
        /// </summary>
        List<string> _y_row = null;
        #endregion

        #region   圆的数据
        /// <summary>
        /// 圆心x
        /// </summary>
        double _yuan_xin_x_column = 0;

        /// <summary>
        /// 圆心y
        /// </summary>
        double _yuan_xin_y_row = 0;

        /// <summary>
        /// 圆半径
        /// </summary>
        double _yuan_ban_jing_r = 0;

        /// <summary>
        /// 开始角
        /// </summary>
        double _yuan_kai_shi_jiao = 0;

        /// <summary>
        /// 结束角
        /// </summary>
        double _yuan_jie_su_jiao = 0;

        #endregion

        #endregion

        #region  无用代码
        //#region  构造函数
        //public DianWeiData()
        //{
        //}
        //#endregion
        #endregion

        #region    属性

        #region _x_column点位
        /// <summary>
        ///  _x_column点位
        /// </summary>
        public List<string> X_column
        {
            get
            {
                if (_x_column == null)
                {
                    _x_column = new List<string>();
                }
                return _x_column;
            }
            set
            {
                if (_x_column == null)
                {
                    _x_column = new List<string>();
                }
                _x_column = value;
            }
        }
        #endregion

        #region   _y_row点位
        /// <summary>
        /// _y_row点位
        /// </summary>
        public List<string> Y_row
        {
            get
            {
                if (_y_row == null)
                {
                    _y_row = new List<string>();
                }
                return _y_row;
            }
            set
            {
                if (_y_row == null)
                {
                    _y_row = new List<string>();
                }
                _y_row = value;
            }
        }
        #endregion

        #region  圆心半径
        /// <summary>
        /// 圆心x
        /// </summary>
        public double Yuan_xin_x_column
        {
            get { return _yuan_xin_x_column; }
            set { _yuan_xin_x_column = value; }
        }

        /// <summary>
        /// 圆心y
        /// </summary>
        public double Yuan_xin_y_row
        {
            get { return _yuan_xin_y_row; }
            set { _yuan_xin_y_row = value; }
        }

        /// <summary>
        /// 圆半径
        /// </summary>
        public double Yuan_ban_jing_r
        {
            get { return _yuan_ban_jing_r; }
            set { _yuan_ban_jing_r = value; }
        }

        /// <summary>
        /// 开始角
        /// </summary>
        public double Yuan_kai_shi_jiao
        {
            get { return _yuan_kai_shi_jiao; }
            set { _yuan_kai_shi_jiao = value; }
        }

        /// <summary>
        /// 结束角
        /// </summary>
        public double Yuan_jie_su_jiao
        {
            get { return _yuan_jie_su_jiao; }
            set { _yuan_jie_su_jiao = value; }
        }
        #endregion

        #endregion
    }
    #endregion

    #region   数据接口
    /// <summary>
    /// 拟合圆心的数据接口
    /// </summary>
    public interface IDianWeiData
    {
        #region    属性

        #region _x_column点位
        /// <summary>
        ///  _x_column点位
        /// </summary>
        List<string> X_column
        {
            get;
            set;
        }
        #endregion

        #region   _y_row点位
        /// <summary>
        /// _y_row点位
        /// </summary>
        List<string> Y_row
        {
            get;
            set;
        }
        #endregion

        #region  圆心半径
        /// <summary>
        /// 圆心x
        /// </summary>
        double Yuan_xin_x_column
        {
            get;
            set;
        }

        /// <summary>
        /// 圆心y
        /// </summary>
        double Yuan_xin_y_row
        {
            get;
            set;
        }

        /// <summary>
        /// 圆半径
        /// </summary>
        double Yuan_ban_jing_r
        {
            get;
            set;
        }

        /// <summary>
        /// 开始角
        /// </summary>
        double Yuan_kai_shi_jiao
        {
            get;
            set;
        }

        /// <summary>
        /// 结束角
        /// </summary>
        double Yuan_jie_su_jiao
        {
            get;
            set;
        }
        #endregion

        #endregion
    }
    #endregion

    #region  拟合圆求出圆心工具
    /// <summary>
    /// 拟合圆求出圆心工具
    /// </summary>
    public class NiHeYuanTool
    {

        #region  拟合求圆
        /// <summary>
        ///  拟合求圆
        /// </summary>
        /// <param name="IDian"></param>
        public void niHeQiuYuan(IDianWeiData IDian)
        {

            /*********************转换数据************************/
            List<double> x_column_ = new List<double>();
            List<double> y_row_ = new List<double>();

            foreach (string num in IDian.X_column)
            {
                x_column_.Add(Convert.ToDouble(num));
            }

            foreach (string num in IDian.Y_row)
            {
                y_row_.Add(Convert.ToDouble(num));
            }

            /*******************数据赋值*************************/
            HTuple column_x = new HTuple();
            HTuple row_y = new HTuple();

            int x_i = 0;

            foreach (double x_ in x_column_)
            {

                column_x[x_i] = x_;
                row_y[x_i] = y_row_[x_i];
                x_i += 1;
            }

            /****************求圆心********************/
            HTuple hv_Column = new HTuple();
            HTuple hv_Row = new HTuple();
            HTuple hv_Radius = new HTuple();

            HTuple hv_StartPhi = new HTuple();
            HTuple hv_EndPhi = new HTuple();
            HTuple hv_PointOrder = new HTuple();

            HObject contour = new HObject();
            HOperatorSet.GenEmptyObj(out contour);

            HOperatorSet.GenContourPolygonXld(out contour, row_y, column_x);
            HOperatorSet.FitCircleContourXld(contour, "algebraic", -1, 0, 0, 3, 2, out hv_Row,
            out hv_Column, out hv_Radius, out hv_StartPhi, out hv_EndPhi, out hv_PointOrder);

            IDian.Yuan_xin_x_column = (double)hv_Column;
            IDian.Yuan_xin_y_row = (double)hv_Row;
            IDian.Yuan_ban_jing_r = (double)hv_Radius;
            IDian.Yuan_kai_shi_jiao = (double)hv_StartPhi;
            IDian.Yuan_jie_su_jiao = (double)hv_EndPhi;

        }
        #endregion

        #region  写入数据
        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="IDian"></param>
        /// <param name="x_"></param>
        /// <param name="y_"></param>
        public void xieRuShuJu(IDianWeiData IDian, List<string> x_, List<string> y_)
        {
            if (x_.Count == y_.Count)
            {
                foreach (string x_str_ in x_)
                {
                    IDian.X_column.Add(x_str_);
                }

                foreach (string y_str in y_)
                {
                    IDian.Y_row.Add(y_str);
                }
            }
            else
            {
                MessageBox.Show("数据有错");
            }
        }
        #endregion

        #region  无用代码
        //#region  求取补偿值
        ///// <summary>
        ///// 求取补偿值
        ///// </summary>
        ///// <param name="xuanZhuanZhongXin_X"></param>
        ///// <param name="xuanZhuanZhongXin_Y"></param>
        ///// <param name="muBanDian_X"></param>
        ///// <param name="muBanDian_Y"></param>
        ///// <param name="muBanDian_A"></param>
        ///// <param name="dangQianZuoBiao_X"></param>
        ///// <param name="dangQianZuoBiao_Y"></param>
        ///// <param name="dangQianJiaoDu"></param>
        ///// <param name="xuanZhuanHouDeZuoBiao_X"></param>
        ///// <param name="xuanZhuanHouDeZuoBiao_Y"></param>
        ///// <returns></returns>
        //public bool qiuQuXuanZhuangZhongXin(double xuanZhuanZhongXin_X, double xuanZhuanZhongXin_Y, double muBanDian_X, double muBanDian_Y, double muBanDian_A, double dangQianZuoBiao_X, double dangQianZuoBiao_Y, double dangQianJiaoDu, out double buChangZhi_X, out double buChangZhi_Y, out double BuChangZhi_A)
        //{
        //    bool ok = false;

        //    #region  创建halcon变量
        //    buChangZhi_X = 0;
        //    buChangZhi_Y = 0;
        //    BuChangZhi_A = 0;

        //    HTuple hv_modMat2D;
        //    HTuple hv_xuanZhuanZhongXin_X, hv_xuanZhuanZhongXin_Y, hv_muBanDian_X, hv_muBanDian_Y, hv_muBanDian_A, hv_dangQianZuoBiao_X, hv_dangQianZuoBiao_Y, hv_dangQianJiaoDu, hv_xuanZhuanHouDe_X, hv_xuanZhuanHouDe_Y, hv_JiaoDuPianCha;
        //    HObject hv_circle, hv_circleTran;
        //    HOperatorSet.GenEmptyObj(out hv_circle);
        //    HOperatorSet.GenEmptyObj(out hv_circleTran);
        //    #endregion

        //    #region   赋值
        //    hv_xuanZhuanZhongXin_X = xuanZhuanZhongXin_X;
        //    hv_xuanZhuanZhongXin_Y = xuanZhuanZhongXin_Y;

        //    hv_muBanDian_X = muBanDian_X;
        //    hv_muBanDian_Y = muBanDian_Y;
        //    hv_muBanDian_A = muBanDian_A;

        //    hv_dangQianZuoBiao_X = dangQianZuoBiao_X;
        //    hv_dangQianZuoBiao_Y = dangQianZuoBiao_Y;
        //    hv_dangQianJiaoDu = dangQianJiaoDu;
        //    #endregion

        //    #region  无用代码
        //    //HOperatorSet.VectorAngleToRigid(hv_muBanDian_Y, hv_muBanDian_X, hv_muBanDian_A, hv_dangQianZuoBiao_X, hv_dangQianZuoBiao_Y, hv_dangQianJiaoDu, out hv_modMat2D);

        //    //HTuple hv_rad;
        //    //HOperatorSet.TupleRad(360, out hv_rad);

        //    //HOperatorSet.GenCircleContourXld(out hv_circle, hv_xuanZhuanZhongXin_Y, hv_xuanZhuanZhongXin_X, 30, 0, hv_rad, "positive",1);

        //    ////HOperatorSet.GenCircle(out hv_circle, hv_xuanZhuanZhongXin_Y, hv_xuanZhuanZhongXin_X, 30);

        //    //HOperatorSet.AffineTransContourXld(hv_circle, out hv_circleTran, hv_modMat2D);

        //    ////HOperatorSet.GetContourXld(hv_circleTran, out hv_xuanZhuanHouDe_Y, out hv_xuanZhuanHouDe_X);

        //    //HTuple hv_area,hv_op;
        //    //HOperatorSet.AreaCenterXld(hv_circleTran, out hv_area, out hv_xuanZhuanHouDe_Y, out hv_xuanZhuanHouDe_X, out hv_op);

        //    ////HOperatorSet.AffineTransPoint2d(hv_modMat2D, hv_xuanZhuanZhongXin_X, hv_xuanZhuanZhongXin_Y, out hv_xuanZhuanHouDe_X, out hv_xuanZhuanHouDe_Y);
        //    #endregion

        //    #region  生成要转换的xld
        //    HTuple hv_rad;
        //    HOperatorSet.TupleRad(360, out hv_rad);
        //    HOperatorSet.GenCircleContourXld(out hv_circle, hv_dangQianZuoBiao_Y, hv_dangQianZuoBiao_X, 60, 0, hv_rad, "positive", 1.0);
        //    #endregion

        //    #region   求旋转矩阵
        //    hv_JiaoDuPianCha = hv_muBanDian_A - hv_dangQianJiaoDu;
        //    HOperatorSet.HomMat2dIdentity(out hv_modMat2D);
        //    HOperatorSet.HomMat2dRotate(hv_modMat2D, hv_JiaoDuPianCha, hv_xuanZhuanZhongXin_X, hv_xuanZhuanZhongXin_Y, out hv_modMat2D);
        //    #endregion

        //    #region   旋转xld   得出旋转后的点位
        //    HTuple hv_area, hv_point;
        //    HOperatorSet.AffineTransContourXld(hv_circle, out hv_circleTran, hv_modMat2D);
        //    HOperatorSet.AreaCenterXld(hv_circleTran, out hv_area, out hv_xuanZhuanHouDe_Y, out hv_xuanZhuanHouDe_X, out hv_point);
        //    //HOperatorSet.AffineTransPoint2d(hv_modMat2D, hv_dangQianZuoBiao_X, hv_dangQianZuoBiao_Y, out hv_xuanZhuanHouDe_X, out hv_xuanZhuanHouDe_Y);

        //    #endregion

        //    #region   清空缓存
        //    hv_circleTran.Dispose();
        //    hv_circle.Dispose();
        //    #endregion

        //    #region  计算出来的值转换
        //    BuChangZhi_A = hv_JiaoDuPianCha.D;
        //    buChangZhi_X = (hv_muBanDian_X - hv_xuanZhuanHouDe_X).D;
        //    buChangZhi_Y = (hv_muBanDian_Y - hv_xuanZhuanHouDe_Y).D;
        //    #endregion

        //    ok = true;
        //    return ok;
        //}
        //#endregion
        #endregion
    }
    #endregion

    #region  一次对位，求补偿值

    /// <summary>
    /// 一次对位，求补偿值
    /// </summary>
    public static class YiCiDuiWeiQiuBuChangZhiTool
    {

        #region  求取补偿值
        /// <summary>
        /// 一次对位，求补偿值
        /// </summary>
        /// <param name="xuanZhuanZhongXin_X"></param>
        /// <param name="xuanZhuanZhongXin_Y"></param>
        /// <param name="muBanDian_X"></param>
        /// <param name="muBanDian_Y"></param>
        /// <param name="muBanDian_A"></param>
        /// <param name="dangQianZuoBiao_X"></param>
        /// <param name="dangQianZuoBiao_Y"></param>
        /// <param name="dangQianJiaoDu"></param>
        /// <param name="xuanZhuanHouDeZuoBiao_X"></param>
        /// <param name="xuanZhuanHouDeZuoBiao_Y"></param>
        /// <returns></returns>
        public static bool yiCiDuiWeiQiuBuChangZhi(double xuanZhuanZhongXin_X, double xuanZhuanZhongXin_Y, double muBanDian_X, double muBanDian_Y, double muBanDian_A, double dangQianZuoBiao_X, double dangQianZuoBiao_Y, double dangQianJiaoDu, out double buChangZhi_X, out double buChangZhi_Y, out double BuChangZhi_A)
        {
            bool ok = false;

            #region  创建halcon变量
            buChangZhi_X = 0;
            buChangZhi_Y = 0;
            BuChangZhi_A = 0;

            HTuple hv_modMat2D;
            HTuple hv_xuanZhuanZhongXin_X, hv_xuanZhuanZhongXin_Y, hv_muBanDian_X, hv_muBanDian_Y, hv_muBanDian_A, hv_dangQianZuoBiao_X, hv_dangQianZuoBiao_Y, hv_dangQianJiaoDu, hv_xuanZhuanHouDe_X, hv_xuanZhuanHouDe_Y, hv_JiaoDuPianCha;
            HObject hv_circle, hv_circleTran;
            HOperatorSet.GenEmptyObj(out hv_circle);
            HOperatorSet.GenEmptyObj(out hv_circleTran);
            #endregion

            #region   赋值
            hv_xuanZhuanZhongXin_X = xuanZhuanZhongXin_X;
            hv_xuanZhuanZhongXin_Y = xuanZhuanZhongXin_Y;

            hv_muBanDian_X = muBanDian_X;
            hv_muBanDian_Y = muBanDian_Y;
            hv_muBanDian_A = muBanDian_A;

            hv_dangQianZuoBiao_X = dangQianZuoBiao_X;
            hv_dangQianZuoBiao_Y = dangQianZuoBiao_Y;
            hv_dangQianJiaoDu = dangQianJiaoDu;
            #endregion

            #region  生成要转换的xld
            HTuple hv_rad;
            HOperatorSet.TupleRad(360, out hv_rad);
            HOperatorSet.GenCircleContourXld(out hv_circle, hv_dangQianZuoBiao_Y, hv_dangQianZuoBiao_X, 60, 0, hv_rad, "positive", 1.0);
            #endregion

            #region   求旋转矩阵
            hv_JiaoDuPianCha = hv_muBanDian_A - hv_dangQianJiaoDu;
            HOperatorSet.HomMat2dIdentity(out hv_modMat2D);
            HOperatorSet.HomMat2dRotate(hv_modMat2D, hv_JiaoDuPianCha, hv_xuanZhuanZhongXin_X, hv_xuanZhuanZhongXin_Y, out hv_modMat2D);
            #endregion

            #region   旋转xld   得出旋转后的点位
            HTuple hv_area, hv_point;
            HOperatorSet.AffineTransContourXld(hv_circle, out hv_circleTran, hv_modMat2D);
            HOperatorSet.AreaCenterXld(hv_circleTran, out hv_area, out hv_xuanZhuanHouDe_Y, out hv_xuanZhuanHouDe_X, out hv_point);
            #endregion

            #region   清空缓存
            hv_circleTran.Dispose();
            hv_circle.Dispose();
            #endregion

            #region  计算出来的值转换
            BuChangZhi_A = hv_JiaoDuPianCha.D;
            buChangZhi_X = (hv_muBanDian_X - hv_xuanZhuanHouDe_X).D;
            buChangZhi_Y = (hv_muBanDian_Y - hv_xuanZhuanHouDe_Y).D;
            #endregion

            ok = true;
            return ok;
        }
        #endregion


    }

    #endregion


}
