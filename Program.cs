using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatosAvanzadas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var grafoNoDirigido = new GrafoNoDirigido<string>();
            grafoNoDirigido.addVertice("1");
            grafoNoDirigido.addVertice("2");
            grafoNoDirigido.addVertice("3");
            grafoNoDirigido.addVertice("4");
            grafoNoDirigido.addVertice("5");
            grafoNoDirigido.addVertice("6");
            grafoNoDirigido.addArista("1", "2", 1);
            grafoNoDirigido.addArista("1", "4", 1);
            grafoNoDirigido.addArista("1", "6", 1);
            grafoNoDirigido.addArista("2", "3", 1);
            grafoNoDirigido.addArista("2", "4", 1);
            grafoNoDirigido.addArista("4", "5", 1);
            grafoNoDirigido.addArista("4", "6", 1);
            grafoNoDirigido.addArista("5", "6", 1);
            System.Diagnostics.Debug.WriteLine("Grafo no dirigido:");
            for (int i = 1; i <= 6; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    if (i != j) System.Diagnostics.Debug.WriteLine(i.ToString() + " y " + j.ToString() + " son adyacentes? -> " + grafoNoDirigido.adyacente(i.ToString(), j.ToString()));
                }
            }
            for (int i = 1; i <= 6; i++)
            {
                System.Diagnostics.Debug.WriteLine("Adyacentes de " + i.ToString() + ":");
                grafoNoDirigido.adyacentes(i.ToString()).ForEach(x => System.Diagnostics.Debug.WriteLine(x.ToString()));
            }

            var grafoDirigido = new GrafoDirigido<string>();
            grafoDirigido.addVertice("1");
            grafoDirigido.addVertice("2");
            grafoDirigido.addVertice("3");
            grafoDirigido.addVertice("4");
            grafoDirigido.addVertice("5");
            grafoDirigido.addVertice("6");
            grafoDirigido.addArista("1", "4", 8);
            grafoDirigido.addArista("2", "1", 5);
            grafoDirigido.addArista("2", "4", 2);
            grafoDirigido.addArista("3", "2", 10);
            grafoDirigido.addArista("4", "1", 1);
            grafoDirigido.addArista("4", "5", 6);
            grafoDirigido.addArista("6", "4", 7);
            System.Diagnostics.Debug.WriteLine("Grafo dirigido:");
            for (int i = 1; i <= 6; i++)
            {
                for (int j = 1; j <= 6; j++)
                {
                    if (i != j) System.Diagnostics.Debug.WriteLine(i.ToString() + " y " + j.ToString() + " son adyacentes? -> " + grafoDirigido.adyacente(i.ToString(), j.ToString()));
                }
            }
            for (int i = 1; i <= 6; i++)
            {
                System.Diagnostics.Debug.WriteLine("Adyacentes de " + i.ToString() + ":");
                grafoDirigido.adyacentes(i.ToString()).ForEach(x => System.Diagnostics.Debug.WriteLine(x.ToString()));
            }
        }
    }
}
