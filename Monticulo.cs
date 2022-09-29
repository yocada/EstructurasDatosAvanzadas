using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatosAvanzadas
{
    public class Monticulo<T> where T : IComparable<T>
    {
        private T[] vector;
        private int numElementos;
        private int maxElementos;

        public Monticulo() : this(5)
        {
        }

        public Monticulo(int maxElementos)
        {
            vector = new T[maxElementos];
            numElementos = 0;
            this.maxElementos = maxElementos;
        }

        public bool monticuloVacio()
        {
            return numElementos == 0;
        }

        public void insertar(T e)
        {
            if (numElementos < maxElementos)
            {
                vector[numElementos] = e;
                flotar(vector, numElementos);
                numElementos++;
            }
            else
            {
                //Posibilidad 1 -> Error
                //Posibilidad 2 -> Redimensionar
            }
        }

        public T primero()
        {
            if (!monticuloVacio())
            {
                return vector[0];
            }
            else
            {
                throw new Exception("El montículo no contiene elementos");
            }
        }

        public T obtenerCima()
        {
            if (!monticuloVacio())
            {
                var e = vector[0];
                vector[0] = vector[numElementos - 1];
                hundir(vector, 0);
                numElementos--;
                return e;
            }
            else
            {
                throw new Exception("El montículo no contiene elementos");
            }
        }

        private void intercambiar(T[] v, int pos1, int pos2)
        {
            T tmp = v[pos2];
            v[pos2] = v[pos1];
            v[pos1] = tmp;
        }

        private void flotar(T[] v, int i)
        {
            var indicePadre = (int)Math.Ceiling(Decimal.Divide(i, 2)) - 1;
            while (i > 0 && v[indicePadre].CompareTo(v[i]) < 0)
            //while (i > 0 && v[i / 2 - 1] < v[i])
            {
                intercambiar(v, i, indicePadre);
                i = indicePadre;
                indicePadre = (int)Math.Ceiling(Decimal.Divide(i, 2)) - 1;
            }
        }

        private void hundir(T[] v, int i)
        {
            int p;
            do
            {
                var hi = 2 * i + 1;
                var hd = 2 * i + 2;
                p = i;
                if (hd <= numElementos && v[hd].CompareTo(v[i]) > 0)
                //if (hd <= numElementos && v[hd] > v[i])
                {
                    i = hd;
                }
                if (hi <= numElementos && v[hi].CompareTo(v[i]) > 0)
                {
                    i = hi;
                }
                intercambiar(v, p, i);
            }
            while (p != i);
        }
    }
}
