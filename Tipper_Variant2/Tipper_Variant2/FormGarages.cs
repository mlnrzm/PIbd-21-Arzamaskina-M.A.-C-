using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace Tipper_Variant2
{
    public partial class FormGarages : Form
    {
        /// <summary>
        /// Объект от класса-коллекции парковок (гаражей)
        /// </summary>
        private readonly GarageCollection garageCollection;

        /// <summary>
        /// Логгер
        /// </summary>
        private readonly Logger logger;

        public FormGarages()
        {
            InitializeComponent();
            garageCollection = new GarageCollection(pictureBoxGarages.Width,
                pictureBoxGarages.Height);
            logger = LogManager.GetCurrentClassLogger();
            Draw();
        }
        /// <summary>
        /// Заполнение listBoxGarages
        /// </summary>
        private void ReloadLevels()
        {
            int index = listBoxGarages.SelectedIndex;
            listBoxGarages.Items.Clear();
            for (int i = 0; i < garageCollection.Keys.Count; i++)
            {
                listBoxGarages.Items.Add(garageCollection.Keys[i]);
            }
            if (listBoxGarages.Items.Count > 0 && (index == -1 || index >=
            listBoxGarages.Items.Count))
            {
                listBoxGarages.SelectedIndex = 0;
            }
            else if (listBoxGarages.Items.Count > 0 && index > -1 && index <
            listBoxGarages.Items.Count)
            {
                listBoxGarages.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Метод отрисовки гаражей
        /// </summary>
        private void Draw()
        {
            if (listBoxGarages.SelectedIndex > -1)
            {
                Bitmap bmp = new Bitmap(pictureBoxGarages.Width,
                pictureBoxGarages.Height);
                Graphics gr = Graphics.FromImage(bmp);
                garageCollection[listBoxGarages.SelectedItem.ToString()].Draw(gr);
                pictureBoxGarages.Image = bmp;
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTake_Click(object sender, EventArgs e)
        {
            if (listBoxGarages.SelectedIndex > -1 && numberGarage.Text != "")
            {
                try
                {
                    var car = garageCollection[listBoxGarages.SelectedItem.ToString()] -
                        Convert.ToInt32(numberGarage.Text);
                    if (car != null)
                    {
                        FormCar form = new FormCar();
                        form.SetCar(car);
                        form.ShowDialog();
                        logger.Info($"Изъят автомобиль {car} с места { numberGarage.Text}");
                        Draw();
                    }
                }
                catch (ParkingNotFoundException ex)
                {
                    MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                    logger.Warn($"Автомобиль на месте { numberGarage.Text} не найден.");
                }
                catch (Exception ex)
                {
                    logger.Warn($"Автомобиль на месте { numberGarage.Text} не найден.");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Добавить парковку (гаражи)"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddGarage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxGarages.Text))
            {
                MessageBox.Show("Введите название парковки (гаражей)", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            logger.Info($"Добавили парковку {textBoxGarages.Text}");
            garageCollection.AddGarage(textBoxGarages.Text);
            ReloadLevels();
        }

        /// <summary>
        /// Обработка нажатия кнопки "Удалить парковку (гаражи)" 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteGarages_Click(object sender, EventArgs e)
        {
            if (listBoxGarages.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить парковку (гаражи) { listBoxGarages.SelectedItem.ToString()}?", 
                    "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    logger.Info($"Удалили парковку { listBoxGarages.SelectedItem.ToString()}");
                    garageCollection.DelGarage(textBoxGarages.Text);
                    ReloadLevels();
                }
            }

        }

        /// <summary>
        /// Метод обработки выбора элемента на listBoxGarages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxGarages_SelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Перешли на парковку{ listBoxGarages.SelectedItem.ToString()}");

            Draw();
        }

        /// <summary>
        /// Метод добавления машины
        /// </summary>
        /// <param name="car"></param>
        private void AddCar(Vehicle car)
        {
            if (car != null && listBoxGarages.SelectedIndex > -1)
                try
                {
                        if ((garageCollection[listBoxGarages.SelectedItem.ToString()]) + car > -1)
                        {
                            Draw();
                            logger.Info($"Добавлен автомобиль {car}");
                        }
                        else
                        {
                            MessageBox.Show("Машину не удалось поставить");
                            logger.Warn($"Автомобиль {car} не удалось поставить");
                        }
                    Draw();
                }
                catch (ParkingOverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                    logger.Warn($"Автомобиль {car} не удалось поставить. Парковка переполнена.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Info($"Автомобиль {car} не удалось поставить. Ошибка.");
                }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Добавить грузовик/самосвал"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetTruckOrTipper_Click(object sender, EventArgs e)
        {
            var formCarConfig = new FormCarConfig();
            formCarConfig.AddEvent(AddCar);
            formCarConfig.Show();
        }
        /// <summary>
        /// Обработка нажатия пункта меню "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    garageCollection.LoadData(openFileDialog.FileName);
                    garageCollection.LoadData(openFileDialog.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn("Ошибка при сохранении в файл " + saveFileDialog.FileName);
                }
            }
        }
        /// <summary>
        /// Обработка нажатия пункта меню "Загрузить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    garageCollection.LoadData(openFileDialog.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog.FileName);
                    ReloadLevels();
                    Draw();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Info("Ошибка загрузки из файла " + openFileDialog.FileName);
                }
            }
        }
    }
}
