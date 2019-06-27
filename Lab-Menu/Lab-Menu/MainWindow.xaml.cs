using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Lab_Menu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoutedCommand MyComandOpen = new RoutedCommand();
        public static RoutedCommand MyComandSave = new RoutedCommand();
        public static RoutedCommand MyComandExit = new RoutedCommand();
        public static RoutedCommand MyComandAbout = new RoutedCommand();
        Employee emp = new Employee();
        
        public MainWindow()
        {
            
            DataContext = this;
            InitializeComponent();

            this.Title = "Employee";

            MyComandOpen.InputGestures.Add(new KeyGesture(Key.O, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(MyComandOpen, MenuItem_Click));

            MyComandSave.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(MyComandSave, MenuItem_Click_1));
            
            MyComandExit.InputGestures.Add(new KeyGesture(Key.E, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(MyComandExit, MenuItem_Click_2));
            
            MyComandAbout.InputGestures.Add(new KeyGesture(Key.A, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(MyComandAbout, MenuItem_Click_2));

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
                     
            if (openFileDialog.ShowDialog() == true)
            {
                this.Title += " - " + openFileDialog.SafeFileName;
                emp.readIn(openFileDialog.FileName);
            }
            idTextBox.Text = emp.id;
            departmentTextBox.Text = emp.department;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();

            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    sw.WriteLine(emp.id);
                    sw.WriteLine(emp.department);
                }
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Creator: Jason Diaz", "About");
        }
    }
}
