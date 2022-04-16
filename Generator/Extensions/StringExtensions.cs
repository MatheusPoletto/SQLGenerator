using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGenerator.Extensions
{
    public static class StringExtensions
    {
        public static string ReplacePascalCaseWithUnderscore(this string nameToConvert)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < nameToConvert.Length; i++)
            {
                char currentLetter = nameToConvert[i];

                if (i == 0)
                {
                    sb.Append(currentLetter);
                    continue;
                }

                bool nextCharIsLower = (i + 1 < nameToConvert.Length) ? char.IsLower(nameToConvert[i + 1]) : false;
                bool currentIsUpper = char.IsUpper(currentLetter);

                if (currentIsUpper && !nextCharIsLower)
                    sb.Append(currentLetter);
                else if (currentIsUpper && nextCharIsLower)
                    sb.Append("_" + currentLetter);
                else if (!currentIsUpper)
                    sb.Append(currentLetter);
            }

            return sb.ToString();

        }
    }
}
