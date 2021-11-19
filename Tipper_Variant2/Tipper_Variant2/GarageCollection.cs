using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipper_Variant2
{
    /// <summary>
    /// Класс-коллекция гаражей
    /// </summary>
    class GarageCollection
    {
        /// <summary>
        /// Словарь (хранилище) с гаражами
        /// </summary>
        readonly Dictionary<string, Garage<Vehicle>> garageStages;
        /// <summary>
        /// Возвращение списка названий гаражей
        /// </summary>
        public List<string> Keys => garageStages.Keys.ToList();
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        /// <summary>
        /// Разделитель для записи информации в файл
        /// </summary>
        private readonly char separator = ':';
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public GarageCollection(int pictureWidth, int pictureHeight)
        {
            garageStages = new Dictionary<string, Garage<Vehicle>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
        }

         /// <summary>
         /// Добавление парковки
         /// </summary>
         /// <param name="name">Название парковки (гаража)</param>
         public void AddGarage(string name)
         {
            if(!garageStages.ContainsKey(name))
            garageStages.Add(name, new Garage<Vehicle>(pictureWidth, pictureHeight));
         }
         /// <summary>
         /// Удаление парковки (гаража)
         /// </summary>
         /// <param name="name">Название парковки (гаража)</param>
         public void DelGarage(string name)
         {
            if (garageStages.ContainsKey(name))
            {
                garageStages.Remove(name);
            }
         }
         /// <summary>
         /// Доступ к парковке (гаражам)
         /// </summary>
         /// <param name="ind"></param>
         /// <returns></returns>
         public Garage<Vehicle> this[string ind]
        {
            get 
            {
                if (garageStages.ContainsKey(ind))
                    return garageStages[ind];
                else
                    return null;
            }
            set 
            {
                if (garageStages.ContainsKey(ind))
                    garageStages[ind] = value; 
            }
         }
        /// <summary>
        /// Метод записи информации в файл
        /// </summary>
        /// <param name="text">Строка, которую следует записать</param>
        /// <param name="stream">Поток для записи</param>
        private void WriteToFile(string text, FileStream stream)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            stream.Write(info, 0, info.Length);
        }
        /// <summary>
        /// Сохранение информации по автомобилям на парковках в файл
        /// </summary>
        /// <param name="filename">Путь и имя файла</param>
        /// <returns></returns>
        public bool SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            using (StreamWriter SW = new StreamWriter(filename)) 
            {
                SW.WriteLine($"GarageCollection");
                foreach (var level in garageStages)
                {
                    SW.WriteLine($"Garage{separator}{level.Key}");
                    ITransport car = null;
                    for (int i = 0; (car = level.Value.GetNext(i)) != null; i++)
                    {
                        if (car != null)
                        {
                            //если место не пустое
                            //Записываем тип машины
                            if (car.GetType().Name == "Truck")
                            {
                                SW.WriteLine($"Truck{separator}" + car);
                            }
                            if (car.GetType().Name == "TipperCar")
                            {
                                SW.WriteLine($"TipperCar{separator}" + car);
                            }

                        }
                    }
                }
            }
                return true;
        }

        /// <summary>
        /// Загрузка информации по автомобилям на парковках из файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                return false;
            }
            string strTextFromFile = "";
            using (StreamReader SR = new StreamReader(filename, new UTF8Encoding(true)))
            {
                int i = 0;
                Vehicle car = null;
                string key = string.Empty;
                while ((strTextFromFile = SR.ReadLine()) != null)
                {
                    if (i == 0)
                    {
                        if (strTextFromFile.Contains("GarageCollection"))
                        {
                            //очищаем записи
                            garageStages.Clear();
                        }
                        else
                        {
                            //если нет такой записи, то это не те данные
                            return false;
                        }
                        i++;
                    }
                    else
                    {
                        //идем по считанным записям
                        if (strTextFromFile.Contains("Garage"))
                        {
                            //начинаем новую парковку
                            key = strTextFromFile.Split(separator)[1];
                            garageStages.Add(key, new Garage<Vehicle>(pictureWidth, pictureHeight));
                            continue;
                        }
                        if (string.IsNullOrEmpty(strTextFromFile))
                        {
                            continue;
                        }
                        if (strTextFromFile.Split(separator)[0] == "Truck")
                        {
                            car = new Truck(strTextFromFile.Split(separator)[1]);
                        }
                        else if (strTextFromFile.Split(separator)[0] == "TipperCar")
                        {
                            car = new TipperCar(strTextFromFile.Split(separator)[1]);
                        }
                        if(key != string.Empty)
                        {
                            var result = garageStages[key] + car;
                            if (result <= -1)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

    }
}
