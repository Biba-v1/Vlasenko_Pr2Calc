using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using CalcLib;



namespace Vlasenko_Pr2_Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TBI.Clear();

            foreach(UIElement el in a.Children)
            { 
                if (el is Button)
                ((Button)el).Click += Button_Click;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string TextBut = ((Button)e.OriginalSource).Content.ToString();

            if (TBI.Text == "На ноль делить незя!")
            {
                TBI.Clear();
            }

                if (TextBut == "C")
            {
                TBH.Clear();
                TBI.Clear();
            }
            else if(TextBut == "=")
            {
                TBH.Clear();
                TBH.Text = Regex.Replace((TBI.Text).Trim(), @"\." , ",");
                TBI.Text = Calc.RPN(TBI.Text);

                if (TBI.Text == "На ноль делить незя!")
                {
                    TBH.Clear();
                }
                else TBH.Text += $"={TBI.Text}";
            }
          
            else
            {
                TBI.Text += TextBut;
            }
        }
    }
}
