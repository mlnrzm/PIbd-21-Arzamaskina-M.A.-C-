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
        /// Объект от класса-гаражей
        /// </summary>
        private readonly Garage<Truck> parking;
        public FormGarages()
        {
            InitializeComponent();
            parking = new Garage<Truck>(pictureBoxGarages.Width,
           pictureBoxGarages.Height);
            Draw();
        }
        /// <summary>
        /// Метод отрисовки гаражей
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxGarages.Width, pictureBoxGarages.Height);
            Graphics gr = Graphics.FromImage(bmp);
            parking.Draw(gr);
            pictureBoxGarages.Image = bmp;
        }

        /// <summary>
        /// Обработка нажатия кнопки "Припарковать грузовик"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonParkingTruck_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var car = new Truck(100, 1000, dialog.Color);
                if ((parking + car) > -1)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Гараж переполнен");
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
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var car = new TipperCar(100, 1000, dialog.Color, dialogDop.Color,
                   true, true, true);
                    if ((parking + car) > -1)
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
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTake_Click(object sender, EventArgs e)
        {
            if (numberGarage.Text != "")
            {
                var car = parking - Convert.ToInt32(numberGarage.Text);
                if (car != null)
                {
                    FormCar form = new FormCar();
                    form.SetCar(car);
                    form.ShowDialog();
                }
                Draw();
            }
        }
    }
}
