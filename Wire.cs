using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monocircle
{
    internal class Wire
    {
        public Wire(string node1, string node2)
        {
            if (node1 == null || node2 == null) throw new Exception("Node cannot be null");

            // ensures wire AB has the same signature as BA
            if (node1.CompareTo(node2) > 0)
            {
                this.Node1 = node2;
                this.Node2 = node1;
            }
            else
            {
                this.Node1 = node1;
                this.Node2 = node2;
            }
        }

        private string Node1, Node2;

        public bool isNode1Connected = false;

        public bool isNode2Connected = false;

        public string Signature { get { return Node1 + Node2; } } // all clones have the same signature whether connected or not

        public override string ToString()
        {
            return $"{Node1} - {Node2}";
        }

        internal Wire Clone()
        {
            return new Wire(Node1, Node2)
            {
                isNode1Connected = this.isNode1Connected,
                isNode2Connected = this.isNode2Connected
            };
        }

        internal bool CanConnectTo(Wire wire)
        {
            if (this.Node1 == wire.Node1 && !this.isNode1Connected && !wire.isNode1Connected) return true;
            if (this.Node1 == wire.Node2 && !this.isNode1Connected && !wire.isNode2Connected) return true;
            if (this.Node2 == wire.Node1 && !this.isNode2Connected && !wire.isNode1Connected) return true;
            if (this.Node2 == wire.Node2 && !this.isNode2Connected && !wire.isNode2Connected) return true;

            return false;
        }

        internal bool Connect(Wire wire)
        {
            if (this.Node1 == wire.Node1 && !this.isNode1Connected && !wire.isNode1Connected)
            {
                this.isNode1Connected = true;
                wire.isNode1Connected = true;
                return true;
            }

            if (this.Node1 == wire.Node2 && !this.isNode1Connected && !wire.isNode2Connected)
            {
                this.isNode1Connected = true;
                wire.isNode2Connected = true;
                return true;
            }

            if (this.Node2 == wire.Node1 && !this.isNode2Connected && !wire.isNode1Connected)
            {
                this.isNode2Connected = true;
                wire.isNode1Connected = true;
                return true;
            }

            if (this.Node2 == wire.Node2 && !this.isNode2Connected && !wire.isNode2Connected)
            {
                this.isNode2Connected = true;
                wire.isNode2Connected = true;
                return true;
            }

            return false;
        }

    }
}
