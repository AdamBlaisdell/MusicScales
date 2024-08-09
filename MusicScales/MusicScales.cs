using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicScales
{
    internal class MusicScales
    {
        // a list of musical notes and enharmonic equivalents
        public static string[][] Notes = new string[][]
        {
            new string[] { "B#",  "C",  "Dbb" },
            new string[] { "B##", "C#", "Db"  },
            new string[] { "C##", "D",  "Ebb" },
            new string[] { "D#",  "Eb", "Fbb" },
            new string[] { "D##", "E",  "Fb"  },
            new string[] { "E#",  "F",  "Gbb" },
            new string[] { "E##", "F#", "Gb"  },
            new string[] { "F##", "G",  "Abb" },
            new string[] { "G#",  "Ab"        },
            new string[] { "G##", "A",  "Bbb" },
            new string[] { "A#",  "Bb", "Cbb" },
            new string[] { "A##", "B",  "Cb"  }
        };
    }
}
