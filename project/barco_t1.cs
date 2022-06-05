using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class barco
    {
        private bool estado;
        private List<int[]> coordenadas = new List<int[]>();
        public void setposicion(bool estado, int[] c_i,int tipo)
        {
            this.estado = estado;
            switch (tipo)
            {
                case 1:
                    coordenadas.Clear();
                    if (estado)
                    {
                        coordenadas.Add(c_i);
                        int[] c = new int[2] { c_i[0], c_i[1] + 1 };
                        coordenadas.Add(c);
                    }
                    else
                    {
                        coordenadas.Add(c_i);
                        int[] c = new int[2] { c_i[0] + 1, c_i[1] };
                        coordenadas.Add(c);
                    }
                    break;
                case 2:
                    coordenadas.Clear();
                    if (estado)
                    {
                        coordenadas.Add(c_i);
                        int[] c = new int[2] { c_i[0], c_i[1] + 1 };
                        coordenadas.Add(c);
                        int[] c2 = new int[2] { c[0], c[1] + 1 };
                        coordenadas.Add(c2);
                    }
                    else
                    {
                        coordenadas.Add(c_i);
                        int[] c = new int[2] { c_i[0] + 1, c_i[1] };
                        coordenadas.Add(c);
                        int[] c2 = new int[2] { c[0] + 1, c[1] };
                        coordenadas.Add(c2);
                    }
                    break;
                case 3:
                    coordenadas.Clear();
                    if (estado)
                    {
                        coordenadas.Add(c_i);
                        int[] c = new int[2] { c_i[0], c_i[1] + 1 };
                        coordenadas.Add(c);
                        int[] c2 = new int[2] { c[0], c[1] + 1 };
                        coordenadas.Add(c2);
                        int[] c3 = new int[2] { c[0] + 1, c[1] };
                        coordenadas.Add(c3);

                    }
                    else
                    {
                        coordenadas.Add(c_i);
                        int[] c = new int[2] { c_i[0] + 1, c_i[1] };
                        coordenadas.Add(c);
                        int[] c2 = new int[2] { c[0] + 1, c[1] };
                        coordenadas.Add(c2);
                        int[] c3 = new int[2] { c[0], c[1] + 1 };
                        coordenadas.Add(c3);
                    }
                    break;
                case 4:
                    coordenadas.Clear();
                    if (estado)
                    {
                        coordenadas.Add(c_i);
                        int[] c = new int[2] { c_i[0], c_i[1] + 1 };
                        coordenadas.Add(c);
                        int[] c2 = new int[2] { c[0], c[1] + 1 };
                        coordenadas.Add(c2);
                        int[] c3 = new int[2] { c2[0], c2[1] + 1 };
                        coordenadas.Add(c3);


                    }
                    else
                    {
                        coordenadas.Add(c_i);
                        int[] c = new int[2] { c_i[0] + 1, c_i[1] };
                        coordenadas.Add(c);
                        int[] c2 = new int[2] { c[0] + 1, c[1] };
                        coordenadas.Add(c2);
                        int[] c3 = new int[2] { c2[0] + 1, c2[1] };
                        coordenadas.Add(c3);
                    }
                    break;
                case 5:
                    coordenadas.Clear();
                    if (estado)
                    {
                        coordenadas.Add(c_i);
                        int[] c = new int[2] { c_i[0], c_i[1] + 1 };
                        coordenadas.Add(c);
                        int[] c2 = new int[2] { c[0], c[1] + 1 };
                        coordenadas.Add(c2);
                        int[] c3 = new int[2] { c2[0], c2[1] + 1 };
                        coordenadas.Add(c3);
                        int[] c4 = new int[2] { c3[0], c3[1] + 1 };
                        coordenadas.Add(c4);

                    }
                    else
                    {
                        coordenadas.Add(c_i);
                        int[] c = new int[2] { c_i[0] + 1, c_i[1] };
                        coordenadas.Add(c);
                        int[] c2 = new int[2] { c[0] + 1, c[1] };
                        coordenadas.Add(c2);
                        int[] c3 = new int[2] { c2[0] + 1, c2[1] };
                        coordenadas.Add(c3);
                        int[] c4 = new int[2] { c3[0] + 1, c3[1] };
                        coordenadas.Add(c4);
                    }
                    break;
                case 6:
                    coordenadas.Clear();
                    if (estado)
                    {
                        coordenadas.Add(c_i);
                        int[] c = new int[2] { c_i[0], c_i[1] + 1 };
                        coordenadas.Add(c);
                        int[] c2 = new int[2] { c[0], c[1] + 1 };
                        coordenadas.Add(c2);
                        int[] c3 = new int[2] { c[0] + 1, c[1] };
                        coordenadas.Add(c3);
                        int[] c4 = new int[2] { c3[0], c3[1] + 1 };
                        coordenadas.Add(c4);
                        int[] c5 = new int[2] { c4[0], c4[1] + 1 };
                        coordenadas.Add(c5);
                    }
                    else
                    {
                        coordenadas.Add(c_i);
                        int[] c = new int[2] { c_i[0] + 1, c_i[1] };
                        coordenadas.Add(c);
                        int[] c2 = new int[2] { c[0] + 1, c[1] };
                        coordenadas.Add(c2);
                        int[] c3 = new int[2] { c[0], c[1] + 1 };
                        coordenadas.Add(c3);
                        int[] c4 = new int[2] { c3[0] + 1, c3[1] };
                        coordenadas.Add(c4);
                        int[] c5 = new int[2] { c4[0] + 1, c4[1] };
                        coordenadas.Add(c5);
                    }
                    break;
            }
            
        }
        public List<int[]> getCoordenadas()
        {
            return coordenadas;
        }
        public bool getEstado()
        {
            return estado;
        }
    }
}
