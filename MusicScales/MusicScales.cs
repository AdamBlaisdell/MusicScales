using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


}