using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Cappuccino : HotDrink
    {
        private int cost; // Стоимость.

        public int Cost { get => cost; set => cost = value; }

        public Cappuccino()
        {
            cost = 40;
        }
    }
}
