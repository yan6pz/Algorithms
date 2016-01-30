namespace ArffSharp.Extensions
{
    using System;

    public static class StringExtensions
    {
        public static bool StartsWithI(this string target, string value)
        {
            return target.StartsWith(value, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Unescapes the specified input.
        /// http://stackoverflow.com/a/6736653/13932
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The unescaped string.</returns>
        public static String Unescape(this string input)
        {
            if (input == null || input.Length <= 1) return input;

            // the input string can only get shorter
            // so init the buffer so we won't have to reallocate later
            char[] buffer = new char[input.Length];
            int outIdx = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c == '\'' && (i == 0 || i == input.Length - 1))
                {
                    continue;
                }
                else if (c == '\\')
                {
                    if (i < input.Length - 1)
                    {
                        char? outChar = null;
                        switch (input[i + 1])
                        {
                            case 'n': outChar = '\n'; break;
                            case 'r': outChar = '\r'; break;
                            case 't': outChar = '\t'; break;
                            case '\'': outChar = '\''; break;
                            case '"': outChar = '"'; break;
                        }

                        if (outChar != null)
                        {
                            buffer[outIdx++] = outChar.Value;
                            i++;
                            continue;
                        }
                    }
                }

                buffer[outIdx++] = c;
            }

            return new String(buffer, 0, outIdx);
        }
    }
}
