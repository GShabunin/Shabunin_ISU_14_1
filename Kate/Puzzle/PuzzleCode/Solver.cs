using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8Puzzle.PuzzleCode.Calculators;
using _8Puzzle.PuzzleCode.SuccessorNodes;

namespace _8Puzzle
{
    class Solver
    {
        private readonly SuccessorNodesGeneratorInterface _successorNodesGenerator;
        private readonly GValueCalculatorInterface _gValueCalculator;
        private readonly HValueCalculatorInterface _hValueCalculator;
 
        public Solver(SuccessorNodesGeneratorInterface successorNodesGenerator,
                          GValueCalculatorInterface gValueCalculator,
                          HValueCalculatorInterface hValueCalculator)
        {
            _successorNodesGenerator = successorNodesGenerator;
            _gValueCalculator = gValueCalculator;
            _hValueCalculator = hValueCalculator;
        }
 
        public int Cycles { get; private set; }
 
        public NodeInterface Execute(NodeInterface startNode, NodeInterface goalNode)
        {
            Cycles = 0;

            var openList = new List<NodeInterface> { startNode };
            var closedList = new List<NodeInterface>();
 
            while (openList.Count > 0)
            {
                Cycles++;
                NodeInterface currentNode = GetBestNodeFromOpenList(openList);
 
                openList.Remove(currentNode);
                closedList.Add(currentNode);

                IEnumerable<NodeInterface> successorNodes =
                    _successorNodesGenerator.Execute(currentNode);

                foreach (NodeInterface successorNode in successorNodes)
                {
                    if (successorNode.Equals(goalNode))
                        return successorNode;
 
                    successorNode.G = _gValueCalculator.AddCost(currentNode);
                    successorNode.H = _hValueCalculator.Execute(goalNode, successorNode);
                    successorNode.F = successorNode.G + successorNode.H;
 
                    if (OpenListHasBetterNode(successorNode, openList))
                        continue;
 
                    openList.Add(successorNode);
                }
            }
 
            return null;
        }

        private static NodeInterface GetBestNodeFromOpenList(IEnumerable<NodeInterface> openList)
        {
            return openList.OrderBy(n => n.F).First();
        }

        private static bool OpenListHasBetterNode(NodeInterface successor, IEnumerable<NodeInterface> list)
        {
            return list.FirstOrDefault(n => n.G.Equals(successor.G) 
                    && n.F < successor.F) != null;
        }
    }
}
