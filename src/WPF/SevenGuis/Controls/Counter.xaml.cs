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

namespace SevenGuis.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Counter : UserControl
    {
        private int count = 0;

        public Counter()
        {
            InitializeComponent();
        }

        private void CounterButton_Click(object sender, RoutedEventArgs e)
        {
            count += 1;
            CounterTextBox.Text = count.ToString();
        }
    }
}
