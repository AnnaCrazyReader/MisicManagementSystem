using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicManagementSystem.Models;
using AxWMPLib;
using WMPLib;

namespace MusicManagementSystem
{
    public partial class SongDetailsForm : Form
    {
        private Artist currentArtist;
        private Song currentSong;
        private string mp3FilePath = string.Empty;
        public bool ReadOnly { get; set; } = false;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;


        public SongDetailsForm(Song song = null)
        {
            InitializeComponent();

            // Инициализация медиаплеера
            mediaPlayer = new AxWindowsMediaPlayer();
            mediaPlayer.Dock = DockStyle.None;
            mediaPlayer.Location = new System.Drawing.Point(20, 300);
            mediaPlayer.Name = "mediaPlayer";
            mediaPlayer.Size = new System.Drawing.Size(450, 100);
            this.Controls.Add(mediaPlayer);

            // Подписываемся на событие создания дескриптора
            mediaPlayer.HandleCreated += MediaPlayer_HandleCreated;

            // Настройка дополнительных параметров
            mediaPlayer.CreateControl(); // Важно для создания элемента управления
            

            // Заполняем комбобокс с исполнителями
            LoadArtists();
            numReleaseYear.Minimum = 1900;
            numReleaseYear.Maximum = 2030;
            numPlayCount.Minimum = 0;
          
            if (song != null)
            {
                // Если передана существующая песня
                this.currentSong = song;
                txtSongName.Text = song.track_name;
                txtAlbumTitle.Text = song.album_title;
                numReleaseYear.Value = song.release_year;
                numPlayCount.Value = song.play_count;

                // Устанавливаем длительность
                int totalSeconds = (int)song.duration.TotalSeconds;
                numDurationMin.Value = totalSeconds / 60;
                numDurationSec.Value = totalSeconds % 60;

                // Выбираем исполнителя в комбобоксе
                if (song.Artist != null)
                {
                    for (int i = 0; i < cmbArtist.Items.Count; i++)
                    {
                        var artist = (Artist)cmbArtist.Items[i];
                        if (artist.artist_id == song.artist_id)
                        {
                            cmbArtist.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            else
            {
                // Создаем новую песню
                this.currentSong = new Song();
                numReleaseYear.Value = DateTime.Now.Year;
            }

            // Подписываемся на событие загрузки формы
            this.Load += SongDetailsForm_Load;
        }

        private void MediaPlayer_HandleCreated(object sender, EventArgs e)
        {
            // Настройки можно безопасно задавать только после создания дескриптора
            mediaPlayer.settings.autoStart = false;
            mediaPlayer.uiMode = "mini";
        }


        private void LoadArtists()
        {
            using (var context = new MusicDbContext())
            {
                // Загружаем список исполнителей из БД
                var artists = context.Artists.ToList();
                cmbArtist.DataSource = artists;
                cmbArtist.DisplayMember = "artist_name";
                cmbArtist.ValueMember = "artist_id";
            }
        }

        private void SongDetailsForm_Load(object sender, EventArgs e)
        {
            if (ReadOnly)
            {
                // Отключаем редактирование в режиме только для чтения
                txtSongName.ReadOnly = true;
                txtAlbumTitle.ReadOnly = true;
                cmbArtist.Enabled = false;
                numReleaseYear.Enabled = false;
                numDurationMin.Enabled = false;
                numDurationSec.Enabled = false;
                numPlayCount.Enabled = false;

                btnSave.Visible = false;
                this.Text = "Просмотр песни";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            currentSong.mp3_file_path = mp3FilePath;

            // Проверка на заполнение обязательных полей
            if (string.IsNullOrWhiteSpace(txtSongName.Text))
            {
                MessageBox.Show("Введите название песни", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSongName.Focus();
                return;
            }

            if (cmbArtist.SelectedItem == null)
            {
                MessageBox.Show("Выберите исполнителя", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbArtist.Focus();
                return;
            }

            // Заполняем объект данными из формы
            currentSong.track_name = txtSongName.Text;
            currentSong.album_title = txtAlbumTitle.Text;
            currentSong.release_year = (int)numReleaseYear.Value;
            currentSong.play_count = (int)numPlayCount.Value;

            // Устанавливаем длительность
            int minutes = (int)numDurationMin.Value;
            int seconds = (int)numDurationSec.Value;
            currentSong.duration = new TimeSpan(0, minutes, seconds);

            // Устанавливаем исполнителя
            var selectedArtist = (Artist)cmbArtist.SelectedItem;
            currentSong.artist_id = selectedArtist.artist_id;

            try
            {
                using (var context = new MusicDbContext())
                {
                    if (currentSong.song_id == 0)
                    {
                        // Добавляем новую песню
                        context.Songs.Add(currentSong);
                    }
                    else
                    {
                        // Обновляем существующую песню
                        var existingSong = context.Songs.Find(currentSong.song_id);
                        if (existingSong != null)
                        {
                            // Копируем значения из формы в существующий объект
                            existingSong.track_name = currentSong.track_name;
                            existingSong.album_title = currentSong.album_title;
                            existingSong.release_year = currentSong.release_year;
                            existingSong.duration = currentSong.duration;
                            existingSong.play_count = currentSong.play_count;
                            existingSong.artist_id = currentSong.artist_id;
                        }
                        else
                        {
                            // Если песня была удалена, добавляем как новую
                            context.Songs.Add(currentSong);
                        }
                    }

                    // Сохраняем изменения
                    context.SaveChanges();
                }

                // Закрываем форму с результатом OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Закрываем форму с результатом Cancel
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btmLoadMP3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "MP3 файлы (*.mp3)|*.mp3|Все файлы (*.*)|*.*";
                openFileDialog.Title = "Выберите MP3 файл";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        mp3FilePath = openFileDialog.FileName;

                        // Извлекаем название песни из имени файла (без расширения)
                        string fileName = Path.GetFileNameWithoutExtension(mp3FilePath);
                        if (string.IsNullOrEmpty(txtSongName.Text))
                        {
                            txtSongName.Text = fileName;
                        }

                        // Определяем длительность MP3-файла
                        TimeSpan duration = GetMP3Duration(mp3FilePath);

                        // Устанавливаем значения в numericUpDown для минут и секунд
                        numDurationMin.Value = (int)duration.TotalMinutes;
                        numDurationSec.Value = duration.Seconds;

                        MessageBox.Show($"MP3 файл загружен.\nДлительность: {duration:mm\\:ss}",
                                      "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}",
                                      "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // После успешной загрузки предлагаем воспроизвести
                if (MessageBox.Show("MP3 файл загружен. Воспроизвести?",
                                  "Информация", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PlayMp3File();
                }

            }
        }

        // Метод для определения длительности MP3-файла
        private TimeSpan GetMP3Duration(string filePath)
        {
            try
            {
                using (var reader = new NAudio.Wave.Mp3FileReader(filePath))
                {
                    return reader.TotalTime;
                }
            }
            catch
            {
                return new TimeSpan(0, 0, 0);
            }
        }

        private void PlayMp3File()
        {
            if (string.IsNullOrEmpty(mp3FilePath) || !File.Exists(mp3FilePath))
            {
                MessageBox.Show("Файл MP3 не выбран или не существует.",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Устанавливаем URL для проигрывания (локальный файл)
                mediaPlayer.URL = mp3FilePath;
                // Включаем автоматическое воспроизведение
                mediaPlayer.Ctlcontrols.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка воспроизведения: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPlayMp3_Click(object sender, EventArgs e)
        {
            PlayMp3File();
        }
    }
}
