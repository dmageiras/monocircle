// See https://aka.ms/new-console-template for more information
using monocircle;

Console.WriteLine("Hello, World!");

// schema: https://docs.google.com/document/d/1HkW3mK9zcSlzg4funtn4NwEqeWD4ntQHSwyTAfp3gWk/edit?tab=t.0

// mercedes! 

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
// solver.Solve(wires);
solver.PrintSolutions();

// complex diagram with 16 wires, each vertex 4 connections
var wires2 = new List<Wire>();
var temps = new[] {
    new string[] { "2", "3", "5", "7", }, // 1
    new string[] { "1", "4", "8", "6", }, // 2
    new string[] { "1", "4", "9", "11", }, // 3
    new string[] { "2", "10", "12", "3", }, // 4 
    new string[] { "6", "13", "9", "1", }, // 5
    new string[] { "2", "5", "10", "14", }, // 6
    new string[] { "1", "8", "13", "11", }, // 7
    new string[] { "2", "14", "12", "7", }, // 8
    new string[] { "3", "5", "10", "15", }, // 9
    new string[] { "4", "6", "16", "9", }, // 10
    new string[] { "3", "7", "12", "15", }, // 11 
    new string[] { "11", "4", "8", "16", }, // 12
    new string[] { "5", "14", "15", "7", }, // 13
    new string[] { "6", "8", "13", "16", }, // 14
    new string[] { "11", "9", "13", "16", }, // 15
    new string[] { "14", "10", "12", "15", }, // 16
};

int counter = 0;
foreach (var t in temps)
{
    counter++;
    string n = counter.ToString();

    foreach (var v in t)
    {
        wires2.Add(new Wire() { isNode1Connected = false, isNode2Connected = false, Node1 = n, Node2 = v});
    }
}

var solver2 = new Solver();
solver2.Solve(wires2);
solver2.PrintSolutions();