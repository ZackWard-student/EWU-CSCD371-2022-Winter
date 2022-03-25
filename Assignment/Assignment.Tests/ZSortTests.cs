using IntelliTect.TestTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Z_Sorting;

[TestClass]
public class ZSortTests
{
    
    [TestMethod]
    public void Sort_Success()
    {
        int [] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        int [] sortedArrayControl = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        int [] mixedArray = { 13, 2, 9, 7, 10, 11, 19, 14, 8, 6, 4, 17, 3, 12, 1, 15, 5, 18, 20, 16 };

        sortedArray = ZSort.sort(sortedArray);
        mixedArray = ZSort.sort(mixedArray);

        for(int i = 0; i < sortedArray.Length; i++)
        {
            Assert.AreEqual<int>(sortedArrayControl[i], sortedArray[i]);
            Assert.AreEqual<int>(sortedArrayControl[i], mixedArray[i]);
        }
    }
    
}
