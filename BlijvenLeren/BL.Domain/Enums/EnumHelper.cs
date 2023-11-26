namespace BL.Domain.Enums
{
    public static class EnumHelper
    {
        public static T Enums<T>(T enumRequest) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException(typeof(T).Name + " is not an Enum");
            var commaSeparatedFlags = string.Join(",", enumRequest);
            Enum.TryParse(commaSeparatedFlags, true, out T flags);
            return flags;
        }
    }
}
