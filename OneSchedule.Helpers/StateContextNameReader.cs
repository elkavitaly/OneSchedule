using OneSchedule.Attributes;
using System;
using System.Reflection;

namespace OneSchedule.Helpers
{
    public static class StateContextNameReader
    {
        public static string GetStateContextName(Type type)
        {
            return (type.GetCustomAttribute(typeof(StateContextName))
                as StateContextName)?.Name ?? $"{type.Name}s";
        }
    }
}