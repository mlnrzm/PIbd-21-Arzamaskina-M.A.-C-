using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tipper_Variant2
{
    public partial class FormGarages : Form
    {
        /// <summary>
        /// Объект от класса-коллекции парковок (гаражей)
        /// </summary>
        private readonly GarageCollection garageCollection;

        public FormGarages()
        {
            InitializeComponent();
            garageCollection = new GarageCollection(pictureBoxGarages.Width,
                pictureBoxGarages.Height);
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
        /// Обработка нажатия кнопки "Припарковать грузовик"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonParkingTruck_Click(object sender, EventArgs e)
        {
            if (listBoxGarages.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var car = new Truck(100, 1000, dialog.Color);
                    if ((garageCollection[listBoxGarages.SelectedItem.ToString()] + car) > -1)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Гараж переполнен");
                    }
                }
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Припарковать самосвал"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonParkingTipper_Click(object sender, EventArgs e)
        {
            if (listBoxGarages.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ColorDialog dialogDop = new ColorDialog();
                    if (dialogDop.ShowDialog() == DialogResult.OK)
                    {
                        var car = new TipperCar(100, 1000, dialog.Color, dialogDop.Color,
                       true, true, true);
                        if ((garageCollection[listBoxGarages.SelectedItem.ToString()] + car) > -1)
                        {
                            Draw();
                        }
                        else
                        {
                            MessageBox.Show("Гараж переполнен");
                        }
                    }
                }
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
                if (numberGarage.Text != "")
                {
                    var car = garageCollection[listBoxGarages.SelectedItem.ToString()] - 
                        Convert.ToInt32(numberGarage.Text);
                    if (car != null)
                    {
                        FormCar form = new FormCar();
                        form.SetCar(car);
                        form.ShowDialog();
                    }
                    Draw();
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
            Draw();
        }
    }
}
