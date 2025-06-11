// See https://aka.ms/new-console-template for more information
using monocircle;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

internal class Solver
{
    int expected_nodes_in_solution = 0; 

    internal List<Set> Solutions = new List<Set>();
    public void Solve(List<Wire> wires, bool extensive= false)
    {
        this.expected_nodes_in_solution = wires.Count;

        foreach (var w in wires)
        { 
            var wire1 = w.Clone();
            wire1.isNode1Connected = true;
            var consumed1 = new Set() { wire1 };
            var available1 = new Set(); available1.CloneAndRemove(wires, wire1);
            Sink(consumed1, available1, extensive);

            var wire2 = w.Clone();
            wire2.isNode2Connected = true;
            var consumed2 = new Set() { wire2 };
            var available2 = new Set(); available2.CloneAndRemove(wires, wire2);
            
            Sink(consumed2, available2, extensive);
        }
    }

    public bool Sink(Set consumed, Set available, bool extensive)
    {
        // Check if all wires are consumed
        if (consumed.Count == this.expected_nodes_in_solution && available.Count == 0)
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

                bool found = Sink(consumed4, available2, extensive);

                if (found && !extensive) return found;
            }
        }

        return false;
    }

    internal void PrintSolutions()
    {
        Console.WriteLine($"Solutions found: {this.Solutions.Count}");

        int counter = 0;

        foreach (var s in this.Solutions)
        {
            Console.WriteLine("Solution" + (++counter).ToString() + ":");
            foreach (var w in s)
            {
                Console.Write(w + " / " );
            }
            Console.WriteLine();
        }

    }
}