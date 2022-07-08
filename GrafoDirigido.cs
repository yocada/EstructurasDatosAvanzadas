using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatosAvanzadas
{
    public class GrafoDirigido<T> : Grafo<T>
    {
        public override void addArista(T u, T v, int peso)
        {
            var posU = vertices.IndexOf(u);
            var posV = vertices.IndexOf(v);
            if (posU == -1 || posV == -1) return;
            matrizAdyacencia[posU, posV] = peso;
        }

        public override void delArista(T u, T v)
        {
            var posU = vertices.IndexOf(u);
            var posV = vertices.IndexOf(v);
            if (posU == -1 || posV == -1) return;
            matrizAdyacencia[posU, posV] = 0;
        }
    }
}
