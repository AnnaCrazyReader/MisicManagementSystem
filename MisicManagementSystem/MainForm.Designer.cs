using System.Windows.Forms;

namespace MisicManagementSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabArtists = new System.Windows.Forms.TabPage();
            this.tabSongs = new System.Windows.Forms.TabPage();
            this.dgvArtists = new System.Windows.Forms.DataGridView();
            this.dgvSongs = new System.Windows.Forms.DataGridView();
            this.artistButtonPanel = new System.Windows.Forms.Panel();
            this.SongButtonPanel = new System.Windows.Forms.Panel();
            this.btnAddArtist = new System.Windows.Forms.Button();
            this.btnEditArtist = new System.Windows.Forms.Button();
            this.btnDeleteArtist = new System.Windows.Forms.Button();
            this.btnViewArtistDetails = new System.Windows.Forms.Button();
            this.btnAddSong = new System.Windows.Forms.Button();
            this.btnEditSong = new System.Windows.Forms.Button();
            this.btnDeleteSong = new System.Windows.Forms.Button();
            this.btnViewSongDetails = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabArtists.SuspendLayout();
            this.tabSongs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSongs)).BeginInit();
            this.artistButtonPanel.SuspendLayout();
            this.SongButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(200, 100);
            this.tabPage1.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.exitToolStripMenuItem.Text = "Вихід";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.helpToolStripMenuItem.Text = "Допомога";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.aboutToolStripMenuItem.Text = "Про програму";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabArtists);
            this.tabControl1.Controls.Add(this.tabSongs);
            this.tabControl1.Location = new System.Drawing.Point(0, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 420);
            this.tabControl1.TabIndex = 1;
            // 
            // tabArtists
            // 
            this.tabArtists.Controls.Add(this.artistButtonPanel);
            this.tabArtists.Controls.Add(this.dgvArtists);
            this.tabArtists.Location = new System.Drawing.Point(4, 22);
            this.tabArtists.Name = "tabArtists";
            this.tabArtists.Padding = new System.Windows.Forms.Padding(3);
            this.tabArtists.Size = new System.Drawing.Size(792, 394);
            this.tabArtists.TabIndex = 0;
            this.tabArtists.Text = "Виконавці";
            this.tabArtists.UseVisualStyleBackColor = true;
            // 
            // tabSongs
            // 
            this.tabSongs.Controls.Add(this.SongButtonPanel);
            this.tabSongs.Controls.Add(this.dgvSongs);
            this.tabSongs.Location = new System.Drawing.Point(4, 22);
            this.tabSongs.Name = "tabSongs";
            this.tabSongs.Padding = new System.Windows.Forms.Padding(3);
            this.tabSongs.Size = new System.Drawing.Size(792, 394);
            this.tabSongs.TabIndex = 1;
            this.tabSongs.Text = "Пісні";
            this.tabSongs.UseVisualStyleBackColor = true;
            // 
            // dgvArtists
            // 
            this.dgvArtists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtists.Location = new System.Drawing.Point(168, 3);
            this.dgvArtists.Name = "dgvArtists";
            this.dgvArtists.Size = new System.Drawing.Size(616, 384);
            this.dgvArtists.TabIndex = 0;
            // 
            // dgvSongs
            // 
            this.dgvSongs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSongs.Location = new System.Drawing.Point(161, 1);
            this.dgvSongs.Name = "dgvSongs";
            this.dgvSongs.Size = new System.Drawing.Size(628, 393);
            this.dgvSongs.TabIndex = 0;
            // 
            // artistButtonPanel
            // 
            this.artistButtonPanel.Controls.Add(this.btnViewArtistDetails);
            this.artistButtonPanel.Controls.Add(this.btnDeleteArtist);
            this.artistButtonPanel.Controls.Add(this.btnEditArtist);
            this.artistButtonPanel.Controls.Add(this.btnAddArtist);
            this.artistButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.artistButtonPanel.Name = "artistButtonPanel";
            this.artistButtonPanel.Size = new System.Drawing.Size(162, 387);
            this.artistButtonPanel.TabIndex = 1;
            // 
            // SongButtonPanel
            // 
            this.SongButtonPanel.Controls.Add(this.btnViewSongDetails);
            this.SongButtonPanel.Controls.Add(this.btnDeleteSong);
            this.SongButtonPanel.Controls.Add(this.btnEditSong);
            this.SongButtonPanel.Controls.Add(this.btnAddSong);
            this.SongButtonPanel.Location = new System.Drawing.Point(0, 1);
            this.SongButtonPanel.Name = "SongButtonPanel";
            this.SongButtonPanel.Size = new System.Drawing.Size(155, 393);
            this.SongButtonPanel.TabIndex = 1;
            // 
            // btnAddArtist
            // 
            this.btnAddArtist.Location = new System.Drawing.Point(8, 6);
            this.btnAddArtist.Name = "btnAddArtist";
            this.btnAddArtist.Size = new System.Drawing.Size(138, 23);
            this.btnAddArtist.TabIndex = 0;
            this.btnAddArtist.Text = "Додати Виконавці";
            this.btnAddArtist.UseVisualStyleBackColor = true;
            this.btnAddArtist.Click += new System.EventHandler(this.btnAddArtist_Click);
            // 
            // btnEditArtist
            // 
            this.btnEditArtist.Location = new System.Drawing.Point(9, 36);
            this.btnEditArtist.Name = "btnEditArtist";
            this.btnEditArtist.Size = new System.Drawing.Size(137, 23);
            this.btnEditArtist.TabIndex = 1;
            this.btnEditArtist.Text = "Редагувати";
            this.btnEditArtist.UseVisualStyleBackColor = true;
            this.btnEditArtist.Click += new System.EventHandler(this.btnEditArtist_Click);
            // 
            // btnDeleteArtist
            // 
            this.btnDeleteArtist.Location = new System.Drawing.Point(9, 65);
            this.btnDeleteArtist.Name = "btnDeleteArtist";
            this.btnDeleteArtist.Size = new System.Drawing.Size(137, 23);
            this.btnDeleteArtist.TabIndex = 2;
            this.btnDeleteArtist.Text = "Видалити";
            this.btnDeleteArtist.UseVisualStyleBackColor = true;
            this.btnDeleteArtist.Click += new System.EventHandler(this.btnDeleteArtist_Click);
            // 
            // btnViewArtistDetails
            // 
            this.btnViewArtistDetails.Location = new System.Drawing.Point(9, 95);
            this.btnViewArtistDetails.Name = "btnViewArtistDetails";
            this.btnViewArtistDetails.Size = new System.Drawing.Size(137, 23);
            this.btnViewArtistDetails.TabIndex = 3;
            this.btnViewArtistDetails.Text = "Профіль";
            this.btnViewArtistDetails.UseVisualStyleBackColor = true;
            this.btnViewArtistDetails.Click += new System.EventHandler(this.btnViewArtistDetails_Click);
            // 
            // btnAddSong
            // 
            this.btnAddSong.Location = new System.Drawing.Point(9, 6);
            this.btnAddSong.Name = "btnAddSong";
            this.btnAddSong.Size = new System.Drawing.Size(143, 23);
            this.btnAddSong.TabIndex = 0;
            this.btnAddSong.Text = "Додати пісню";
            this.btnAddSong.UseVisualStyleBackColor = true;
            // 
            // btnEditSong
            // 
            this.btnEditSong.Location = new System.Drawing.Point(9, 36);
            this.btnEditSong.Name = "btnEditSong";
            this.btnEditSong.Size = new System.Drawing.Size(143, 23);
            this.btnEditSong.TabIndex = 1;
            this.btnEditSong.Text = "Редагувати";
            this.btnEditSong.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSong
            // 
            this.btnDeleteSong.Location = new System.Drawing.Point(9, 66);
            this.btnDeleteSong.Name = "btnDeleteSong";
            this.btnDeleteSong.Size = new System.Drawing.Size(143, 23);
            this.btnDeleteSong.TabIndex = 2;
            this.btnDeleteSong.Text = "Видалити";
            this.btnDeleteSong.UseVisualStyleBackColor = true;
            // 
            // btnViewSongDetails
            // 
            this.btnViewSongDetails.Location = new System.Drawing.Point(9, 96);
            this.btnViewSongDetails.Name = "btnViewSongDetails";
            this.btnViewSongDetails.Size = new System.Drawing.Size(143, 23);
            this.btnViewSongDetails.TabIndex = 3;
            this.btnViewSongDetails.Text = "Профіль";
            this.btnViewSongDetails.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Система керування музикою";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabArtists.ResumeLayout(false);
            this.tabSongs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSongs)).EndInit();
            this.artistButtonPanel.ResumeLayout(false);
            this.SongButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TabPage tabPage1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private MenuStrip menuStrip1;
        private TabControl tabControl1;
        private TabPage tabArtists;
        private TabPage tabSongs;
        private DataGridView dgvArtists;
        private DataGridView dgvSongs;
        private Panel artistButtonPanel;
        private Button btnViewArtistDetails;
        private Button btnDeleteArtist;
        private Button btnEditArtist;
        private Button btnAddArtist;
        private Panel SongButtonPanel;
        private Button btnAddSong;
        private Button btnViewSongDetails;
        private Button btnDeleteSong;
        private Button btnEditSong;
    }
}

