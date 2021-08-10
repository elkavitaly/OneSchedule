using System;

namespace OneSchedule.Helpers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CollectionName: Attribute
    {
        public string Name { get;}
        public CollectionName(string name)
        {
            Name = name;
            if (string.IsNullOrWhiteSpace(name))
            {
                Name = new Guid().ToString();
            }
        }
    }
}
