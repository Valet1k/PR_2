using PR2_UchebnayaPractika.Classes;
using PR2_UchebnayaPractika.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        int order_id = 0;
        public PageEditOrder(Order order)
        {
            InitializeComponent();

            EquipmentTextBox.Text = order.Equipment;
            SerialNumberTextBox.Text = order.Serial_Number;
            MalfunctionTextBox.Text = order.Type_Of_Malfunction;
            ProblemDescriptionTextBox.Text = order.Description_Problem;
            UserPhoneTextBox.Text = order.Number_Phone;
            order_id = order.OrderID;

            PriorityCmb.SelectedValuePath = "PriorityID";
            PriorityCmb.DisplayMemberPath = "Name_Priority";
            PriorityCmb.ItemsSource = ConnectBase1.entObj.Priority.ToList();


            CpecialNameCmb.SelectedValuePath = "UserID";
            CpecialNameCmb.DisplayMemberPath = "Full_name";
            CpecialNameCmb.ItemsSource = ConnectBase1.entObj.User.Where(x => x.RoleID == 2).ToList();

            if (order.UserID != null)
            {
                CpecialNameCmb.SelectedValue = order.UserID;
            }

            if (order.Priority != null)
            {
                PriorityCmb.SelectedItem = order.Priority;
            }

            if (order.Rough_Date != null)
            {
                RoughDatePicker.SelectedDate = order.Rough_Date;
            }
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnAddSave_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = RoughDatePicker.SelectedDate;
            if ((PriorityCmb.SelectedIndex == -1) || (CpecialNameCmb.SelectedIndex == -1) || !(selectedDate.HasValue))
            {
                MessageBox.Show("Заполните все поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var existingOrder = ConnectBase1.entObj.Order.FirstOrDefault(o => o.OrderID == order_id);

            if (existingOrder != null)
            {

                existingOrder.PriorityID = Convert.ToInt32(PriorityCmb.SelectedValue.ToString());
                existingOrder.UserID = Convert.ToInt32(CpecialNameCmb.SelectedValue.ToString());
                existingOrder.Rough_Date = selectedDate;
                existingOrder.StatusID = 2;

                ConnectBase1.entObj.SaveChanges();

                MessageBox.Show("Запись успешно обновлена!");
            }
            else
            {
                MessageBox.Show("Запись с указанным OrderID не найдена!");
            }
        }
    }
}
