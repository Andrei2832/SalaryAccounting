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
using System.Windows.Shapes;
using SalaryAccounting.Entity;

namespace SalaryAccounting.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReferenceWindows.xaml
    /// </summary>
    public partial class ReferenceWindows : Window
    {
        public ReferenceWindows()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SurNameBlock.Text = AppData.userSave.SurName;
            NameBlock.Text = AppData.userSave.Name;
            PatronymicBlock.Text = AppData.userSave.Patronymic;
            ProfessionBlock.Text = AppData.userSave.Profession;
            ServiceNumberBlock.Text = AppData.userSave.ServiceNumber.ToString();
            WorkshopNumberBlock.Text = AppData.userSave.WorkshopNumber.ToString();
            RegionNumberBlock.Text = AppData.userSave.RegionNumber.ToString();
            CityBlock.Text = AppData.userSave.City;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            AppData.userSave = new View_1(); ;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void DigitBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void Form_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Saiary saiary = new Saiary();
                saiary.idUser = AppData.userSave.idUser;
                saiary.SalaryDay = Int32.Parse(SalaryDay.Text);
                saiary.SalaryPay = Int32.Parse(SalaryPay.Text);
                saiary.PaymentHolidaysDay = Int32.Parse(PaymentHolidaysDay.Text);
                saiary.PaymentHolidaysPay = Int32.Parse(PaymentHolidaysDay.Text);
                saiary.HolidaySurchargeDay = Int32.Parse(HolidaySurchargeDay.Text);
                saiary.HolidaySurchargePay = Int32.Parse(HolidaySurchargePay.Text);
                saiary.SurchargeWithoutSurchargesDay = Int32.Parse(SurchargeWithoutSurchargesDay.Text);
                saiary.SurchargeWithoutSurchargesPay = Int32.Parse(SurchargeWithoutSurchargesPay.Text);
                saiary.DifficultyAllowanceDay = Int32.Parse(DifficultyAllowanceDay.Text);
                saiary.DifficultyAllowancePay = Int32.Parse(DifficultyAllowancePay.Text);
                saiary.PrizeDay = Int32.Parse(PrizeDay.Text);
                saiary.PrizePay = Int32.Parse(PrizePay.Text);
                saiary.ratioDay = Int32.Parse(ratioDay.Text);
                saiary.ratioPay = Int32.Parse(ratioPay.Text);

                AppData.context.Saiary.Add(saiary);
                AppData.context.SaveChanges();
                MessageBox.Show("Зарплата сформирована!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }
    }
}
