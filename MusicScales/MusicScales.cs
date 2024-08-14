using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class MusicScales
{
    //Alphabet
    public static string[] alphabet = new string[] { "A", "B", "C", "D", "E", "F", "G" };



    // A list of musical notes and enharmonic equivalents
    public static string[][] notes = new string[][]
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

    // Two-dimensional array representing intervals
    public static readonly string[][] intervalsStandard = new string[][]
    {
        new string[] { "P1", "d2" },  // Perfect unison, Diminished second
        new string[] { "m2", "A1" },  // Minor second, Augmented unison
        new string[] { "M2", "d3" },  // Major second, Diminished third
        new string[] { "m3", "A2" },  // Minor third, Augmented second
        new string[] { "M3", "d4" },  // Major third, Diminished fourth
        new string[] { "P4", "A3" },  // Perfect fourth, Augmented third
        new string[] { "d5", "A4" },  // Diminished fifth, Augmented fourth
        new string[] { "P5", "d6" },  // Perfect fifth, Diminished sixth
        new string[] { "m6", "A5" },  // Minor sixth, Augmented fifth
        new string[] { "M6", "d7" },  // Major sixth, Diminished seventh
        new string[] { "m7", "A6" },  // Minor seventh, Augmented sixth
        new string[] { "M7", "d8" },  // Major seventh, Diminished octave
        new string[] { "P8", "A7" }   // Perfect octave, Augmented seventh
    };


    // Major scale intervals
    public static readonly string[][] intervalsMajor = new string[][]
    {
        new string[] { "1",  "bb2" },
        new string[] { "b2", "#1"  },
        new string[] { "2",  "bb3",  "9"  },
        new string[] { "b3", "#2"  },
        new string[] { "3",  "b4"  },
        new string[] { "4",  "#3",   "11" },
        new string[] { "b5", "#4",   "#11" },
        new string[] { "5",  "bb6" },
        new string[] { "b6", "#5"  },
        new string[] { "6",  "bb7",  "13" },
        new string[] { "b7", "#6"  },
        new string[] { "7",  "b8"  },
        new string[] { "8",  "#7"  }
    };

    public static readonly Dictionary<string, Dictionary<string, string>> formulas = new Dictionary<string, Dictionary<string, string>>
{
    // Scale formulas
    { "scales", new Dictionary<string, string>
        {
            // Major scale, its modes, and minor scale
            { "major", "1,2,3,4,5,6,7" },
            { "minor", "1,2,b3,4,5,b6,b7" },
            // Melodic minor and its modes
            { "melodic_minor", "1,2,b3,4,5,6,7" },
            // Harmonic minor and its modes
            { "harmonic_minor", "1,2,b3,4,5,b6,7" },
            // Blues scales
            { "major_blues", "1,2,b3,3,5,6" },
            { "minor_blues", "1,b3,4,b5,5,b7" },
            // Pentatonic scales
            { "pentatonic_major", "1,2,3,5,6" },
            { "pentatonic_minor", "1,b3,4,5,b7" },
            { "pentatonic_blues", "1,b3,4,b5,5,b7" },
        }
    },
    { "chords", new Dictionary<string, string>
        {
            // Major
            { "major", "1,3,5" },
            { "major_6", "1,3,5,6" },
            { "major_6_9", "1,3,5,6,9" },
            { "major_7", "1,3,5,7" },
            { "major_9", "1,3,5,7,9" },
            { "major_13", "1,3,5,7,9,11,13" },
            { "major_7_#11", "1,3,5,7,#11" },
            // Minor
            { "minor", "1,b3,5" },
            { "minor_6", "1,b3,5,6" },
            { "minor_6_9", "1,b3,5,6,9" },
            { "minor_7", "1,b3,5,b7" },
            { "minor_9", "1,b3,5,b7,9" },
            { "minor_11", "1,b3,5,b7,9,11" },
            { "minor_7_b5", "1,b3,b5,b7" },
            // Dominant
            { "dominant_7", "1,3,5,b7" },
            { "dominant_9", "1,3,5,b7,9" },
            { "dominant_11", "1,3,5,b7,9,11" },
            { "dominant_13", "1,3,5,b7,9,11,13" },
            { "dominant_7_#11", "1,3,5,b7,#11" },
            // Diminished
            { "diminished", "1,b3,b5" },
            { "diminished_7", "1,b3,b5,bb7" },
            { "diminished_7_half", "1,b3,b5,b7" },
            // Augmented
            { "augmented", "1,3,#5" },
            // Suspended
            { "sus2", "1,2,5" },
            { "sus4", "1,4,5" },
            { "7sus2", "1,2,5,b7" },
            { "7sus4", "1,4,5,b7" },
        }
    }
};



    // Get the index of a note for arrays
    public static int FindNoteIndex(string[] scale, string searchNote)
    {
        return Array.IndexOf(scale, searchNote);
    }


    // Overloaded method to get the index of a note for 2d arrays
    public static int FindNoteIndex(string[][] scale, string searchNote)
    {
        for (int i = 0; i < scale.Length; i++)
        {
            int index = Array.IndexOf(scale[i], searchNote);
            if (index != -1)
            {
                return i; // Return the index of the sub-array containing the note
            }
        }
        return -1; // Return -1 if the note is not found
    }


    // Method that rotates array by N degrees
    public static string[] Rotate(string[] scale, int degrees)
    {
        int length = scale.Length;
        int n = degrees % length; // Normalize degrees to avoid unnecessary full rotations

        // Create a new array with the rotated elements
        string[] rotatedScale = new string[length];

        // Copy elements starting from index n to the end of the array
        Array.Copy(scale, n, rotatedScale, 0, length - n);

        // Copy the beginning of the array to the end
        Array.Copy(scale, 0, rotatedScale, length - n, n);

        return rotatedScale;
    }


    // Overloaded ethod that rotates rows of a 2D array by N degrees
    public static string[][] Rotate(string[][] scale, int degrees)
    {
        int length = scale.Length;
        int n = degrees % length; // Normalize degrees to avoid unnecessary full rotations

        // Create a new 2D array with the rotated rows
        string[][] rotatedScale = new string[length][];

        // Copy rows starting from index n to the end of the array
        for (int i = 0; i < length - n; i++)
        {
            rotatedScale[i] = scale[n + i];
        }

        // Copy the beginning of the array to the end
        for (int i = 0; i < n; i++)
        {
            rotatedScale[length - n + i] = scale[i];
        }

        return rotatedScale;
    }

    public static string[][] Chromatic(string key)
    {
        // Figure out how much to rotate the notes list by and return
        int numRotations = FindNoteIndex(notes, key);
        return Rotate(notes, numRotations);
    }


    /*    public static Dictionary<string, string> MakeIntervalsStandard(string key)
        {
            var labels = new Dictionary<string, string>();

            // Generate a chromatic scale in the desired key
            var chromaticScale = Chromatic(key);

            // The alphabets starting at provided key's alphabet
            var alphabetKey = Rotate(alphabet, FindNoteIndex(alphabet, key[0].ToString()));

            // Iterate through all intervals (list of lists)
            for (int index = 0; index < intervals.GetLength(0); index++)
            {
                // Get the current interval list from the 2D array
                var intervalList = new string[]
                {
                intervals[index, 0],
                intervals[index, 1]
                };

                // Find the notes to search through based on degree
                var notesToSearch = chromaticScale[index % chromaticScale.Length];

                foreach (var intervalName in intervalList)
                {
                    // Get the interval degree
                    var degree = int.Parse(intervalName[1].ToString()) - 1; // e.g. M3 --> 3, m7 --> 7

                    // Get the alphabet to look for
                    var alphabetToSearch = alphabetKey[degree % alphabetKey.Length];

                    string note;
                    try
                    {
                        note = notesToSearch.First(x => x[0].ToString() == alphabetToSearch);
                    }
                    catch
                    {
                        note = notesToSearch[0];
                    }

                    labels[intervalName] = note;
                }
            }

            return labels;
        }*/

    public static Dictionary<string, string> MakeIntervals(string key, string intervalType = "standard")
    {
        var labels = new Dictionary<string, string>();

        // Generate a chromatic scale in the desired key
        var chromaticScale = Chromatic(key);

        // The alphabets starting at provided key's alphabet
        var alphabetKey = Rotate(alphabet, FindNoteIndex(alphabet, key[0].ToString()));

        // Choose the appropriate interval set based on interval type
        string[][] intervs = intervalType == "standard" ? intervalsStandard : intervalsMajor;

        // Iterate through all intervals (list of lists)
        for (int index = 0; index < intervs.Length; index++)
        {
            var intervalList = intervs[index];

            // Find the notes to search through based on degree
            var notesToSearch = chromaticScale[index % chromaticScale.Length];

            foreach (var intervalName in intervalList)
            {
                // Get the interval degree
                int degree;
                if (intervalType == "standard")
                {
                    degree = int.Parse(intervalName[1].ToString()) - 1; // e.g. M3 --> 3, m7 --> 7
                }
                else if (intervalType == "major")
                {
                    degree = int.Parse(Regex.Replace(intervalName, "[b#]", "")) - 1;
                }
                else
                {
                    throw new ArgumentException("Invalid interval type specified.");
                }

                // Get the alphabet to look for
                var alphabetToSearch = alphabetKey[degree % alphabetKey.Length];

                string note;
                try
                {
                    note = notesToSearch.First(x => x[0].ToString() == alphabetToSearch);
                }
                catch
                {
                    note = notesToSearch[0];
                }

                labels[intervalName] = note;
            }
        }

        return labels;
    }



    public static List<string> MakeFormula(string formula, Dictionary<string, string> labeled)
    {
        // Split the formula by commas and return the corresponding notes from the labeled dictionary
        return formula.Split(',')
                      .Select(x => labeled[x])
                      .ToList();
    }

/*    public static string Dump(IEnumerable<string> scale, string separator = " ")
    {
        // Format each note in the scale to have a minimum width of 3 characters
        var formattedScale = scale.Select(x => string.Format("{0,-3}", x));

        // Join the formatted notes with the separator and replace 'b' and '#' with their respective Unicode symbols
        return string.Join(separator, formattedScale)
                     .Replace('b', '\u266D')  // Unicode flat symbol
                     .Replace('#', '\u266F'); // Unicode sharp symbol
    }*/


}