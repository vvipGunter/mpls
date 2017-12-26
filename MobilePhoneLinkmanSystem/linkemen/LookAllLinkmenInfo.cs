using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace linkemen
{
    public partial class LookAllLinkmenInfo : Form
    {
        public LookAllLinkmenInfo()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LookAllLinkmenInfo_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“gunterMPLMSDataSet.procViewLinkmenInfo”中。您可以根据需要移动或移除它。
            this.procViewLinkmenInfoTableAdapter.Fill(this.gunterMPLMSDataSet.procViewLinkmenInfo);
            //dataGridView1.DataSource = new UserManager().SelectAllLinkmenInfo();
            
        }
        private void bangding()
        {
 
        }
    }
}
