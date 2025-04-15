namespace MusicManagementSystem
{
    partial class ArtistDetailsForm
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
            this.txtArtistName = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.numBirthYear = new System.Windows.Forms.NumericUpDown();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLoadPic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numBirthYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtArtistName
            // 
            this.txtArtistName.Location = new System.Drawing.Point(135, 31);
            this.txtArtistName.Name = "txtArtistName";
            this.txtArtistName.Size = new System.Drawing.Size(162, 20);
            this.txtArtistName.TabIndex = 0;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(135, 66);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(162, 20);
            this.txtCountry.TabIndex = 1;
            // 
            // numBirthYear
            // 
            this.numBirthYear.Location = new System.Drawing.Point(135, 105);
            this.numBirthYear.Name = "numBirthYear";
            this.numBirthYear.Size = new System.Drawing.Size(162, 20);
            this.numBirthYear.TabIndex = 2;
            // 
            // cmbGenre
            // 
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Location = new System.Drawing.Point(135, 140);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(162, 21);
            this.cmbGenre.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(325, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 218);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(222, 273);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Зберігти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ім\'я:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Країна:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Вік:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Жанр:";
            // 
            // btnLoadPic
            // 
            this.btnLoadPic.Location = new System.Drawing.Point(325, 273);
            this.btnLoadPic.Name = "btnLoadPic";
            this.btnLoadPic.Size = new System.Drawing.Size(166, 23);
            this.btnLoadPic.TabIndex = 11;
            this.btnLoadPic.Text = "Завантажити фото";
            this.btnLoadPic.UseVisualStyleBackColor = true;
            this.btnLoadPic.Click += new System.EventHandler(this.btnLoadPic_Click);
            // 
            // ArtistDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 368);
            this.Controls.Add(this.btnLoadPic);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.numBirthYear);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.txtArtistName);
            this.Name = "ArtistDetailsForm";
            this.Text = "Інформація про виконавця";
            this.Load += new System.EventHandler(this.ArtistDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numBirthYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArtistName;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.NumericUpDown numBirthYear;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLoadPic;
    }
}