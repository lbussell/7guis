using System;
using System.Windows.Controls;

namespace SevenGuis.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class TempConverter: UserControl
    {

        public TempConverter()
        {
            InitializeComponent();
        }

        private static double CelsiusToFahrenheit(double celsius)
            => (celsius * 1.8) + 32;

        private static double FahrenheitToCelsius(double fahrenheit)
            => (fahrenheit - 32) * 5.0 / 9.0;

        private void CelsiusTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FahrenheitTextBox is not null && CelsiusTextBox.IsFocused)
            {
                if (double.TryParse(CelsiusTextBox.Text, out double celsius))
                {
                    FahrenheitTextBox.Text = Math.Round(CelsiusToFahrenheit(celsius), 2).ToString();
                }
            }
        }

        private void FahrenheitTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CelsiusTextBox is not null && FahrenheitTextBox.IsFocused)
            {
                if (double.TryParse(FahrenheitTextBox.Text, out double celsius))
                {
                    CelsiusTextBox.Text = Math.Round(FahrenheitToCelsius(celsius), 2).ToString();
                }
            }
        }
    }
}
