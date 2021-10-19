using System;
using System.Collections;
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
    public partial class NgayVaGio : Form
    {

        private RichTextBox rtxGhi;
        private string str = "";
        public NgayVaGio(RichTextBox rtx)
        {
            InitializeComponent();
            this.rtxGhi = rtx;
            DateTime date = DateTime.Now;

            Hashtable s = new Hashtable();
            s.Add("Monday", "Thứ Hai");
            s.Add("Tuesday", "Thứ Ba");
            s.Add("Wednesday", "Thứ Tư");
            s.Add("Thurday", "Thứ Năm");
            s.Add("Friday", "Thứ Sáu");
            s.Add("Saturday", "Thứ Bảy");
            s.Add("Sunday", "Chủ Nhật");
            s.Add("January", "Tháng Một");
            s.Add("February", "Tháng Hai");
            s.Add("March", "Tháng Ba");
            s.Add("April", "Tháng Tư");
            s.Add("May", "Tháng Năm");
            s.Add("June", "Tháng Sáu");
            s.Add("July", "Tháng Bảy");
            s.Add("August", "Tháng Tám");
            s.Add("September", "Tháng Chín");
            s.Add("October", "Tháng Mười");
            s.Add("November", "Tháng Mười Một");
            s.Add("December", "Tháng Mười Hai");
            s.Add("AM", "Buổi Sáng");
            s.Add("PM", "Buổi Chiều");
            radioButton1.Text = date.ToString("dd/MM/yyyy");
            radioButton2.Text = date.ToString("dd-MM-yyyy");
            radioButton3.Text = thayDoiNT(s, DateTime.Now.DayOfWeek.ToString()) + ", Ngày " + date.Day +" "+ thayDoiNT(s,date.ToString("MMMM"))+", "+date.ToString("yyyy");
            radioButton4.Text = thayDoiNT(s, DateTime.Now.DayOfWeek.ToString()) +", Ngày "+date.Day+ " Tháng "+date.Month + " Năm " + date.ToString("yyyy");
            radioButton5.Text = date.ToString("hh:mm:ss");
            radioButton6.Text = date.ToString("HH:mm:ss ")+date.ToString("tt");
            radioButton7.Text = date.ToString("HH:mm:ss ") + thayDoiNT(s,date.ToString("tt"));
        }

        public string thayDoiNT(Hashtable s1, String  s2)
        {
            if (s1[s2] != null) return s1[s2].ToString();
            else return s2;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radXuLy(object sender, EventArgs e)
        {
            RadioButton s = (RadioButton) sender;
            if(s.Checked)
            {
                str = s.Text;
            }    
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            rtxGhi.SelectedText = str;
            this.Close();
        }

        private void NgayVaGio_Load(object sender, EventArgs e)
        {

        }
    }
}
