using System.Collections.Generic;

namespace _8Puzzle.PuzzleCode.SuccessorNodes
{
    public interface SuccessorNodesCalculationRuleInterface
    {
        IEnumerable<NodeInterface> GetSuccessors(NodeInterface node);
        bool Match(NodeInterface node);
    }
}