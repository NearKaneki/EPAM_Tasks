public static class StringExtension
{
    public static TypeStrings TypeString(this string str)
    {
        if (str == string.Empty)
        {
            return TypeStrings.Empty;
        }

        if (char.IsDigit(str[0]))
        {
            if (str.Any(x => !char.IsDigit(x)))
            {
                return TypeStrings.Mixed;
            }
            return TypeStrings.Number;
        }

        if (char.IsLetter(str[0]))
        {
            if (str.Any(x => !char.IsLetter(x)))
            {
                return TypeStrings.Mixed;
            }

            if (str[0] == 1025 || (str[0] >= 1040 && str[0] <= 1103) || str[0] == 1105)
            {
                if (str.Any(x => (x != 1025 && (x < 1040 || x > 1103) && x != 1105)))
                {
                    return TypeStrings.Mixed;
                }

                return TypeStrings.Russian;
            }

            string EnglishLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (EnglishLetters.Contains(str[0]))
            {

                if (str.Any(x => !EnglishLetters.Contains(x)))
                {
                    return TypeStrings.Mixed;
                }

                return TypeStrings.English;
            }
        }

        return TypeStrings.Mixed;
    }
}