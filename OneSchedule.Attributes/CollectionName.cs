using System;

namespace OneSchedule.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CollectionName : Attribute
    {
        public string Name { get; }
        public CollectionName(string name)
        {
            Name = string.IsNullOrWhiteSpace(name) ?
                throw new ArgumentException($"The {nameof(name)} parameter can't be empty", nameof(name))
                : name;
        }
    }
}
