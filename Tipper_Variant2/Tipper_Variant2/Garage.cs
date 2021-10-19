using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tipper_Variant2
{
    /// <summary>
    /// Параметризованный класс для хранения набора объектов от интерфейса ITransport
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Garage<T>
        where T : class, ITransport
    {
        /// <summary>
        /// Массив объектов, которые храним
        /// </summary>
        private readonly T[] _garages;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        /// <summary>
        /// Размер места в гаражe (ширина)
        /// </summary>
        private readonly int _garageSizeWidth = 210;
        /// <summary>
        /// Размер места в гаражe (высота)
        /// </summary>
        private readonly int _garageSizeHeight = 100;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="picWidth">Размер гаража - ширина</param>
        /// <param name="picHeight">Размер гаража - высота</param>
        public Garage(int picWidth, int picHeight)
        {
            int width = picWidth / _garageSizeWidth;
            int height = picHeight / _garageSizeHeight;
            _garages = new T[width * height];
            pictureWidth = picWidth;
            pictureHeight = picHeight;
        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: в гараж добавляется автомобиль
        /// </summary>
        /// <param name="p">Гаражи</param>
        /// <param name="car">Добавляемый автомобиль</param>
        /// <returns></returns>
        public static int operator +(Garage<T> p, T car)
        {
            int add_car = -1;
            for (int i = 0; i < p._garages.Length; i++)
            {
                if (p._garages[i] == null)
                {
                    p._garages[i] = car;
                    add_car = i;
                    break;
                }
            }
            return add_car;
        }
        /// <summary>
        /// Перегрузка оператора вычитания
        /// Логика действия: из гаража забираем автомобиль
        /// </summary>
        /// <param name="p">Гаражи</param>
        /// <param name="index">Индекс гаража, с которого пытаемся извлечь объект</param>
        /// <returns></returns>
        public static T operator -(Garage<T> p, int index)
        {
            T t = null;
            if ((index > -1) && (index < p._garages.Length) && (p._garages[index] != null))
            {
                t = p._garages[index];
                p._garages[index] = null;
            }
            return t;
        }
        /// <summary>
        /// Метод отрисовки гаражей
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _garages.Length; i++)
            {
                _garages[i]?.SetPosition(5 + (i % (pictureWidth / _garageSizeWidth)) * _garageSizeWidth,
                    (i / (pictureWidth / _garageSizeWidth)) * _garageSizeHeight + 25, pictureWidth, pictureHeight);
                _garages[i]?.DrawTransport(g);
            }

        }
        /// <summary>
        /// Метод отрисовки разметки гаражных мест 
        /// </summary>
        /// <param name="g"></param>
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            for (int i = 0; i < pictureWidth / _garageSizeWidth; i++)
            {
                for (int j = 0; j < pictureHeight / _garageSizeHeight + 1; ++j)
                {
                    //крыши гаражей
                    if (j < pictureHeight / _garageSizeHeight)
                    {
                        SolidBrush brownBrush = new SolidBrush(Color.Brown);
                        g.FillPolygon(brownBrush, new Point[] { new Point(i * _garageSizeWidth, j * _garageSizeHeight),
                            new Point(i * _garageSizeWidth + _garageSizeWidth / 2 - 15, j * _garageSizeHeight + 20),
                            new Point(i * _garageSizeWidth, j * _garageSizeHeight + 20)});

                        g.DrawPolygon(pen, new Point[] { new Point(i * _garageSizeWidth, j * _garageSizeHeight),
                            new Point(i * _garageSizeWidth + _garageSizeWidth / 2 - 15, j * _garageSizeHeight + 20),
                            new Point(i * _garageSizeWidth, j * _garageSizeHeight + 20)});
                    }

                    if (j > 0) g.DrawLine(pen, i * _garageSizeWidth, j * _garageSizeHeight, i *
                   _garageSizeWidth + _garageSizeWidth / 2, j * _garageSizeHeight);
                }
                g.DrawLine(pen, i * _garageSizeWidth, 0, i * _garageSizeWidth,
               (pictureHeight / _garageSizeHeight) * _garageSizeHeight);
            }
        }
    }

}
