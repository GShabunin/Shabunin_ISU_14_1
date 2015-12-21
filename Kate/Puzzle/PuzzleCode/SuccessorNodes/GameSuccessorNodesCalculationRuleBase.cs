using System.Collections.Generic;
using System.Linq;

namespace _8Puzzle.PuzzleCode.SuccessorNodes
{
    public class GameSuccessorNodesCalculationRuleBase : SuccessorNodesCalculationRuleInterface
    {

        public virtual IEnumerable<NodeInterface> GetSuccessors(NodeInterface node)
        {
            return null;
        }

        public virtual bool Match(NodeInterface node)
        {
            return false;
        }


        protected static void AddSuccessor(GameNode node,
                                           ICollection<NodeInterface> result,
                                           int swapTile)
        {
            var newState = node.Tiles.Clone() as int[];
            if (newState == null) return;
            newState[node.EmptyTileIndex] = newState[swapTile];
            newState[swapTile] = 0;

            if (!IsEqualToParentState(node.ParentNode, newState))
                result.Add(new GameNode {Tiles = newState, ParentNode = node});
        }

        private static bool IsEqualToParentState(NodeInterface node, IEnumerable<int> state)
        {
            return node != null && state.SequenceEqual(((GameNode) node).Tiles);
        }
    }
}