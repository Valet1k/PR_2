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
    /// Логика взаимодействия для PageEditOrder.xaml
    /// </summary>
    public partial class PageEditOrder : Page
    {
        public PageEditOrder(Order order)
        {
            InitializeComponent();

            EquipmentTextBox.Text = order.Equipment;
            SerialNumberTextBox.Text = order.Serial_Number;
            MalfunctionTextBox.Text = order.Type_Of_Malfunction;
            ProblemDescriptionTextBox.Text = order.Description_Problem;
            UserPhoneTextBox.Text = order.Number_Phone;

            PriorityCmb.SelectedValuePath = "PriorityID";
            PriorityCmb.DisplayMemberPath = "Name_Priority";
            PriorityCmb.ItemsSource = ConnectBase1.entObj.Priority.ToList();

            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
