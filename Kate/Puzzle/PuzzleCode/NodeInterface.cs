using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Puzzle
{
    public interface NodeInterface
    {
        float F { get; set; }
        float G { get; set; }
        float H { get; set; }

        int[] Tiles { get; set; }

        int[,] unstringNode(NodeInterface node);

        NodeInterface ParentNode { get; set; }

        bool Equals(NodeInterface node);
    }
}
