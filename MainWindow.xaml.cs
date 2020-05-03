using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace SecuenciadorTest
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal int CountNest { get; set; }
        internal List<NestForm> NestList { get; set; }
        internal List<Thread> ThreadList { get; set; }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NestList = new List<NestForm>();
        }

        private void btnMenuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        internal void FillNests()
        {
            for (int i = 0; i < CountNest; i++)
            {
                NestForm nestForm = new NestForm();
                //Set the grid dimention
                ColumnDefinition gridCol = new ColumnDefinition();
                dynamicGrid.ColumnDefinitions.Add(gridCol);
                //Add new form to list
                NestList.Add(nestForm);
                Frame frmMain = new Frame();
                //Set the frame
                frmMain.Content = NestList[i];
                //Assign the form to the column
                Grid.SetColumn(frmMain, i);
                dynamicGrid.Children.Add(frmMain);
            }
        }

        internal void Test()
        {
            for (int i = 0; i < CountNest; i++)
            {
                CreateThread();
            }
        }

        internal void CreateThread()
        {
            Thread t1 = new Thread(new ThreadStart( CreateForm));
            t1.SetApartmentState(ApartmentState.STA);
            t1.Name = "Custom Thread";
            t1.Start();
        }

        internal void CreateForm()
        {
            NestForm nestForm = new NestForm();
            NestList.Add(nestForm);
        }


        private void menuCmbNest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (menuCmbNest.SelectedItem != null || menuCmbNest.SelectedIndex != -1)
            {
                if (menuCmbNest.SelectedIndex == 0)
                    CountNest = 1;
                if (menuCmbNest.SelectedIndex == 1)
                    CountNest = 2;
                if (menuCmbNest.SelectedIndex == 2)
                    CountNest = 3;
                menuCmbVersion.IsEnabled = true;
            }
        }

        private void menuCmbVersion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (menuCmbVersion != null || menuCmbVersion.SelectedIndex != -1)
            {
                menuBtnStart.IsEnabled = true;
                FillNests();
            }
        }

        private void menuBtnStart_Click(object sender, RoutedEventArgs e)
        {
            menuBtnStart.IsEnabled = true;
            menuBtnStart.IsEnabled = false;
            menuCmbNest.IsEnabled = false;
            menuCmbVersion.IsEnabled = false;
        }

        
    }
}
