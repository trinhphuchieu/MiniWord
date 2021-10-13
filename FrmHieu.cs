using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniWord_TrinhPhucHieu
{
    public partial class FrmHieu : Form
    {
        public FrmHieu()
        {
            InitializeComponent();
            FontText();
            tscmbFont.SelectedItem = "Times New Roman";
            tscmbSize.SelectedItem = "11";
          
        }


        // thuộc tính 

        private float sizeText = 11;
        private string fontText = "Times New Roman";




        

        // định dạng phông chữ
        private void FontText()
        {
            foreach(FontFamily f in FontFamily.Families)
            {
                tscmbFont.Items.Add(f.Name);
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
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            string path = file.FileName;
            try
            {
            
                if (path != "") rtxGhi.LoadFile(path);
            }catch(ArgumentException)
            {
                MessageBox.Show("Không hổ trợ định dạng file","Thông báo");
            }
   

        }


        // Save
        private void tsmiSave_Click(object sender, EventArgs e)
        {
             string path = "";
             SaveFileDialog save = new SaveFileDialog();
             save.ShowDialog();
             path = save.FileName;
             if (path != "") rtxGhi.SaveFile(path); 
        }


        // Lưu File
       


        // Màu
        private void tsbtnColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if(color.ShowDialog() == DialogResult.OK)
            {     
                rtxGhi.SelectionBackColor = color.Color;
            }
        }


        // Chữ
        private void tsbtnTextColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                rtxGhi.SelectionColor = color.Color;
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
            rtxGhi.SelectionFont = new Font(fontText, sizeText);
        }
        //Mở ảnh
        private void tsbtnHinhAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog Mo_Anh = new OpenFileDialog();
            Mo_Anh.Title = "Chọn Ảnh";
            Mo_Anh.Filter = "Hinh Anh|*.bmp;*.jpg;*.gif;*.png;*.tif";
            
            if (Mo_Anh.ShowDialog() == DialogResult.OK)
            {

                string fileName = Mo_Anh.FileName;
                if (fileName.EndsWith(".tif") || fileName.EndsWith(".png") || fileName.EndsWith(".bmp") || fileName.EndsWith(".gif")
                    || fileName.EndsWith(".jpg"))
                {


                    Bitmap bitmap = new Bitmap(fileName);
                    
                   
                    Clipboard.SetDataObject(bitmap);

                    DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);

                    if (rtxGhi.CanPaste(myFormat))
                    {
                        rtxGhi.Paste(myFormat);
                    }
                }
                else
                {
                    MessageBox.Show("Định Dạng Ảnh Không hợp lệ", "Lỗi Định Dạng");
                 
                }
            }
        }


        // phông chữ
        private void tscmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            fontText = tscmbFont.SelectedItem.ToString();

            rtxGhi.SelectionFont = new Font(fontText,sizeText);
        }


        private bool ktDam = false;
        private bool ktNghieng = false;
        private bool ktGachDuoi = false;
        private bool ktGachGiua = false;

        // chọn kiểu chữ
        private void tsbtnKieuChuClick(object sender, EventArgs e)
        {
            ToolStripButton s = (ToolStripButton)sender;
            if(s.Name == "tsbtnChuDam")
            {
                
                if(s.BackColor == SystemColors.Control)
                {
                    rtxGhi.SelectionFont = new Font(fontText, sizeText, (FontStyle.Bold|(ktNghieng ? FontStyle.Italic : 0) | (ktGachDuoi ? FontStyle.Underline : 0)| (ktGachGiua ? FontStyle.Strikeout : 0)) );
                    s.BackColor = SystemColors.GradientActiveCaption;
                    ktDam = true;
                }
                else
                {
                    rtxGhi.SelectionFont = new Font(fontText, sizeText, (FontStyle.Regular | (ktNghieng ? FontStyle.Italic : 0) | (ktGachDuoi ? FontStyle.Underline : 0)| (ktGachGiua ? FontStyle.Strikeout : 0)));
                    s.BackColor = SystemColors.Control;
                    ktDam = false;
                }
            }else if(s.Name == "tsbtnChuNghieng")
            {
                if (s.BackColor == SystemColors.Control)
                {
                    rtxGhi.SelectionFont = new Font(fontText, sizeText, (FontStyle.Italic | (ktDam ? FontStyle.Bold : 0) | (ktGachDuoi ? FontStyle.Underline : 0)| (ktGachGiua ? FontStyle.Strikeout : 0)));
                    s.BackColor = SystemColors.GradientActiveCaption;
                    ktNghieng = true;
                }
                else
                {
                    rtxGhi.SelectionFont = new Font(fontText, sizeText, (FontStyle.Regular | (ktDam ? FontStyle.Bold : 0) | (ktGachDuoi ? FontStyle.Underline : 0)| (ktGachGiua ? FontStyle.Strikeout : 0)));
                    s.BackColor = SystemColors.Control;
                    ktNghieng = false;
                }
            }else if(s.Name == "tsbtnGachDuoi")
            {
                if (s.BackColor == SystemColors.Control)
                {
                    rtxGhi.SelectionFont = new Font(fontText, sizeText, (FontStyle.Underline | (ktNghieng ? FontStyle.Italic : 0) | (ktDam ? FontStyle.Bold : 0)| (ktGachGiua ? FontStyle.Strikeout : 0)));
                    s.BackColor = SystemColors.GradientActiveCaption;
                    ktGachDuoi = true;
                }
                else
                {
                    rtxGhi.SelectionFont = new Font(fontText, sizeText, (FontStyle.Regular | (ktNghieng ? FontStyle.Italic : 0) | (ktDam ? FontStyle.Bold : 0)| (ktGachGiua ? FontStyle.Strikeout : 0)));
                    s.BackColor = SystemColors.Control;
                    ktGachDuoi = false;
                }
            }else if(s.Name == "tsbtnGachGiua")
            {
                if (s.BackColor == SystemColors.Control)
                {
                    rtxGhi.SelectionFont = new Font(fontText, sizeText, ((ktGachDuoi ? FontStyle.Underline : 0) | (ktNghieng ? FontStyle.Italic : 0) | (ktDam ? FontStyle.Bold : 0) | FontStyle.Strikeout ));
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
            
            //MessageBox.Show(rtxGhi.Text[rtxGhi.SelectionStart-1].ToString());
        }

        private void rtxGhi_CursorChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(rtxGhi.Text[rtxGhi.SelectionStart - 1].ToString());
        }


        // kiểm tra vị trí kiểu chữ
        private void rtxGhi_SelectionChanged(object sender, EventArgs e)
        {
            if (rtxGhi.SelectionFont != null)
            {
                tsbtnChuDam.BackColor = SystemColors.Control;
                tsbtnChuNghieng.BackColor = SystemColors.Control;
                tsbtnGachDuoi.BackColor = SystemColors.Control;
                tsbtnGachGiua.BackColor = SystemColors.Control;


                if (rtxGhi.SelectionFont.Bold)
                {
                    tsbtnChuDam.BackColor = SystemColors.GradientActiveCaption;
                }

                if (rtxGhi.SelectionFont.Italic)
                {
                    tsbtnChuNghieng.BackColor = SystemColors.GradientActiveCaption;
                }

                if (rtxGhi.SelectionFont.Underline)
                {
                    tsbtnGachDuoi.BackColor = SystemColors.GradientActiveCaption;
                }

                if (rtxGhi.SelectionFont.Strikeout)
                {
                    tsbtnGachGiua.BackColor = SystemColors.GradientActiveCaption;
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
            this.rtxGhi.ZoomFactor = size_PhongTo;
            size_PhongTo += 2;
        }

        private void tsmiThuNho_Click(object sender, EventArgs e)
        {

            if (size_PhongTo - 2 < 1) return;
            else size_PhongTo -= 2;
            this.rtxGhi.ZoomFactor = size_PhongTo;
            
        }

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
    }
}
