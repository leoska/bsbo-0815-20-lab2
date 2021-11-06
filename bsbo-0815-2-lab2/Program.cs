using System;
using System.Collections.Generic;
using System.Linq;

namespace bsbo_0815_2_lab2
{ 

    class Program
    {
        static List<List<int>> list = new List<List<int>>();
        static List<int> order, component = new List<int>();
        static List<bool> used;


        static void Main(string[] args)
        {
            // Определить в орграфе сильно связные компоненты, подсчитать их число и вывести состав (номера узлов) каждой сильно связной компоненты.
            // Матрица смежности
        //                         A  B  C  D  E  F  G  H
          list.Add(new List<int> { 0, 1, 0, 0, 0, 0, 0, 0 }); // A
          list.Add(new List<int> { 0, 0, 1, 0, 1, 1, 0, 0 }); // B
          list.Add(new List<int> { 0, 0, 0, 1, 0, 0, 1, 0 }); // C
          list.Add(new List<int> { 0, 0, 1, 0, 0, 0, 0, 1 }); // D
          list.Add(new List<int> { 1, 0, 0, 0, 0, 1, 0, 0 }); // E
          list.Add(new List<int> { 0, 0, 0, 0, 0, 0, 1, 0 }); // F
          list.Add(new List<int> { 0, 0, 0, 0, 0, 1, 0, 0 }); // G
          list.Add(new List<int> { 0, 0, 0, 1, 0, 0, 1, 0 }); // H

          used = Enumerable.Repeat(false, 8).ToList();
          //Console.WriteLine(list[1][2]);

        }

        void dfs1(int v)
        {
          used[v] = true;
          for (int i = 0; i < list[v].Count(); ++i)
            if (!used[i] && list[v][i] == 1)
              dfs1(list[v][i]);
          order.Add(v);
        }

    }
}
