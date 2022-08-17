namespace TestCaseAnalysisAPI.App
{
    public static class Extensions
    {
        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }

        public static bool Contains(this string value, params string[] values)
        {
            if (values == null)
            {
                return false;
            }

            foreach (var item in values)
            {
                if (value?.Contains(item) == true)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
