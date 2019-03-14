using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BarTenderLibrary.UI
{
    public partial class BartenderFrm : Form
    {
        #region 构造函数    
        public BartenderFrm()
        {
            InitializeComponent();
        }
        #endregion 

        #region  初始化
        private void BartenderFrm_Load(object sender, EventArgs e)
        {
            bartenderControl1.init(BarTenderLibrary.StaticBartenderTool.IBar1);
        }
        #endregion
    }
}
