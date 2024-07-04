using System.Collections;
namespace HW_DelegatesEvents
{
    public static class CollectionHandler
    {
        public static T GetMax<T>(this IEnumerable collection, Func<T, float> convertToFloat)
            where T : class
        {
            T maxElement = null;
            float maxValue = 0;
            bool gotfirst = false;

            foreach (T SourceT in collection)
            {
                float value = convertToFloat(SourceT);
                if (!gotfirst || value.CompareTo(maxValue) > 0)
                {
                    maxValue = value;
                    maxElement = SourceT;
                    gotfirst = true;
                }
            }
            if (maxElement == null)
            {
                throw new InvalidOperationException("collection does not contains objects");
            }
            return maxElement;
        }
    }
}
