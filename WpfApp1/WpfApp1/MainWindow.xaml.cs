using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HotDrink drink; // Напиток.
        int money = 0; // Внесенные деньги.
        int sum = 0; // Цена за молоко и сахар.
        int sum2 = 0; // Стоимость напитка.
        public MainWindow()
        {
            InitializeComponent();

            drink = new Americano(); // Первый напиток - американо.

            button_ok.IsEnabled = false; // По умолчанию недоступна, так как в начале 0 р.

            info_label.Content = "Внесенная сумма: " + money.ToString(); // Вывод информации о внесенных деньгах.

            sum2 = ((Americano)drink).Cost; // Стоимость американо.
            cost_label.Content = "Цена напитка: " + (sum2 + sum); // Вывод стоимости напитка на экран.

            // Отображение американо.
            drink_img.Source = new BitmapImage(new Uri("H:\\Лаб5\\WpfApp1\\WpfApp1\\bin\\Debug\\Americano.jpeg", UriKind.Absolute));      

        }

        // Кнопка окей - оплата напитка.
        private void button_ok_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Готово! Сдача: " + (money - sum - sum2).ToString()); // Сообщение о готовности + сдача.
            money = 0; // Обнуление внесенных денег.
            info_label.Content = "Внесенная сумма: " + money.ToString(); // Вывод информации о внесенных деньгах. 

            Check(); // Вызов метода проверки.
        }

        // Кнопка внести деньги.
        private void button_enter_Click(object sender, RoutedEventArgs e)
        {
            // Если поле не пустое.
            if(money_tb.Text != "")
            {
                // Добавление денег.
                money += Convert.ToInt32(money_tb.Text);
            }
            // Вывод новой информации о внесенных деньгах.
            info_label.Content = "Внесенная сумма: " + money.ToString();

            Check(); // Вызов метода проверки.

        }

        // Метод для проверки, хватает ли денег для покупки напитка.
        private void Check()
        {
            // Если внесенных денег меньше, чем стоимость напитка + стоимость сахара и молока.
            if (money < (sum2+sum))
            {
                // Кнопка ок недоступна, так как не хватает денег.
                button_ok.IsEnabled = false;
            }
            // Иначе доступна.
            else button_ok.IsEnabled = true;
        }

        // Добавление/удаление сахара.
        private void sugar_cb_Click(object sender, RoutedEventArgs e)
        {
            // Если галочка стоит (добавили сахар).
            if(sugar_cb.IsChecked == true)
            {
                // К стоимости добавляется цена сахара.
                sum += drink.Sugar;
                // Изображение сахара.
                sugar_img.Source = new BitmapImage(new Uri("H:\\Лаб5\\WpfApp1\\WpfApp1\\bin\\Debug\\sugar.jpeg", UriKind.Absolute));
            }
            // Если не стоит галочка.
            else
            {
                // Из стоимости вычитается цена сахара.
                sum -= drink.Sugar;
                // Картинка пропадает.
                sugar_img.Source = null;
            }
            // Обновление цены напитка.
            cost_label.Content = "Цена напитка: " + (sum2 + sum);

            Check(); // Вызов метода проверки.
        }

        // Добавление/удаление молока.
        private void milk_cb_Click(object sender, RoutedEventArgs e)
        {
            // Если галочка стоит (добавили молоко).
            if (milk_cb.IsChecked == true)
            {
                // К стоимости добавляется цена молока.
                sum += drink.Milk;
                // Изображение молока.
                milk_img.Source = new BitmapImage(new Uri("H:\\Лаб5\\WpfApp1\\WpfApp1\\bin\\Debug\\milk.jpeg", UriKind.Absolute));
            }
            // Если не стоит галочка.
            else
            {
                // Из стоимости вычитается цена молока.
                sum -= drink.Milk;
                // Картинка пропадает.
                milk_img.Source = null;
            }
            // Обновление цены напитка.
            cost_label.Content = "Цена напитка: " + (sum2 + sum);
            Check(); // Вызов метода проверки.
        }

        // Выбор американо.
        private void Americano_rb_Click(object sender, RoutedEventArgs e)
        {
            drink = new Americano(); // Американо.
            sum2 = (drink as Americano).Cost; // Стоимость американо.
            cost_label.Content = "Цена напитка: " + (sum2 + sum); // Обновление цены напитка.
            // Отображение американо.
            drink_img.Source = new BitmapImage(new Uri("H:\\Лаб5\\WpfApp1\\WpfApp1\\bin\\Debug\\Americano.jpeg", UriKind.Absolute));
            drink_img.Stretch = Stretch.Fill;

            Check(); // Вызов метода проверки.
        }
        // Выбор капучино.
        private void Cappuccino_rb_Click(object sender, RoutedEventArgs e)
        { 
            drink = new Cappuccino(); // Капучино.
            sum2 = (drink as Cappuccino).Cost; // Стоимость капучино.
            cost_label.Content = "Цена напитка: " + (sum2 + sum); // Обновление цены напитка.
            // Отображение капучино.
            drink_img.Source = new BitmapImage(new Uri("H:\\Лаб5\\WpfApp1\\WpfApp1\\bin\\Debug\\capp.jpeg", UriKind.Absolute));
            drink_img.Stretch = Stretch.Fill;

            
            Check(); // Вызов метода проверки.
        }
        // Выбор эспрессо.
        private void Espresso_rb_Click(object sender, RoutedEventArgs e)
        {
            drink = new Espresso(); // Эспрессо.
            sum2 = ((Espresso)drink).Cost; // Стоимость эспрессо.
            cost_label.Content = "Цена напитка: " + (sum2+sum); // Обновление цены напитка.
            // Отображение эспрессо.
            drink_img.Source = new BitmapImage(new Uri("H:\\Лаб5\\WpfApp1\\WpfApp1\\bin\\Debug\\espresso.jpeg", UriKind.Absolute));
            drink_img.Stretch = Stretch.Fill;

            Check(); // Вызов метода проверки.
        }
        // Выбор какао.
        private void Cocoa_rb_Click(object sender, RoutedEventArgs e)
        {
            drink = new Cocoa(); // Какао.
            sum2 = ((Cocoa)drink).Cost; // Стоимость какао.
            cost_label.Content = "Цена напитка: " + (sum2 + sum); // Обновление цены напитка.
            // Отображение какао.
            drink_img.Source = new BitmapImage(new Uri("H:\\Лаб5\\WpfApp1\\WpfApp1\\bin\\Debug\\Cocoa.jpeg", UriKind.Absolute));
            drink_img.Stretch = Stretch.Fill;

            Check(); // Вызов метода проверки.
        }
    }
}
