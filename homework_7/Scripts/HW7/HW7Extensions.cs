using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class HW7Extensions
{
    public static int NumberOfSymbolsInStringVariant1(this IEnumerable<char> self)
    {
        return self.ToString().Length;
    }

    public static int NumberOfSymbolsInStringVariant2(this IEnumerable<char> self)
    {
        int counter = 0;
        foreach (char element in self)
        {
            counter++;
        }

        return counter;
    }

    public static Dictionary<T, int> GetSeemsElementsNumberVariant1<T>(this List<T> self)
    {
        SortedSet<T> sortedSet = new SortedSet<T>(self);
        Dictionary<T, int> result = new Dictionary<T, int>();

        foreach(T element in sortedSet)
        {
            result.Add(element, 0);
        }

        foreach(T listelement in self)
        {
            foreach(T setelement in sortedSet)
            {
                if (listelement.Equals(setelement))
                {
                    result[setelement] += 1;
                }
            }
        }
        return result;
    }

    public static Dictionary<T, int> GetSeemsElementsNumberVariant2<T>(this List<T> self)
    {
        SortedSet<T> sortedSet = new SortedSet<T>(self);
        Dictionary<T, int> result = new Dictionary<T, int>();
        self.Sort();

        result = self.GroupBy(x => x).Where(g => g.Count() >= 1).ToDictionary(x => x.Key, y => y.Count());

        
        return result;
    }


    public static void DoExerciseNumber4Lambda()
    {
        Dictionary<string, int> dict = new Dictionary<string, int>()
        {
            {"four",4 },
            {"two",2 },
            { "one",1 },
            {"three",3 },
        };
        var d = dict.OrderBy(x => x.Value);
        foreach (var pair in d)
        {
            Debug.Log($"{pair.Key} - {pair.Value}");
        }

    }

    public static void DoExerciseNumber4Delegate()
    {
        Dictionary<string, int> dict = new Dictionary<string, int>()
        {
            {"four",4 },
            {"two",2 },
            { "one",1 },
            {"three",3 },
        };
        var d = dict.OrderBy(delegate(KeyValuePair<string, int> pair ) { return pair.Value; });
        foreach (var pair in d)
        {
            Debug.Log($"{pair.Key} - {pair.Value}");
        }

    }





}
