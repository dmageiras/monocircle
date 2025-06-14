﻿// See https://aka.ms/new-console-template for more information
using monocircle;

Console.WriteLine("Hello, World!");

// schema: https://docs.google.com/document/d/1HkW3mK9zcSlzg4funtn4NwEqeWD4ntQHSwyTAfp3gWk/edit?tab=t.0

// mercedes! 

var wires = new Set() 
{
    new Wire("A", "B"),
    new Wire("B", "C"),
    new Wire("C", "A"),
    new Wire("O", "A"),
    new Wire("O", "B"),
    new Wire("O", "C"),
};

var solver = new Solver();
solver.Solve(wires);
solver.PrintSolutions();

// complex diagram with 16 wires, each vertex 4 connections
var wires2 = new Set();
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
        wires2.AddUnique(new Wire( n , v ) );
    }
}

var solver2 = new Solver();
solver2.Solve(wires2);
solver2.PrintSolutions();

// complex diagram with 16 wires, each vertex 4 connections
Set wires3 = new Set();
var temps3 = new[] {
    new string[] { "2", "3"  }, // 1
    new string[] { "1", "3", "4", "6", }, // 2
    new string[] { "1", "2", "7", "5", }, // 3
    new string[] { "2", "6"  }, // 4 
    new string[] { "3", "7"  }, // 5
    new string[] { "4", "2", "7", "8", }, // 6
    new string[] { "6", "8", "3", "5", }, // 7
    new string[] { "6", "7"  }, // 8
};

int counter3 = 0;
foreach (var t in temps3)
{
    counter3++;
    string n = counter3.ToString();

    foreach (var v in t)
    {
        wires3.AddUnique(new Wire(n, v));
    }
}

var solver3 = new Solver();
solver3.Solve(wires3, true);
solver3.PrintSolutions();


// Konigsberg bridge
var wires_konigs = new Set();
var temps_konigs = new[] {
    new string[] { "2", "4", "5"  }, // 1
    new string[] { "3", "4", "1", }, // 2
    new string[] { "2", "4", "6" }, // 3
    new string[] { "6", "2", "1", "1", "5",  }, // 4 
    new string[] { "1", "4"  }, // 5
    new string[] { "4", "3",}, // 6
};

int counter_konigs = 0;
foreach (var t in temps_konigs)
{
    counter_konigs++;
    string n = counter_konigs.ToString();

    foreach (var v in t)
    {
        wires_konigs.AddUnique(new Wire(n, v));
    }
}

var solver_konigs = new Solver();
solver_konigs.Solve(wires_konigs, true);
solver_konigs.PrintSolutions();