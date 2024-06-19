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

namespace pr7._2
{
    /// <summary>
    /// Логика взаимодействия для InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        public InputWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double number1, number2;
            if (double.TryParse(textBox1.Text, out number1) && double.TryParse(textBox2.Text, out number2))
            {
                string result = "";

                // Выполняем вычисления в зависимости от выбранных флажков
                if (checkBoxComposition.IsChecked == true)
                {
                    result += "Composition: " + (number1 * number2) + "\n";
                }
                if (checkBoxPower.IsChecked == true)
                {
                    result += "Power: " + Math.Pow(number1, number2) + "\n";
                }
                if (checkBoxMaxDivisor.IsChecked == true)
                {
                    int maxDivisor = MaxDivisor((int)number1, (int)number2);
                    result += "Max divisor: " + maxDivisor + "\n";
                }

                this.DialogResult = true;
                this.Close();
                ((MainWindow)this.Owner).CalcResult = result;
                ((MainWindow)this.Owner).EnableCalcButton();
            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }
            private int MaxDivisor(int a, int b)
        {
            int maxDivisor = 1;
            for (int i = 2; i <= Math.Min(a, b); i++)
            {
                if (a % i == 0 && b % i == 0)
                {
                    maxDivisor = i;
                }
            }
            return maxDivisor;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
    }

