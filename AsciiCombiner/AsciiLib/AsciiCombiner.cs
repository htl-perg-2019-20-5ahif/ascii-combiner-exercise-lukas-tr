using System;
using System.Collections.Generic;
using System.Linq;

namespace AsciiLib
{
    public class AsciiCombiner : IAsciiCombiner
    {
        public string combineImages(IEnumerable<string> layers)
        {
            var result = "";
            foreach (var layer in layers)
            {
                var normalized = normalizeString(layer);
                if (string.IsNullOrEmpty(result))
                {
                    result = normalized;
                }
                else
                {
                    result = CombineLayers(result, normalized);
                }
            }
            return result;
        }

        private string normalizeString(string s) => s.Replace("\r", "");

        private string CombineLayers(string background, string overlay)
        {
            var b = background.ToCharArray();
            var o = overlay.ToCharArray();
            if (b.Length != o.Length)
            {
                throw new FormatException("invalid number of characters");
            }
            for (var i = 0; i < b.Length; i++)
            {
                if (o[i] == '\n' || b[i] == '\n')
                {
                    if (o[i] != b[i])
                    {
                        throw new FormatException("invalid newline");
                    }
                    continue;
                }
                if (o[i] == ' ')
                {
                    continue;
                }
                b[i] = o[i];
            }
            return new string(b);
        }

    }
}
