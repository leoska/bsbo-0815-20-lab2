using System;
using System.Collections.Generic;
using System.Linq;

namespace bsbo_0815_2_lab2
{ 

    class Program
    {
        static List<List<int>> list = new List<List<int>>();
        static List<List<int>> gr;
        static List<int> order = new List<int>();
        static List<int> component = new List<int>();
        static List<bool> used;
    


        static void Main(string[] args)
        {
      // Определить в орграфе сильно связные компоненты, подсчитать их число и вывести состав (номера узлов) каждой сильно связной компоненты.
      // Матрица смежности
      //                         A  B  C  D  E  F  G  H
      /*
      0 4 1
      2 3 7
      6 5
      */
          list.Add(new List<int> { 0, 1, 0, 0, 0, 0, 0, 0 }); // A
          list.Add(new List<int> { 0, 0, 1, 0, 1, 1, 0, 0 }); // B
          list.Add(new List<int> { 0, 0, 0, 1, 0, 0, 1, 0 }); // C
          list.Add(new List<int> { 0, 0, 1, 0, 0, 0, 0, 1 }); // D
          list.Add(new List<int> { 1, 0, 0, 0, 0, 1, 0, 0 }); // E
          list.Add(new List<int> { 0, 0, 0, 0, 0, 0, 1, 0 }); // F
          list.Add(new List<int> { 0, 0, 0, 0, 0, 1, 0, 0 }); // G
          list.Add(new List<int> { 0, 0, 0, 1, 0, 0, 1, 0 }); // H

          used = Enumerable.Repeat(false, 8).ToList();
          gr = transpose(list);
          for (int i = 0; i < list.Count; ++i)
            if (!used[i])
              dfs1(i);

          used = Enumerable.Repeat(false, 8).ToList();

          for (int i = 0; i < list.Count; ++i)
          {
            int v = order[list.Count - 1 - i];
            if (!used[v])
            {
              dfs2(v);
              foreach(var item in component)
                Console.Write(item + " ");
              Console.WriteLine();
			        component.Clear();
            }
          }

    }

        static void dfs1(int v)
        {
          used[v] = true;
          for (int i = 0; i < list[v].Count; ++i)
            if (!used[i] && list[v][i] == 1)
              dfs1(i);
          order.Add(v);
        }

        static void dfs2(int v)
        {
          used[v] = true;
          component.Add(v);
          for (int i = 0; i < gr[v].Count; ++i)
            if (!used[i] && gr[v][i] == 1)
              dfs2(i);
        }

        static List<List<int>> transpose(List<List<int>> graph)
        {
          List<List<int>> result = new List<List<int>>();

          for(int i = 0; i < 8; i++)
            result.Add(Enumerable.Repeat(0, 8).ToList());

          for(int i = 0; i < list.Count; i++)
          {
            for(int j = 0; j < list[i].Count; j++)
            {
              if(list[i][j] == 1)
              {
                result[j][i] = 1;
              }
            }
          }

          return result;
        }

  }
}
