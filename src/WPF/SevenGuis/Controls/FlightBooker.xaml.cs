using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Media;
using System;

namespace SevenGuis.Controls
{
    /// <summary>
    /// Interaction logic for FlightBooker.xaml
    /// </summary>
    public partial class FlightBooker : UserControl
    {
        private const string DateFormatString = "MM.dd.yyyy";
        private bool isReturnFlight = false;
        private DateTime originDate;
        private DateTime returnDate;

        public FlightBooker()
        {
            InitializeComponent();
            originDate = DateTime.Today;
            OriginFlightTextBox.Text = originDate.ToString(DateFormatString);
            returnDate = DateTime.Today;
            ReturnFlightTextBox.Text = returnDate.ToString(DateFormatString);
            ReturnFlightTextBox.IsEnabled = false;
        }

        private void OriginFlightTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DateTime.TryParseExact(OriginFlightTextBox.Text,
                                       DateFormatString,
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out DateTime newOriginDate))
            {
                originDate = newOriginDate;
                SetOriginValid();
                CheckSetBookFlightButton();
            }
            else
            {
                SetOriginInvalid();
                BookFlightButton.IsEnabled = false;
            }
        }

        private void ReturnFlightTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DateTime.TryParseExact(ReturnFlightTextBox.Text,
                           DateFormatString,
                           CultureInfo.InvariantCulture,
                           DateTimeStyles.None,
                           out DateTime newReturnDate))
            {
                returnDate = newReturnDate;
                SetReturnValid();
                CheckSetBookFlightButton();
            }
            else
            {
                SetReturnInvalid();
                BookFlightButton.IsEnabled = false;
            }
        }

        private void SetOriginInvalid()
        {
            OriginFlightTextBox.Background = Brushes.Red;
            ReturnFlightTextBox.IsEnabled = false;
        }

        private void SetReturnInvalid()
        {
            ReturnFlightTextBox.Background = Brushes.Red;
        }

        private void SetOriginValid()
        {
            OriginFlightTextBox.Background = Brushes.White;
            if (isReturnFlight)
            {
                ReturnFlightTextBox.IsEnabled = true;
            }
        }

        private void SetReturnValid()
        {
            ReturnFlightTextBox.Background = Brushes.White;
        }

        private void CheckSetBookFlightButton()
        {
            BookFlightButton.IsEnabled = !isReturnFlight || returnDate >= originDate;
        }

        private void FlightComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(FlightComboBox.SelectedItem.ToString());
            if (((ComboBoxItem)FlightComboBox.SelectedValue).Name == "return")
            {
                isReturnFlight = true;
                ReturnFlightTextBox.IsEnabled = true;
                CheckSetBookFlightButton();
            }
            else
            {
                isReturnFlight = false;
            }
        }

        private void BookFlightButton_Click(object sender, RoutedEventArgs e)
        {
            string caption = "Flight booked!";
            string messageBoxText;

            if (isReturnFlight)
            {
                messageBoxText = $"You have booked a flight from {originDate.ToString(DateFormatString)} to {returnDate.ToString(DateFormatString)}.";
            }
            else
            {
                messageBoxText = $"You have booked a one-way flight on {originDate.ToString(DateFormatString)}.";
            }

            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Exclamation;

            MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
        }
    }
}
