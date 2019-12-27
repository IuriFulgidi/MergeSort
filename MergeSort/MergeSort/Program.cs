using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //lista originale
            List<int> lista = new List<int>();

            //generatore random
            Random rnd = new Random();

            //caricamento lista originale
            Console.WriteLine("elementi della lista originale:");
            for (int i = 0; i < 10; i++)
            {
                lista.Add(rnd.Next(0, 100));
                Console.Write($"{lista[i]} ");
            }
            Console.WriteLine();

            //sort
            lista = MergeSort(lista);

            //stampa lista ordinata
            Console.WriteLine("Sorted array elements: ");
            foreach (int a in lista)
                Console.Write($"{a} ");

            Console.ReadLine();
        }

        private static List<int> MergeSort(List<int> lista)
        {
            List<int> sx = new List<int>();
            List<int> dx = new List<int>();

            //divisione 
            int centro = lista.Count / 2;
            for (int i = 0; i < centro; i++)
            {
                sx.Add(lista[i]);
            }

            for (int i = centro; i < lista.Count; i++)
            {
                dx.Add(lista[i]);
            }

            sx = MergeSort(sx);
            dx = MergeSort(dx);
            return Merge(sx, dx);
        }

        private static List<int> Merge(List<int> sx, List<int> dx)
        {
            List<int> result = new List<int>();

            while (sx.Count > 0 || dx.Count > 0)
            {
                if (sx.Count > 0 && dx.Count > 0)
                {
                    if (sx[0] <= dx[0])  //Comparing First two elements to see which is smaller
                    {
                        result.Add(sx[0]);
                        sx.Remove(sx[0]);      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(dx[0]);
                        dx.Remove(dx[0]);
                    }
                }
                else if (sx.Count > 0)
                {
                    result.Add(sx[0]);
                    sx.Remove(sx[0]);
                }
                else if (dx.Count > 0)
                {
                    result.Add(dx[0]);

                    dx.Remove(dx[0]);
                }
            }
            return result;
        }
    }
}
