using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using XmlLibrary;
using System.Windows.Forms;

namespace ZhuCeRuanJianLibrary.UI
{
    public partial class ZhuCeRuanJianFrm : Form
    {
        #region  构造函数
        public ZhuCeRuanJianFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region  注册软件
        private void button_ZhuCeRuanJian_Click(object sender, EventArgs e)
        {
            if (textBox_ZhuCeMa.Text != "")
            {
                if (RuanJianZhuCe.RegistIt(textBox_ZhuCeMa.Text, ShengChengZhuCeMa.GetCode(textBox_JiQiMa.Text)))
                {
                    ZhuCeMaPeiZhiWenJian zhu = new ZhuCeMaPeiZhiWenJian();
                    zhu.ZhuCeMa = textBox_ZhuCeMa.Text;
                    XmlDataCfgMgr<ZhuCeMaPeiZhiWenJian>.SaveV(zhu);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.No;
                }
            }
        }
        #endregion

        #region 初始化
        private void ZhuCeRuanJianFrm_Load(object sender, EventArgs e)
        {
            /********生成机器码************/
            textBox_JiQiMa.Text = ShengChengJiQiMa.CreateCode();
      
        }
        #endregion
    }
}
