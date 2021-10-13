using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniWord_TrinhPhucHieu
{
    public partial class TimKiem : Form
    {
        internal FrmHieu FrmH = null;

        private RichTextBox ghi;
        
        public TimKiem(RichTextBox ghi)
        {
            this.ghi = ghi;
            InitializeComponent();
         
        }



   







        // Lựa chọn hình thức tìm kiếm
        private RichTextBoxFinds GetOptions()
        {
            RichTextBoxFinds rtbf = new RichTextBoxFinds();

            if (this.chkMatchCase.Checked == true)
            {
                rtbf = rtbf | RichTextBoxFinds.MatchCase;
            }
            if (this.chkWholeWord.Checked == true)
            {
                rtbf = rtbf | RichTextBoxFinds.WholeWord;
            }
            return rtbf;
        }

        private int res = 0;
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string str = txtTimKiem.Text;
            string file = this.ghi.Text;

            res = ghi.Find(str, res, GetOptions()); // hàm tìm kiếm

            // nếu ko tìm thấy
            if (res == -1)
            {
                this.ghi.Select(0, 0);
                res = 0;
                MessageBox.Show("Tìm kiếm hoàn tất.");           
            }
            else 
            {
                this.ghi.Focus();
                res = res + txtTimKiem.Text.Length;
            } 
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
