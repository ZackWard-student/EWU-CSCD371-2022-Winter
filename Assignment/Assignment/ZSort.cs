using System;
using System.Collections;
using System.Linq;

namespace Z_Sorting;

public class ZSort
{
    public void sort(IIndexable[] array)
    {
        (int min, int max, int count) = getMinMaxCount(array);
        throw new NotImplementedException();
    }

    public void sort(IIndexable[] array, int min, int max, int count)
    {
        throw new NotImplementedException();
    }

    

    public static void sort(int[] array)
    {
        (int min, int max, int length) = getMinMaxCount(array);
        int indexableArrayLength = max - min + 1;
        index[] indexArray = new index[indexableArrayLength];
        bool[] trueIfSorted = new bool[length];

        foreach (int idexable in array)
        {
            (indexArray[idexable - min] ??= new index()).Count++;
        }

        int index = 0;

        foreach (index item in indexArray)
        {
            item.StartingIndex = index;
            index += item.Count;
            item.EndingIndex = index - 1;
        }

        for (int i = 0; i < length; ++i)
        {
            if (!trueIfSorted[i])
            {
                int currentNumber = array[i]; //temporary storage of the elements indexable label to be sorted

                int indexableIndex = currentNumber - min;
                AlreadySorted(indexArray, trueIfSorted, i, indexableIndex);

                while (!trueIfSorted[i])
                {
                    int targetIndex = indexArray[indexableIndex].StartingIndex;
                    
                    //looking for a target index in the matching index range that is not already sorted
                    if (!trueIfSorted[targetIndex])
                    {
                        while (AlreadySorted(indexArray, trueIfSorted, targetIndex, indexableIndex))
                        {
                            targetIndex = ++indexArray[indexableIndex].StartingIndex; //no need to worry about the ending index
                        }
                    }
                    
                    int targetedNumber = array[targetIndex]; //temporary storage of the next elements indexable label to be sorted
                    //if not an int would need to also temporily store the element
                    array[targetIndex] = currentNumber; //assigning of the element
                    trueIfSorted[targetIndex] = true;
                    
                    currentNumber = targetedNumber;
                    indexableIndex = currentNumber - min;
                }
            }
        }
        return;
    }

    private static bool AlreadySorted(index[] indexArray, bool[] trueIfSorted, int targetIndex, int indexedIndex)
    {
        if ((indexArray[indexedIndex].StartingIndex < targetIndex) && (targetIndex <= indexArray[indexedIndex].EndingIndex))
        {
            trueIfSorted[targetIndex] = true;
            return true;
        }
        return false;
    }

    private static (int min, int max, int length) getMinMaxCount(IIndexable[] array)
    {
        int length = array.Length;
        int min = int.MinValue;
        int max = int.MaxValue;
        if(length > 0)
        {
            foreach (var item in array)
            {
                int index = item.Index;
                if (min > index) min = index;
                if (max < index) max = index;
            }
        }

        return (min, max, length);
    }

    private static (int min, int max, int length) getMinMaxCount(int[] array)
    {
        int length = array.Length;
        int min = int.MaxValue;
        int max = int.MinValue;
        if (length > 0)
        {
            foreach (int item in array)
            {
                int index = item;
                if (min > index) min = index;
                if (max < index) max = index;
            }
        }

        return (min, max, length);
    }
}

internal class index
{
    public int Count { get; set; }
    public int StartingIndex { get; set; }
    public int EndingIndex { get; set; }

}