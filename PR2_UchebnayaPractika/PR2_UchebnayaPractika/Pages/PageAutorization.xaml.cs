using PR2_UchebnayaPractika.Classes;
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
    /// Логика взаимодействия для PageAutorization.xaml
    /// </summary>
    public partial class PageAutorization : Page
    {
        public PageAutorization()
        {
            InitializeComponent();
            

        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var userObj = ConnectBase1.entObj.User.FirstOrDefault(
                    x => x.Login == TxbLogin.Text && x.Password == PsbPassword.Password);
                

                if (userObj == null)
                {
                    MessageBox.Show("Такой пользователь отсутствует! Если у вас есть аккаунт внимательней просмотрите данные правильно ли вы ввели их, если у вас нет аккаунта пожалуйста зарегистрируйтесь!",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else 
                {
                    UserControlHelper.UserID = userObj.UserID;
                    

                    switch (userObj.RoleID)
                    {
                        case 1:
                            {
                                UserControlHelper.Login = TxbLogin.Text;
                                FrameApp.frmObj.Navigate(new Pages.PageEmployee());
                            }
                            break;

                            case 2: 
                            {
                                UserControlHelper.UserID = userObj.UserID;
                                FrameApp.frmObj.Navigate(new Pages.PageForMaster());
                            }
                            break;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбор в работе приложения:" + ex.Message.ToString(), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Btn_Registration_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Pages.PageRegistrarion());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

    }
}
