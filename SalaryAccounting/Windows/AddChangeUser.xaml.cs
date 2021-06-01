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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddChangeUser : Window
    {
        List<String> Prof = new List<string>();
        List<String> City = new List<string>();
        public AddChangeUser()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Prof = AppData.context.Profession.Select(i => i.Name).ToList();
            ProfessionBox.ItemsSource = Prof;

            City = AppData.context.City.Select(i => i.Name).ToList();
            CityBox.ItemsSource = City;

            if (AppData.userSave.Name != null)
            {
                AddBut.Content = "Изменить";

                SurNameBox.Text = AppData.userSave.SurName;
                NameBox.Text = AppData.userSave.Name;
                PatronymicBox.Text = AppData.userSave.Patronymic;
                ProfessionBox.SelectedIndex = AppData.context.Profession.Where(i => i.Name == AppData.userSave.Profession).Select(j => j.idProfession).FirstOrDefault() - 1;
                ServiceNumberBox.Text = AppData.userSave.ServiceNumber.ToString();
                WorkshopNumberBox.Text = AppData.userSave.WorkshopNumber.ToString();
                RegionNumberBox.Text = AppData.userSave.RegionNumber.ToString();
                CityBox.SelectedIndex = AppData.context.City.Where(i => i.Name == AppData.userSave.City).Select(j => j.idCity).FirstOrDefault() - 1;
            }
        }
        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            if (SurNameBox.Text != "" && NameBox.Text != "" && ProfessionBox.Text != "" && ServiceNumberBox.Text != "" && WorkshopNumberBox.Text != "" && RegionNumberBox.Text != "" && CityBox.Text != "")
            {
                if (AppData.userSave.Name != null)
                {
                    User user = AppData.context.User.Where(i => i.idUser == AppData.userSave.idUser).FirstOrDefault();
                    user.SurName = SurNameBox.Text;
                    user.Name = NameBox.Text;
                    user.Patronymic = PatronymicBox.Text;
                    user.idProfession = AppData.context.Profession.Where(i => i.Name == ProfessionBox.Text).Select(j => j.idProfession).FirstOrDefault();
                    user.ServiceNumber = Convert.ToInt32(ServiceNumberBox.Text);
                    user.WorkshopNumber = Convert.ToInt32(WorkshopNumberBox.Text);
                    user.RegionNumber = Convert.ToInt32(RegionNumberBox.Text);
                    user.idCity = AppData.context.City.Where(i => i.Name == CityBox.Text).Select(j => j.idCity).FirstOrDefault();

                    AppData.userSave = null;
                    AppData.context.SaveChanges();
                    this.Close();

                }
                else
                {
                    User user = AppData.context.User.Add(new User()
                    {
                        SurName = SurNameBox.Text,
                        Name = NameBox.Text,
                        Patronymic = PatronymicBox.Text,
                        idProfession = AppData.context.Profession.Where(i => i.Name == ProfessionBox.Text).Select(j => j.idProfession).FirstOrDefault(),
                        ServiceNumber = Convert.ToInt32(ServiceNumberBox.Text),
                        WorkshopNumber = Convert.ToInt32(WorkshopNumberBox.Text),
                        RegionNumber = Convert.ToInt32(RegionNumberBox.Text),
                        idCity = AppData.context.City.Where(i => i.Name == CityBox.Text).Select(j => j.idCity).FirstOrDefault(),
                    });

                    AppData.context.SaveChanges();
                    this.Close();
                }
            }

                

        }

        private void CancelBut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DigitBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
                e.Handled = true;
            else
                e.Handled = false;
        }
    }
}
