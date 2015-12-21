using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Puzzle
{
    public class GameNode : NodeInterface
    {
        int _emptyTileIndex;

        int N = 3;
 
        public GameNode()
        {
            _emptyTileIndex = -1;
        }
 
        public int[] Tiles { get; set; }
 
        public int EmptyTileIndex
        {
            get
            {
                if (_emptyTileIndex == -1)
                    _emptyTileIndex = GetEmptyTilePosition(this);
 
                return _emptyTileIndex;
            }
        }
 
        public float F { get; set; }
        public float G { get; set; }
        public float H { get; set; }
 
        public NodeInterface ParentNode { get; set; }
 
        public bool Equals(NodeInterface node)
        {
            var testNode = node as GameNode;
 
            return testNode != null && Tiles.SequenceEqual(testNode.Tiles);
        }

        public int[,] unstringNode(NodeInterface node)
        {
            int[] strung = node.Tiles;
            int[,] unstrung = new int[N,N];
            int elemN = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    unstrung[i, j] = strung[elemN];
                    elemN++;
                }
            }
            return unstrung;
        }
 
 
        private static int GetEmptyTilePosition(GameNode node)
        {
            int emptyTilePos = -1;
 
            for (int i = 0; i < 9; i++)
            {
                if (node.Tiles[i] == 0)
                {
                    emptyTilePos = i;
                    break;
                }
            }
 
            return emptyTilePos;
        }

        public static int[] getNode(GameNode node)
        {
            return node.Tiles;
        }
    }
}
