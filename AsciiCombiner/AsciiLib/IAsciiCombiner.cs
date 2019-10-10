using System;
using System.Collections.Generic;
using System.Text;

namespace AsciiLib
{
    public interface IAsciiCombiner
    {
        string combineImages(IEnumerable<string> layers);
    }
}
