namespace Z_Sorting
{
    public class InternalBoolArray
    {
        internal static bool[]? _InternalBoolArray;

        public static bool AreAllTrue()
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