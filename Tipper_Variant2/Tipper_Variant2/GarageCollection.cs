using System;
using System.Collections.Generic;
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
                garageStages.Remove(name);
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
    }
}
