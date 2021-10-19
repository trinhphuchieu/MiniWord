using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniWord_TrinhPhucHieu
{
    public partial class FrmHieu : Form
    {
        public FrmHieu()
        {
            
            InitializeComponent();
            chenEmoji();
            FontText();
            tscmbFont.SelectedItem = "Times New Roman";
            tscmbSize.SelectedItem = "11";
   
        }

        
        // thuộc tính 

        private float sizeText = 11;
        private string fontText = "Times New Roman";
        public string curDuongDan= "New";
        public bool curOpen = false;
        public bool curSave = false;
        public bool ktTrangThai = true;
      





        // định dạng phông chữ
        private void FontText()
        {
            try
            {
                foreach (FontFamily f in FontFamily.Families)
                {
                    tscmbFont.Items.Add(f.Name);
                }
            }catch
            {
                MessageBox.Show("Lỗi Phông chữ");
                tscmbFont.SelectedIndex = 0;
            }
        }



        private void tscmbFont_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmHieu_Load(object sender, EventArgs e)
        {

        }


        
        // Mở File
        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (!ktTrangThai)
            {
                DialogResult tb = MessageBox.Show("Bạn có muốn lưu lại thay đổi không? ", "Thông báo", MessageBoxButtons.YesNoCancel);

                switch (tb)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Yes:    
                        tsmiLuu.PerformClick();
                        break;
                }
            }
            OpenFileDialog file = new OpenFileDialog();
            
            file.Filter = "Mở File (*.rtf)|*.rtf| (*.txt)|*.txt";
            if (file.ShowDialog() == DialogResult.OK)
            {
                string path = file.FileName;
                try
                {
                    if (path != "")
                    {

                        if (!path.EndsWith(".txt"))
                        {
                            rtxGhi.LoadFile(path);
                            curDuongDan = path;

                        }
                        else if (path.EndsWith(".txt"))
                        {
                            rtxGhi.Text = File.ReadAllText(path);
                        }
                        setGiaTriLuu(path);
                        rtxGhi.Visible = true;
                        ktTrangThai = true;
                        tscCongCu.Enabled = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Không hổ trợ định dạng file", "Thông báo");
                }
            }
   

        }


        // Lưu File
        private void tsmiSave_Click(object sender, EventArgs e)
        {
            try
            {

                string path = "";
                SaveFileDialog save = new SaveFileDialog();

                save.Title = "Chọn Ảnh";
                save.Filter = "Luu File (*.rtf)|*.rtf| (*.txt)|*.txt";
                save.FilterIndex = 1;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    path = save.FileName;
                    setGiaTriLuu(path);

                    if (path != "")
                    {
                        ktTrangThai = true;
                        rtxGhi.SaveFile(path);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Bị sai");
            }

        }

        private void setGiaTriLuu(string path)
        {
            curOpen = true;
            curDuongDan = path;
            string[] s = path.Split('\\');
            tslbDuongDan.Text = s[s.Length - 1];
        }




        // Màu
        private void tsbtnColor_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog color = new ColorDialog();
                if (color.ShowDialog() == DialogResult.OK)
                {
                    rtxGhi.SelectionBackColor = color.Color;
                    lbColorBack.BackColor = color.Color;
                }
            }
            catch
            {

            }
        }


        // Chữ
        private void tsbtnTextColor_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog color = new ColorDialog();
                if (color.ShowDialog() == DialogResult.OK)
                {
                    rtxGhi.SelectionColor = color.Color;
                    tsbtnTextColor.ForeColor = rtxGhi.SelectionColor;
                    lbColorText.BackColor = rtxGhi.SelectionColor;
                }
            }
            catch
            {
                
            }
        }

        // Cỡ Chữ click
        private void tscmbSize_Click(object sender, EventArgs e)
        {
            //sizeText = float.Parse(tscmbSize.SelectedItem.ToString());
        }

        // cỡ chữ sau chọn
        private void tscmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            sizeText = float.Parse(tscmbSize.SelectedItem.ToString());
            rtxGhi.SelectionFont = new Font(fontText, sizeText, (ktDam ? FontStyle.Bold : 0 | (ktNghieng ? FontStyle.Italic : 0) | (ktGachDuoi ? FontStyle.Underline : 0) | (ktGachGiua ? FontStyle.Strikeout : 0)));
        }
        //Mở ảnh
        private void tsbtnHinhAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog Mo_Anh = new OpenFileDialog();
            Mo_Anh.Title = "Chọn Ảnh";
            Mo_Anh.Filter = "Hinh Anh|*.bmp;*.jpg;*.gif;*.png;*.tif";
            try
            {
                if (Mo_Anh.ShowDialog() == DialogResult.OK)
                {

                    string fileName = Mo_Anh.FileName;
                    if (fileName.EndsWith(".tif") || fileName.EndsWith(".png") || fileName.EndsWith(".bmp") || fileName.EndsWith(".gif")
                        || fileName.EndsWith(".jpg"))
                    {
                        Clipboard.SetImage(Image.FromFile(fileName));
                        rtxGhi.Paste();
                        /*
                        Bitmap bitmap = new Bitmap(fileName);


                        Clipboard.SetDataObject(bitmap);

                        DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);

                        if (rtxGhi.CanPaste(myFormat))
                        {
                            rtxGhi.Paste(myFormat);
                        }
                        */
                    }
                    else
                    {
                        MessageBox.Show("Định Dạng Ảnh Không hợp lệ", "Lỗi Định Dạng");

                    }
                }
            }
            catch
            {

            }
            
        }


        // phông chữ
        private void tscmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            fontText = tscmbFont.SelectedItem.ToString();
            rtxGhi.SelectionFont = new Font(fontText,sizeText, (ktDam ? FontStyle.Bold : 0 | (ktNghieng ? FontStyle.Italic : 0) | (ktGachDuoi ? FontStyle.Underline : 0) | (ktGachGiua ? FontStyle.Strikeout : 0)));
        }
       
        private Hashtable s = new Hashtable();


        /*
         * 
         * 
         * 
         * */
        // chọn kiểu chữ

        private bool ktDam = false;
        private bool ktNghieng = false;
        private bool ktGachDuoi = false;
        private bool ktGachGiua = false;
        private void tsbtnKieuChuClick(object sender, EventArgs e)
        {
            try
            {
                
                ToolStripButton s = (ToolStripButton)sender;
                if (s.Name == "tsbtnChuDam")
                {
                    if (s.BackColor == SystemColors.Control)
                    {

                        rtxGhi.SelectionFont = new Font(fontText, sizeText, (FontStyle.Bold | (ktNghieng ? FontStyle.Italic : 0) | (ktGachDuoi ? FontStyle.Underline : 0) | (ktGachGiua ? FontStyle.Strikeout : 0)));
                        s.BackColor = SystemColors.GradientActiveCaption;
                        ktDam = true;
                    }
                    else
                    {
                        rtxGhi.SelectionFont = new Font(fontText, sizeText, (FontStyle.Regular | (ktNghieng ? FontStyle.Italic : 0) | (ktGachDuoi ? FontStyle.Underline : 0) | (ktGachGiua ? FontStyle.Strikeout : 0)));
                        s.BackColor = SystemColors.Control;
                        ktDam = false;
                    }
                }
                else if (s.Name == "tsbtnChuNghieng")
                {
                    if (s.BackColor == SystemColors.Control)
                    {

                        rtxGhi.SelectionFont = new Font(fontText, sizeText, (FontStyle.Italic | (ktDam ? FontStyle.Bold : 0) | (ktGachDuoi ? FontStyle.Underline : 0) | (ktGachGiua ? FontStyle.Strikeout : 0)));
                        s.BackColor = SystemColors.GradientActiveCaption;
                        ktNghieng = true;
                    }
                    else
                    {
                        rtxGhi.SelectionFont = new Font(fontText, sizeText, (FontStyle.Regular | (ktDam ? FontStyle.Bold : 0) | (ktGachDuoi ? FontStyle.Underline : 0) | (ktGachGiua ? FontStyle.Strikeout : 0)));
                        s.BackColor = SystemColors.Control;
                        ktNghieng = false;
                    }
                }
                else if (s.Name == "tsbtnGachDuoi")
                {
                    if (s.BackColor == SystemColors.Control)
                    {
                        rtxGhi.SelectionFont = new Font(fontText, sizeText, (FontStyle.Underline | (ktNghieng ? FontStyle.Italic : 0) | (ktDam ? FontStyle.Bold : 0) | (ktGachGiua ? FontStyle.Strikeout : 0)));
                        s.BackColor = SystemColors.GradientActiveCaption;
                        ktGachDuoi = true;
                    }
                    else
                    {
                        rtxGhi.SelectionFont = new Font(fontText, sizeText, (FontStyle.Regular | (ktNghieng ? FontStyle.Italic : 0) | (ktDam ? FontStyle.Bold : 0) | (ktGachGiua ? FontStyle.Strikeout : 0)));
                        s.BackColor = SystemColors.Control;
                        ktGachDuoi = false;
                    }
                }
                else if (s.Name == "tsbtnGachGiua")
                {
                    if (s.BackColor == SystemColors.Control)
                    {
                        rtxGhi.SelectionFont = new Font(fontText, sizeText, ((ktGachDuoi ? FontStyle.Underline : 0) | (ktNghieng ? FontStyle.Italic : 0) | (ktDam ? FontStyle.Bold : 0) | FontStyle.Strikeout));
                        s.BackColor = SystemColors.GradientActiveCaption;
                        ktGachGiua = true;
                    }
                    else
                    {
                        rtxGhi.SelectionFont = new Font(fontText, sizeText, (FontStyle.Regular | (ktNghieng ? FontStyle.Italic : 0) | (ktDam ? FontStyle.Underline : 0) | (ktDam ? FontStyle.Bold : 0)));
                        s.BackColor = SystemColors.Control;
                        ktGachGiua = false;
                    }
                }
            }
            catch
            {

            }
           
        }
        
        // tăng giảm cỡ chữ
        private void tsbtnTangGiamChu_Click(object sender, EventArgs e)
        {
            ToolStripButton s = (ToolStripButton)sender;
            
                if (s.Name == "tsbtnTangChu")
                {
                try
                {
                    tscmbSize.SelectedIndex += 1;
                }
                catch(ArgumentOutOfRangeException)
                {
                    return;
                }
                }
                else
                {
                if (tscmbSize.SelectedIndex == 0) return;
                tscmbSize.SelectedIndex -= 1;
                }     
        }

        //parse
        private void tsbtnDan_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text)) rtxGhi.Paste();
        }
        // cut
        private void tsbtnCut_Click(object sender, EventArgs e)
        {
            if (rtxGhi.SelectionLength > 0) rtxGhi.Cut();
        }
        // copy
        private void tsbtnCopy_Click(object sender, EventArgs e)
        {
            if (rtxGhi.SelectionLength > 0) rtxGhi.Copy();
        }

        private void rtxGhi_TextChanged(object sender, EventArgs e)
        {
            tslbTu.Text = "Số Từ: "+Regex.Matches(rtxGhi.Text, @"[\S]+").Count.ToString();
            if (rtxGhi.Text.Length > 0) ktTrangThai = false;
        }

        private void rtxGhi_CursorChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(rtxGhi.Text[rtxGhi.SelectionStart - 1].ToString());
        }


        // kiểm tra vị trí kiểu chữ

        // doi mau chu
      


            // kiểm tra kiểu
        private void rtxGhi_SelectionChanged(object sender, EventArgs e)
        {

            if (rtxGhi.SelectionFont != null)
            {
                tscmbFont.SelectedItem = rtxGhi.SelectionFont.Name;
                tscmbSize.SelectedItem = rtxGhi.SelectionFont.Size+"";
                tsbtnTextColor.ForeColor = rtxGhi.SelectionColor;
                lbColorText.BackColor = rtxGhi.SelectionColor;

                lbColorBack.BackColor = rtxGhi.SelectionBackColor;
                tsbtnChuDam.BackColor = SystemColors.Control;
                tsbtnChuNghieng.BackColor = SystemColors.Control;
                tsbtnGachDuoi.BackColor = SystemColors.Control;
                tsbtnGachGiua.BackColor = SystemColors.Control;
                 ktDam = false;
                 ktNghieng = false;
                 ktGachDuoi = false;
                 ktGachGiua = false;
                if (rtxGhi.SelectionFont.Bold)
                {
                    tsbtnChuDam.BackColor = SystemColors.GradientActiveCaption;
                    ktDam = true;
                }
                

                if (rtxGhi.SelectionFont.Italic)
                {
                    tsbtnChuNghieng.BackColor = SystemColors.GradientActiveCaption;
                    ktNghieng = true;
                }
               
                if (rtxGhi.SelectionFont.Underline)
                {
                    tsbtnGachDuoi.BackColor = SystemColors.GradientActiveCaption;
                    ktGachDuoi = true;
                }

                
                if (rtxGhi.SelectionFont.Strikeout)
                {
                    tsbtnGachGiua.BackColor = SystemColors.GradientActiveCaption;
                    ktGachGiua = true;
                }
                
                // căn lề
                tsbtnCanTrai.BackColor = SystemColors.Control;
                tsbtnCanGiua.BackColor = SystemColors.Control;
                tsbtnCanPhai.BackColor = SystemColors.Control;

                switch (rtxGhi.SelectionAlignment)
                {
                    case HorizontalAlignment.Left:
                        tsbtnCanTrai.BackColor = SystemColors.GradientActiveCaption;
                        break;
                    case HorizontalAlignment.Center:
                        tsbtnCanGiua.BackColor = SystemColors.GradientActiveCaption;
                        break;
                    case HorizontalAlignment.Right:
                        tsbtnCanPhai.BackColor = SystemColors.GradientActiveCaption;
                        break;
                }
            }
        }


        // canh chữ
        private void tsbtnCanChu_Click(object sender, EventArgs e)
        {
            ToolStripButton s = (ToolStripButton)sender;
            tsbtnCanTrai.BackColor = SystemColors.Control;
            tsbtnCanGiua.BackColor = SystemColors.Control;
            tsbtnCanPhai.BackColor = SystemColors.Control;
            
            if (s.Name == "tsbtnCanTrai")
            {
                rtxGhi.SelectionAlignment = HorizontalAlignment.Left;
                tsbtnCanTrai.BackColor = SystemColors.GradientActiveCaption;

            }
            else if(s.Name == "tsbtnCanGiua")
            {
                rtxGhi.SelectionAlignment = HorizontalAlignment.Center;
                tsbtnCanGiua.BackColor = SystemColors.GradientActiveCaption;

            }
            else if(s.Name == "tsbtnCanPhai")
            {
                rtxGhi.SelectionAlignment = HorizontalAlignment.Right;
                tsbtnCanPhai.BackColor = SystemColors.GradientActiveCaption;

            }    
        }

        private void tsmnIn_Click(object sender, EventArgs e)
        {
            if (prd.ShowDialog() == DialogResult.OK)
            {
                pdc.Print();
            }
        }

        private void pdc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            char[] param = { '\n' };

            if (prd.PrinterSettings.PrintRange == PrintRange.Selection)
            {
                lines = rtxGhi.SelectedText.Split(param);
            }
            else
            {
                lines = rtxGhi.Text.Split(param);
            }

            int i = 0;
            char[] trimParam = { '\r' };
            foreach (string s in lines)
            {
                lines[i++] = s.TrimEnd(trimParam);
            }
        }

        private int linesPrinted;
        private string[] lines;

        
        private void pdc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (lines.Length <= 0) return;
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Brush brush = new SolidBrush(rtxGhi.ForeColor);

            while (linesPrinted < lines.Length)
            {
                e.Graphics.DrawString(lines[linesPrinted++],
                    rtxGhi.Font, brush, x, y);
                y += 15;
                if (y >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            linesPrinted = 0;
            e.HasMorePages = false;
        }
        public RichTextBox getRtxGhi()
        {
            return this.rtxGhi;
        }

        
    
        private void tsbtnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem timKiem = new TimKiem(rtxGhi);
            timKiem.Show(this);
        }


       
        private void tsbtnThayThe_Click(object sender, EventArgs e)
        {
           ThayThe thayThe = new ThayThe(this.rtxGhi);
           thayThe.Show(this);
        }

        private float size_PhongTo = 1;
        private void tsmiPhongTo_Click(object sender, EventArgs e)
        {
            
            if (size_PhongTo >= 64) return;
            size_PhongTo += 2;
            this.rtxGhi.ZoomFactor = size_PhongTo;
            
        }

        private void tsmiThuNho_Click(object sender, EventArgs e)
        {

            if (size_PhongTo - 2 < 1) return;
            else size_PhongTo -= 2;
            this.rtxGhi.ZoomFactor = size_PhongTo;
            
        }


        // undo
        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            this.rtxGhi.Undo();
        }

        private void tsmiRedo_Click(object sender, EventArgs e)
        {
            this.rtxGhi.Redo();
        }




        // ----------------------- Xử lý Chuột phải --------------------------------

        private void cms_tsmi_Undo_Click(object sender, EventArgs e)
        {
            this.rtxGhi.Undo();
        }

        private void cms_tsmi_Redo_Click(object sender, EventArgs e)
        {
            this.rtxGhi.Redo();
        }

      

        // dán
        private void cms_tsmi_Dan_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text)) this.rtxGhi.Paste();
        }
        // cut
        private void cms_tsmi_Cat_Click(object sender, EventArgs e)
        {
            this.rtxGhi.Cut();
        }
        // copy
        private void cms_tsmi_Copy_Click(object sender, EventArgs e)
        {
            this.rtxGhi.Copy();
        }

        private void tsmiXemIn_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog(this);
        }

        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            this.rtxGhi.Copy();
        }

        private void tsmiCat_Click(object sender, EventArgs e)
        {
            this.rtxGhi.Cut();
        }

        private void tsmiDan_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text)) this.rtxGhi.Paste();
        }



        private bool click = true;
        private void tsbtnEmoji_Click(object sender, EventArgs e)
        {
            if (click)
            {
                lvEmoji.Visible = true;
                click = false;
            }
            else
            {
                lvEmoji.Visible = false;
                click = true;
            }
        }


        public static String duongDan()
        {
            string duongDan = Environment.CurrentDirectory.ToString(); // lấy đường dẫn thư mục
            var url = Directory.GetParent(Directory.GetParent(duongDan).ToString()); // lấy thư mục cha

            return url.ToString();

        }
        private void chenEmoji()
        {
            string path = duongDan() + @"\Emoij"; // lấy đường dẫn
           
            string[] files = Directory.GetFiles(path); // lấy tên file là ảnh
            
            foreach(String f in files)
            {
                Image img = Image.FromFile(f);  // từ cái file đó chuyển qua định dạng ảnh
                imgEmoji.Images.Add(img); // bỏ vào img list
            }
            this.lvEmoji.View = View.LargeIcon;
            this.imgEmoji.ImageSize = new Size(32, 32);
            
            this.lvEmoji.LargeImageList = this.imgEmoji;
            for(int i = 0; i < this.imgEmoji.Images.Count;i++)
            {
                this.lvEmoji.Items.Add(" ",i);
            }
      
        }

        private void lvEmoji_MouseLeave(object sender, EventArgs e)
        {
            lvEmoji.Visible = false;
            click = true;
        }

        private int id = 0;
        private void lvEmoji_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvEmoji.SelectedIndices.Count <= 0) return;
            if(lvEmoji.FocusedItem == null) return;
            id = lvEmoji.SelectedIndices[0];
            if(id < 0) return;
            Clipboard.SetImage(imgEmoji.Images[id]);
            rtxGhi.Paste();
        }

        // Lưu
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(curOpen)
            {
                ktTrangThai = true;
                rtxGhi.SaveFile(curDuongDan);
            }
            else
            {
                tsmiSave.PerformClick();
            }
            
        }

 
       
       private void ktDong()
        {
            if (!ktTrangThai)
            {
                DialogResult tb = MessageBox.Show("Bạn có muốn lưu lại thay đổi không? ", "Thông báo", MessageBoxButtons.YesNoCancel);

                switch (tb)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Yes:
                        tsmiLuu.PerformClick();
                        break;
                }
            }
        }
        // mới 
        private void tsmiNew_Click(object sender, EventArgs e)
        {
            
            ktDong();
            rtxGhi.Clear();
            ktDam = false;
            ktNghieng = false;
            ktGachDuoi = false;
            ktGachGiua = false;
            tscmbFont.SelectedItem = "Times New Roman";
            tscmbSize.SelectedItem = "11";
            fontText = "Times New Roman";
            sizeText = float.Parse(tscmbSize.SelectedItem.ToString());
            
            rtxGhi.Visible = true;
            tscCongCu.Enabled = true;
            rtxGhi.Visible = true;
            ktTrangThai = true;
            giaTriMoi();
            rtxGhi.SelectionFont = new Font(fontText, sizeText);
        }

        private void giaTriMoi()
        {
            curOpen = false;
            curDuongDan = "";
            tslbDuongDan.Text = "MiniWord";
        }
        // đóng
        private void tsmiDong_Click(object sender, EventArgs e)
        {
            ktDong();
            ktTrangThai = true;
            rtxGhi.Text = "";
            tscCongCu.Enabled = false;
            rtxGhi.Visible = false;
            giaTriMoi();
            
        }

        // thoát 
        private void tsmiThoat_Click(object sender, EventArgs e)
        {
            ktDong();
            this.Close();
        }

        private void tsbtnNgayvaGio_Click(object sender, EventArgs e)
        {
            NgayVaGio ngay = new NgayVaGio(this.rtxGhi);
            ngay.Show(this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            rtxGhi.Undo();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            rtxGhi.Redo();
        }

        private void FrmHieu_FormClosing(object sender, FormClosingEventArgs e)
        {
           

            if (!ktTrangThai)
            {
                DialogResult tb = MessageBox.Show("Bạn có muốn lưu lại thay đổi không? ", "Thông báo", MessageBoxButtons.YesNoCancel);

                switch(tb)
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.No:          
                        break;
                    case DialogResult.Yes:
                        //SaveMenuButton_Click(sender, e);
                        tsmiLuu.PerformClick();
                        break;
                }
            }
            
             
        }

        private void tsmiTimKiem_Click(object sender, EventArgs e)
        {
            toolStripButton3.PerformClick();
        }

        private void tsmiTimKiemThayThe_Click(object sender, EventArgs e)
        {
            tsbtnThayThe.PerformClick();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnTangChu_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void tsbtnDan_Click_1(object sender, EventArgs e)
        {
            rtxGhi.Paste();
        }

       

   

        private void boiDenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbtnChuDam.PerformClick();
        }

        private void boiDamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbtnChuNghieng.PerformClick();
        }

        private void gachChanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbtnGachDuoi.PerformClick();
        }

        private void gachGiuaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
