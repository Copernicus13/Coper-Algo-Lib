using System.Collections.Generic;
using System.Linq;

namespace CoperAlgoLib.Data
{
    public static class ArrayHelpers
    {
        public static T[,] GetSubArray<T>(this T[,] map, int x, int y, int width, int height)
        {
            var subMap = new T[height, width];
            for (int j = 0; j < height; ++j)
                for (int i = 0; i < width; ++i)
                    subMap[j, i] = map[y + j, x + i];
            return subMap;
        }

        public static T[] GetRow<T>(this T[,] map, int row)
        {
            int width = map.GetLength(1);
            var subMap = new T[width];
            for (int x = 0; x < width; ++x)
                subMap[x] = map[row, x];
            return subMap;
        }

        public static T[] GetColumn<T>(this T[,] map, int column)
        {
            int height = map.GetLength(0);
            var subMap = new T[height];
            for (int y = 0; y < height; ++y)
                subMap[y] = map[y, column];
            return subMap;
        }

        public static List<T> ToList<T>(this T[,] map, bool rowFirst = true)
        {
            var result = new List<T>();
            if (rowFirst)
            {
                int height = map.GetLength(0);
                for (int y = 0; y < height; ++y)
                    result.AddRange(map.GetRow(y).ToList());
            }
            else
            {
                int width = map.GetLength(1);
                for (int x = 0; x < width; ++x)
                    result.AddRange(map.GetColumn(x).ToList());
            }
            return result;
        }

        public static List<List<T>> ToListList<T>(this T[,] map, bool rowFirst = true)
        {
            var result = new List<List<T>>();
            if (rowFirst)
            {
                int height = map.GetLength(0);
                for (int y = 0; y < height; ++y)
                    result.Add(map.GetRow(y).ToList());
            }
            else
            {
                int width = map.GetLength(1);
                for (int x = 0; x < width; ++x)
                    result.Add(map.GetColumn(x).ToList());
            }
            return result;
        }

        /// <remarks>
        /// The input list must have at least one element and
        /// all inner lists should have the same size as the first inner list
        /// </remarks>
        public static T[,] ToJaggedArray<T>(this List<List<T>> list)
        {
            int width = list[0].Count;
            int height = list.Count;
            var result = new T[height, width];
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                    result[y, x] = list[y][x];
            return result;
        }
    }
}
