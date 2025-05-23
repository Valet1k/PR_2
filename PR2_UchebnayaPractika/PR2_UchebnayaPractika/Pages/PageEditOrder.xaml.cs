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
using Spire.Xls;
using System.Data;

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

            if (order.StatusID == 1)
            {
                TotalMaterialsTxb.Text = order.Total_Materials_List;
                FinalyDecsription.Text = order.Final_Description;
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
            

            if (existingOrder.StatusID == 1)
            {
                FrameApp.frmObj.Navigate(new Pages.PageEmployee());
                return;
            }


            if (existingOrder != null)
            {

                existingOrder.PriorityID = Convert.ToInt32(PriorityCmb.SelectedValue.ToString());
                existingOrder.UserID = Convert.ToInt32(CpecialNameCmb.SelectedValue.ToString());
                existingOrder.Rough_Date = selectedDate;
                existingOrder.StatusID = 2;

                ConnectBase1.entObj.SaveChanges();

                MessageBox.Show("Запись успешно обновлена!");
                FrameApp.frmObj.Navigate(new Pages.PageEmployee());
            }
            else
            {
                MessageBox.Show("Запись с указанным OrderID не найдена!");
            }
        }

        private void BtnOtchet_Click(object sender, RoutedEventArgs e)
        {

            var existingOrder = ConnectBase1.entObj.Order.FirstOrDefault(o => o.OrderID == order_id);

            if (existingOrder.StatusID != 3)
            {
                MessageBox.Show("НУ НЕ ЗАКРЫЛИ ЕЩЁ ПОГОДИ ТЫЫЫЫ");
                return;
            }

            try
            {
                DataTable dt = new DataTable("OrderTable");

                // 2. Создаем столбцы DataTable (основываясь на свойствах класса Order)
                dt.Columns.Add("OrderID", typeof(int)); // Замените типы на правильные
                dt.Columns.Add("PriorityID", typeof(int));
                dt.Columns.Add("UserID", typeof(int));
                dt.Columns.Add("StatusID", typeof(int));
                // Добавьте все остальные столбцы, соответствующие свойствам класса Order

                // 3. Создаем строку в DataTable и заполняем ее данными из existingOrder
                DataRow dr = dt.NewRow();
                dr["OrderID"] = existingOrder.OrderID;
                dr["PriorityID"] = existingOrder.PriorityID;
                dr["UserID"] = existingOrder.UserID;
                dr["StatusID"] = existingOrder.StatusID;
                // Заполните значения для всех остальных столбцов

                // 4. Добавляем строку в DataTable
                dt.Rows.Add(dr);





                Workbook book = new Workbook();
                Worksheet sheet = book.Worksheets[0];
                sheet.InsertDataTable(dt, true, 1, 1);
                book.SaveToFile("insertTableToExcel.xls");
                System.Diagnostics.Process.Start("insertTableToExcel.xls");



            }
            catch (Exception ex)
            {

            }


        }
    }
}
