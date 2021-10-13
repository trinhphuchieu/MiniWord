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
    public partial class ThayThe : Form
    {

        private RichTextBox ghi; 
        public ThayThe(RichTextBox rtxGhi)
        {
            InitializeComponent();
            this.ghi = rtxGhi;
        }


        // lựa chọn kiểu tìm kiếm
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



        // vị trí tìm kiếm
        private int res;


        // tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string str = txtTimKiem.Text;
            string file = this.ghi.Text;
            if (res > file.Length) res = 0;
            res = ghi.Find(str, res, GetOptions());

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


        // thay thế 
        private void btnThayThe_Click(object sender, EventArgs e)
        {
            string str = txtThayThe.Text.Length == 0 ? " " : txtThayThe.Text;



            if (this.ghi.SelectedText.Length != 0)
            {
                this.ghi.SelectedText = this.ghi.SelectedText.Replace(this.ghi.SelectedText, str);
            }  
            btnTimKiem.PerformClick();
         
        }


        // thay thế tất cả
        private void btnThayTheAll_Click(object sender, EventArgs e)
        {
            string str = txtThayThe.Text.Length == 0 ? " " : txtThayThe.Text;
            string txt = " ";
            if(txtTimKiem.Text.Length != 0) txt = txtTimKiem.Text; 
            this.ghi.Text = this.ghi.Text.Replace(txt, str);
        }

        // hủy
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if(txtTimKiem.Text.Length > 0)
            {
                btnThayThe.Enabled = true;
                btnTimKiem.Enabled = true;
                btnThayTheAll.Enabled = true;
            }
            else
            {
                btnThayThe.Enabled = false;
                btnTimKiem.Enabled = false;
                btnThayTheAll.Enabled = false;
                
            }

        }

        private void txtThayThe_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
