using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kyrsach
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            LoadStatus();
            LoadRoom();
            LoadNumber();

           
        }

        private void LoadNumber()
        {
            DB.k_09Entities Connection = new DB.k_09Entities();


            var NumberList = Connection.Статусы_номеров.Where(n => n.Название == "Свободен").ToList();

            foreach (var Status in NumberList)
            {
                var numbers = Status.Номера.ToList();
                foreach (var number in numbers)
                {
                    Room_number.Items.Add(number.Номер);
                }
            }
        }


        private void LoadStatus()
        {
            DB.k_09Entities Connection = new DB.k_09Entities();

            var StatusList = Connection.Номера.ToList();
            foreach (var Status in StatusList)
            {
                Type_of_number.Items.Add(Status.Количество_комнат);
            }
        }
        private void LoadRoom()
        {
            DB.k_09Entities Connection = new DB.k_09Entities();

            var Roomlist = Connection.Номера.ToList();
            foreach (var Room in Roomlist)
            {
                Cost_per_day.Items.Add(Room.Стоимость_день_);
            }
        }

        private void Фамилия_TextChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DB.k_09Entities Connection = new DB.k_09Entities();
            DB.Регистрация регистрация = new DB.Регистрация();
          
            DB.Номера номера = new DB.Номера();

            

            string Reg_Фамилия = Surname.Text;
            string Reg_Имя = Name.Text;
            string Reg_Отчество = Patronomic.Text;
            string Reg_Паспорт = Passport.Text;
            string Reg_Телефон = Phone.Text;
            string Reg_Тип_номера = Type_of_number.Text;
            DateTime Reg_Дата_заселения = Check_in_date.SelectedDate.Value;
            DateTime Reg_Дата_выселения = Check_out_date.SelectedDate.Value;


            decimal Reg_Стоимость_сутки = 0;
            int Reg_Кол_во_ночей = 0;
            long Reg_Номер_номера = 0;

            decimal.TryParse(Cost_per_day.Text, out Reg_Стоимость_сутки);
            int.TryParse(Number_of_nights.Text, out Reg_Кол_во_ночей);
            long.TryParse(Room_number.Text, out Reg_Номер_номера);

           // var Reg_User = Connection.Регистрация.ToList();
            if (Reg_Фамилия.Length == 0 || Reg_Имя.Length == 0 || Reg_Отчество.Length == 0
                || Reg_Паспорт.Length == 0 || Reg_Телефон.Length == 0 || Reg_Тип_номера.Length == 0
                || Check_in_date.SelectedDate == null || Check_out_date.SelectedDate == null
                || Reg_Стоимость_сутки == 0 || Reg_Кол_во_ночей == 0 || Reg_Номер_номера == 0)
            {
                MessageBox.Show("Вы не заполнили поле");
            }
            else
            {

                Surname.Text = "";
                Name.Text = "";
                Patronomic.Text = "";
                Passport.Text = "";
                Phone.Text = "";
                Type_of_number.Text = "";
                Check_in_date.Text = "";
                Check_out_date.Text = "";
                Cost_per_day.Text = "";
                Number_of_nights.Text = "";
                Room_number.Text = "";
                Amount.Content = "";


                регистрация.Имя = Reg_Имя;
                регистрация.Фамилия = Reg_Фамилия;
                регистрация.Отчество = Reg_Отчество;
                регистрация.Паспорт = Reg_Паспорт;
                регистрация.Телефон = Reg_Телефон;
                регистрация.Тип_номера = Reg_Тип_номера;
                регистрация.Дата_заселения = Reg_Дата_заселения;
                регистрация.Дата_выселения = Reg_Дата_выселения;
                регистрация.Стоимость_в_день = Reg_Стоимость_сутки;
                регистрация.Кол_во_ночей = Reg_Кол_во_ночей;
                регистрация.Номер = Reg_Номер_номера;
                номера.Статусы_номеров.Where(m => m.Название == "Свободен").ToList();
                


                Connection.Регистрация.Add(регистрация);
                int result = Connection.SaveChanges();
                if (result != 0)
                {
                    MessageBox.Show("Пользователь успешно добавлен");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }


        }

        private void Тип_номера_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Подсчитать_Click(object sender, RoutedEventArgs e)
        {
            Amount.Content = "";
            int count = 0;

            if (int.TryParse(Number_of_nights.Text, out count) == false)
            {
                return;
            }
            decimal price = (decimal)Cost_per_day.SelectedItem;
            price = count * price;
            Amount.Content = "ИТОГ: " + price;

        }

        private void SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var lastDate = Check_out_date.SelectedDate;
            var firstDate = Check_in_date.SelectedDate;
            if (lastDate == null || firstDate == null)
            {
                return;
            }

            Number_of_nights.Text = (lastDate.Value - firstDate.Value).Days.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(pages.Class1.page2);
        }

        private void Cost_per_day_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Number_of_nights_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Фамилия_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
