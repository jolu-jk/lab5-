using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    abstract class HotDrink
    {
        private int sugar = 10; // Сахар.
        private int milk = 15; // Молоко.

        public int Sugar { get => sugar; set => sugar = value; }
        public int Milk { get => milk; set => milk = value; }

    }
}
