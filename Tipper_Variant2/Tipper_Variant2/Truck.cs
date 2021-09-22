using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tipper_Variant2
{
    public class Truck : Vehicle
    {
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        protected readonly int carWidth = 80;
        /// <summary>
        /// Высота отрисовки автомобиля
        /// </summary>
        protected readonly int carHeight = 70;
        /// <summary>
        /// Конструктор с изменением размеров машины
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        public Truck(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }

        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="carWidth">Ширина отрисовки автомобиля</param>
        /// <param name="carHeight">Высота отрисовки автомобиля</param>
        protected Truck(int maxSpeed, float weight, Color mainColor, int carWidth, int
       carHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            this.carWidth = carWidth;
            this.carHeight = carHeight;
        }
        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - carWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;

                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - carHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);

            {
                Brush spoiler1 = new SolidBrush(MainColor);
                //отрисовка платформы
                g.FillRectangle(spoiler1, _startPosX, _startPosY + 40, 80, 15);
                g.DrawRectangle(pen, _startPosX, _startPosY + 40, 80, 15);

                //отрисовка кабины
                g.FillRectangle(spoiler1, _startPosX + 55, _startPosY, 25, 40);
                g.DrawRectangle(pen, _startPosX + 55, _startPosY, 25, 40);

                //отрисовка лобового стекла
                Brush spoiler2 = new SolidBrush(Color.Gray);
                g.FillRectangle(spoiler2, _startPosX + 65, _startPosY + 4, 15, 20);
                g.DrawRectangle(pen, _startPosX + 65, _startPosY + 4, 15, 20);

                //отрисовка колес
                Brush spoiler = new SolidBrush(Color.Black);
                g.FillEllipse(spoiler, _startPosX, _startPosY + 55, 15, 15);
                g.FillEllipse(spoiler, _startPosX + 20, _startPosY + 55, 15, 15);
                g.FillEllipse(spoiler, _startPosX + 65, _startPosY + 55, 15, 15);
                g.DrawEllipse(pen, _startPosX, _startPosY + 55, 15, 15);
                g.DrawEllipse(pen, _startPosX + 20, _startPosY + 55, 15, 15);
                g.DrawEllipse(pen, _startPosX + 65, _startPosY + 55, 15, 15);

            }
        }

    }
}

