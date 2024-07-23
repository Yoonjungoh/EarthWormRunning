using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Extension
{ 
    private static Random random = new Random();
    public static T RandomPick<T>(this IEnumerable<T> list, Func<T, decimal> selector)
    {
        decimal sum = list.Sum(selector);

        Random random = new System.Random();
        decimal randomValue = Convert.ToDecimal(random.NextDouble()) * sum;

        foreach (T item in list)
        {
            decimal rate = selector(item);
            if (rate > randomValue)
            {
                return item;
            }

            randomValue -= rate;
        }

        return default(T);
    }

    // Fisher-Yates Shuffle 알고리즘 O(n)
    public static void Shuffle<T>(this IList<T> values)
    {
        for (int i = values.Count - 1; i > 0; i--)
        {
            int k = random.Next(i + 1);
            T value = values[k];
            values[k] = values[i];
            values[i] = value;
        }
    }
}