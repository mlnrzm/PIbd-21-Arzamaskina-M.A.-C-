using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipper_Variant2
{
    public class CarComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            if (x is TipperCar && y is Truck) return -1;
            else if (x is Truck && y is TipperCar) return 1;
            else if (x is Truck && y is Truck)
            {
                if (ComparerTruck((Truck)x, (Truck)y) < 0) return 1;
                else if (ComparerTruck((Truck)x, (Truck)y) > 0) return -1;
                else if (ComparerTruck((Truck)x, (Truck)y) == 0) return 0;
            }
            else if (x is TipperCar && y is TipperCar) 
            {
                if (ComparerTipperCar((TipperCar)x, (TipperCar)y) < 0) return 1;
                else if (ComparerTipperCar((TipperCar)x, (TipperCar)y) > 0) return -1;
                else if (ComparerTipperCar((TipperCar)x, (TipperCar)y) == 0) return 0;
            }
            return 0;
        }
        private int ComparerTruck(Truck x, Truck y)
        {
            if (x.MaxSpeed != y.MaxSpeed)
            {
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            }

            if (x.Weight != y.Weight)
            {
                return x.Weight.CompareTo(y.Weight);
            }
            if (x.MainColor != y.MainColor)
            {
                return x.MainColor.Name.CompareTo(y.MainColor.Name);
            }
            return 0;
        }
        private int ComparerTipperCar(TipperCar x, TipperCar y)
        {
            var res = ComparerTruck(x, y);
            if (res != 0)
            {
                return res;
            }
            if (x.DopColor != y.DopColor)
            {
                return x.DopColor.Name.CompareTo(y.DopColor.Name);
            }
            if (x.WheelRims != y.WheelRims)
            {
                return x.WheelRims.CompareTo(y.WheelRims);
            }
            if (x.Headlight != y.Headlight)
            {
                return x.Headlight.CompareTo(y.Headlight);
            }
            if (x.Platform != y.Platform)
            {
                return x.Platform.CompareTo(y.Platform);
            }
            return 0;
        }
    }

}
