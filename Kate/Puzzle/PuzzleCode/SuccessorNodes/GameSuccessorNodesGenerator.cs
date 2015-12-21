using System.Collections.Generic;
using System.Linq;

namespace _8Puzzle.PuzzleCode.SuccessorNodes
{
    public class GameSuccessorNodesGenerator : SuccessorNodesGeneratorInterface
    {
        #region ISuccessorNodesGenerator Members

        public IEnumerable<NodeInterface> Execute(NodeInterface currentNode)
        {
            var node = currentNode as GameNode;

            var successorRules =
                new List<SuccessorNodesCalculationRuleInterface>
                    {
                        new GameSuccessorsForEmptyTile()
                    };

            return successorRules
                .Single(r => r.Match(node))
                .GetSuccessors(node);
        }

        #endregion
    }
}