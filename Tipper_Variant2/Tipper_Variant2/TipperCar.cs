using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tipper_Variant2
{
    public class TipperCar : Truck
    {
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }

        /// <summary>
        /// Признак наличия колесных дисков
        /// </summary>
        public bool WheelRims { private set; get; }

        /// <summary>
        /// Признак наличия фар 
        /// </summary>
        public bool Headlight { private set; get; }

        /// <summary>
        /// Признак наличия платформы самосвала 
        /// </summary>
        public bool Platform { private set; get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="wheelRims">Признак наличия колесных дисков</param>
        /// <param name="headlight ">Признак наличия фар</param>
        /// <param name="platform ">Признак наличия платформы самосвала</param>
        public TipperCar(int maxSpeed, float weight, Color mainColor, Color dopColor,
       bool wheelRims, bool headlight, bool platform) :
            base(maxSpeed, weight, mainColor, 90, 50)
        {
            DopColor = dopColor;
            WheelRims = wheelRims;
            Headlight = headlight;
            Platform = platform;
        }

        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);

            {
                Brush spoiler2 = new SolidBrush(DopColor);
                base.DrawTransport(g);

                //отприсовка платформы самосвала
                if (Platform)
                {
                    g.FillRectangle(spoiler2, _startPosX, _startPosY + 10, 50, 30);
                    g.DrawRectangle(pen, _startPosX, _startPosY + 10, 50, 30);

                }

                //отрисовка колесных дисков
                if (WheelRims)
                {
                    Brush sp = new SolidBrush(Color.Gray);
                    g.FillEllipse(sp, _startPosX + 5, _startPosY + 60, 5, 5);
                    g.FillEllipse(sp, _startPosX + 25, _startPosY + 60, 5, 5);
                    g.FillEllipse(sp, _startPosX + 70, _startPosY + 60, 5, 5);
                    g.DrawEllipse(pen, _startPosX + 5, _startPosY + 60, 5, 5);
                    g.DrawEllipse(pen, _startPosX + 25, _startPosY + 60, 5, 5);
                    g.DrawEllipse(pen, _startPosX + 70, _startPosY + 60, 5, 5);
                }

                //отрисовка фар
                if (Headlight)
                {
                    Brush spoiler0 = new SolidBrush(Color.Red);
                    g.FillRectangle(spoiler0, _startPosX + 70, _startPosY + 45, 10, 5);
                    g.FillRectangle(spoiler0, _startPosX, _startPosY + 45, 10, 5);
                    g.DrawRectangle(pen, _startPosX + 70, _startPosY + 45, 10, 5);
                    g.DrawRectangle(pen, _startPosX, _startPosY + 45, 10, 5);
                }
            }

        }

    }
}
