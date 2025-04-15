using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicManagementSystem;
using MusicManagementSystem.Models;

namespace MisicManagementSystem
{
    public partial class MainForm : Form
    {
        private DataManager dataManager;

        public MainForm()
        {
            InitializeComponent();
            
            dataManager = new DataManager();

            // Налаштування DataGridView
            SetupDataGridViews();

            // Завантаження даних при запуску
            LoadArtistsData();
            LoadSongsData();

            // Додавання обробників подій для кнопок
            btnAddArtist.Click += btnAddArtist_Click;
            btnEditArtist.Click += btnEditArtist_Click;
            btnDeleteArtist.Click += btnDeleteArtist_Click;
            btnViewArtistDetails.Click += btnViewArtistDetails_Click;

        }

        private void SetupDataGridViews()
        {
            // Налаштування колонок для виконавців
            dgvArtists.AutoGenerateColumns = false;

            dgvArtists.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "artist_id",
                HeaderText = "ID",
                Width = 50
            });

            dgvArtists.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "artist_name",
                HeaderText = "Ім'я виконавця",
                Width = 150
            });

            dgvArtists.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "country_origin",
                HeaderText = "Країна виконавця",
                Width = 150
            });

            dgvArtists.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "birth_year",
                HeaderText = "Дата народження",
                Width = 100
            });

            dgvArtists.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "musical_genre",
                HeaderText = "Жанр",
                Width = 100
            });

            // Додайте інші колонки
            // ...

            // Аналогічно для пісень
            // ...
        }

        private void LoadArtistsData(string sortField = null, bool ascending = true)
        {
            if (string.IsNullOrEmpty(sortField))
                dgvArtists.DataSource = dataManager.GetAllArtists();
            else
                dgvArtists.DataSource = dataManager.GetArtistsSorted(sortField, ascending);
        }

        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            var form = new ArtistDetailsForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Оновлення даних після додавання
                LoadArtistsData();
            }
        }

        private void LoadSongsData(string sortField = null, bool ascending = true)
        {
            if (string.IsNullOrEmpty(sortField))
                dgvSongs.DataSource = dataManager.GetAllSongs();
            else
                dgvSongs.DataSource = dataManager.GetSongsSorted(sortField, ascending);
        }


        private void btnEditArtist_Click(object sender, EventArgs e)
        {
            if (dgvArtists.SelectedRows.Count == 0) return;

            var selectedArtist = dgvArtists.SelectedRows[0].DataBoundItem as Artist;
            var form = new ArtistDetailsForm(selectedArtist);

            if (form.ShowDialog() == DialogResult.OK)
            {
                // Оновлення даних
                LoadArtistsData();
            }
        }

        private void btnDeleteArtist_Click(object sender, EventArgs e)
        {
            if (dgvArtists.SelectedRows.Count == 0) return;

            var selectedArtist = dgvArtists.SelectedRows[0].DataBoundItem as Artist;

            if (MessageBox.Show($"Ви впевнені, що хочете видалити виконавця '{selectedArtist.artist_name}'?",
                                "Підтвердження видалення",
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataManager.DeleteArtist(selectedArtist.artist_id);
                LoadArtistsData();
            }
        }

        private void btnViewArtistDetails_Click(object sender, EventArgs e)
        {
            if (dgvArtists.SelectedRows.Count == 0) return;

            var selectedArtist = dgvArtists.SelectedRows[0].DataBoundItem as Artist;
            var form = new ArtistDetailsForm(selectedArtist);
            form.ReadOnly = true;  // Режим тільки для перегляду
            form.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
