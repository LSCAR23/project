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

namespace project
{
    /// <summary>
    /// Lógica de interacción para ventana_ganador.xaml
    /// </summary>
    public partial class ventana_ganador : Window
    {
        public ventana_ganador(int g)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Grid grid = new Grid();
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(@"C:\Users\Oscar\source\repos\project\project\bin\Debug\imagenes\1511193452_world-of-warships.jpg"));
            grid.Children.Add(img);
            grid.Background = Brushes.Black;
            Button but_jugar = new Button();
            but_jugar.Content = "Volver";
            but_jugar.HorizontalAlignment = HorizontalAlignment.Left;
            but_jugar.VerticalAlignment = VerticalAlignment.Top;
            but_jugar.Margin = new Thickness(125, 150, 0, 0);
            but_jugar.Height = 45;
            but_jugar.Width = 120;
            but_jugar.Background = Brushes.Green;
            but_jugar.Foreground = Brushes.White;
            but_jugar.FontSize = 16;
            but_jugar.FontFamily = new FontFamily("Arial Black");
            but_jugar.Click += Button_Click;
            TextBlock t = new TextBlock();
            t.Text = "Ganador\njugador "+g+"!";
            t.Margin = new Thickness(110, 80, 0, 0);
            t.FontSize = 30;
            t.Foreground = Brushes.White;
            t.FontFamily = new FontFamily("Arial Black");
            grid.Children.Add(t);
            grid.Children.Add(but_jugar);
            this.Content = grid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ven = new MainWindow();
            ven.Show();
            this.Close();
        }
    }
}
