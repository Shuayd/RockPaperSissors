using System;

namespace SA.RPS.Library.Extensions
{
    public static class EnumConverter<T>
    {
        public static T StringToEnum(string text)
        {
            return (T)Enum.Parse(typeof(T), text, true);
        }
    }
}
