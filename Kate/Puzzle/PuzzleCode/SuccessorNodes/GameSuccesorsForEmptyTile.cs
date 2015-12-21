using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Puzzle.PuzzleCode.SuccessorNodes
{
    class GameSuccessorsForEmptyTile : GameSuccessorNodesCalculationRuleBase
    {
        public override IEnumerable<NodeInterface> GetSuccessors(NodeInterface node)
        {
            var result = new List<NodeInterface>();
            int emptyIndex = ((GameNode)node).EmptyTileIndex;

            switch (emptyIndex)
            {
                case 0:
                    AddSuccessor((GameNode) node, result, 1);
                    AddSuccessor((GameNode) node, result, 3);
                    break;
                case 1:
                    AddSuccessor((GameNode) node, result, 0);
                    AddSuccessor((GameNode) node, result, 2);
                    AddSuccessor((GameNode) node, result, 4);
                    break;
                case 2:
                    AddSuccessor((GameNode) node, result, 1);
                    AddSuccessor((GameNode) node, result, 5);
                    break;
                case 3:
                    AddSuccessor((GameNode) node, result, 0);
                    AddSuccessor((GameNode) node, result, 4);
                    AddSuccessor((GameNode) node, result, 6);
                    break;
                case 4:
                    AddSuccessor((GameNode) node, result, 1);
                    AddSuccessor((GameNode) node, result, 3);
                    AddSuccessor((GameNode) node, result, 5);
                    AddSuccessor((GameNode) node, result, 7);
                    break;
                case 5:
                    AddSuccessor((GameNode) node, result, 2);
                    AddSuccessor((GameNode) node, result, 4);
                    AddSuccessor((GameNode) node, result, 8);
                    break;
                case 6:
                    AddSuccessor((GameNode) node, result, 3);
                    AddSuccessor((GameNode) node, result, 7);
                    break;
                case 7:
                    AddSuccessor((GameNode) node, result, 4);
                    AddSuccessor((GameNode) node, result, 6);
                    AddSuccessor((GameNode) node, result, 8);
                    break;
                case 8:
                    AddSuccessor((GameNode) node, result, 5);
                    AddSuccessor((GameNode) node, result, 7);
                    break;
                default:
                    break;
            }

            return result;
        }

        public override bool Match(NodeInterface node)
        {
            int emptyIndex = ((GameNode)node).EmptyTileIndex;

            switch (emptyIndex)
            {
                case 0:
                    return ((GameNode)node).EmptyTileIndex == 0;
                case 1:
                    return ((GameNode)node).EmptyTileIndex == 1;
                case 2:
                    return ((GameNode)node).EmptyTileIndex == 2;
                case 3:
                    return ((GameNode)node).EmptyTileIndex == 3;
                case 4:
                    return ((GameNode)node).EmptyTileIndex == 4;
                case 5:
                    return ((GameNode)node).EmptyTileIndex == 5;
                case 6:
                    return ((GameNode)node).EmptyTileIndex == 6;
                case 7:
                    return ((GameNode)node).EmptyTileIndex == 7;
                case 8:
                    return ((GameNode)node).EmptyTileIndex == 8;
            }

            return false;
        }
    }
}
