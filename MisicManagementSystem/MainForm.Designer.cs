using System.Windows.Forms;

namespace MusicManagementSystem
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabArtists = new System.Windows.Forms.TabPage();
            this.artistButtonPanel = new System.Windows.Forms.Panel();
            this.btnViewArtistDetails = new System.Windows.Forms.Button();
            this.btnDeleteArtist = new System.Windows.Forms.Button();
            this.btnEditArtist = new System.Windows.Forms.Button();
            this.btnAddArtist = new System.Windows.Forms.Button();
            this.dgvArtists = new System.Windows.Forms.DataGridView();
            this.tabSongs = new System.Windows.Forms.TabPage();
            this.songButtonPanel = new System.Windows.Forms.Panel();
            this.btnViewSongDetails = new System.Windows.Forms.Button();
            this.btnDeleteSong = new System.Windows.Forms.Button();
            this.btnEditSong = new System.Windows.Forms.Button();
            this.btnAddSong = new System.Windows.Forms.Button();
            this.dgvSongs = new System.Windows.Forms.DataGridView();
            this.songFilterPanel = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblSongSearch = new System.Windows.Forms.Label();
            this.txtSongSearch = new System.Windows.Forms.TextBox();
            this.chkSortAscending = new System.Windows.Forms.CheckBox();
            this.cmbSortField = new System.Windows.Forms.ComboBox();
            this.lblSortBy = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabArtists.SuspendLayout();
            this.artistButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtists)).BeginInit();
            this.tabSongs.SuspendLayout();
            this.songButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSongs)).BeginInit();
            this.songFilterPanel.SuspendLayout();
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(852, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabArtists);
            this.tabControl1.Controls.Add(this.tabSongs);
            this.tabControl1.Location = new System.Drawing.Point(0, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(852, 420);
            this.tabControl1.TabIndex = 1;
            // 
            // tabArtists
            // 
            this.tabArtists.Controls.Add(this.artistButtonPanel);
            this.tabArtists.Controls.Add(this.dgvArtists);
            this.tabArtists.Location = new System.Drawing.Point(4, 22);
            this.tabArtists.Name = "tabArtists";
            this.tabArtists.Padding = new System.Windows.Forms.Padding(3);
            this.tabArtists.Size = new System.Drawing.Size(844, 394);
            this.tabArtists.TabIndex = 0;
            this.tabArtists.Text = "Виконавці";
            this.tabArtists.UseVisualStyleBackColor = true;
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
            // dgvArtists
            // 
            this.dgvArtists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtists.Location = new System.Drawing.Point(168, 3);
            this.dgvArtists.Name = "dgvArtists";
            this.dgvArtists.Size = new System.Drawing.Size(676, 384);
            this.dgvArtists.TabIndex = 0;
            // 
            // tabSongs
            // 
            this.tabSongs.Controls.Add(this.songButtonPanel);
            this.tabSongs.Controls.Add(this.dgvSongs);
            this.tabSongs.Location = new System.Drawing.Point(4, 22);
            this.tabSongs.Name = "tabSongs";
            this.tabSongs.Padding = new System.Windows.Forms.Padding(3);
            this.tabSongs.Size = new System.Drawing.Size(844, 394);
            this.tabSongs.TabIndex = 1;
            this.tabSongs.Text = "Пісні";
            this.tabSongs.UseVisualStyleBackColor = true;
            // 
            // songButtonPanel
            // 
            this.songButtonPanel.Controls.Add(this.btnViewSongDetails);
            this.songButtonPanel.Controls.Add(this.btnDeleteSong);
            this.songButtonPanel.Controls.Add(this.btnEditSong);
            this.songButtonPanel.Controls.Add(this.btnAddSong);
            this.songButtonPanel.Location = new System.Drawing.Point(0, 3);
            this.songButtonPanel.Name = "songButtonPanel";
            this.songButtonPanel.Size = new System.Drawing.Size(168, 367);
            this.songButtonPanel.TabIndex = 1;
            // 
            // btnViewSongDetails
            // 
            this.btnViewSongDetails.Location = new System.Drawing.Point(9, 96);
            this.btnViewSongDetails.Name = "btnViewSongDetails";
            this.btnViewSongDetails.Size = new System.Drawing.Size(143, 23);
            this.btnViewSongDetails.TabIndex = 3;
            this.btnViewSongDetails.Text = "Профіль";
            this.btnViewSongDetails.UseVisualStyleBackColor = true;
            this.btnViewSongDetails.Click += new System.EventHandler(this.btnViewSongDetails_Click);
            // 
            // btnDeleteSong
            // 
            this.btnDeleteSong.Location = new System.Drawing.Point(9, 66);
            this.btnDeleteSong.Name = "btnDeleteSong";
            this.btnDeleteSong.Size = new System.Drawing.Size(143, 23);
            this.btnDeleteSong.TabIndex = 2;
            this.btnDeleteSong.Text = "Видалити";
            this.btnDeleteSong.UseVisualStyleBackColor = true;
            this.btnDeleteSong.Click += new System.EventHandler(this.btnDeleteSong_Click);
            // 
            // btnEditSong
            // 
            this.btnEditSong.Location = new System.Drawing.Point(9, 36);
            this.btnEditSong.Name = "btnEditSong";
            this.btnEditSong.Size = new System.Drawing.Size(143, 23);
            this.btnEditSong.TabIndex = 1;
            this.btnEditSong.Text = "Редагувати";
            this.btnEditSong.UseVisualStyleBackColor = true;
            this.btnEditSong.Click += new System.EventHandler(this.btnEditSong_Click);
            // 
            // btnAddSong
            // 
            this.btnAddSong.Location = new System.Drawing.Point(9, 6);
            this.btnAddSong.Name = "btnAddSong";
            this.btnAddSong.Size = new System.Drawing.Size(143, 23);
            this.btnAddSong.TabIndex = 0;
            this.btnAddSong.Text = "Додати пісню";
            this.btnAddSong.UseVisualStyleBackColor = true;
            this.btnAddSong.Click += new System.EventHandler(this.btnAddSong_Click);
            // 
            // dgvSongs
            // 
            this.dgvSongs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSongs.Location = new System.Drawing.Point(165, 3);
            this.dgvSongs.Name = "dgvSongs";
            this.dgvSongs.Size = new System.Drawing.Size(683, 395);
            this.dgvSongs.TabIndex = 0;
            // 
            // songFilterPanel
            // 
            this.songFilterPanel.Controls.Add(this.txtSongSearch);
            this.songFilterPanel.Controls.Add(this.btnSearch);
            this.songFilterPanel.Controls.Add(this.lblSongSearch);
            this.songFilterPanel.Controls.Add(this.chkSortAscending);
            this.songFilterPanel.Controls.Add(this.cmbSortField);
            this.songFilterPanel.Controls.Add(this.lblSortBy);
            this.songFilterPanel.Location = new System.Drawing.Point(139, 0);
            this.songFilterPanel.Name = "songFilterPanel";
            this.songFilterPanel.Size = new System.Drawing.Size(708, 27);
            this.songFilterPanel.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(241, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Шукати";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblSongSearch
            // 
            this.lblSongSearch.AutoSize = true;
            this.lblSongSearch.Location = new System.Drawing.Point(3, 7);
            this.lblSongSearch.Name = "lblSongSearch";
            this.lblSongSearch.Size = new System.Drawing.Size(43, 13);
            this.lblSongSearch.TabIndex = 5;
            this.lblSongSearch.Text = "Пошук:";
            // 
            // txtSongSearch
            // 
            this.txtSongSearch.Location = new System.Drawing.Point(46, 4);
            this.txtSongSearch.Name = "txtSongSearch";
            this.txtSongSearch.Size = new System.Drawing.Size(189, 20);
            this.txtSongSearch.TabIndex = 6;
            // 
            // chkSortAscending
            // 
            this.chkSortAscending.AutoSize = true;
            this.chkSortAscending.Location = new System.Drawing.Point(599, 5);
            this.chkSortAscending.Name = "chkSortAscending";
            this.chkSortAscending.Size = new System.Drawing.Size(103, 17);
            this.chkSortAscending.TabIndex = 3;
            this.chkSortAscending.Text = "За зростанням";
            this.chkSortAscending.UseVisualStyleBackColor = true;
            this.chkSortAscending.CheckedChanged += new System.EventHandler(this.chkSortAscending_CheckedChanged);
            // 
            // cmbSortField
            // 
            this.cmbSortField.FormattingEnabled = true;
            this.cmbSortField.Location = new System.Drawing.Point(405, 3);
            this.cmbSortField.Name = "cmbSortField";
            this.cmbSortField.Size = new System.Drawing.Size(188, 21);
            this.cmbSortField.TabIndex = 4;
            this.cmbSortField.SelectedIndexChanged += new System.EventHandler(this.cmbSortField_SelectedIndexChanged);
            // 
            // lblSortBy
            // 
            this.lblSortBy.AutoSize = true;
            this.lblSortBy.Location = new System.Drawing.Point(322, 7);
            this.lblSortBy.Name = "lblSortBy";
            this.lblSortBy.Size = new System.Drawing.Size(77, 13);
            this.lblSortBy.TabIndex = 3;
            this.lblSortBy.Text = "Сортувати по:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 450);
            this.Controls.Add(this.songFilterPanel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Система керування музикою";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabArtists.ResumeLayout(false);
            this.artistButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtists)).EndInit();
            this.tabSongs.ResumeLayout(false);
            this.songButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSongs)).EndInit();
            this.songFilterPanel.ResumeLayout(false);
            this.songFilterPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TabPage tabPage1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
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
        private Panel songButtonPanel;
        private Button btnAddSong;
        private Button btnViewSongDetails;
        private Button btnDeleteSong;
        private Button btnEditSong;
        private Panel songFilterPanel;
        private ComboBox cmbSortField;
        private Label lblSortBy;
        private CheckBox chkSortAscending;
        private TextBox txtSongSearch;
        private Label lblSongSearch;
        private Button btnSearch;
    }
}

