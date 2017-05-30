namespace A51
{
    partial class KeyForm
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
            this.fileNameLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.encryptBtn = new System.Windows.Forms.Button();
            this.skipThisFileBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.keyStatusLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxIV = new System.Windows.Forms.TextBox();
            this.IVStatusLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fileNameLbl
            // 
            this.fileNameLbl.AutoSize = true;
            this.fileNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameLbl.Location = new System.Drawing.Point(76, 116);
            this.fileNameLbl.Name = "fileNameLbl";
            this.fileNameLbl.Size = new System.Drawing.Size(45, 16);
            this.fileNameLbl.TabIndex = 21;
            this.fileNameLbl.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "FileName:";
            // 
            // encryptBtn
            // 
            this.encryptBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.encryptBtn.Enabled = false;
            this.encryptBtn.Location = new System.Drawing.Point(280, 145);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(75, 23);
            this.encryptBtn.TabIndex = 19;
            this.encryptBtn.Text = "Encrypt";
            this.encryptBtn.UseVisualStyleBackColor = true;
            // 
            // skipThisFileBtn
            // 
            this.skipThisFileBtn.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.skipThisFileBtn.Location = new System.Drawing.Point(199, 145);
            this.skipThisFileBtn.Name = "skipThisFileBtn";
            this.skipThisFileBtn.Size = new System.Drawing.Size(75, 23);
            this.skipThisFileBtn.TabIndex = 18;
            this.skipThisFileBtn.Text = "Skip this file";
            this.skipThisFileBtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(248, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Key is 64 bits value.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Key Status:";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(47, 6);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(302, 20);
            this.textBoxKey.TabIndex = 13;
            this.textBoxKey.TextChanged += new System.EventHandler(this.textBoxKey_TextChanged);
            // 
            // keyStatusLbl
            // 
            this.keyStatusLbl.AutoSize = true;
            this.keyStatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyStatusLbl.ForeColor = System.Drawing.Color.Red;
            this.keyStatusLbl.Location = new System.Drawing.Point(88, 69);
            this.keyStatusLbl.Name = "keyStatusLbl";
            this.keyStatusLbl.Size = new System.Drawing.Size(51, 16);
            this.keyStatusLbl.TabIndex = 16;
            this.keyStatusLbl.Text = "No key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Key:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "IV:";
            // 
            // textBoxIV
            // 
            this.textBoxIV.Location = new System.Drawing.Point(47, 32);
            this.textBoxIV.Name = "textBoxIV";
            this.textBoxIV.Size = new System.Drawing.Size(302, 20);
            this.textBoxIV.TabIndex = 22;
            this.textBoxIV.TextChanged += new System.EventHandler(this.textBoxIV_TextChanged);
            // 
            // IVStatusLbl
            // 
            this.IVStatusLbl.AutoSize = true;
            this.IVStatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IVStatusLbl.ForeColor = System.Drawing.Color.Red;
            this.IVStatusLbl.Location = new System.Drawing.Point(88, 91);
            this.IVStatusLbl.Name = "IVStatusLbl";
            this.IVStatusLbl.Size = new System.Drawing.Size(41, 16);
            this.IVStatusLbl.TabIndex = 25;
            this.IVStatusLbl.Text = "No IV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "IV status:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(256, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "IV is 64 bits value.";
            // 
            // KeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 175);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.IVStatusLbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxIV);
            this.Controls.Add(this.fileNameLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.encryptBtn);
            this.Controls.Add(this.skipThisFileBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.keyStatusLbl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "KeyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Key";
            this.Load += new System.EventHandler(this.KeyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fileNameLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button encryptBtn;
        private System.Windows.Forms.Button skipThisFileBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Label keyStatusLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxIV;
        private System.Windows.Forms.Label IVStatusLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}