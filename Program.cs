// See https://aka.ms/new-console-template for more information
using monocircle;

Console.WriteLine("Hello, World!");

// schema: https://docs.google.com/document/d/1HkW3mK9zcSlzg4funtn4NwEqeWD4ntQHSwyTAfp3gWk/edit?tab=t.0

var wab = new Wire { Node1 = "A", Node2 = "B", isNode1Connected = false, isNode2Connected = false };
var wbc = new Wire { Node1 = "B", Node2 = "C", isNode1Connected = false, isNode2Connected = false };
var wca = new Wire { Node1 = "C", Node2 = "A", isNode1Connected = false, isNode2Connected = false };
var woa = new Wire { Node1 = "A", Node2 = "O", isNode1Connected = false, isNode2Connected = false };
var wob = new Wire { Node1 = "B", Node2 = "O", isNode1Connected = false, isNode2Connected = false };
var woc = new Wire { Node1 = "C", Node2 = "O", isNode1Connected = false, isNode2Connected = false };

var wires = new List<Wire>
{
    wab, wbc, wca, woa, wob, woc
};

var solver = new Solver();

solver.Solve(wires);

Console.WriteLine($"Solutions found: {solver.Solutions.Count}");

foreach (var s in solver.Solutions)
{
    Console.WriteLine("Solution:");
    foreach (var w in s)
    {
        Console.WriteLine(w);
    }
    Console.WriteLine();
}

