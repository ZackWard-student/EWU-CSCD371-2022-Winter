using System;

namespace Z_Sorting
{
    public class SudoSorted<T> where T : IIndexable
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        public int Length { get; private set; }
        private index[] IndexArray { get; set; }
        public T[] Array { get; private set; }


        public SudoSorted(T[] array)
        {
            Array = array;
            (Min, Max, Length) = getMinMaxLength(Array);
            IndexArray = InitializeIndexArray();
        }

        private index[] InitializeIndexArray()
        {
            var indexArray = new index[Max - Min + 1];

            //count all of the numbers given
            foreach (var item in Array)
            {
                (indexArray[item.Index - Min] ??= new index()).Count++;
            }

            InitializeIndeces(indexArray);

            return indexArray;
        }

        private static void InitializeIndeces(index[] indexArray)
        {
            int index = 0;

            //take the the count of each number and mark the range of indexes
            foreach (index item in indexArray)
            {
                item.StartingIndex = index; //inclusive
                index += item.Count;
                item.EndingIndex = index; //non-inclusive
                item.RoamingIndex = item.StartingIndex;
            }
        }

        public T this[int i]
        {
            get => Index(i);
            set => setIndex(i, value);
        }


        private T Index(int index)
        {
            sort(index);
            return Array[index];
        }
        private void setIndex(int index, T value)
        {
            sort(index);
            Ratify(index, value); 
        }

        private void Ratify(int index, T value)
        {
            if (index != value.Index)
            {
                IndexArray[Array[index].Index - Min].Count--;

                if (Min > value.Index || Max < value.Index)
                {
                    if (Min > value.Index)
                    {
                        Min = value.Index;
                    }
                    else
                    {
                        Max = value.Index;
                    }

                    Array[index] = value;
                    //can be streamlined more by taking into acount the item replaced
                    IndexArray = InitializeIndexArray();
                    return;
                }
                else
                {
                    (IndexArray[value.Index - Min] ??= new index()).Count++;
                    //can be streamlined more by taking into acount the item replaced
                    InitializeIndeces(IndexArray);
                }
                
            }
            Array[index] = value;
        }

        private void sort(int index)
        {
            //int currentIndex = index;
            T currentItem = Array[index]; //temporary storage of the elements indexable label to be sorted
            int currentIndexable = currentItem.Index - Min;

            //in a closed finite system of numbers when you know where each of them go. If you pick one up (leaving an empty space) and place it where it needs to go then pick that one up and reapeat
            //the empty space of the first one will never be left blank and will be filled with the correct number. I have not yet written a proof for this, but it is experimentaly true so far.
            while (!CheckIfSorted(index, Array[index].Index - Min))
            {
                int targetIndex = IndexArray[currentIndexable].RoamingIndex++;
                int targetIndexable = Array[targetIndex].Index - Min;

                //looking for a target index in the matching index range that is not already sorted
                //since there is an unsorted item there will be an unsorted target 
                while (CheckIfSorted(targetIndex, targetIndexable))
                {
                    targetIndex = IndexArray[currentIndexable].RoamingIndex++;
                    targetIndexable = Array[targetIndex].Index - Min;
                }
                T targetedItem = Array[targetIndex]; //temporary storage of the next elements indexable label to be sorted
                Array[targetIndex] = currentItem; //assigning of the element
                currentItem = targetedItem;

                currentIndexable = targetIndexable;
            }
            return;
        }

        internal bool CheckIfSorted(int targetIndex, int indexableIndex)
        {
            if ((IndexArray[indexableIndex].StartingIndex <= targetIndex) && (targetIndex < IndexArray[indexableIndex].EndingIndex))
            {
                return true;
            }
            return false;
        }

        private static (int min, int max, int length) getMinMaxLength(T[] array)
        {
            int length = array.Length;
            int min = int.MaxValue;
            int max = int.MinValue;
            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    int index = array[i].Index;
                    if (min > index) min = index;
                    if (max < index) max = index;
                }
            }

            return (min, max, length);
        }

        internal class index
        {
            public int Count { get; set; }
            public int StartingIndex { get; set; }  //inclusive
            public int EndingIndex { get; set; }    //non-inclusive

            private int _RoamingIndex;
            public int RoamingIndex
            {
                get { return _RoamingIndex; }
                set 
                { 
                    _RoamingIndex = (value-StartingIndex)%(EndingIndex-StartingIndex)+StartingIndex; 
                }
            }

        }
    }
}