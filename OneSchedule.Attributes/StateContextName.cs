using System;

namespace OneSchedule.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StateContextName : Attribute
    {
        public string Name { get; }

        public StateContextName(string name)
        {
            Name = string.IsNullOrWhiteSpace(name) 
                ? throw new ArgumentException($"The {nameof(name)} parameter can't be empty", nameof(name))
                : name;
        }
    }
}
