using System.Collections.Generic;

namespace _8Puzzle.PuzzleCode.SuccessorNodes
{
    public interface SuccessorNodesGeneratorInterface
    {
        IEnumerable<NodeInterface> Execute(NodeInterface node);
    }
}