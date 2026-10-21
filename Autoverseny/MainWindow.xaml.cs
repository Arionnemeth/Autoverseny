using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Autoverseny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private Random r = new Random();

        private Random kieses = new Random();

        private Random kieso_kocsi = new Random();

        private double celvonal = 650;

        private List<Button> autok = new List<Button>();

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += Timer_Tick;
            autok.Add(auto);
            autok.Add(auto2);
            autok.Add(auto3);
            autok.Add(auto4);
            autok.Add(auto5);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            foreach (var autos in autok)
            {
                Mozog(autos);
            }
        }

        

        private void Mozog(Button auto)
        {
            double aktualispozicio = Canvas.GetLeft(auto);
            double sebesseg = r.Next(1, 5);
            int kieso = kieses.Next(1, 10000);
            double ujpozicio = aktualispozicio + sebesseg;
            Canvas.SetLeft(auto, ujpozicio);
            if(kieso == 67)
            {
                Canvas.SetLeft(autok[kieso_kocsi.Next(0, autok.Count)], 20);
            }
            if (ujpozicio >= celvonal)
            {
                timer.Stop();
                MessageBox.Show($"{auto.Content} nyert!");
                elozo_nyertes.Text = auto.Content.ToString();
                start.IsEnabled = true;
                start.Foreground = Brushes.White;
            }  
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            foreach (var autos in autok)
            {
                Canvas.SetLeft(autos, 20);
            }
            timer.Start();
            start.Foreground = Brushes.Yellow;
            start.IsEnabled = false;
        }
    }

}