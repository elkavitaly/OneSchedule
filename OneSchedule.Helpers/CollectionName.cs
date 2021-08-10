using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace OneSchedule.Helper
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
