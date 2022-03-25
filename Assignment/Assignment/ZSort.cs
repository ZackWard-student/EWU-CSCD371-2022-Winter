using System;
using System.Linq;

namespace Z_Sorting;

public class ZSort
{
    public void sort(IIndexable[] array)
    {
        (int min, int max, int count) = getMinMaxCount(array);
        throw new NotImplementedException();
    }

    private (int min, int max, int count) getMinMaxCount(IIndexable[] array)
    {
        throw new NotImplementedException();
    }

    public void sort(IIndexable[] array, int min, int max, int count)
    {
        throw new NotImplementedException();
    }

    

    public static int[] sort(int[] array)
    {
        (int min, int max, int length) = getMinMaxCount(array);
       
        index[] indexArray = new index[max - min + 1];
        bool[] trueIfSorted = new bool[length];

        foreach (int idexable in array)
        {
            (indexArray[idexable - min] ??= new index()).Count++;
        }

        int index = 0;
        for (int i = 0; i < length; ++i)
        {
            indexArray[i].StartingIndex = index;
            index += indexArray[i].Count;
            indexArray[i].EndingIndex = index - 1;
        }

        for (int i = 0; i < length; ++i)
        {
            if (!trueIfSorted[i])
            {
                int currentNumber = array[i]; //temporary storage of the elements indexable label to be sorted

                int currentIndex = i;
                int indexableIndex = currentNumber - min;
                AlreadySorted(indexArray, trueIfSorted, currentIndex, indexableIndex);

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
                    //if not an int would need to also tmeporily store the element
                    array[targetIndex] = currentNumber; //assigning of the element
                    trueIfSorted[targetIndex] = true;
                    
                    currentNumber = targetedNumber;
                    indexableIndex = currentNumber - min;
                }
            }
        }
        return array;
    }

    private static bool AlreadySorted(index[] indexArray, bool[] trueIfSorted, int i, int indexedIndex)
    {
        if ((indexArray[indexedIndex].StartingIndex < i) && (i <= indexArray[indexedIndex].EndingIndex))
        {
            trueIfSorted[i] = true;
            return true;
        }
        return false;
    }

    private static (int min, int max, int length) getMinMaxCount(int[] array) => (array.Min(), array.Max(), array.Length);
}

internal class index
{
    public int Count { get; set; }
    public int StartingIndex { get; set; }
    public int EndingIndex { get; set; }

}