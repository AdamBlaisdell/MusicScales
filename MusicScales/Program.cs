using System;
using System.Linq;
using static MusicScales;

int noteIndex = MusicScales.FindNoteIndex(notes, "A");
int noteIndex2 = MusicScales.FindNoteIndex(alphabet, "A");

Console.WriteLine(noteIndex);
Console.WriteLine(noteIndex2);
string[][] newarray = Rotate(notes, noteIndex);

foreach (var row in newarray)
{
    foreach (var item in row)
    {
        Console.Write(item + ", ");
    }
    Console.WriteLine();    
}
