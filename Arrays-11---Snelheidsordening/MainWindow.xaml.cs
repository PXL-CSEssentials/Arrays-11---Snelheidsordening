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

namespace Arrays_11___Snelheidsordening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private short _index = 0;
        private const short MaxNumber = 100;
        private StringBuilder _resultBuilder = new StringBuilder();

        private int[] _times = new int[MaxNumber];
        private string[] _atletes = new string[MaxNumber];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            if (_index >= MaxNumber)
            {
                MessageBox.Show($"Klik eerst op opnieuw. Het maximaal aantal atleten van {MaxNumber} is bereikt!",
                    "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Nieuwe invoer toevoegen aan arrays
            _atletes[_index] = nameTextBox.Text;
            _times[_index] = int.Parse(timeTextBox.Text);
            _index++;

            // Klaarzetten voor nieuwe invoer
            nameTextBox.Clear();
            timeTextBox.Text = "0";
            nameTextBox.Focus();
        }

        private void fastestButton_Click(object sender, RoutedEventArgs e)
        {
            // Ordenen van klein naar groot.
            for (int i = 0; i < _index; i++)
            {
                int indexOfFastest = i;
                for (int j = i + 1; j < _index; j++)
                    if (_times[j] < _times[indexOfFastest])
                        indexOfFastest = j; // indien sneller dan het minimum, wordt deze tijd het nieuwe minimum

                // Wissel vorige minimum (index i) met nieuwe minimum (indexVanSnelste)
                // eerst voor de tijden
                int tempTime = _times[i];
                _times[i] = _times[indexOfFastest];
                _times[indexOfFastest] = tempTime;

                // daarna voor de atleten
                string tempName = _atletes[i];
                _atletes[i] = _atletes[indexOfFastest];
                _atletes[indexOfFastest] = tempName;
            }
            // Resultaat opbouwen en tonen
            _resultBuilder.Clear();
            for (int i = 0; i < _index; i++)
            {
                _resultBuilder.AppendLine($"{_atletes[i],-20}{_times[i]}");
            }

            resultTextBox.Text = _resultBuilder.ToString();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            // Arrays leeg maken en aantal terug op 0 brengen
            _index = 0;
            Array.Clear(_times, 0, _times.Length);
            Array.Clear(_atletes, 0, _atletes.Length);

            //Alternatief
            //for (int i = 0; i < _times.Length; i++)
            //{
            //    _times[i] = 0;
            //}
            //for (int i = 0; i < _atletes.Length; i++)
            //{
            //    _atletes[i] = "";
            //}

            // Tekstvakken leeg maken
            resultTextBox.Clear();
            nameTextBox.Clear();
            timeTextBox.Text = "0";
            nameTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
