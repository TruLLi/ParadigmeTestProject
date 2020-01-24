using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba1
{
    public class Car : CrashMove
    {
        public override int Victory(Motorcycle motorcycle)
        {
            return 1;
        }
        public override int Victory(Truck truck)
        {
            return -1;
        }
        public override int Victory(Car car)
        {
            return 0;
        }
    }
}
