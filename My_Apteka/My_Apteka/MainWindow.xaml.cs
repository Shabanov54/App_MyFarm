using My_Apteka.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace My_Apteka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logger logger;
        PasswordWindow password = new PasswordWindow();
        AptCheck check = new AptCheck();
        CheckBox checkBox = new CheckBox();
        List<Apt> apts = new List<Apt>();
        Context context;

        public MainWindow()
        {
            Login login = new Login();
            var loginpass = login.GetPeople();
            if (password.ShowDialog() == true)

                foreach (var item in loginpass)
            {
                    if (password.Password == item.Password && password.LoginName == item.LoginName)
                    {
                        context = new Context();
                        MessageBox.Show("Авторизация пройдена");
                        logger = new Logger();
                        logger.Log($"Был произведен вход пользователя : {password.LoginName}");

                        OpenMainWindow();
                    }
                
            }
            if(password.Password!= "Xharyt34="&& password.Password != "!QAZxsw2" && password.Password != "@WSXcde3" && password.Password != "#EDCvfr4")
            {
                foreach (var item in loginpass)
                {
                    if (password.Password != item.Password || password.LoginName != item.LoginName)
                    {
                        MessageBox.Show("неверный пароль");
                        logger = new Logger();
                        logger.Log($"Не верно введен пароль от Пользователя : {password.LoginName} и введен пароль : {password.Password}");
                        logger.Log("Авторизация не пройдена");
                        MessageBox.Show("Аторизация не пройдена");
                        break;
                    }
                }

            }

        }

internal void OpenMainWindow()

        {
            context = new Context();
            InitializeComponent();
            checkBox.Checked += Chekbox_cheked;
            checkBox.Checked += Chekbox_uncheked;
            DataGridView.MouseLeftButtonUp += DataGridView_Click;
            DataGridView.MouseLeftButtonUp += DataGridView_Click_Text;

        }

        private void Chekbox_cheked(object sender, RoutedEventArgs e)
        {
            apts.Clear();

            try
            {
                var apt = new ObservableCollection<Apt>();
                apts = check.GetAptsCheck();
                foreach (var item in apts)
                {
                    Apt aptDB = item;
                    apt.Add(aptDB);
                }
                DataGridView.ItemsSource = apt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Chekbox_uncheked(object sender, RoutedEventArgs e)
        {
            apts.Clear();

            try
            {
                var apt = new ObservableCollection<Apt>();
                apts = check.GetAptsUNCheck();
                foreach (var item in apts)
                    {
                        Apt aptDB = item;
                        apt.Add(aptDB);
                    }
                    DataGridView.ItemsSource = apt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        public Apt Select_row()
        {
            var select_row = (Apt)DataGridView.SelectedItem;
            return select_row;
        }

        private void DataGridView_Click_Text(object sender, MouseButtonEventArgs e)
        {
            var select_row = Select_row();
                context.OutPut_textBox(select_row, TextBox_View_APT);
        }


        private void DataGridView_Click(object sender, MouseButtonEventArgs e)
        {
            var select_row = Select_row();
                context.OutPut(select_row, TextBox_view);
        }


        private void ComboBoxSelect(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            int q =comboBox.SelectedIndex;

            if (q == 0)
            {
                TextBox_Select.TextChanged += TextBox_Select_node;
            }
            if (q == 2)
            {
                TextBox_Select.TextChanged += TextBox_Select_Adress;
            }
            if (q == 1)
            {
                TextBox_Select.TextChanged += TextBox_Select_UR;
            }
        }

        private void TextBox_Select_UR(object sender, TextChangedEventArgs e)
        {
            var select = new Select_Param(apts);
            string ur_sel = UR_Combobox.Text;

                var i = new ObservableCollection<Apt>();
                List<Apt> ur = select.Select_UR(TextBox_Select);
                foreach (var item in ur)
                {
                    Apt apt = item;
                    i.Add(apt);
                }
                DataGridView.ItemsSource = ur;
        }

        private void TextBox_Select_Adress(object sender, TextChangedEventArgs e)
        {
            var select = new Select_Param(apts);

                var i = new ObservableCollection<Apt>();
                List<Apt> adress = select.Select_ADDress(TextBox_Select);
                foreach (var item in adress)
                {
                    Apt apt = item;
                    i.Add(apt);
                }
                DataGridView.ItemsSource = adress;

        }

        private void TextBox_Select_node(object sender, TextChangedEventArgs e)
        {

            var select = new Select_Param(apts);
                var i = new ObservableCollection<Apt>();
                List<Apt> nodes = select.Select_Node(TextBox_Select);
                foreach (var item in nodes)
                {
                    Apt apt = item;
                    i.Add(apt);
                }
                DataGridView.ItemsSource = nodes;
            }

        private void Select_Change_Click(object sender, RoutedEventArgs e)
        {

            var select_row = Select_row();
            if(select_row!= null)
            {
                Window_Change_My_Apteka Change = new Window_Change_My_Apteka();
                Change.Log(password.LoginName);
                Change.Change_show(select_row);
                Change.Show();
            }
        }


        private void Select_Add_Click(object sender, RoutedEventArgs e)
        {
            Window_Add_My_Apteka Add = new Window_Add_My_Apteka();
            Add.Log(password.LoginName);
            Add.Show();
        }

        private void Select_Del_Click(object sender, RoutedEventArgs e)
        {
            logger = new Logger();

            var select_row = Select_row();
            if (select_row != null)
            {
                context.Dell_Row(select_row, password.LoginName);
                apts.Clear();
            }
        }

    }
}
