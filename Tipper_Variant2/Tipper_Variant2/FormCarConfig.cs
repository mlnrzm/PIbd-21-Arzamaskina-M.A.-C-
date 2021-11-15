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
    public partial class FormCarConfig : Form
    {
        /// <summary>
        /// Переменная-выбранная машина
        /// </summary>
        Vehicle car = null;

        /// <summary>
        /// Событие
        /// </summary>
        private event Action<Vehicle> eventAddCar;

        public FormCarConfig()
        {
            InitializeComponent();

            panelBlack.MouseDown += panelColor_MouseDown;
            panelBrown.MouseDown += panelColor_MouseDown;
            panelOrange.MouseDown += panelColor_MouseDown;
            panelGreen.MouseDown += panelColor_MouseDown;
            panelRed.MouseDown += panelColor_MouseDown;
            panelDarkGreen.MouseDown += panelColor_MouseDown;
            panelYellow.MouseDown += panelColor_MouseDown;
            panelBlue.MouseDown += panelColor_MouseDown;

            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };

        }

        /// <summary>
        /// Отрисовать машину
        /// </summary>
        private void DrawCar()
        {
            if (car != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxCar.Width, pictureBoxCar.Height);
                Graphics gr = Graphics.FromImage(bmp);
                car.SetPosition(15, 15, pictureBoxCar.Width, pictureBoxCar.Height);
                car.DrawTransport(gr);
                pictureBoxCar.Image = bmp;
            }
        }

         /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="ev"></param>
        public void AddEvent(Action<Vehicle> ev)
        {
            if (eventAddCar == null)
            {
                eventAddCar = new Action<Vehicle>(ev);
            }
            else
            {
                eventAddCar += ev;
            }
        }

        /// <summary>
        /// Передаем информацию при нажатии на Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTruck_MouseDown(object sender, MouseEventArgs e)
        {
            labelTruck.DoDragDrop(labelTruck.Name, DragDropEffects.Move |
                DragDropEffects.Copy);

        }

        /// <summary>
        /// Передаем информацию при нажатии на Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTipper_MouseDown(object sender, MouseEventArgs e)
        {
            labelTipper.DoDragDrop(labelTipper.Name, DragDropEffects.Move |
                DragDropEffects.Copy);

        }

        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelCar_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        /// <summary>
        /// Действия при приеме перетаскиваемой информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelCar_DragDrop(object sender, DragEventArgs e)
        {
            
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "labelTruck":
                car = new Truck((int)numericUpDownMaxSpeed.Value,
                (int)numericUpDownCarWeight.Value, Color.White);
                    break;
                case "labelTipper":
                car = new TipperCar((int)numericUpDownMaxSpeed.Value,
                   (int)numericUpDownCarWeight.Value, Color.White, Color.Black,
                    checkBoxWheelRims.Checked, checkBoxHeadlight.Checked,
                   checkBoxPlatform.Checked);
                    break;
            }

            DrawCar();
        }

        /// <summary>
        /// Отправляем цвет с панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((Color)(sender as Control).BackColor, DragDropEffects.Move | DragDropEffects.Copy);

        }

        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMainColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Принимаем основной цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMainColor_DragDrop(object sender, DragEventArgs e)
        {
            if (car != null)
            {
                car.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawCar();
            }
        }

        /// <summary>
        /// Принимаем дополнительный цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (car != null)
            {
                if (car is TipperCar)
                {
                    (car as TipperCar).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawCar();
                }
            }

        }

        /// <summary>
        /// Добавление машины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            eventAddCar?.Invoke(car);
            Close();
        }

    }
}
