// See https://aka.ms/new-console-template for more information
using monocircle;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

internal class Solver
{
    int expected_solutions = 0; 

    internal List<Set> Solutions = new List<Set>();
    public void Solve(List<Wire> wires)
    {
        this.expected_solutions = wires.Count;

        foreach (var w in wires)
        { 
            var wire1 = w.Clone();
            wire1.isNode1Connected = true;
            var consumed1 = new Set() { wire1 };
            var available1 = new Set(); available1.CloneAndRemove(wires, wire1);
            Sink(consumed1, available1);

            var wire2 = w.Clone();
            wire2.isNode2Connected = true;
            var consumed2 = new Set() { wire2 };
            var available2 = new Set(); available2.CloneAndRemove(wires, wire2);
            Sink(consumed2, available2);
        }
    }

    public bool Sink(Set consumed, Set available)
    {
        // Check if all wires are consumed
        if (consumed.Count == this.expected_solutions && available.Count == 0)
        {
            this.Solutions.Add(consumed);
            // All wires are consumed, we can return or process the route
            return true;
        }

        // Iterate through available wires
        foreach (var a in available)
        {
            var last = consumed.Last();
            if ( a.CanConnectTo( last ) )
            {
                var wire1 = last.Clone();
                var wire2 = a.Clone();

                var consumed2 = new Set(); consumed2.CloneAndRemove(consumed, wire1);
                
                wire1.Connect(wire2);

                var consumed3 = new Set(); 
                consumed3.CloneAndAdd(consumed2, wire1);
                var consumed4 = new Set();
                consumed4.CloneAndAdd(consumed3, wire2);
                var available2 = new Set(); 
                available2.CloneAndRemove(available, wire2);

                return Sink(consumed4, available2);
            }
        }

        return false;
    }

    internal void PrintSolutions()
    {
        Console.WriteLine($"Solutions found: {this.Solutions.Count}");

        foreach (var s in this.Solutions)
        {
            Console.WriteLine("Solution:");
            foreach (var w in s)
            {
                Console.WriteLine(w);
            }
            Console.WriteLine();
        }

    }
}