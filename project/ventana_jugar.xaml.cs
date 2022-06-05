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
    /// Lógica de interacción para ventana_jugar.xaml
    /// </summary>
    public partial class ventana_jugar : Window
    {
        public Dictionary<string, Button> posiciones = new Dictionary<string, Button>();
        public Dictionary<string, Button> posiciones2 = new Dictionary<string, Button>();
        List<int[]> p_j1;
        List<int[]> p_j2;
        public ventana_jugar(List<int[]> p_j1, List<int[]> p_j2)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.p_j1 = p_j1;
            this.p_j2 = p_j2;
            Grid grid = new Grid();
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(@"C:\Users\Oscar\source\repos\project\project\bin\Debug\imagenes\1511193452_world-of-warships.jpg"));
            grid.Children.Add(img);
            grid.Background = Brushes.Black;
            this.Content = grid;
            Grid tablero1 = new Grid();
            Grid tablero2 = new Grid();
            tablero1.Margin = new Thickness(10, 10, 600, 150);
            grid.Children.Add(tablero1);
            tablero2.Margin = new Thickness(600, 10, 10, 150);
            grid.Children.Add(tablero2);
            crear_tablero(tablero1, posiciones);
            crear_tablero(tablero2, posiciones2);
            posicionar_barco(p_j1, posiciones);
            posicionar_barco(p_j2, posiciones2);
        }
        public void crear_tablero(Grid tab, Dictionary<string, Button> posiciones)
        {
            int x = 0;
            int y = 0;
            for (int i = 10; i < 360; i = i + 35)
            {
                y = 0;
                for (int j = 10; j < 360; j = j + 35)
                {
                    Button button = new Button();
                    button.Height = 35;
                    button.Width = 35;
                    button.Background = Brushes.Blue;
                    button.HorizontalAlignment = HorizontalAlignment.Left;
                    button.VerticalAlignment = VerticalAlignment.Top;
                    button.Margin = new Thickness(j, i, 0, 0);
                    posiciones.Add(Convert.ToString(x) + "," + Convert.ToString(y), button);
                    tab.Children.Add(button);
                    y++;
                }
                x++;
            }
        }
        public void posicionar_barco(List<int[]> c, Dictionary<string, Button> p)
        {
            try
            {
                foreach (int[] c2 in c)
                {
                    p[Convert.ToString(c2[0]) + "," + Convert.ToString(c2[1])].Background = Brushes.Gray;
                }
            }
            catch
            {
                MessageBox.Show("Posicion invaida");
            }
        }
    }
}
