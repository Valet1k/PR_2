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
    /// Логика взаимодействия для PageRegistrarion.xaml
    /// </summary>
    public partial class PageRegistrarion : Page
    {
        public PageRegistrarion()
        {
            InitializeComponent();
            RoleComboBox.SelectedValuePath = "RoleID";
            RoleComboBox.DisplayMemberPath = "Name";
            RoleComboBox.ItemsSource = ConnectBase1.entObj.Role.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TxbPassword.Text == PsbPassword.Password)
            {
                Btn_Create.IsEnabled = true;
                PsbPassword.Background = Brushes.LightGreen;
                PsbPassword.BorderBrush = Brushes.Green;
                Btn_Create.Background = Brushes.Transparent;
            }
            else
            {
                Btn_Create.IsEnabled = false;
                PsbPassword.Background = Brushes.DarkRed;
                PsbPassword.BorderBrush = Brushes.DarkRed;
            }
        }

        private void Btn_Create_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TxbLogin.Text) || string.IsNullOrWhiteSpace(TxbFullName.Text) || string.IsNullOrWhiteSpace(TxbPassword.Text) || (RoleComboBox.SelectedIndex == -1))
            {
                MessageBox.Show("Заполните все поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }













            if (ConnectBase1.entObj.User.Count(x => x.Login == TxbLogin.Text) > 0)
            {
                MessageBox.Show("Такой пользователь уже есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                try
                {

                    User userObj = new User()
                    {
                        Login = TxbLogin.Text,
                        Password = TxbPassword.Text,
                        RoleID = Convert.ToInt32(RoleComboBox.SelectedValue.ToString()),
                        Full_name = TxbFullName.Text,
                    };

                    ConnectBase1.entObj.User.Add(userObj);
                    ConnectBase1.entObj.SaveChanges();
                    MessageBox.Show("Вы успешно зарегистрировались!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка! Проверьте правильно ли вы ввели данные!" + ex.Message.ToString(),
                        " Сбой работы приложения!", MessageBoxButton.OK, MessageBoxImage.Error);
                }



            }

            
            

            

        }
    }
}
