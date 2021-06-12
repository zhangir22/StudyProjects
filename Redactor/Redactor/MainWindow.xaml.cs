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

namespace Redactor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<MenuItem> MenuItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        

        }



        public void ChangeFontSize(int size)
        {
            TextSelection text = richBox.Selection;
            text.ApplyPropertyValue(TextElement.FontSizeProperty, Convert.ToString(size));
        }
        public void ClearWords(string style)
        {
            string text = richBox.Selection.Text;
            richBox.Selection.Text = richBox.Selection.Text.Replace(text, "");
        }
        public void ChangeWords(string style)
        {
            richBox.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, style);

        }
        private void Bold_Click(object sender, RoutedEventArgs e)
        {
            richBox.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, "Bold");
        }

        private void Italic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearWords("");
        }

        private void FontSize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Size1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Italic_Click_1(object sender, RoutedEventArgs e)
        {
            ChangeWords("Italic");
        }

        private void Underline_Click(object sender, RoutedEventArgs e)
        {
            richBox.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, "Heavy");
            richBox.Selection.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Aquamarine);
        }

        private void FontSize_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void UserChose_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string s = UserChose.Text;
                if (s == "")
                {
                    s = "16";
                }
                ChangeFontSize(Convert.ToInt32(s));
            }
            catch 
            {
                MessageBox.Show("ERROR");
            }
        }

        private void ColorRed_Click(object sender, RoutedEventArgs e)
        {
            richBox.Selection.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Red);
        }

        private void ColorBlue_Click(object sender, RoutedEventArgs e)
        {
            richBox.Selection.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Blue);
        }

        private void ColorGreen_Click(object sender, RoutedEventArgs e)
        {
            richBox.Selection.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Green);
        }

        private void ColorAquamarin_Click(object sender, RoutedEventArgs e)
        {
            richBox.Selection.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Aquamarine);
        }

        private void ColorBrown_Click(object sender, RoutedEventArgs e)
        {
            richBox.Selection.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Brown);
        }
    }
}
