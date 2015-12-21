using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Puzzle.PuzzleCode.Calculators
{
    public interface GValueCalculatorInterface
    {
        float AddCost(NodeInterface node);
    }
}
