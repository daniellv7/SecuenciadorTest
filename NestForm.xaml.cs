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
using System.Threading;

namespace SecuenciadorTest
{
    /// <summary>
    /// Lógica de interacción para NestForm.xaml
    /// </summary>
    public partial class NestForm : Page
    {
        public int State { get; set; }

        bool stateMachineStatus;

        public NestForm()
        {
            InitializeComponent();
            //
            
        }

        internal void InitStateMachine()
        {
            while (stateMachineStatus)
            {
                switch (State)
                {
                    case 1: //Start
                        break;
                    case 2: //Stop
                        break;
                }
            }
        }

        internal void StartSequence()
        {

        }

        internal void FillListView()
        {
            List<Steps> items = new List<Steps>();
            items.Add(new Steps() { Name = "Prueba numero 1", Number = 1, Status = "Passed" });
            items.Add(new Steps() { Name = "Prueba numero 2", Number = 2, Status = "Passed" });
            items.Add(new Steps() { Name = "Prueba numero 3", Number = 3, Status = "Failed" });
            lvwSteps.ItemsSource = items;
        }
    }
}
