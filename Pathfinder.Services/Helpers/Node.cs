using System.Collections.Generic;

namespace Pathfinder.Services.Helpers
{
    internal class Node
    {
        //public bool IsLatNode { get; }
        //public int Index { get; set; }
        public int Value { get; set; }
        public List<Node> Childs { get; set; }
        public Node Parent { get; set; }
        public Node(int index, int[] data, Node parent, Tree tree)
        {
            //this.Index = index;
            this.Value = data[index];
            this.Childs = new List<Node>();
            this.Parent = parent;
            //this.IsLatNode = index == data.Length - 1;

            if (index == data.Length - 1) //last node
            {
                tree.FinalNodes.Add(this);
            }

            for (int i = 1; i <= Value && data.Length > i + index; i++)
            {
                Childs.Add(new Node(i + index, data, this, tree));
            }
        }
    }
}
