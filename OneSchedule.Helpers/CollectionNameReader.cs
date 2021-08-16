using OneSchedule.Attributes;
using System.Reflection;

namespace OneSchedule.Helpers
{
    public static class CollectionNameReader
    {
        public static string GetCollectionName<T>()
        {
            var type = typeof(T);
            return (type.GetCustomAttribute(typeof(CollectionName))
                as CollectionName)?.Name ?? $"{type.Name}s";
        }
    }
}
