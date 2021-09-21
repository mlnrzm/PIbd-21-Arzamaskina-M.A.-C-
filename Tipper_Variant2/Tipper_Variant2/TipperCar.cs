using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tipper_Variant2
{
    class TipperCar
    {
        /// <summary>
        /// Левая координата отрисовки автомобиля
        /// </summary>
        private float _startPosX;

        /// <summary>
        /// Правая кооридната отрисовки автомобиля
        /// </summary>
        private float _startPosY;

        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int _pictureWidth;

        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int _pictureHeight;

        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        private readonly int carWidth = 80;

        /// <summary>
        /// Высота отрисовки автомобиля
        /// </summary>
        private readonly int carHeight = 70;

        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { private set; get; }

        /// <summary>
        /// Вес автомобиля
        /// </summary>
        public float Weight { private set; get; }

        /// <summary>
        /// Основной цвет
        /// </summary>
        public Color MainColor { private set; get; }

        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }

        /// <summary>
        /// Признак наличия колесных дисков
        /// </summary>
        public bool WheelRims { private set; get; }

        /// <summary>
        /// Признак наличия лобового стекла
        /// </summary>
        public bool Windscreen { private set; get; }

        /// <summary>
        /// Признак наличия фар 
        /// </summary>
        public bool Headlight { private set; get; }

        /// <summary>
        /// Инициализация свойств
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="wheelRims">Признак наличия колесных дисков</param>
        /// <param name="windscreen">Признак наличия боковых спойлеров</param>
        /// <param name="headlight ">Признак наличия заднего спойлера</param>
        public void Init(int maxSpeed, float weight, Color mainColor, Color dopColor,
       bool wheelRims, bool windscreen, bool headlight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            WheelRims = wheelRims;
            Windscreen = windscreen;
            Headlight = headlight;
        }

        /// <summary>
        /// Установка позиции автомобиля
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            // Продумать логику
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;

        }

        /// <summary>
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
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

        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        public void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);

            {
                Brush spoiler1 = new SolidBrush(MainColor);
                //отрисовка платформы
                g.DrawRectangle(pen, _startPosX, _startPosY + 40, 80, 15);
                g.FillRectangle(spoiler1, _startPosX, _startPosY + 40, 80, 15);

                //отрисовка кабины
                g.DrawRectangle(pen, _startPosX + 55, _startPosY, 25, 40);
                g.FillRectangle(spoiler1, _startPosX + 55, _startPosY, 25, 40);

                //отрисовка колес
                g.DrawEllipse(pen, _startPosX, _startPosY + 55, 15, 15);
                g.DrawEllipse(pen, _startPosX + 20, _startPosY + 55, 15, 15);
                g.DrawEllipse(pen, _startPosX + 65, _startPosY + 55, 15, 15);
                Brush spoiler = new SolidBrush(Color.Black);
                g.FillEllipse(spoiler, _startPosX, _startPosY + 55, 15, 15);
                g.FillEllipse(spoiler, _startPosX + 20, _startPosY + 55, 15, 15);
                g.FillEllipse(spoiler, _startPosX + 65, _startPosY + 55, 15, 15);

                if (WheelRims)
                {
                    Brush sp = new SolidBrush(Color.Gray);
                    g.FillEllipse(sp, _startPosX + 5, _startPosY + 60, 5, 5);
                    g.FillEllipse(sp, _startPosX + 25, _startPosY + 60, 5, 5);
                    g.FillEllipse(sp, _startPosX + 70, _startPosY + 60, 5, 5);
                }

                //отрисовка лобового стекла
                if (Windscreen)
                {
                    Brush spoiler2 = new SolidBrush(DopColor);
                    g.FillRectangle(spoiler2, _startPosX + 65, _startPosY + 4, 15, 20);
                }

                //отрисовка фар
                if (Headlight)
                {
                    Brush spoiler0 = new SolidBrush(Color.Red);
                    g.DrawRectangle(pen, _startPosX + 70, _startPosY + 45, 10, 5);
                    g.FillRectangle(spoiler0, _startPosX + 70, _startPosY + 45, 10, 5);
                    g.DrawRectangle(pen, _startPosX, _startPosY + 45, 10, 5);
                    g.FillRectangle(spoiler0, _startPosX, _startPosY + 45, 10, 5);
                }
            }

        }

    }
}
