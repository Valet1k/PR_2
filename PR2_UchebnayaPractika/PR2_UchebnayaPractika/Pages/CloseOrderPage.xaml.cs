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
    /// Логика взаимодействия для CloseOrderPage.xaml
    /// </summary>
    public partial class CloseOrderPage : Page
    {
        int order_id = 0;
        public CloseOrderPage(Order order)
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

        private void BtnOrderClose_Click(object sender, RoutedEventArgs e)
        {
            var existingOrder = ConnectBase1.entObj.Order.FirstOrDefault(o => o.OrderID == order_id);

            if (existingOrder != null)
            {

                existingOrder.Final_Description = FinalyDecsription.Text;
                existingOrder.Total_Materials_List = TotalMaterialsTxb.Text;
                existingOrder.Close_Date = DateTime.Now;
                existingOrder.StatusID = 1;

                ConnectBase1.entObj.SaveChanges();

                MessageBox.Show("Запись успешно обновлена!");
            }
            else
            {
                MessageBox.Show("Запись с указанным OrderID не найдена!");
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            int material_count = 0;
            if (string.IsNullOrEmpty(MaterialNameTxb.Text) || string.IsNullOrEmpty(MaterialCountTxb.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (!(int.TryParse(MaterialCountTxb.Text, out material_count)))
            {
                MessageBox.Show("Количество должно быть числом!");
                MaterialCountTxb.Clear();
                return;
            }

            string material_name = MaterialNameTxb.Text;
            material_count = Convert.ToInt32(MaterialCountTxb.Text);

            TotalMaterialsTxb.AppendText($"{material_name} в количестве {material_count} шт;\n");

            MaterialNameTxb.Clear();
            MaterialCountTxb.Clear();
        }
    }
}
