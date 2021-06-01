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
using SalaryAccounting.Entity;

namespace SalaryAccounting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AppData.userSave = new View_1();

            List<View_1> view = AppData.context.View_1.ToList();
            LoadView(view);

            List<string> prof = AppData.context.Profession.Select(i => i.Name).ToList();
            SearchProfession.ItemsSource = prof;
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (SearchSurName.Text != null)
            {
                List<View_1> view = AppData.context.View_1.ToList();
                if (SearchSurName.Text != "")
                    view = view.FindAll(i => i.SurName == SearchSurName.Text);
                if (SearchProfession.Text != "")
                    view = view.FindAll(i => i.Profession == SearchProfession.Text);
                if (SearchServiceNumber.Text != "")
                    view = view.FindAll(i => i.ServiceNumber == Int32.Parse(SearchServiceNumber.Text));
                LoadView(view);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddChangeUser addWindow = new Windows.AddChangeUser();
            addWindow.ShowDialog();
            List<View_1> view = AppData.context.View_1.ToList();
            LoadView(view);
            View.Items.Refresh();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (View.SelectedItem != null)
            {
                AppData.userSave = (View_1)View.SelectedItem;
                Windows.AddChangeUser addWindow = new Windows.AddChangeUser();
                addWindow.ShowDialog();
                List<View_1> view = AppData.context.View_1.ToList();
                LoadView(view);
                View.Items.Refresh();
            }
            else
                MessageBox.Show("Выбирите пользователя!");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (View.SelectedItem != null)
            {
                View_1 view1 = (View_1)View.SelectedItem;
                AppData.context.User.Remove(AppData.context.User.Where(i => i.idUser == view1.idUser).FirstOrDefault());
                AppData.context.SaveChanges();
                List<View_1> view = AppData.context.View_1.ToList();
                LoadView(view);
                View.Items.Refresh();
            }
            else
                MessageBox.Show("Выбирите пользователя!");

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Creating_Click(object sender, RoutedEventArgs e)
        {
            if(View.SelectedItem != null)
            {
                AppData.userSave = (View_1)View.SelectedItem;
                Windows.ReferenceWindows referenceWindows = new Windows.ReferenceWindows();
                referenceWindows.Show();
                this.Close();
            }
            else
                MessageBox.Show("Выбирите пользователя!");
        }
        public void LoadView(List<View_1> views)
        {
            View.Items.Clear();
            foreach (var item in views)
                View.Items.Add(item);
        }

        private void ResetSearch_Click(object sender, RoutedEventArgs e)
        {
            List<View_1> view = AppData.context.View_1.ToList();
            LoadView(view);
            SearchSurName.Text = "";
            SearchProfession.Text = "";
            SearchServiceNumber.Text = "";
        }

        private void CreatingNow_Click(object sender, RoutedEventArgs e)
        {
            Windows.ReferencesViewsWindows referencesViewsWindows = new Windows.ReferencesViewsWindows();
            referencesViewsWindows.Show();
            this.Close();
        }
    }
}
