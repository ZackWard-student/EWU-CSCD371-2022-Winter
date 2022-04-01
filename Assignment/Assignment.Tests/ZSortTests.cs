
namespace Z_Sorting;

[TestClass]
public class ZSortTests
{
    
    [TestMethod]
    public void Sort_Presorted_Success()
    {
        int [] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        int [] sortedArrayControl = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        ZSort.sort(sortedArray);

        for(int i = 0; i < sortedArrayControl.Length; i++)
        {
            Assert.AreEqual<int>(sortedArrayControl[i], sortedArray[i]);
        }
    }

    [TestMethod]
    public void Sort_Unsorted_Success()
    {
        int[] sortedArrayControl = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        int[] mixedArray = { 13, 2, 9, 7, 10, 11, 19, 14, 8, 6, 4, 17, 3, 12, 1, 15, 5, 18, 20, 16 };

        ZSort.sort(mixedArray);

        for (int i = 0; i < sortedArrayControl.Length; i++)
        {
            Assert.AreEqual<int>(sortedArrayControl[i], mixedArray[i]);
        }
    }

    [TestMethod]
    public void Sort_SortedReapeating_Success()
    {
        int[] sortedArrayControl = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18, 19, 19, 20, 20 };
        int[] sortedArray = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18, 19, 19, 20, 20 };

        ZSort.sort(sortedArray);

        for (int i = 0; i < sortedArrayControl.Length; i++)
        {
            Assert.AreEqual<int>(sortedArrayControl[i], sortedArray[i]);
        }
    }

    [TestMethod]
    public void Simple_Sort_UnsortedRepeating_Success_v1()
    {
        int[] sortedArrayControl = { 1, 2, 2};
        int[] mixedArray = { 2, 2, 1};

        ZSort.sort(mixedArray, internals: true);

        for (int i = 0; i < sortedArrayControl.Length; i++)
        {
            Assert.AreEqual<int>(sortedArrayControl[i], mixedArray[i]);
        }
    }

    [TestMethod]
    public void Simple_Sort_UnsortedRepeating_Success_v2()
    {
        int[] sortedArrayControl = { 1, 2, 2 };
        int[] mixedArray = { 2, 1, 2 };

        ZSort.sort(mixedArray, internals: true);

        Assert.IsTrue(InternalBoolArray.AreAllTrue());

        for (int i = 0; i < sortedArrayControl.Length; i++)
        {
            Assert.AreEqual<int>(sortedArrayControl[i], mixedArray[i]);
        }
    }

    [TestMethod]
    public void Simple_Sort_UnsortedRepeating_Success_v3()
    {
        int[] sortedArrayControl = { 1, 1, 2, 2 };
        int[] mixedArray = { 1, 2, 1, 2 };

        ZSort.sort(mixedArray, internals: true);

        Assert.IsTrue(InternalBoolArray.AreAllTrue());

        for (int i = 0; i < sortedArrayControl.Length; i++)
        {
            System.Console.WriteLine($"index: {i}");
            Assert.AreEqual<int>(sortedArrayControl[i], mixedArray[i]);
        }
    }

    [TestMethod]
    public void Simple_Sort_UnsortedRepeating_Success_v4()
    {
        int[] sortedArrayControl = { 1, 1, 2, 2 };
        int[] mixedArray = { 2, 2, 1, 1 };

        ZSort.sort(mixedArray, internals: true);

        Assert.IsTrue(InternalBoolArray.AreAllTrue());

        for (int i = 0; i < sortedArrayControl.Length; i++)
        {
            System.Console.WriteLine($"index: {i}");
            Assert.AreEqual<int>(sortedArrayControl[i], mixedArray[i]);
        }
    }

    [TestMethod]
    public void Sort_UnsortedRepeating_Success()
    {
        int[] sortedArrayControl = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18, 19, 19, 20, 20 };
        int[] mixedArray = { 13, 2, 9, 7, 10, 11, 19, 14, 8, 6, 4, 17, 3, 12, 1, 15, 5, 18, 20, 16, 13, 2, 9, 7, 10, 11, 19, 14, 8, 6, 4, 17, 3, 12, 1, 15, 5, 18, 20, 16 };

        ZSort.sort(mixedArray, internals: true);

        Assert.IsTrue(InternalBoolArray.AreAllTrue());

        for (int i = 0; i < sortedArrayControl.Length; i++)
        {
            Assert.AreEqual<int>(sortedArrayControl[i], mixedArray[i]);
        }
    }

    [TestMethod]
    public void SudoSort_UnsortedRepeating_Successv_v0()
    {
        int[] sortedArrayControl = { 0, 1};
        int[] mixedArray = { 1, 0};

        testSudoSort[] IndexableArray = new testSudoSort[mixedArray.Length];
        for (int i = 0; i < mixedArray.Length; i++)
        {
            IndexableArray[i] = new testSudoSort(mixedArray[i]);
        }

        SudoSorted<testSudoSort> SudoSortedIndexableArray = new(IndexableArray);

        for (int i = 0; i < sortedArrayControl.Length; i++)
        {
            Assert.AreEqual<int>(sortedArrayControl[i], SudoSortedIndexableArray[i].Index);
        }
    }

    [TestMethod]
    public void SudoSort_UnsortedRepeating_Successv_v1()
    {
        int[] sortedArrayControl = { 1, 1, 2};
        int[] mixedArray = { 1, 2, 1};

        testSudoSort[] IndexableArray = new testSudoSort[mixedArray.Length];
        for (int i = 0; i < mixedArray.Length; i++)
        {
            IndexableArray[i] = new testSudoSort(mixedArray[i]);
        }

        SudoSorted<testSudoSort> SudoSortedIndexableArray = new(IndexableArray);

        for (int i = 0; i < sortedArrayControl.Length; i++)
        {
            Assert.AreEqual<int>(sortedArrayControl[i], SudoSortedIndexableArray[i].Index);
        }
    }

    [TestMethod]
    public void SudoSort_UnsortedRepeating_Success_v2()
    {
        int[] sortedArrayControl = { 1, 2, 2};
        int[] mixedArray = { 2, 2, 1};

        testSudoSort[] IndexableArray = new testSudoSort[mixedArray.Length];
        for (int i = 0; i < mixedArray.Length; i++)
        {
            IndexableArray[i] = new testSudoSort(mixedArray[i]);
        }

        SudoSorted<testSudoSort> SudoSortedIndexableArray = new(IndexableArray);

        for (int i = 0; i < sortedArrayControl.Length; i++)
        {
            Assert.AreEqual<int>(sortedArrayControl[i], SudoSortedIndexableArray[i].Index);
        }
    }

    [TestMethod]
    public void SudoSort_UnsortedMoreRepeating_Success()
    {
        int[] sortedArrayControl = { 1, 2, 2, 2, 2 };
        int[] mixedArray = { 2, 2, 2, 2, 1 };

        testSudoSort[] IndexableArray = new testSudoSort[mixedArray.Length];
        for (int i = 0; i < mixedArray.Length; i++)
        {
            IndexableArray[i] = new testSudoSort(mixedArray[i]);
        }

        SudoSorted<testSudoSort> SudoSortedIndexableArray = new(IndexableArray);

        for (int i = 0; i < sortedArrayControl.Length; i++)
        {
            Assert.AreEqual<int>(sortedArrayControl[i], SudoSortedIndexableArray[i].Index);
        }
    }

    [TestMethod]
    public void SudoSort_UnsortedRepeating_Successv_v3()
    {
        int[] sortedArrayControl = { 1, 1, 2, 2 };
        int[] mixedArray = { 1, 2, 1, 2 };

        testSudoSort[] IndexableArray = new testSudoSort[mixedArray.Length];
        for (int i = 0; i < mixedArray.Length; i++)
        {
            IndexableArray[i] = new testSudoSort(mixedArray[i]);
        }

        SudoSorted<testSudoSort> SudoSortedIndexableArray = new (IndexableArray);

        for (int i = 0; i < sortedArrayControl.Length; i++)
        {
            Assert.AreEqual<int>(sortedArrayControl[i], SudoSortedIndexableArray[i].Index);
        }
    }

    [TestMethod]
    public void SudoSort_UnsortedRepeating_Success_v4()
    {
        int[] sortedArrayControl = { 1, 1, 2, 2 };
        int[] mixedArray = { 2, 2, 1, 1 };

        testSudoSort[] IndexableArray = new testSudoSort[mixedArray.Length];
        for (int i = 0; i < mixedArray.Length; i++)
        {
            IndexableArray[i] = new testSudoSort(mixedArray[i]);
        }

        SudoSorted<testSudoSort> SudoSortedIndexableArray = new(IndexableArray);

        for (int i = 0; i < sortedArrayControl.Length; i++)
        {
            Assert.AreEqual<int>(sortedArrayControl[i], SudoSortedIndexableArray[i].Index);
        }
    }

    [TestMethod]
    public void SudoSort_UnsortedRepeating_Success_v5()
    {
        int[] sortedArrayControl = {1, 1, 2, 3, 3 };
        int[] mixedArray = {3, 2, 3, 1, 1};

        testSudoSort[] IndexableArray = new testSudoSort[mixedArray.Length];
        for (int i = 0; i < mixedArray.Length; i++)
        {
            IndexableArray[i] = new testSudoSort(mixedArray[i]);
        }

        SudoSorted<testSudoSort> SudoSortedIndexableArray = new(IndexableArray);

        for (int i = 0; i < sortedArrayControl.Length; i++)
        {
            Assert.AreEqual<int>(sortedArrayControl[i], SudoSortedIndexableArray[i].Index);
        }
    }

    [TestMethod]
    public void SudoSort_UnsortedRepeating_Success()
    {
        int[] sortedArrayControl = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18, 19, 19, 20, 20 };
        int[] mixedArray = { 13, 2, 9, 7, 10, 11, 19, 14, 8, 6, 4, 17, 3, 12, 1, 15, 5, 18, 20, 16, 13, 2, 9, 7, 10, 11, 19, 14, 8, 6, 4, 17, 3, 12, 1, 15, 5, 18, 20, 16 };

        testSudoSort[] IndexableArray = new testSudoSort[mixedArray.Length];
        for (int i = 0; i < mixedArray.Length; i++)
        {
            IndexableArray[i] = new testSudoSort(mixedArray[i]);
        }

        SudoSorted<testSudoSort> SudoSortedIndexableArray = new(IndexableArray);

        for (int i = 0; i < sortedArrayControl.Length; i++)
        {
            Assert.AreEqual<int>(sortedArrayControl[i], SudoSortedIndexableArray[i].Index);
        }
    }
    public class testSudoSort : IIndexable
    {
        public testSudoSort(int intiger)
            {
                Index = intiger;
            }
        public int Index { get; private set; }

    }
}
