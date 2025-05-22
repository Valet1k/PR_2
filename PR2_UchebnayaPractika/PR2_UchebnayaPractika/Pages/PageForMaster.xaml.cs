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
    /// Логика взаимодействия для PageForMaster.xaml
    /// </summary>
    public partial class PageForMaster : Page
    {
        public PageForMaster()
        {
            InitializeComponent();
            GridListRequest.ItemsSource = ConnectBase1.entObj.Order.Where(x => x.UserID == UserControlHelper.UserID).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnCloseOrder_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new CloseOrderPage((sender as Button).DataContext as Order));
        }
    }
}
