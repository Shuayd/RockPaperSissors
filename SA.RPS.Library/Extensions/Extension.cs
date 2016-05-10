using System;
using System.Collections.Generic;

namespace SA.RPS.Library.Extensions
{
    public static class Extension
    {
        private static Random _rnd = new Random();

        public static void Random<T>(this List<T> list, int numberOfTimesToShuffle = 3)
        {       
            List<T> newList = new List<T>();

            for (int i = 0; i < numberOfTimesToShuffle; i++)
            {

                while (list.Count > 0)
                {
                    int index = _rnd.Next(list.Count);
                    newList.Add(list[index]);
                    list.RemoveAt(index);
                }

                list.AddRange(newList);
                newList.Clear();
            }
        }
    }
}
