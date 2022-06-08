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
using WindowsInput.Native;
using WindowsInput;

namespace project
{
    /// <summary>
    /// Lógica de interacción para ventana_acomodar.xaml
    /// </summary>
    public partial class ventana_acomodar : Window
    {
        int turno;
        public List<int[]> posiciones_J1 = new List<int[]>();
        public List<int[]> posiciones_en_uso=new List<int[]>();
        public Dictionary<string, Button> posiciones = new Dictionary<string, Button>();
        barco b1 = new barco();
        barco b2 = new barco();
        barco b3 = new barco();
        barco b4 = new barco();
        barco b5 = new barco();
        barco b6 = new barco();
        barco[] barcos; 
        int barc;
        public ventana_acomodar(List<int[]> posiciones_J1, int turno)
        {
      
            InitializeComponent();
            this.posiciones_J1 = posiciones_J1;
            this.turno = turno;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Grid grid = new Grid();
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(@"C:\Users\Oscar\source\repos\project\project\bin\Debug\imagenes\1511193452_world-of-warships.jpg"));
            TextBlock instruc= new TextBlock();
            instruc.Text = "CONTROLES:\nA: Izquierda\nD: Derecha\nW: Arriba\nS: Abajo\nR: Rotar\nI: Iniciar la partida\nTurno: Jugador "+turno;
            instruc.Foreground = Brushes.White;
            instruc.FontSize = 22;
            instruc.FontFamily = new FontFamily("Arial Black");
            instruc.Margin= new Thickness(700, 50, 0, 0);
            grid.Children.Add(img);
            grid.Background = Brushes.Black;
            grid.Children.Add(instruc);
            this.Content = grid;
            Grid tablero1 = new Grid();
            tablero1.Margin = new Thickness(10, 10, 600, 150);
            grid.Children.Add(tablero1);
            crear_tablero(tablero1, posiciones);
            crear_RB(grid);
            b1.setposicion(false, new int[2] { 6, 4 }, 1);
            b2.setposicion(false, new int[2] { 0, 3 }, 2);
            b3.setposicion(true, new int[2] { 8, 0 }, 3);
            b4.setposicion(false, new int[2] { 2, 8 }, 4);
            b5.setposicion(true, new int[2] { 0, 5 }, 5);
            b6.setposicion(true, new int[2] { 8, 6 }, 6);
            barc = 0;
            barcos = new barco[6] { b1, b2, b3, b4, b5, b6 };
            foreach (barco item in barcos)
            {
                posicionar_barco(item.getCoordenadas(), item.getCoordenadas());
            }
            relle_P_en_uso();
        }
        public bool verificar_pos(barco b)
        {
            bool val = true;
            for (int i = 0; i < posiciones_en_uso.Count; i++)
            {
                for (int j = 0; j < b.getCoordenadas().Count; j++)
                {
                    string x = Convert.ToString(posiciones_en_uso[i][0]) + Convert.ToString(posiciones_en_uso[i][1]);
                    string y = Convert.ToString(b.getCoordenadas()[j][0]) + Convert.ToString(b.getCoordenadas()[j][1]);
                    if (x.Equals(y))
                    {
                        val = false;
                    }
                }
            }      
            return val;
        }
        public void relle_P_en_uso()
        {
            int x = 5;
            posiciones_en_uso.Clear();
            for (int i = 0; i < x; i++)
            {
                if (i==barc)
                {
                    i++;
                    x++;
                }
                foreach (int [] item in barcos[i].getCoordenadas())
                {
                    posiciones_en_uso.Add(item);
                }
            }
        }
        public void relle_P_en_uso2_0()
        {
            posiciones_en_uso.Clear();
            for (int i = 0; i < barcos.Length; i++)
            {
                foreach (int[] item in barcos[i].getCoordenadas())
                {
                    posiciones_en_uso.Add(item);
                }
            }
        }
        public void crear_RB(Grid g)
        {
            int x = 50;
            String[] n = new string[6] { "Barco 1", "Barco 2", "Barco 3", "Barco 4", "Barco 5", "Barco 6" };
            for (int i = 0; i < n.Length; i++)
            {
                RadioButton rb = new RadioButton();
                rb.Margin = new Thickness(500, x, 0, 0);
                rb.Content = n[i];
                rb.FontSize = 16;
                rb.FontFamily = new FontFamily("Arial Black");
                rb.Foreground = Brushes.White;
                switch (i)
                {
                    case 0:
                        rb.Click += RadioButton_Checked1;
                        rb.IsChecked=true;
                        break;
                    case 1:
                        rb.Click += RadioButton_Checked2;
                        break;
                    case 2:
                        rb.Click += RadioButton_Checked3;
                        break;
                    case 3:
                        rb.Click += RadioButton_Checked4;
                        break;
                    case 4:
                        rb.Click += RadioButton_Checked5;
                        break;
                    case 5:
                        rb.Click += RadioButton_Checked6;
                        break;
                }
                g.Children.Add(rb);
                x += 50;
            }
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
        public void posicionar_barco(List<int[]> a, List<int[]> c)
        {
            List<int[]> b = new List<int[]>();
            try
            {
                foreach (int[] c2 in a)
                {
                    posiciones[Convert.ToString(c2[0]) + "," + Convert.ToString(c2[1])].Background = Brushes.Blue;
                }
                foreach (int[] item in c)
                {
                    posiciones[Convert.ToString(item[0]) + "," + Convert.ToString(item[1])].Background = Brushes.Gray;
                    b.Add(item);
                }
            }
            catch
            {
                foreach (int[] c2 in b)
                {
                    posiciones[Convert.ToString(c2[0]) + "," + Convert.ToString(c2[1])].Background = Brushes.Blue;
                }
                foreach (int[] item in a)
                {
                    posiciones[Convert.ToString(item[0]) + "," + Convert.ToString(item[1])].Background = Brushes.Gray;

                }
            }
        }

        private void RadioButton_Checked1(object sender, RoutedEventArgs e)
        {
            barc = 0;
            relle_P_en_uso();
        }
        private void RadioButton_Checked2(object sender, RoutedEventArgs e)
        {
            barc=1;
            relle_P_en_uso();
        }
        private void RadioButton_Checked3(object sender, RoutedEventArgs e)
        {
            barc = 2;
            relle_P_en_uso();
        }
        private void RadioButton_Checked4(object sender, RoutedEventArgs e)
        {
            barc=3;
            relle_P_en_uso();
        }
        private void RadioButton_Checked5(object sender, RoutedEventArgs e)
        {
            barc=4;
            relle_P_en_uso();
        }
        private void RadioButton_Checked6(object sender, RoutedEventArgs e)
        {
            barc=5;
            relle_P_en_uso();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            int i;
            int j;
            barco x;
            int[] y;
            bool v = true;
            switch (e.Key)
            {
                case Key.W:
                    i = barcos[barc].getCoordenadas()[0][0] - 1;
                    j = barcos[barc].getCoordenadas()[0][1];
                    x= new barco();
                    y= new int[2] {i,j};
                    x.setposicion(barcos[barc].getEstado(), y, barc+1);
                    foreach (int[] item in x.getCoordenadas())
                    {
                        if (item[0] > 9 || item[0] < 0 || item[1] > 9 || item[1] < 0)
                        {
                            v = false;
                        }
                    }
                    if (verificar_pos(x) && v)
                    {
                        posicionar_barco(barcos[barc].getCoordenadas(), x.getCoordenadas());
                        barcos[barc] = x;
                        relle_P_en_uso();
                    }
                    break;
                case Key.A:
                    i = barcos[barc].getCoordenadas()[0][0];
                    j = barcos[barc].getCoordenadas()[0][1]-1;
                    x = new barco();
                    y = new int[2] { i, j };
                    x.setposicion(barcos[barc].getEstado(), y, barc + 1);
                    foreach (int[] item in x.getCoordenadas())
                    {
                        if (item[0] > 9 || item[0] < 0 || item[1] > 9 || item[1] < 0)
                        {
                            v = false;
                        }
                    }
                    if (verificar_pos(x) && v)
                    {
                        posicionar_barco(barcos[barc].getCoordenadas(), x.getCoordenadas());
                        barcos[barc] = x;
                        relle_P_en_uso();

                    }
                    break;
                case Key.S:
                    i = barcos[barc].getCoordenadas()[0][0]+1;
                    j = barcos[barc].getCoordenadas()[0][1];
                    x = new barco();
                    y = new int[2] { i, j };
                    x.setposicion(barcos[barc].getEstado(), y, barc + 1);
                    foreach (int[] item in x.getCoordenadas())
                    {
                        if (item[0] > 9 || item[0] < 0 || item[1] > 9 || item[1] < 0)
                        {
                            v = false;
                        }
                    }
                    if (verificar_pos(x) && v)
                    {

                        posicionar_barco(barcos[barc].getCoordenadas(), x.getCoordenadas());
                        barcos[barc] = x;
                        relle_P_en_uso();

                    }
                    break;
                case Key.D:
                    i = barcos[barc].getCoordenadas()[0][0];
                    j = barcos[barc].getCoordenadas()[0][1]+1;
                    x = new barco();
                    y = new int[2] { i, j };
                    x.setposicion(barcos[barc].getEstado(), y, barc + 1);
                    foreach (int[] item in x.getCoordenadas())
                    {
                        if (item[0] > 9 || item[0] < 0 || item[1] > 9 || item[1] < 0)
                        {
                            v = false;
                        }
                    }
                    if (verificar_pos(x) && v)
                    {

                        posicionar_barco(barcos[barc].getCoordenadas(), x.getCoordenadas());
                        barcos[barc] = x;
                        relle_P_en_uso();
                    }
                    break;
                case Key.R:
                    i = barcos[barc].getCoordenadas()[0][0];
                    j = barcos[barc].getCoordenadas()[0][1];
                    x = new barco();
                    y = new int[2] { i, j };
                    x.setposicion(!(barcos[barc].getEstado()), y, barc + 1);
                    foreach (int[] item in x.getCoordenadas())
                    {
                        if (item[0]>9 || item[0]<0 || item[1] > 9 || item[1] < 0)
                        {
                            v = false;
                        }
                    }
                    if (verificar_pos(x) && v)
                    {

                        posicionar_barco(barcos[barc].getCoordenadas(), x.getCoordenadas());
                        barcos[barc] = x;
                        relle_P_en_uso();
                    }
                    break;
                case Key.I:
                    if (turno == 1)
                    {
                        relle_P_en_uso2_0();
                        ventana_acomodar ven = new ventana_acomodar(posiciones_en_uso, 2);
                        ven.Show();
                        this.Close();
                    }
                    else
                    {
                        relle_P_en_uso2_0();
                        ventana_jugar ve = new ventana_jugar(posiciones_J1,posiciones_en_uso,1,new List<int[]>(),new List<int[]>(),new List<int[]>(),new List<int[]>());
                        ve.Show();
                        this.Close();
                    }
                    break;
                case Key.X:
                    //Mov = "Aba
                    break;
            }
        }
    } 
}
