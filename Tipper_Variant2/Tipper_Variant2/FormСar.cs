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
    public partial class FormCar : Form
    {
        private ITransport car;

        /// <summary>
        /// Конструктор
        /// </summary>
        public FormCar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод отрисовки машины
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxCars.Width, pictureBoxCars.Height);
            Graphics gr = Graphics.FromImage(bmp);
            car?.DrawTransport(gr);
            pictureBoxCars.Image = bmp;
        }

        /// <summary>
        /// Передача машины на форму
        /// </summary>
        /// <param name="car"></param>
        public void SetCar(ITransport car)
        {
            this.car = car;

            Random rnd = new Random();
            car.SetPosition(rnd.Next(10, 100), rnd.Next(100, 110), pictureBoxCars.Width,
           pictureBoxCars.Height);

            Draw();
        }

        /// <summary>
        /// Обработка нажатия кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreate_Click_1(object sender, EventArgs e)
        {
            Random rnd = new Random();
            car = new Truck(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue);
            car.SetPosition(rnd.Next(10, 100), rnd.Next(100, 110), pictureBoxCars.Width,
           pictureBoxCars.Height);
            Draw();
        }

        /// <summary>
        /// Обработка нажатия кнопки "Создать гоночный автомобиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateTipperCar_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            car = new TipperCar(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue,
           Color.Yellow, true, true, true);
            car.SetPosition(rnd.Next(10, 100), rnd.Next(100, 110), pictureBoxCars.Width,
           pictureBoxCars.Height);
            Draw();
        }

        /// <summary>
        /// Обработка нажатия кнопок управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    car?.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    car?.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    car?.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    car?.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }

    }
}
