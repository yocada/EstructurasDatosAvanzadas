using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatosAvanzadas
{
    public abstract class Grafo<T>
    {
        protected int[,] matrizAdyacencia;
        protected List<T> vertices;
        protected int size;

        public Grafo()
        {
            size = 0;
            vertices = new List<T>();
        }

        public abstract void addArista(T u, T v, int peso);
        
        public void addVertice(T v)
        {
            if (size == 0)
            {
                size = 1;
                matrizAdyacencia = new int[size, size];
                matrizAdyacencia[0, 0] = 0;
            }
            else
            {
                ampliaMatriz(1);
            }
            vertices.Add(v);
        }

        public abstract void delArista(T u, T v);

        public void delVertice(T v)
        {
            var posV = vertices.IndexOf(v);
            if (posV == -1) return;
            reduceMatriz(1,posV);
            vertices.RemoveAt(posV);
        }

        public bool adyacente(T u, T v)
        {
            var posU = vertices.IndexOf(u);
            var posV = vertices.IndexOf(v);
            if (posU == -1 || posV == -1) return false;
            return matrizAdyacencia[posU,posV] != 0;
        }

        public List<T> adyacentes(T v)
        {
            var res = new List<T>();
            var posV = vertices.IndexOf(v);
            if (posV == -1) return res;
            for (int i = 0; i < size; i++)
            {
                if (posV != i && matrizAdyacencia[posV, i] != 0)
                {
                    var vertice = vertices.ElementAt(i);
                    res.Add(vertice);
                }
            }
            return res;
        }

        public int etiqueta(T u, T v)
        {
            var posU = vertices.IndexOf(u);
            var posV = vertices.IndexOf(v);
            if (posU == -1 || posV == -1) return 0;
            return matrizAdyacencia[posU, posV] = 0;
        }

        private void ampliaMatriz(int incremento)
        {
            var newSize = size + incremento;
            var matrizCopia = new int[size, size];
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    matrizCopia[i, j] = matrizAdyacencia[i, j];
                }
            }
            matrizAdyacencia = new int[newSize, newSize];
            for (int i = 0; i < newSize; i++)
            {
                for (int j = 0; j < newSize; j++)
                {
                    if (i <= size - 1 && j <= size - 1)
                    {
                        matrizAdyacencia[i, j] = matrizCopia[i, j];
                    }
                    else
                    {
                        matrizAdyacencia[i, j] = 0;
                    }
                }
            }
            size += incremento;
        }

        private void reduceMatriz(int decremento, int indice)
        {
            var newSize = size - decremento;
            var matrizCopia = new int[newSize, newSize];
            for (int i = 0; i < newSize; i++)
            {
                for (int j = 0; j < newSize; j++)
                {
                    if (i != indice && j != indice) matrizCopia[i, j] = matrizAdyacencia[i, j];
                }
            }
            matrizAdyacencia = new int[newSize, newSize];
            for (int i = 0; i < newSize; i++)
            {
                for (int j = 0; j < newSize; j++)
                {
                    matrizAdyacencia[i, j] = matrizCopia[i, j];
                }
            }
            size -= decremento;
        }

    }
}
