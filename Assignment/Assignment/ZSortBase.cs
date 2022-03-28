namespace Z_Sorting
{
    public class ZSortBase
    {
        internal static bool[]? _InternalBoolArray;

        public static bool IsSortedbyInternalBoolArray()
        {
            if (_InternalBoolArray is null) return false;

            foreach (bool b in _InternalBoolArray)
            {
                if (!b) return false;
            }
            return true;
        }
    }
}