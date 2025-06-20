﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monocircle
{
    internal class Set : List<Wire>
    {
        public void CloneAndAdd(List<Wire> wires, Wire wire)
        {
            this.Clear();

            foreach (var w in wires)
            {
                this.Add(w.Clone());
            }

            this.Add(wire.Clone());
        }
        public void CloneAndRemove(List<Wire> wires, Wire wire)
        {
            this.Clear();

            foreach (var w in wires)
            {
                if (w.Signature != wire.Signature)
                {
                    this.Add(w.Clone());
                }
            }
        }
        internal bool AddUnique(Wire wire)
        {
            var s = wire.Signature; // ensure signature is set
            foreach (var w in this)
            {
                if (w.Signature == s) return false; // already exists
            }
            this.Add(wire);
            return true; // added successfully
        }
    }
}
