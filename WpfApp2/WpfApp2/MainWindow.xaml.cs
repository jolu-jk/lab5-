using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer; // Таймер.
        Elevator elevator; // Лифт.
        int cur_floor = 1; // Текущий этаж.
        int need_floor; // Нужный этаж.
        int max_floor; // Кол-во этажей в здании.
        public MainWindow()
        {
            InitializeComponent();
            elevator = new Elevator(); // Лифт.

            // Все кнопки лифта недоступны, пока неизвестно количество этажей в здании (нужно ввести).
            button_close.IsEnabled = false;
            button_open.IsEnabled = false;
            button_enter.IsEnabled = false;
            need_floor_tb.IsEnabled = false;

            // Экран лифта с отображение ткущего этажа скрыт, пока нет самого изображения.
            label_floor.Visibility = Visibility.Hidden;

            // Таймер.
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);


        }

        // Работа таймера.
        private void timer_Tick(object sender, EventArgs e)
        {
            // Если текущий этаж ниже нужного, то
            if (cur_floor < need_floor)
            {
                cur_floor++; // Поднимаемся на этаж выше.
                label.Content = cur_floor.ToString() + "-й этаж" + elevator.Move(elevator.Elevator_Condition); // Выводим сообщение о новом положении.
                // Кнопки недоступны, пока лифт совершает движение.
                button_open.IsEnabled = false;
                button_close.IsEnabled = false;
                button_enter.IsEnabled = false;
                need_floor_tb.IsEnabled = false;
                // На экране лифта отображается текущий этаж.
                label_floor.Content = cur_floor.ToString();
            }
            // Если текущий этаж выше нужного, то
            else if (cur_floor > need_floor)
            {
                cur_floor--; // Спускаемся на этаж ниже.
                label.Content = cur_floor.ToString() + "-й этаж" + elevator.Move(elevator.Elevator_Condition); // Выводим сообщение о новом положении.
                // Кнопки недоступны, пока лифт совершает движение.
                button_open.IsEnabled = false;
                button_close.IsEnabled = false;
                button_enter.IsEnabled = false;
                need_floor_tb.IsEnabled = false;
                // На экране лифта отображается текущий этаж.
                label_floor.Content = cur_floor.ToString();
            }
            // Если лифт приехал на нужный этаж, то 
            else
            {
                timer.Stop(); // Остановка таймера.
                elevator.Elevator_Condition = Elevator.Elevator_condition.Close; // Состояние меняется от движения на закрытые двери.
                label.Content = cur_floor.ToString() + "-й этаж" + elevator.Move(elevator.Elevator_Condition); // Выводим сообщение о новом положении.
                button_open.IsEnabled = true; // Кнопка открыть двери доступна, так как лифт стоит.
            }
        }

        // Кнопка открыть двери.
        private void button_open_Click(object sender, RoutedEventArgs e)
        {
            elevator.Elevator_Condition = Elevator.Elevator_condition.Open; // Изменение состояния лифта.

            // Ввод нужного этажа недоступен, так как двери открыты, закрыть двери доступна.
            button_close.IsEnabled = true;
            button_open.IsEnabled = false;
            button_enter.IsEnabled = false;
            need_floor_tb.IsEnabled = false;

            // Вывод состояния на экран.
            label.Content = cur_floor.ToString() + "-й этаж" + elevator.Move(elevator.Elevator_Condition);
            // Отображение лифта.
            elevator_img.Source = new BitmapImage(new Uri("H:\\Лаб5\\WpfApp2\\WpfApp2\\bin\\Debug\\open.jpeg", UriKind.Absolute));
            elevator_img.Stretch = Stretch.Fill;
        }

        // Кнопка закрыть двери.
        private void button_close_Click(object sender, RoutedEventArgs e)
        {
            elevator.Elevator_Condition = Elevator.Elevator_condition.Close; // Изменение состояния лифта.
            // Ввод нужного этажа доступен, так как двери закрыты, открыть двери доступна.
            button_enter.IsEnabled = true;
            button_open.IsEnabled = true;
            button_close.IsEnabled = false;
            need_floor_tb.IsEnabled = true;
            // Вывод состояния на экран.
            label.Content = cur_floor.ToString() + "-й этаж" + elevator.Move(elevator.Elevator_Condition);
            // Отображение лифта.
            elevator_img.Source = new BitmapImage(new Uri("H:\\Лаб5\\WpfApp2\\WpfApp2\\bin\\Debug\\close.jpeg", UriKind.Absolute));
            elevator_img.Stretch = Stretch.Fill;
        }

        // Кнопка ввода количества этажей в здании.
        private void button_ok_Click(object sender, RoutedEventArgs e)
        {
            // Запись в переменную.
            max_floor = Convert.ToInt32(floor_num.Text);
            // Скрытие элементов.
            floor_num.Visibility = Visibility.Hidden;
            button_ok.Visibility = Visibility.Hidden;
            info_label.Visibility = Visibility.Hidden;

            // Кнопка закрыть доступна, так как двери открыты в начале.
            button_close.IsEnabled = true;
            // Вывод состояния на экран.
            label.Content = cur_floor.ToString() + "-й этаж" + elevator.Move(elevator.Elevator_Condition);
            // Отображение лифта.
            elevator_img.Source = new BitmapImage(new Uri("H:\\Лаб5\\WpfApp2\\WpfApp2\\bin\\Debug\\open.jpeg", UriKind.Absolute));
            elevator_img.Stretch = Stretch.Fill;
            label_floor.Visibility = Visibility.Visible;
            label_floor.Content = cur_floor.ToString();
        }
        // Кнопка ввода нужного этажа.
        private void button_enter_Click(object sender, RoutedEventArgs e)
        {
            // Запись в переменную.
            need_floor = Convert.ToInt32(need_floor_tb.Text);
            // Если текущий этаж ниже нужного и нужный не привышает кол-во этажей здания.
            if (cur_floor < need_floor && need_floor <= max_floor)
            {
                // Лифт начинает движение вверх.
                elevator.Elevator_Condition = Elevator.Elevator_condition.Up;
                timer.Start();
            }
            // Если текущий этаж выше нужного и нужный не ниже 1.
            else if (cur_floor > need_floor && need_floor > 0)
            {
                // Лифт начинает движение вниз.
                elevator.Elevator_Condition = Elevator.Elevator_condition.Down;
                timer.Start();
            }
            else
            {
                // Если нужный этаж - это текущий или нужный выходит за рамки, то игнорирование команды.
                need_floor_tb.Text = null;
                elevator.Elevator_Condition = Elevator.Elevator_condition.Close;
            }
        }
    }
}
