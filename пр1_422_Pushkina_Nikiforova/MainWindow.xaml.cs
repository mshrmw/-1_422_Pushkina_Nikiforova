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

namespace пр1_422_Pushkina_Nikiforova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            vichislit.Click += vichislit_Click;
            ochistit.Click += ochistit_Click;
        }
        private void vichislit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double xValue = double.Parse(x_t.Text);
                double yValue = double.Parse(m_t.Text);

                double result = CalculateB(xValue, yValue);
                otvet.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода данных: " + ex.Message);
            }
        }
        private double CalculateB(double x, double y)
        {
            double fX = GetFunctionValue(x);

            if (y == 0)
            {
                return 0;
            }
            else if (x == 0)
            {
                return Math.Pow(fX * fX + y, 3);
            }
            else if (x / y > 0)
            {
                return Math.Log(fX) + Math.Pow(fX * fX + y, 3);
            }
            else
            {
                return Math.Log(Math.Abs(fX / y)) + Math.Pow(fX + y, 3);
            }
        }

        private double GetFunctionValue(double x)
        {
            if (sh.IsChecked == true)
            {
                return Math.Sinh(x);
            }
            else if (steptwo.IsChecked == true)
            {
                return x * x;
            }
            else if (estepx.IsChecked == true)
            {
                return Math.Exp(x);
            }
            else
            {
                throw new InvalidOperationException("Функция не выбрана.");
            }
        }


        private void ochistit_Click(object sender, RoutedEventArgs e)
        {
            x_t.Text = string.Empty;
            m_t.Text = string.Empty;
            otvet.Text = string.Empty;
            sh.IsChecked = false;
            steptwo.IsChecked = false;
            estepx.IsChecked = false;
        }
    }
}