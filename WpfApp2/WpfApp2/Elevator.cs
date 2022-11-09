using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    class Elevator
    {
        private Elevator_condition elevator_Condition; // Состояние лифта.

        public Elevator_condition Elevator_Condition { get => elevator_Condition; set => elevator_Condition = value; }

        // Конструктор.
        public Elevator()
        {
            elevator_Condition = Elevator_condition.Open;
        }

        public string Move(Elevator_condition condition)
        {
            switch (condition)
            {
                case Elevator_condition.Up: // Вверх.
                    return ": движется вверх";
                case Elevator_condition.Down: // Вниз.
                    return ": движется вниз";
                case Elevator_condition.Open: // Открытые двери.
                    return ": двери открыты";
                case Elevator_condition.Close: // Закрытые двери.
                    return ": двери закрыты";
                default:
                    return ": лифт не работает."; // Если ничего не совпало.
            }
        }

        public enum Elevator_condition // Перечисления состояний лифта.
        {
            Up,
            Down,
            Open,
            Close
        }
    }


}
