using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HalconDotNet;


namespace HalControl.ROI
{
    #region  ROI数据
    /// <summary>
    ///  ROI数据
    /// </summary>
    internal class ROI : IROI
    {
        #region  显示
        /// <summary>
        /// 显示
        /// </summary>
        public virtual void displayROI(HWindow hwin)
        {

        }
        #endregion

        #region  是否选中ROI
        /// <summary>
        /// 是否选中ROI
        /// </summary>
        /// <returns></returns>
        public virtual int isSelected(double x, double y)
        {
            return -1;
        }
        #endregion

        #region  显示选中的操作点
        /// <summary>
        /// 显示选中的操作点
        /// </summary>
        /// <param name="number"></param>
        public virtual void displayOperation(int number, HWindow hwin)
        {

        }
        #endregion

        #region  设置点位
        /// <summary>
        /// 设置点位
        /// </summary>
        /// <param name="col_x"></param>
        /// <param name="row_y"></param>
        /// <param name="number">设置地几个点</param>
        public virtual void setOpoint(double col_x, double row_y)
        {

        }
        #endregion

        #region  无用代码
        //#region   对接外部数据
        ///// <summary>
        ///// 对接外部数据
        ///// </summary>
        ///// <returns></returns>
        //public virtual IOutside iOutSide()
        //{
        //    return null;
        //}
        //#endregion
        #endregion

    }
    #endregion

    #region   接口
    /// <summary>
    /// 接口ROI
    /// </summary>
    internal interface IROI
    {
        #region   显示ROI
        /// <summary>
        /// 显示ROI
        /// </summary>
        /// <param name="hwin"></param>
        void displayROI(HWindow hwin);
        #endregion

        #region  是否选中
        /// <summary>
        /// 是否选中
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        int isSelected(double x, double y);
        #endregion

        #region  显示选中的操作点
        /// <summary>
        /// 显示选中的操作点
        /// </summary>
        /// <param name="number"></param>
        /// <param name="hwin"></param>
        void displayOperation(int number, HWindow hwin);
        #endregion

        #region  设置点位
        /// <summary>
        /// 设置点位
        /// </summary>
        /// <param name="col_x"></param>
        /// <param name="row_y"></param>
        /// <param name="number">设置地几个点</param>
        void setOpoint(double col_x, double row_y);
        #endregion

        #region  无用代码
        //#region  对接外接数据
        ///// <summary>
        ///// 对接外接数据
        ///// </summary>
        ///// <returns></returns>
        //IOutside iOutSide();
        //#endregion
        #endregion
    }
    #endregion

    #region   无用代码
    //#region  外部数据接口
    ///// <summary>
    ///// 外部数据接口
    ///// </summary>
    //public interface IOutside : Rectangle2.IOutsideRectangle2ROI, Rectangle1.IOutsideRectangle1ROI, Cricle.IOutsideCricleROI
    //{

    //}
    //#endregion
    #endregion
}
