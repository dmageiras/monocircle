using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monocircle
{
    internal class Wire
    {
        public required string Node1;

        public required string Node2;

        public required bool isNode1Connected = false;

        public required bool isNode2Connected = false;

        public string Signature { get { return Node1 + Node2; } } // all clones have the same signature whether connected or not

        public override string ToString()
        {
            return $"{Node1} - {Node2}";
        }

        internal Wire Clone()
        {
            return new Wire() { isNode1Connected = this.isNode1Connected, isNode2Connected = this.isNode2Connected, Node1 = this.Node1, Node2 = this.Node2 };
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
