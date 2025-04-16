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

namespace MusicManagementSystem
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

            // Ініціалізація комбобокса сортування
            InitializeSortingControls();

            // Завантаження даних при запуску
            LoadArtistsData();
            LoadSongsData();

            // Додавання обробників подій для кнопок
            cmbSortField.SelectedIndexChanged += cmbSortField_SelectedIndexChanged;
            chkSortAscending.CheckedChanged += chkSortAscending_CheckedChanged;
        }

        private void InitializeSortingControls()
        {
            // Очистіть попередні елементи перед додаванням нових
            cmbSortField.Items.Clear();
            // Додавайте українські назви полів сортування
            cmbSortField.Items.AddRange(new object[] { "Назва", "Виконавець", "Альбом" });
            cmbSortField.SelectedIndex = 0;
            chkSortAscending.Checked = true;
        }

        private void SetupDataGridViews()
        {
            // Налаштування для виконавців
            SetupArtistsDataGridView();

            // Налаштування для пісень
            SetupSongsDataGridView();
        }

        private void SetupArtistsDataGridView()
        {
            // Налаштування колонок для виконавців
            dgvArtists.AutoGenerateColumns = false;
            dgvArtists.Columns.Clear(); // Очищення існуючих колонок

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
                HeaderText = "Країна походження",
                Width = 150
            });

            dgvArtists.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "musical_genre",
                HeaderText = "Жанр",
                Width = 100
            });

            dgvArtists.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "birth_year",
                HeaderText = "Рік заснування",
                Width = 100
            });
        }

        private void SetupSongsDataGridView()
        {
            dgvSongs.AutoGenerateColumns = false;
            dgvSongs.Columns.Clear(); // Очищення існуючих колонок

            dgvSongs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "song_id",
                HeaderText = "ID",
                Width = 50
            });

            dgvSongs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "track_name",
                HeaderText = "Назва пісні",
                Width = 150
            });

            dgvSongs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "artist_name",
                HeaderText = "Виконавець",
                Width = 150
            });

            dgvSongs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "album_title",
                HeaderText = "Альбом",
                Width = 150
            });

            dgvSongs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "duration",
                HeaderText = "Тривалість",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "mm\\:ss"
                }
            });
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Оновлення списку полів сортування при зміні вкладки
            cmbSortField.Items.Clear();

            if (tabControl1.SelectedTab == tabArtists)
            {
                cmbSortField.Items.AddRange(new object[] { "Ім'я виконавця", "Країна", "Жанр" });
            }
            else if (tabControl1.SelectedTab == tabSongs)
            {
                cmbSortField.Items.AddRange(new object[] { "Назва пісні", "Альбом", "Виконавець" });
            }

            cmbSortField.SelectedIndex = 0;
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
                try
                {
                    dataManager.DeleteArtist(selectedArtist.artist_id);
                    LoadArtistsData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при видаленні виконавця: {ex.Message}",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void btnAddSong_Click(object sender, EventArgs e)
        {
            var form = new SongDetailsForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Обновляем данные после добавления
                LoadSongsData();
            }
        }

        private void btnEditSong_Click(object sender, EventArgs e)
        {
            if (dgvSongs.SelectedRows.Count == 0) return;

            var selectedViewModel = dgvSongs.SelectedRows[0].DataBoundItem as SongViewModel;

            // Отримуємо повний об'єкт Song з бази даних
            Song selectedSong = null;
            using (var context = new MusicDbContext())
            {
                selectedSong = context.Songs
                    .Include("Artist")
                    .FirstOrDefault(s => s.song_id == selectedViewModel.song_id);
            }

            if (selectedSong != null)
            {
                var form = new SongDetailsForm(selectedSong);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Оновлюємо дані
                    LoadSongsData();
                }
            }
        }

        private void btnDeleteSong_Click(object sender, EventArgs e)
        {
            if (dgvSongs.SelectedRows.Count == 0) return;

            var selectedSong = dgvSongs.SelectedRows[0].DataBoundItem as Song;

            if (MessageBox.Show($"Вы уверены, что хотите удалить песню '{selectedSong.track_name}'?",
                              "Подтверждение удаления",
                              MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataManager.DeleteSong(selectedSong.song_id);
                LoadSongsData();
            }
        }

        private void btnViewSongDetails_Click(object sender, EventArgs e)
        {
            if (dgvSongs.SelectedRows.Count == 0) return;

            var selectedSong = dgvSongs.SelectedRows[0].DataBoundItem as Song;
            var form = new SongDetailsForm(selectedSong);
            form.ReadOnly = true;  // Режим только для чтения
            form.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchTerm = txtSongSearch.Text.Trim();

            // Визначення активної вкладки
            if (tabControl1.SelectedTab == tabArtists)
            {
                // Пошук виконавців
                if (string.IsNullOrEmpty(searchTerm))
                {
                    LoadArtistsData();
                }
                else
                {
                    dgvArtists.DataSource = dataManager.SearchArtists(searchTerm);
                }
            }
            else if (tabControl1.SelectedTab == tabSongs)
            {
                // Пошук пісень
                if (string.IsNullOrEmpty(searchTerm))
                {
                    LoadSongsData();
                }
                else
                {
                    dgvSongs.DataSource = dataManager.SearchSongs(searchTerm);
                    // Переконайтеся, що метод SearchSongs існує у класі DataManager
                }
            }
        }

        private void chkSortAscending_CheckedChanged(object sender, EventArgs e)
        {
            ApplySorting();
        }

        private void cmbSortField_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySorting();
        }

        private void ApplySorting()
        {
            if (cmbSortField.SelectedIndex < 0) return;

            string sortField;
            // Визначення активної вкладки
            if (tabControl1.SelectedTab == tabArtists)
            {
                // Сортування виконавців
                switch (cmbSortField.SelectedIndex)
                {
                    case 0: sortField = "artist_name"; break;
                    case 1: sortField = "country_origin"; break;
                    case 2: sortField = "musical_genre"; break;
                    default: sortField = "artist_name"; break;
                }

                LoadArtistsData(sortField, chkSortAscending.Checked);
            }
            else if (tabControl1.SelectedTab == tabSongs)
            {
                // Сортування пісень
                switch (cmbSortField.SelectedIndex)
                {
                    case 0: sortField = "track_name"; break;
                    case 1: sortField = "album_title"; break;
                    case 2: sortField = "artist_name"; break;
                    default: sortField = "track_name"; break;
                }

                LoadSongsData(sortField, chkSortAscending.Checked);
            }
        }
    }
}
