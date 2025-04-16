namespace MusicManagementSystem
{
    partial class SongDetailsForm
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                // Обов'язково звільніть ресурси медіаплеєра
                if (mediaPlayer != null)
                {
                    mediaPlayer.Dispose();
                    mediaPlayer = null;
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongDetailsForm));
            this.txtSongName = new System.Windows.Forms.TextBox();
            this.txtAlbumTitle = new System.Windows.Forms.TextBox();
            this.cmbArtist = new System.Windows.Forms.ComboBox();
            this.numReleaseYear = new System.Windows.Forms.NumericUpDown();
            this.numDurationMin = new System.Windows.Forms.NumericUpDown();
            this.numDurationSec = new System.Windows.Forms.NumericUpDown();
            this.numPlayCount = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btmLoadMP3 = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnPlayMp3 = new System.Windows.Forms.Button();
            this.lblMp3Status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numReleaseYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDurationMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDurationSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSongName
            // 
            this.txtSongName.Location = new System.Drawing.Point(165, 42);
            this.txtSongName.Name = "txtSongName";
            this.txtSongName.Size = new System.Drawing.Size(151, 20);
            this.txtSongName.TabIndex = 0;
            // 
            // txtAlbumTitle
            // 
            this.txtAlbumTitle.Location = new System.Drawing.Point(165, 79);
            this.txtAlbumTitle.Name = "txtAlbumTitle";
            this.txtAlbumTitle.Size = new System.Drawing.Size(151, 20);
            this.txtAlbumTitle.TabIndex = 1;
            // 
            // cmbArtist
            // 
            this.cmbArtist.FormattingEnabled = true;
            this.cmbArtist.Location = new System.Drawing.Point(165, 119);
            this.cmbArtist.Name = "cmbArtist";
            this.cmbArtist.Size = new System.Drawing.Size(151, 21);
            this.cmbArtist.TabIndex = 2;
            // 
            // numReleaseYear
            // 
            this.numReleaseYear.Location = new System.Drawing.Point(165, 163);
            this.numReleaseYear.Name = "numReleaseYear";
            this.numReleaseYear.Size = new System.Drawing.Size(151, 20);
            this.numReleaseYear.TabIndex = 3;
            // 
            // numDurationMin
            // 
            this.numDurationMin.Location = new System.Drawing.Point(165, 200);
            this.numDurationMin.Name = "numDurationMin";
            this.numDurationMin.Size = new System.Drawing.Size(151, 20);
            this.numDurationMin.TabIndex = 4;
            // 
            // numDurationSec
            // 
            this.numDurationSec.Location = new System.Drawing.Point(166, 246);
            this.numDurationSec.Name = "numDurationSec";
            this.numDurationSec.Size = new System.Drawing.Size(150, 20);
            this.numDurationSec.TabIndex = 5;
            // 
            // numPlayCount
            // 
            this.numPlayCount.Location = new System.Drawing.Point(165, 282);
            this.numPlayCount.Name = "numPlayCount";
            this.numPlayCount.Size = new System.Drawing.Size(151, 20);
            this.numPlayCount.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(565, 243);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Зберігти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(565, 282);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Відмінити";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Назва пісні:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Назва альбома:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Виконавець:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Рік виходу:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Тривалість, мін.:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Тривалість, сек.:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Кількість прослуховувань:";
            // 
            // btmLoadMP3
            // 
            this.btmLoadMP3.Location = new System.Drawing.Point(344, 243);
            this.btmLoadMP3.Name = "btmLoadMP3";
            this.btmLoadMP3.Size = new System.Drawing.Size(140, 23);
            this.btmLoadMP3.TabIndex = 16;
            this.btmLoadMP3.Text = "Завантажити пісню";
            this.btmLoadMP3.UseVisualStyleBackColor = true;
            this.btmLoadMP3.Click += new System.EventHandler(this.btmLoadMP3_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(344, 42);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(296, 150);
            this.axWindowsMediaPlayer1.TabIndex = 17;
            // 
            // btnPlayMp3
            // 
            this.btnPlayMp3.Location = new System.Drawing.Point(344, 279);
            this.btnPlayMp3.Name = "btnPlayMp3";
            this.btnPlayMp3.Size = new System.Drawing.Size(140, 23);
            this.btnPlayMp3.TabIndex = 18;
            this.btnPlayMp3.Text = "Прослухати пісню";
            this.btnPlayMp3.UseVisualStyleBackColor = true;
            this.btnPlayMp3.Click += new System.EventHandler(this.btnPlayMp3_Click);
            // 
            // lblMp3Status
            // 
            this.lblMp3Status.AutoSize = true;
            this.lblMp3Status.Location = new System.Drawing.Point(353, 207);
            this.lblMp3Status.Name = "lblMp3Status";
            this.lblMp3Status.Size = new System.Drawing.Size(100, 13);
            this.lblMp3Status.TabIndex = 19;
            this.lblMp3Status.Text = "Статус MP3 файлу";
            // 
            // SongDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 326);
            this.Controls.Add(this.lblMp3Status);
            this.Controls.Add(this.btnPlayMp3);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.btmLoadMP3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numPlayCount);
            this.Controls.Add(this.numDurationSec);
            this.Controls.Add(this.numDurationMin);
            this.Controls.Add(this.numReleaseYear);
            this.Controls.Add(this.cmbArtist);
            this.Controls.Add(this.txtAlbumTitle);
            this.Controls.Add(this.txtSongName);
            this.Name = "SongDetailsForm";
            this.Text = "Детальний перегляд пісні";
            this.Load += new System.EventHandler(this.SongDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numReleaseYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDurationMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDurationSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSongName;
        private System.Windows.Forms.TextBox txtAlbumTitle;
        private System.Windows.Forms.ComboBox cmbArtist;
        private System.Windows.Forms.NumericUpDown numReleaseYear;
        private System.Windows.Forms.NumericUpDown numDurationMin;
        private System.Windows.Forms.NumericUpDown numDurationSec;
        private System.Windows.Forms.NumericUpDown numPlayCount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btmLoadMP3;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button btnPlayMp3;
        private System.Windows.Forms.Label lblMp3Status;
    }
}