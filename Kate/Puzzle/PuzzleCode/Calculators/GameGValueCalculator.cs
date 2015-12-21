using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Puzzle.PuzzleCode.Calculators
{
    public class GameGValueCalculator : GValueCalculatorInterface
    {
        private const float CostFactor = 0.265f; // trial and error based

        public float AddCost(NodeInterface node)
        {
            return node.G + CostFactor; // Add cost factor to node's G value
        }

    }
}
