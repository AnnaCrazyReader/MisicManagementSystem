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
            this.Controls.Add(this.lblMp3Status);

            // Подписываемся на событие создания дескриптора
            mediaPlayer.HandleCreated += MediaPlayer_HandleCreated;
            
            // Додаємо обробник події закриття форми
            this.FormClosing += SongDetailsForm_FormClosing;

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
                // Відключаємо редактування для всіх полів
                txtSongName.ReadOnly = true;
                txtAlbumTitle.ReadOnly = true;
                cmbArtist.Enabled = false;
                numReleaseYear.Enabled = false;
                numDurationMin.Enabled = false;
                numDurationSec.Enabled = false;
                numPlayCount.Enabled = false;

                // Приховуємо кнопки, які не потрібні в режимі перегляду
                btnSave.Visible = false;
                btmLoadMP3.Visible = false;  // Кнопка завантаження MP3

                // Залишаємо видимою тільки кнопку відтворення MP3 і кнопку закриття
                btnCancel.Text = "Закрити";  // Перейменовуємо кнопку "Відмінити" на "Закрити"

                // Змінюємо заголовок форми
                this.Text = "Перегляд пісні";

                // Якщо це існуюча пісня, перевіряємо наявність MP3
                if (currentSong != null && !string.IsNullOrEmpty(currentSong.mp3_file_path))
                {
                    mp3FilePath = currentSong.mp3_file_path;
                    string fullPath = Path.Combine(Application.StartupPath, mp3FilePath);

                    // Перевіряємо існування файлу
                    bool fileExists = File.Exists(fullPath);
                    UpdateMp3Status(fileExists);

                    // Якщо файл існує, встановлюємо тривалість
                    if (fileExists)
                    {
                        TimeSpan duration = GetMP3Duration(fullPath);
                        if (duration.TotalSeconds > 0)
                        {
                            numDurationMin.Value = (int)duration.TotalMinutes;
                            numDurationSec.Value = duration.Seconds;
                        }
                    }
                }
            }
        }

        private void InitializeMediaPlayer()
        {
            try
            {
                // Перевірка чи вже існує медіаплеєр
                if (mediaPlayer != null)
                    return;

                mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
                mediaPlayer.Dock = DockStyle.None;
                mediaPlayer.Location = new Point(20, 300);
                mediaPlayer.Size = new Size(450, 100);
                mediaPlayer.CreateControl();

                // Налаштування тільки після створення контролу
                mediaPlayer.HandleCreated += (s, e) => {
                    mediaPlayer.settings.autoStart = false;
                    mediaPlayer.uiMode = "mini";
                };

                // Додаємо в контроли форми
                this.Controls.Add(mediaPlayer);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка ініціалізації медіаплеєра: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CopyMp3ToAppFolder(string originalFilePath)
        {
            try
            {
                // Створюємо директорію для MP3 файлів, якщо вона не існує
                string appDirectory = Application.StartupPath;
                string musicDirectory = Path.Combine(appDirectory, "Music");

                if (!Directory.Exists(musicDirectory))
                {
                    Directory.CreateDirectory(musicDirectory);
                }

                // Створюємо унікальне ім'я файлу
                string fileName = $"{DateTime.Now.Ticks}_{Path.GetFileName(originalFilePath)}";
                string destFilePath = Path.Combine(musicDirectory, fileName);

                // Копіюємо файл
                File.Copy(originalFilePath, destFilePath, true);

                // Повертаємо відносний шлях для збереження в БД
                return Path.Combine("Music", fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка копіювання MP3 файлу: {ex.Message}",
                               "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private void PlayMp3File()
        {
            try
            {
                if (string.IsNullOrEmpty(mp3FilePath))
                {
                    MessageBox.Show("Файл не вибрано", "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Перетворюємо відносний шлях в абсолютний
                string fullPath = Path.Combine(Application.StartupPath, mp3FilePath);

                // Перевіряємо наявність файлу
                if (!File.Exists(fullPath))
                {
                    MessageBox.Show("Файл не знайдено за вказаним шляхом", "Помилка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateMp3Status(false);  // Оновлюємо статус - файл відсутній
                    return;
                }

                // Відтворюємо файл
                mediaPlayer.URL = fullPath;
                mediaPlayer.Ctlcontrols.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка відтворення: {ex.Message}",
                              "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateMp3Status(bool fileExists)
        {
            // Якщо такого контролу немає, додайте його в дизайнер форми
            if (fileExists)
            {
                lblMp3Status.Text = "MP3 файл завантажено";
                lblMp3Status.ForeColor = Color.Green;
                btnPlayMp3.Enabled = true;
            }
            else
            {
                lblMp3Status.Text = "MP3 файл відсутній";
                lblMp3Status.ForeColor = Color.Red;
                btnPlayMp3.Enabled = false;
            }
        }


        private void LoadExistingMp3(string mp3Path)
        {
            if (string.IsNullOrEmpty(mp3Path))
                return;

            try
            {
                string fullPath = Path.Combine(Application.StartupPath, mp3Path);

                if (File.Exists(fullPath))
                {
                    mp3FilePath = mp3Path;

                    // Показати інформацію про наявний файл
                    TimeSpan duration = GetMP3Duration(fullPath);

                    // Оновити інтерфейс
                    lblMp3Status.Text = "MP3 файл знайдено";
                    lblMp3Status.ForeColor = Color.Green;
                    btnPlayMp3.Enabled = true;
                }
                else
                {
                    // Файл не знайдено, хоч шлях і є в базі
                    lblMp3Status.Text = "MP3 файл не знайдено";
                    lblMp3Status.ForeColor = Color.Red;
                    btnPlayMp3.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження MP3 файлу: {ex.Message}",
                             "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
               
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи вказано шлях до MP3
            if (string.IsNullOrEmpty(mp3FilePath))
            {
                // Запитуємо користувача, чи хоче він зберегти пісню без MP3 файлу
                if (MessageBox.Show("Пісня не містить MP3 файлу. Бажаєте все одно зберегти?",
                                 "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            // Зберігаємо шлях до MP3 у поточній пісні
           
            currentSong.mp3_file_path = mp3FilePath;
            // Зупиняємо відтворення перед закриттям
            StopPlayback();

            // Провірка на заповненість обвязкових полів
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
            // Явно зупиняємо відтворення
            StopPlayback();

            // Закриваємо форму з результатом Cancel
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btmLoadMP3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "MP3 файли (*.mp3)|*.mp3|Всі файли (*.*)|*.*";
                openFileDialog.Title = "Виберіть MP3 файл";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string originalFilePath = openFileDialog.FileName;

                        // Копіюємо файл в директорію програми і отримуємо відносний шлях
                        string relativePath = CopyMp3ToAppFolder(originalFilePath);

                        if (!string.IsNullOrEmpty(relativePath))
                        {
                            // Зберігаємо відносний шлях для запису в БД
                            mp3FilePath = relativePath;

                            // Отримуємо абсолютний шлях для програвання
                            string fullPath = Path.Combine(Application.StartupPath, relativePath);

                            // Визначаємо тривалість
                            TimeSpan duration = GetMP3Duration(fullPath);
                            numDurationMin.Value = (int)duration.TotalMinutes;
                            numDurationSec.Value = duration.Seconds;

                            // Підказка користувачу
                            MessageBox.Show($"MP3 файл успішно завантажено\nТривалість: {duration:mm\\:ss}",
                                          "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Оновлюємо статус
                            UpdateMp3Status(true);

                            // Пропонуємо відтворити файл
                            if (MessageBox.Show("Бажаєте прослухати завантажену пісню?",
                                             "Відтворення", MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                PlayMp3File();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при завантаженні файлу: {ex.Message}",
                                       "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void btnPlayMp3_Click(object sender, EventArgs e)
        {
            PlayMp3File();
        }

        private void StopPlayback()
        {
            try
            {
                if (mediaPlayer != null)
                {
                    if (mediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying ||
                        mediaPlayer.playState == WMPLib.WMPPlayState.wmppsPaused)
                    {
                        mediaPlayer.Ctlcontrols.stop();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Помилка зупинки відтворення: {ex.Message}");
            }
        }

        private void SongDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Зупиняємо відтворення MP3 при закритті форми
            try
            {
                if (mediaPlayer != null && mediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    mediaPlayer.Ctlcontrols.stop();
                }
            }
            catch (Exception ex)
            {
                // Логуємо помилку, але не показуємо повідомлення, бо форма закривається
                System.Diagnostics.Debug.WriteLine($"Помилка зупинки відтворення: {ex.Message}");
            }
        }
    }
}
