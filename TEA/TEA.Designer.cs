namespace A51
{
    partial class TEA
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.IVStatusLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxIV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.keyStatusLbl = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.programLogLv = new System.Windows.Forms.ListView();
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Action = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.decryptBtn = new System.Windows.Forms.Button();
            this.encryptBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.encryptAllBtn = new System.Windows.Forms.Button();
            this.outputLocationBtn = new System.Windows.Forms.Button();
            this.outputLbl = new System.Windows.Forms.Label();
            this.fileSystemWatcherCB = new System.Windows.Forms.CheckBox();
            this.inputLbl = new System.Windows.Forms.Label();
            this.inputLocationBtn = new System.Windows.Forms.Button();
            this.fileNameLbl = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.decryptImageBtn = new System.Windows.Forms.Button();
            this.encryptImageBtn = new System.Windows.Forms.Button();
            this.beforeAfterLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.IVStatusLbl);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxIV);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.keyStatusLbl);
            this.groupBox2.Controls.Add(this.textBoxKey);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 131);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Key";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(236, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Key is 128 bits value.";
            // 
            // IVStatusLbl
            // 
            this.IVStatusLbl.AutoSize = true;
            this.IVStatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IVStatusLbl.ForeColor = System.Drawing.Color.Red;
            this.IVStatusLbl.Location = new System.Drawing.Point(82, 107);
            this.IVStatusLbl.Name = "IVStatusLbl";
            this.IVStatusLbl.Size = new System.Drawing.Size(41, 16);
            this.IVStatusLbl.TabIndex = 12;
            this.IVStatusLbl.Text = "No IV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "IV status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "IV:";
            // 
            // textBoxIV
            // 
            this.textBoxIV.Location = new System.Drawing.Point(40, 46);
            this.textBoxIV.Name = "textBoxIV";
            this.textBoxIV.Size = new System.Drawing.Size(302, 20);
            this.textBoxIV.TabIndex = 9;
            this.textBoxIV.TextChanged += new System.EventHandler(this.textBoxIV_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(249, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "IV is 64 bits value.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Key Status:";
            // 
            // keyStatusLbl
            // 
            this.keyStatusLbl.AutoSize = true;
            this.keyStatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyStatusLbl.ForeColor = System.Drawing.Color.Red;
            this.keyStatusLbl.Location = new System.Drawing.Point(82, 78);
            this.keyStatusLbl.Name = "keyStatusLbl";
            this.keyStatusLbl.Size = new System.Drawing.Size(51, 16);
            this.keyStatusLbl.TabIndex = 7;
            this.keyStatusLbl.Text = "No key";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(40, 19);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(302, 20);
            this.textBoxKey.TabIndex = 4;
            this.textBoxKey.TextChanged += new System.EventHandler(this.textBoxKey_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Key:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.programLogLv);
            this.groupBox4.Location = new System.Drawing.Point(368, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(397, 388);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Program Log";
            // 
            // programLogLv
            // 
            this.programLogLv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Number,
            this.fileName,
            this.Action,
            this.Time});
            this.programLogLv.FullRowSelect = true;
            this.programLogLv.Location = new System.Drawing.Point(6, 14);
            this.programLogLv.Name = "programLogLv";
            this.programLogLv.Size = new System.Drawing.Size(385, 368);
            this.programLogLv.TabIndex = 0;
            this.programLogLv.UseCompatibleStateImageBehavior = false;
            this.programLogLv.View = System.Windows.Forms.View.Details;
            // 
            // Number
            // 
            this.Number.Text = "#";
            this.Number.Width = 34;
            // 
            // fileName
            // 
            this.fileName.Text = "File Name";
            this.fileName.Width = 136;
            // 
            // Action
            // 
            this.Action.Text = "Action";
            this.Action.Width = 106;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 102;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.decryptBtn);
            this.groupBox3.Controls.Add(this.encryptBtn);
            this.groupBox3.Location = new System.Drawing.Point(12, 317);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 83);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encryption or Decryption";
            // 
            // decryptBtn
            // 
            this.decryptBtn.Location = new System.Drawing.Point(8, 48);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(334, 23);
            this.decryptBtn.TabIndex = 0;
            this.decryptBtn.Text = "Select File For Decryption ";
            this.decryptBtn.UseVisualStyleBackColor = true;
            this.decryptBtn.Click += new System.EventHandler(this.decryptBtn_Click);
            // 
            // encryptBtn
            // 
            this.encryptBtn.Location = new System.Drawing.Point(8, 19);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(334, 23);
            this.encryptBtn.TabIndex = 2;
            this.encryptBtn.Text = "Select File For Encryption ";
            this.encryptBtn.UseVisualStyleBackColor = true;
            this.encryptBtn.Click += new System.EventHandler(this.encryptBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.encryptAllBtn);
            this.groupBox1.Controls.Add(this.outputLocationBtn);
            this.groupBox1.Controls.Add(this.outputLbl);
            this.groupBox1.Controls.Add(this.fileSystemWatcherCB);
            this.groupBox1.Controls.Add(this.inputLbl);
            this.groupBox1.Controls.Add(this.inputLocationBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 162);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input And Output Location";
            // 
            // encryptAllBtn
            // 
            this.encryptAllBtn.Location = new System.Drawing.Point(174, 120);
            this.encryptAllBtn.Name = "encryptAllBtn";
            this.encryptAllBtn.Size = new System.Drawing.Size(169, 23);
            this.encryptAllBtn.TabIndex = 7;
            this.encryptAllBtn.Text = "Encrypt all in selecteed folder";
            this.encryptAllBtn.UseVisualStyleBackColor = true;
            this.encryptAllBtn.Click += new System.EventHandler(this.encryptAllBtn_Click);
            // 
            // outputLocationBtn
            // 
            this.outputLocationBtn.Location = new System.Drawing.Point(9, 65);
            this.outputLocationBtn.Name = "outputLocationBtn";
            this.outputLocationBtn.Size = new System.Drawing.Size(334, 23);
            this.outputLocationBtn.TabIndex = 6;
            this.outputLocationBtn.Text = "Select Output Location";
            this.outputLocationBtn.UseVisualStyleBackColor = true;
            this.outputLocationBtn.Click += new System.EventHandler(this.outputLocationBtn_Click);
            // 
            // outputLbl
            // 
            this.outputLbl.AutoSize = true;
            this.outputLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLbl.Location = new System.Drawing.Point(6, 91);
            this.outputLbl.Name = "outputLbl";
            this.outputLbl.Size = new System.Drawing.Size(340, 13);
            this.outputLbl.TabIndex = 1;
            this.outputLbl.Text = "Default output location is the same as file location, but with postfix dec.";
            // 
            // fileSystemWatcherCB
            // 
            this.fileSystemWatcherCB.AutoSize = true;
            this.fileSystemWatcherCB.Location = new System.Drawing.Point(9, 126);
            this.fileSystemWatcherCB.Name = "fileSystemWatcherCB";
            this.fileSystemWatcherCB.Size = new System.Drawing.Size(159, 17);
            this.fileSystemWatcherCB.TabIndex = 5;
            this.fileSystemWatcherCB.Text = "Enable File System Watcher";
            this.fileSystemWatcherCB.UseVisualStyleBackColor = true;
            this.fileSystemWatcherCB.CheckedChanged += new System.EventHandler(this.fileSystemWatcherCB_CheckedChanged);
            // 
            // inputLbl
            // 
            this.inputLbl.AutoSize = true;
            this.inputLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputLbl.Location = new System.Drawing.Point(6, 48);
            this.inputLbl.Name = "inputLbl";
            this.inputLbl.Size = new System.Drawing.Size(29, 13);
            this.inputLbl.TabIndex = 4;
            this.inputLbl.Text = "Path";
            // 
            // inputLocationBtn
            // 
            this.inputLocationBtn.Location = new System.Drawing.Point(9, 20);
            this.inputLocationBtn.Name = "inputLocationBtn";
            this.inputLocationBtn.Size = new System.Drawing.Size(334, 23);
            this.inputLocationBtn.TabIndex = 0;
            this.inputLocationBtn.Text = "Select Input Location";
            this.inputLocationBtn.UseVisualStyleBackColor = true;
            this.inputLocationBtn.Click += new System.EventHandler(this.inputLocationBtn_Click);
            // 
            // fileNameLbl
            // 
            this.fileNameLbl.AutoSize = true;
            this.fileNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameLbl.Location = new System.Drawing.Point(12, 403);
            this.fileNameLbl.Name = "fileNameLbl";
            this.fileNameLbl.Size = new System.Drawing.Size(13, 18);
            this.fileNameLbl.TabIndex = 19;
            this.fileNameLbl.Text = "-";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.beforeAfterLbl);
            this.groupBox5.Controls.Add(this.pictureBox);
            this.groupBox5.Controls.Add(this.decryptImageBtn);
            this.groupBox5.Controls.Add(this.encryptImageBtn);
            this.groupBox5.Location = new System.Drawing.Point(772, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(419, 388);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "BMP Image encrypt/decrypt";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(6, 19);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(407, 315);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // decryptImageBtn
            // 
            this.decryptImageBtn.Location = new System.Drawing.Point(213, 353);
            this.decryptImageBtn.Name = "decryptImageBtn";
            this.decryptImageBtn.Size = new System.Drawing.Size(200, 23);
            this.decryptImageBtn.TabIndex = 1;
            this.decryptImageBtn.Text = "Decrypt image";
            this.decryptImageBtn.UseVisualStyleBackColor = true;
            this.decryptImageBtn.Click += new System.EventHandler(this.decryptImageBtn_Click);
            // 
            // encryptImageBtn
            // 
            this.encryptImageBtn.Location = new System.Drawing.Point(6, 353);
            this.encryptImageBtn.Name = "encryptImageBtn";
            this.encryptImageBtn.Size = new System.Drawing.Size(200, 23);
            this.encryptImageBtn.TabIndex = 0;
            this.encryptImageBtn.Text = "Encrypt image";
            this.encryptImageBtn.UseVisualStyleBackColor = true;
            this.encryptImageBtn.Click += new System.EventHandler(this.encryptImageBtn_Click);
            // 
            // beforeAfterLbl
            // 
            this.beforeAfterLbl.AutoSize = true;
            this.beforeAfterLbl.Location = new System.Drawing.Point(6, 337);
            this.beforeAfterLbl.Name = "beforeAfterLbl";
            this.beforeAfterLbl.Size = new System.Drawing.Size(10, 13);
            this.beforeAfterLbl.TabIndex = 3;
            this.beforeAfterLbl.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(132, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Click on image to see image before encryption/decryption.";
            // 
            // TEA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 431);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.fileNameLbl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TEA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TEA";
            this.Load += new System.EventHandler(this.A51_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label keyStatusLbl;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView programLogLv;
        private System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.ColumnHeader fileName;
        private System.Windows.Forms.ColumnHeader Action;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button decryptBtn;
        private System.Windows.Forms.Button encryptBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button encryptAllBtn;
        private System.Windows.Forms.Button outputLocationBtn;
        private System.Windows.Forms.Label outputLbl;
        private System.Windows.Forms.CheckBox fileSystemWatcherCB;
        private System.Windows.Forms.Label inputLbl;
        private System.Windows.Forms.Button inputLocationBtn;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.Label fileNameLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxIV;
        private System.Windows.Forms.Label IVStatusLbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button decryptImageBtn;
        private System.Windows.Forms.Button encryptImageBtn;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label beforeAfterLbl;
        private System.Windows.Forms.Label label4;
    }
}

