
namespace MiniWord_TrinhPhucHieu
{
    partial class ThayThe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.txtThayThe = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnThayThe = new System.Windows.Forms.Button();
            this.btnThayTheAll = new System.Windows.Forms.Button();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.chkWholeWord = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtTimKiem.Location = new System.Drawing.Point(12, 20);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(405, 28);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // txtThayThe
            // 
            this.txtThayThe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtThayThe.Location = new System.Drawing.Point(12, 67);
            this.txtThayThe.Name = "txtThayThe";
            this.txtThayThe.Size = new System.Drawing.Size(405, 28);
            this.txtThayThe.TabIndex = 1;
            this.txtThayThe.TextChanged += new System.EventHandler(this.txtThayThe_TextChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Enabled = false;
            this.btnTimKiem.Location = new System.Drawing.Point(436, 20);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(108, 34);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnThayThe
            // 
            this.btnThayThe.Enabled = false;
            this.btnThayThe.Location = new System.Drawing.Point(436, 67);
            this.btnThayThe.Name = "btnThayThe";
            this.btnThayThe.Size = new System.Drawing.Size(108, 34);
            this.btnThayThe.TabIndex = 3;
            this.btnThayThe.Text = "Thay thế";
            this.btnThayThe.UseVisualStyleBackColor = true;
            this.btnThayThe.Click += new System.EventHandler(this.btnThayThe_Click);
            // 
            // btnThayTheAll
            // 
            this.btnThayTheAll.Enabled = false;
            this.btnThayTheAll.Location = new System.Drawing.Point(436, 110);
            this.btnThayTheAll.Name = "btnThayTheAll";
            this.btnThayTheAll.Size = new System.Drawing.Size(108, 34);
            this.btnThayTheAll.TabIndex = 4;
            this.btnThayTheAll.Text = "Thay thế hết";
            this.btnThayTheAll.UseVisualStyleBackColor = true;
            this.btnThayTheAll.Click += new System.EventHandler(this.btnThayTheAll_Click);
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Location = new System.Drawing.Point(12, 118);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(166, 21);
            this.chkMatchCase.TabIndex = 5;
            this.chkMatchCase.Text = "Phân biệt hoa thường";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // chkWholeWord
            // 
            this.chkWholeWord.AutoSize = true;
            this.chkWholeWord.Location = new System.Drawing.Point(12, 154);
            this.chkWholeWord.Name = "chkWholeWord";
            this.chkWholeWord.Size = new System.Drawing.Size(110, 21);
            this.chkWholeWord.TabIndex = 6;
            this.chkWholeWord.Text = "Toàn bộ chữ";
            this.chkWholeWord.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "Hủy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ThayThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 195);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkWholeWord);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.btnThayTheAll);
            this.Controls.Add(this.btnThayThe);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtThayThe);
            this.Controls.Add(this.txtTimKiem);
            this.Name = "ThayThe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm Kiếm và Thay đổi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.TextBox txtThayThe;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThayThe;
        private System.Windows.Forms.Button btnThayTheAll;
        private System.Windows.Forms.CheckBox chkMatchCase;
        private System.Windows.Forms.CheckBox chkWholeWord;
        private System.Windows.Forms.Button button1;
    }
}