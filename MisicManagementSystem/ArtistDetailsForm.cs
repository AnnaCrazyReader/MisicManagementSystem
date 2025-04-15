using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicManagementSystem.Models;

namespace MusicManagementSystem
{
    public partial class ArtistDetailsForm : Form
    {
        private Artist currentArtist;
        public bool ReadOnly { get; set; } = false;

        public ArtistDetailsForm(Artist artist = null)
        {
            InitializeComponent();
            
            // Если передан существующий исполнитель, заполняем поля
            if (artist != null)
            {
                this.currentArtist = artist;
                txtArtistName.Text = artist.artist_name;
                txtCountry.Text = artist.country_origin;
                numBirthYear.Value = artist.birth_year;
                cmbGenre.Text = artist.musical_genre;

                if (!string.IsNullOrEmpty(artist.profile_photo))
                {
                    try
                    {
                        pictureBox1.Image = Image.FromFile(artist.profile_photo);
                    }
                    catch { /* Обработка ошибки */ }
                }
            }
            else
            {
                this.currentArtist = new Artist();
            }


        }

        private void ArtistDetailsForm_Load(object sender, EventArgs e)
        {
            if (ReadOnly)
            {
                // Отключаем редактирование
                txtArtistName.ReadOnly = true;
                txtCountry.ReadOnly = true;
                numBirthYear.Enabled = false;
                cmbGenre.Enabled = false;

                // Скрываем кнопку сохранения
                btnSave.Visible = false;

                // Скрываем кнопку завантаження фото
                btnLoadPic.Visible = false;

                // Меняем заголовок формы
                this.Text = "Просмотр исполнителя";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка на заполнение обязательных полей
            if (string.IsNullOrWhiteSpace(txtArtistName.Text))
            {
                MessageBox.Show("Введите имя исполнителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtArtistName.Focus();
                return;
            }

            // Заполняем объект данными из формы
            currentArtist.artist_name = txtArtistName.Text;
            currentArtist.country_origin = txtCountry.Text;
            currentArtist.birth_year = (int)numBirthYear.Value;
            currentArtist.musical_genre = cmbGenre.Text;

            try
            {
                using (var context = new MusicDbContext())
                {
                    if (currentArtist.artist_id == 0)
                    {
                        // Если это новый исполнитель, добавляем его в базу данных
                        context.Artists.Add(currentArtist);
                    }
                    else
                    {
                        // Если исполнитель уже существует, находим его в БД и обновляем
                        var existingArtist = context.Artists.Find(currentArtist.artist_id);
                        if (existingArtist != null)
                        {
                            // Копируем значения из формы в существующий объект
                            existingArtist.artist_name = currentArtist.artist_name;
                            existingArtist.country_origin = currentArtist.country_origin;
                            existingArtist.birth_year = currentArtist.birth_year;
                            existingArtist.musical_genre = currentArtist.musical_genre;
                            existingArtist.profile_photo = currentArtist.profile_photo;
                        }
                        else
                        {
                            // Если не нашли в БД (например, был удален), добавляем как новый
                            context.Artists.Add(currentArtist);
                        }
                    }

                    // Сохраняем изменения
                    context.SaveChanges();
                }

                // Устанавливаем результат диалога и закрываем форму
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show($"Произошла ошибка при сохранении: {ex.Message}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnLoadPic_Click(object sender, EventArgs e)
        {
            // Создаем диалог выбора файла
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Настраиваем диалог
                openFileDialog.Title = "Выберите фото исполнителя";
                openFileDialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Все файлы|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                // Если пользователь выбрал файл и нажал OK
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Получаем путь к выбранному файлу
                        string selectedFilePath = openFileDialog.FileName;

                        // Создаем папку для хранения изображений, если она не существует
                        string appDirectory = Application.StartupPath;
                        string imageDirectory = Path.Combine(appDirectory, "Images");

                        if (!Directory.Exists(imageDirectory))
                        {
                            Directory.CreateDirectory(imageDirectory);
                        }

                        // Формируем имя файла (используем ID артиста и оригинальное имя файла)
                        string fileName = $"{DateTime.Now.Ticks}_{Path.GetFileName(selectedFilePath)}";
                        string destFilePath = Path.Combine(imageDirectory, fileName);

                        // Копируем файл в папку приложения
                        File.Copy(selectedFilePath, destFilePath, true);

                        // Сохраняем относительный путь в модели
                        currentArtist.profile_photo = Path.Combine("Images", fileName);

                        // Отображаем изображение в PictureBox
                        pictureBox1.Image = Image.FromFile(destFilePath);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                        MessageBox.Show("Фото успешно загружено!", "Информация",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке фото: {ex.Message}",
                                       "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
