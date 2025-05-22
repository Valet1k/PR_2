using PR2_UchebnayaPractika.Classes;
using PR2_UchebnayaPractika.DataBase;
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

namespace PR2_UchebnayaPractika.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnAddSave_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(EquipmentTextBox.Text) || string.IsNullOrWhiteSpace(SerialNumberTextBox.Text) || string.IsNullOrWhiteSpace(MalfunctionTextBox.Text) || string.IsNullOrWhiteSpace(UserPhoneTextBox.Text) || string.IsNullOrWhiteSpace(ProblemDescriptionTextBox.Text))
            {
                MessageBox.Show("Заполните все поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                Order orderObj = new Order()
                {
                    Equipment = EquipmentTextBox.Text,
                    Serial_Number = SerialNumberTextBox.Text,
                    Type_Of_Malfunction = MalfunctionTextBox.Text,
                    Description_Problem = ProblemDescriptionTextBox.Text,
                    Number_Phone = UserPhoneTextBox.Text,
                    StatusID = 3,
                    DateAdd = DateTime.Now
                };

                ConnectBase1.entObj.Order.Add(orderObj);
                ConnectBase1.entObj.SaveChanges();
                MessageBox.Show($"Скоро починим ваш дурацкий {EquipmentTextBox.Text} ожидайте!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Фигню выкакал! Проверьте правильно ли вы ввели данные!" + ex.Message.ToString(),
                        " Сбой работы приложения!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
}
    }
}
