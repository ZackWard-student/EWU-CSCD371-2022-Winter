using System;
using System.Collections;
using System.Linq;

namespace Z_Sorting;

public class ZSort : InternalBoolArray
{
    public void sort(IIndexable[] array)
    {
        (int min, int max, int length) = getMinMaxCount(array);
        
        //tracks the index information about each number
        index[] indexArray = new index[max - min + 1];

        //tracks what numbers have been sorted so that they are not moved
        bool[] trueIfSorted = new bool[length];

        //count all of the numbers given
        foreach (var item in array)
        {
            (indexArray[item.Index - min] ??= new index()).Count++;
        }

        int index = 0;

        //take the the count of each number and mark the range of indexes
        foreach (index item in indexArray)
        {
            item.StartingIndex = index;
            index += item.Count;
            item.EndingIndex = index - 1;
        }

        //check the numbers in the array to see if they are already within thier sorted index range
        for (int i = 0; i < length; ++i)
        {
            int indexableIndex = array[i].Index - min;
            trueIfSorted[i] = AlreadySorted(indexArray, trueIfSorted, i, indexableIndex);
        }


        for (int i = 0; i < length; ++i)
        {
            if (!trueIfSorted[i])
            {
                var currentItem = array[i]; //temporary storage of the elements indexable label to be sorted
                int currentIndexable = currentItem.Index;
                int indexableIndex = currentIndexable - min;

                //in a closed system of numbers if you know where each of them go. If you pick one up (leaving an empty space) and place it where it needs to go then pick that one up and reapeat
                //the empty space of the first one will never be left blank and will be filled with the correct number. I have not yet written a proof for this, but it is experimentaly true so far.
                while (!trueIfSorted[i])
                {
                    int targetIndex = indexArray[indexableIndex].StartingIndex;
                    int targetIndexalbe = array[targetIndex].Index;
                                                             //if not an int would need to also temporily store the element

                    //looking for a target index in the matching index range that is not already sorted
                    while (trueIfSorted[targetIndex])
                    {
                        targetIndex = indexArray[indexableIndex].StartingIndex++; //shouldn't need to worry about the ending index
                        targetIndexalbe = array[targetIndex].Index;
                        /*
                        if (indexArray[indexableIndex].StartingIndex > indexArray[indexableIndex].EndingIndex + 1)
                        {
                            //this should happen but only up to a single index greater than the Ending Index
                            throw new Exception("Starting Index is greater then the Ending Index");
                        }
                        */
                    }
                    var targetedItem = array[targetIndex]; //temporary storage of the next elements indexable label to be sorted
                    array[targetIndex] = currentItem; //assigning of the element
                    trueIfSorted[targetIndex] = true;
                    currentItem = targetedItem;

                    currentIndexable = targetIndexalbe;
                    indexableIndex = currentIndexable - min;

                }
            }
        }
        //for testing
        return;

    }

    public static void sort(int[] array, bool internals = false)
    {
        (int min, int max, int length) = getMinMaxCount(array);
        
        //tracks the index information about each number
        index[] indexArray = new index[max - min + 1];
        
        //tracks what numbers have been sorted so that they are not moved
        bool[] trueIfSorted = new bool[length];

        //count all of the numbers given
        foreach (int idexable in array)
        {
            (indexArray[idexable - min] ??= new index()).Count++;
        }

        int index = 0;

        //take the the count of each number and mark the range of indexes
        foreach (index item in indexArray)
        {
            item.StartingIndex = index;
            index += item.Count;
            item.EndingIndex = index - 1;
        }

        //check the numbers in the array to see if they are already within thier sorted index range
        for (int i = 0; i < length; ++i)
        {
            int indexableIndex = array[i] - min;
            trueIfSorted[i] = AlreadySorted(indexArray, trueIfSorted, i, indexableIndex);
        }


        for (int i = 0; i < length; ++i)
        {
            if (!trueIfSorted[i])
            {
                int currentNumber = array[i]; //temporary storage of the elements indexable label to be sorted
                int indexableIndex = currentNumber - min;
                
                //in a closed system of numbers if you know where each of them go. If you pick one up (leaving an empty space) and place it where it needs to go then pick that one up and reapeat
                //the empty space of the first one will never be left blank and will be filled with the correct number. I have not yet written a proof for this, but it is experimentaly true so far.
                while (!trueIfSorted[i])
                {
                    int targetIndex = indexArray[indexableIndex].StartingIndex;
                    int targetedNumber = array[targetIndex]; //temporary storage of the next elements indexable label to be sorted
                                                             //if not an int would need to also temporily store the element

                    //looking for a target index in the matching index range that is not already sorted
                    while (trueIfSorted[targetIndex])
                    {
                        targetIndex = indexArray[indexableIndex].StartingIndex++; //shouldn't need to worry about the ending index
                        targetedNumber = array[targetIndex];
                        /*
                        if (indexArray[indexableIndex].StartingIndex > indexArray[indexableIndex].EndingIndex + 1)
                        {
                            //this should happen but only up to a single index greater than the Ending Index
                            throw new Exception("Starting Index is greater then the Ending Index");
                        }
                        */
                    }
                  

                        array[targetIndex] = currentNumber; //assigning of the element
                        trueIfSorted[targetIndex] = true;
                    
                        currentNumber = targetedNumber;
                        indexableIndex = currentNumber - min;
                    
                }
            }
        }
        //for testing
        if(internals) InternalBoolArray._InternalBoolArray = trueIfSorted;

        return;
    }

    internal static bool AlreadySorted(index[] indexArray, bool[] trueIfSorted, int targetIndex, int indexableIndex)
    {
        if ((indexArray[indexableIndex].StartingIndex <= targetIndex) && (targetIndex <= indexArray[indexableIndex].EndingIndex))
        {
            trueIfSorted[targetIndex] = true;
            return true;
        }
        return false;
    }

    internal static (int min, int max, int length) getMinMaxCount(IIndexable[] array)
    {
        int length = array.Length;
        int min = int.MaxValue;
        int max = int.MinValue;
        if (length > 0)
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

    internal class index
    {
        public int Count { get; set; }
        public int StartingIndex { get; set; }
        public int EndingIndex { get; set; }

    }
}

