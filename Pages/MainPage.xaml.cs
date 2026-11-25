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

using trpo10.Models;

namespace trpo10.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public Computer CurrentComputer { get; set; }
        public ObservableCollection<Computer> Computers { get; set; } = new ObservableCollection<Computer>();
        public Computer SelectedComputer { get; set; }
        public MainPage()
        {
            CurrentComputer = new();
            Computers = new ObservableCollection<Computer>(GetComputers());
            SelectedComputer = new();

            InitializeComponent();
            DataContext = this;
        }

        private void SaveConfiguration_Click(object sender, RoutedEventArgs e)
        {
            ComputerBuilder builder = new ComputerBuilder();
            try
            {
                var newComputer = builder
                                    .SetCPU(CurrentComputer.CPU)
                                    .SetRAM(CurrentComputer.RAM)
                                    .SetGraphicsCard(CurrentComputer.GraphicsCard)
                                    .SetSSD(CurrentComputer.SSD)
                                    .Build();

                Computers.Add(newComputer);
                CurrentComputer = new();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(CurrentComputer.CPU + " " + CurrentComputer.RAM + " " + CurrentComputer.SSD + " " + CurrentComputer.GraphicsCard);
            }

        }

        private void Duplicate_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedComputer != null && Computers.Any(c => c == SelectedComputer))
            {
                Computers.Add((Computer)SelectedComputer.Clone());
            }
            else
            {
                MessageBox.Show("Выберите элемент");
            }
        }

        private List<Computer> GetComputers()
        {
            List<Computer> computers = new List<Computer>();

            return computers;
        }
    }
}
