using OneSchedule.Attributes;
using System;
using System.Reflection;

namespace OneSchedule.Helpers
{
    public static class StateNameReader
    {
        public static string GetStateName(Type type)
        {
            return (type.GetCustomAttribute(typeof(StateName))
                as StateName)?.Name ?? $"{type.Name}s";
        }
    }
}