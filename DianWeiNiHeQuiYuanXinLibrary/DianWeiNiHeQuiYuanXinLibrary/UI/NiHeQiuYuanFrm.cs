using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DianWeiNiHeQuiYuanXinLibrary.UI
{
    public partial class NiHeQiuYuanFrm : Form
    {
        #region  全局变量

        /// <summary>
        /// 拟合圆心的数据
        /// </summary>
        DianWeiNiHeQuiYuanXinLibrary.IDianWeiData _iDianWeiData;

        /// <summary>
        /// 拟合圆工具
        /// </summary>
        DianWeiNiHeQuiYuanXinLibrary.NiHeYuanTool _niHeYuanTool;

        #endregion

        #region   构造函数
        public NiHeQiuYuanFrm(DianWeiNiHeQuiYuanXinLibrary.IDianWeiData iDian_)
        {
            InitializeComponent();

            if (iDian_ == null)
            {
                this._iDianWeiData = new DianWeiNiHeQuiYuanXinLibrary.DianWeiData();
            }
            else
            {
                this._iDianWeiData = iDian_;
            }
        }
        #endregion

        #region  初始化
        private void NiHeQiuYuanFrm_Load(object sender, EventArgs e)
        {

            halconWinControl_11.init();
            this._niHeYuanTool = new NiHeYuanTool();

        }
        #endregion

        #region    拟合得到圆心
        private void bnt_niHeDeDaoYuanXin_Click(object sender, EventArgs e)
        {
            this._iDianWeiData.X_column.Clear();
            this._iDianWeiData.Y_row.Clear();

            this._iDianWeiData.X_column.Add(this.txt_x1.Text);
            this._iDianWeiData.Y_row.Add(this.txt_y1.Text);

            this._iDianWeiData.X_column.Add(this.txt_x2.Text);
            this._iDianWeiData.Y_row.Add(this.txt_y2.Text);

            this._iDianWeiData.X_column.Add(this.txt_x3.Text);
            this._iDianWeiData.Y_row.Add(this.txt_y3.Text);

            this._iDianWeiData.X_column.Add(this.txt_x4.Text);
            this._iDianWeiData.Y_row.Add(this.txt_y4.Text);

            this._iDianWeiData.X_column.Add(this.txt_x5.Text);
            this._iDianWeiData.Y_row.Add(this.txt_y5.Text);

            this._iDianWeiData.X_column.Add(this.txt_x6.Text);
            this._iDianWeiData.Y_row.Add(this.txt_y6.Text);

            this._iDianWeiData.X_column.Add(this.txt_x7.Text);
            this._iDianWeiData.Y_row.Add(this.txt_y7.Text);

            this._iDianWeiData.X_column.Add(this.txt_x8.Text);
            this._iDianWeiData.Y_row.Add(this.txt_y8.Text);

            this._iDianWeiData.X_column.Add(this.txt_x9.Text);
            this._iDianWeiData.Y_row.Add(this.txt_y9.Text);

            this._iDianWeiData.X_column.Add(this.txt_x10.Text);
            this._iDianWeiData.Y_row.Add(this.txt_y10.Text);

            this._niHeYuanTool.niHeQiuYuan(this._iDianWeiData);

            lab_status.Text = "圆心坐标:" + this._iDianWeiData.Yuan_xin_x_column + "    " + this._iDianWeiData.Yuan_xin_y_row + "   半径:" + this._iDianWeiData.Yuan_ban_jing_r;

        }
        #endregion
    }
}
