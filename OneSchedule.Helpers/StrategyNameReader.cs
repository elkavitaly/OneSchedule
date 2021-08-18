using OneSchedule.Attributes;
using System;
using System.Reflection;

namespace OneSchedule.Helpers
{
    public static class StrategyNameReader
    {
        public static string GetStrategyName(Type type)
        {
            return (type.GetCustomAttribute(typeof(StrategyName))
                as StrategyName)?.Name ?? $"{type.Name}s";
        }
    }
}
