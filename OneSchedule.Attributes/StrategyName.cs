using System;

namespace OneSchedule.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StrategyName : Attribute
    {
        public string Name { get; }

        public StrategyName(string name)
        {
            Name = string.IsNullOrWhiteSpace(name) 
                ? throw new ArgumentException($"The {nameof(name)} parameter can't be empty", nameof(name))
                : name;
        }
    }
}
