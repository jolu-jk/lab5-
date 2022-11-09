using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Cocoa : HotDrink
    {
        private int cost; // Стоимость.

        public int Cost { get => cost; set => cost = value; }

        public Cocoa()
        {
            cost = 35;
        }
    }
}
