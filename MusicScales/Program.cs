using System;
using System.Linq;
using static MusicScales;


var intervs = MakeIntervals("G#", "major");
string minorBluesScale = formulas.TryGetValue("scales", out var scales) && scales.TryGetValue("major", out var scale) ? scale : "Scale not found";

List<string> newlist = MakeFormula(minorBluesScale, intervs);

foreach (var row in newlist) {
    Console.Write((row + ", "));
}


