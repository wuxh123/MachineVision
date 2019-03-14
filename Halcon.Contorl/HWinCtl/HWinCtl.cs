using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Collections;
using HalControl.ROI;

namespace HalControl.HWinCtl
{
    /// <summary>
    /// halcon窗口控制器,控制窗口里面的roi
    /// </summary>
    internal class HWinCtl
    {
        #region  全局变量

        #region  ROI控制器
        /// <summary>
        /// ROI控制器
        /// </summary>
        ROIControl _roiControl;
        #endregion

        #region  选中ROI的标志
        /// <summary>
        ///  选中ROI的标志
        /// </summary>
        bool _boolROIChioce = false;
        #endregion

        #region    要控制的窗口控件
        /// <summary>
        /// 要控制的窗口控件
        /// </summary>
        HWindowControl _hWindowControl;
        #endregion

        #endregion

        #region  初始化
        /// <summary>
        /// 初始化halcon窗口控制器
        /// </summary>
        /// <param name="hWindowControl_">传入要控制的窗口</param>
        internal HWinCtl(HWindowControl hWindowControl_)
        {
            _hWindowControl = hWindowControl_;
            _roiControl = new ROIControl();
            
            hWindowControl_.HMouseDown += mouseDown;

        }
        #endregion

        #region  halcon窗口事件


        #region 鼠标按下事件
        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mouseDown(object sender, HalconDotNet.HMouseEventArgs e)
        {
            //int tool_point = -1;//确定工具是否被选中
            int button_state;
            double position_col_X, position_row_Y;
            _hWindowControl.HalconWindow.GetMpositionSubPix(out position_row_Y, out position_col_X, out button_state);

            /************确定有没有ROI被选中*************/
            if (_roiControl.isArrayROIExit() == true)
            {
                _boolROIChioce = _roiControl.selectedROI(position_col_X, position_row_Y);
            }

        }
        #endregion

        #region  鼠标释放事件
        private void mouseUp(object sender, HalconDotNet.HMouseEventArgs e)
        {

        }
        #endregion

        #region  鼠标移动事件
        private void mouseMoved(object sender, HalconDotNet.HMouseEventArgs e)
        {
           
        }
        #endregion

        #endregion

        
    }
}
