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
        List<int[]> fallosJ1;
        List<int[]> fallosJ2;
        List<int[]> aciertosJ1;
        List<int[]> aciertosj2;
        List<int[]> p_j1;
        List<int[]> p_j2;
        int[] P_A;
        int turno;
        public ventana_jugar(List<int[]> p_j1, List<int[]> p_j2,int turno, List<int[]> f1, List<int[]> f2, List<int[]> a1, List<int[]> a2)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.p_j1 = p_j1;
            this.p_j2 = p_j2;
            this.turno=turno;
            this.fallosJ1=f1;
            this.fallosJ2 = f2;
            this.aciertosJ1 = a1;
            this.aciertosj2= a2;
            Grid grid = new Grid();
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(@"C:\Users\Oscar\source\repos\project\project\bin\Debug\imagenes\1511193452_world-of-warships.jpg"));
            TextBlock instruc = new TextBlock();
            instruc.Text = "CONTROLES:\nA: Izquierda\nD: Derecha\nW: Arriba\nS: Abajo\nEspacio: Disparar\nTurno: Jugador " + turno;
            instruc.Foreground = Brushes.White;
            instruc.FontSize = 22;
            instruc.FontFamily = new FontFamily("Arial Black");
            instruc.Margin = new Thickness(375, 50, 0, 0);
            grid.Children.Add(img);
            grid.Background = Brushes.Black;
            grid.Children.Add(instruc);
            this.Content = grid;
            Grid tablero1 = new Grid();
            Grid tablero2 = new Grid();
            tablero1.Margin = new Thickness(10, 10, 600, 150);
            grid.Children.Add(tablero1);
            tablero2.Margin = new Thickness(600, 10, 10, 150);
            grid.Children.Add(tablero2);
            crear_tablero(tablero1, posiciones);
            crear_tablero(tablero2, posiciones2);
            P_A = new int[2] { 0, 0 };
            if (turno == 1)
            {
                posicionar_barco(p_j1,a1,f1, posiciones,a2,f2,posiciones2);
                posiciones2[P_A[0] + "," + P_A[1]].Background = Brushes.Cyan;
            }
            else
            {
                posicionar_barco(p_j2,a2,f2, posiciones2,a1,f1,posiciones);
                posiciones[P_A[0] + "," + P_A[1]].Background = Brushes.Cyan;
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
        public void posicionar_barco(List<int[]> c, List<int[]> a1, List<int[]> f1, Dictionary<string, Button> p, List<int[]> a2, List<int[]> f2, Dictionary<string, Button> p2)
        {
            try
            {
                foreach (int[] c2 in c)
                {
                    p[Convert.ToString(c2[0]) + "," + Convert.ToString(c2[1])].Background = Brushes.Gray;
                }
                if (a1.Count>0)
                {
                    foreach (int[] c2 in a1)
                    {
                        p[Convert.ToString(c2[0]) + "," + Convert.ToString(c2[1])].Background = Brushes.Red;
                    }
                }
                if (f1.Count > 0)
                {
                    foreach (int[] c2 in f1)
                    {
                        p[Convert.ToString(c2[0]) + "," + Convert.ToString(c2[1])].Background = Brushes.Green;
                    }
                }
                if (a2.Count > 0)
                {
                    foreach (int[] c2 in a2)
                    {
                        p2[Convert.ToString(c2[0]) + "," + Convert.ToString(c2[1])].Background = Brushes.Red;
                    }
                }
                if (f2.Count > 0)
                {
                    foreach (int[] c2 in f2)
                    {
                        p2[Convert.ToString(c2[0]) + "," + Convert.ToString(c2[1])].Background = Brushes.Green;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Posicion invaida");
            }
        }
        public void selec_boton(int[] pf)
        {
            if (turno == 1)
            {
                bool v = false;
                foreach (int[] p in aciertosj2)
                {
                    if (p[0] == P_A[0] && p[1] == P_A[1])
                    {
                        v = true;
                    }
                }
                bool v2 = false;
                foreach (int[] p in fallosJ2)
                {
                    if (p[0] == P_A[0] && p[1] == P_A[1])
                    {
                        v2 = true;
                    }
                }
                posiciones2[P_A[0] + "," + P_A[1]].Background = Brushes.Blue;
                posiciones2[pf[0] + "," + pf[1]].Background = Brushes.Cyan;
                if (v)
                {
                    posiciones2[P_A[0] + "," + P_A[1]].Background = Brushes.Red;
                }
                if (v2)
                {
                    posiciones2[P_A[0] + "," + P_A[1]].Background = Brushes.Green;
                }
                P_A = pf;
            }
            else
            {
                bool v = false;
                foreach (int[] p in aciertosJ1)
                {
                    if (p[0] == P_A[0] && p[1] == P_A[1])
                    {
                        v = true;
                    }
                }
                bool v2 = false;
                foreach (int[] p in fallosJ1)
                {
                    if (p[0] == P_A[0] && p[1] == P_A[1])
                    {
                        v2 = true;
                    }
                }
                posiciones[P_A[0] + "," + P_A[1]].Background = Brushes.Blue;
                posiciones[pf[0] + "," + pf[1]].Background = Brushes.Cyan;
                if (v)
                {
                    posiciones[P_A[0] + "," + P_A[1]].Background = Brushes.Red;
                }
                if (v2)
                {
                    posiciones[P_A[0] + "," + P_A[1]].Background = Brushes.Green;
                }
                P_A = pf;
            }
        }
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            int[] pf = new int[2];
            switch (e.Key)
            {
                case Key.W:
                    if ((P_A[0] - 1) >= 0)
                    {
                        pf[0] = P_A[0] - 1;
                        pf[1] = P_A[1];
                        selec_boton(pf);
                    }
                    break;
                case Key.A:
                    if ((P_A[1] - 1) >= 0)
                    {
                        pf[0] = P_A[0];
                        pf[1] = P_A[1] - 1;
                        selec_boton(pf);
                    }
                    break;
                case Key.S:
                    if ((P_A[0] + 1) <= 9)
                    {
                        pf[0] = P_A[0] + 1;
                        pf[1] = P_A[1];
                        selec_boton(pf);
                    }
                    break;
                case Key.D:
                    if ((P_A[1] + 1) <= 9)
                    {
                        pf[0] = P_A[0];
                        pf[1] = P_A[1] + 1;
                        selec_boton(pf);
                    }
                    break;
                case Key.Space:
                    if (turno ==1)
                    {
                        bool v = true;
                        foreach (int[] p in aciertosj2)
                        {
                            if (p[0] == P_A[0] && p[1] == P_A[1])
                            {
                                v = false;
                            }
                        }
                        foreach (int[] p in fallosJ2)
                        {
                            if (p[0] == P_A[0] && p[1] == P_A[1])
                            {
                                v = false;
                            }
                        }
                        if (v)
                        {
                            bool val = false;
                            foreach (int[] p in p_j2)
                            {
                                if (p[0] == P_A[0] && p[1] == P_A[1])
                                {
                                    val = true;
                                }
                            }
                            if (val)
                            {
                                posiciones2[P_A[0] + "," + P_A[1]].Background = Brushes.Red;
                                aciertosj2.Add(P_A);
                                if (aciertosj2.Count >= 24)
                                {
                                    ventana_ganador ven = new ventana_ganador(turno);
                                    ven.Show();
                                    this.Close();
                                }
                                else
                                {
                                    ventana_jugar ven = new ventana_jugar(p_j1, p_j2, 2, fallosJ1, fallosJ2, aciertosJ1, aciertosj2);
                                    ven.Show();
                                    this.Close();
                                }
                            }
                            else
                            {
                                posiciones2[P_A[0] + "," + P_A[1]].Background = Brushes.Green;
                                fallosJ2.Add(P_A);
                                ventana_jugar ven = new ventana_jugar(p_j1, p_j2, 2, fallosJ1, fallosJ2, aciertosJ1, aciertosj2);
                                ven.Show();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Aqui ya has disparado.");
                        }   
                    }
                    else
                    {
                        bool v = true;
                        foreach (int[] p in aciertosJ1)
                        {
                            if (p[0] == P_A[0] && p[1] == P_A[1])
                            {
                                v = false;
                            }
                        }
                        foreach (int[] p in fallosJ1)
                        {
                            if (p[0] == P_A[0] && p[1] == P_A[1])
                            {
                                v = false;
                            }
                        }
                        if (v)
                        {
                            bool val = false;
                            foreach (int[] p in p_j1)
                            {
                                if (p[0] == P_A[0] && p[1] == P_A[1])
                                {
                                    val = true;
                                }
                            }
                            if (val)
                            {
                                posiciones[P_A[0] + "," + P_A[1]].Background = Brushes.Red;
                                aciertosJ1.Add(P_A);
                                if (aciertosJ1.Count >= 24)
                                {
                                    ventana_ganador ven = new ventana_ganador(turno);
                                    ven.Show();
                                    this.Close();
                                }
                                else
                                {
                                    ventana_jugar ven = new ventana_jugar(p_j1, p_j2, 1, fallosJ1, fallosJ2, aciertosJ1, aciertosj2);
                                    ven.Show();
                                    this.Close();
                                }
                            }
                            else
                            {
                                posiciones[P_A[0] + "," + P_A[1]].Background = Brushes.Green;
                                fallosJ1.Add(P_A);
                                ventana_jugar ven = new ventana_jugar(p_j1, p_j2, 1, fallosJ1, fallosJ2, aciertosJ1, aciertosj2);
                                ven.Show();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Aqui ya has disparado.");
                        }
                        
                    }
                    break;
            }
        }
    }
}
