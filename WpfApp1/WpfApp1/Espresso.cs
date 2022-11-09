using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Espresso : HotDrink
    {
        private int cost; // Стоимость.

        public int Cost { get => cost; set => cost = value; }

        public Espresso()
        {
            cost = 25;
        }
    }
}
