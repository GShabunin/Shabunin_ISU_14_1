using System;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Threading;
using _8Puzzle.PuzzleCode.Calculators;
using _8Puzzle.PuzzleCode.SuccessorNodes;
using MahApps.Metro.Controls;

namespace _8Puzzle
{
    public partial class MainWindow : MetroWindow 
    {
        const int N = 3;
        Board blocks;
        System.Windows.Controls.Button btnSolve;
        private static readonly GameNode Goal =
            new GameNode { Tiles = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 } };

        private Solver _solver;
        public MainWindow()
        {
            InitializeComponent();
            InitBoard();
            txtSteps.Text = "Steps: 0";
            btnSolve = new System.Windows.Controls.Button();
            btnSolve.Name = "btnSolve";
            btnSolve.Click += btnSolve_Click;
        }

        private void InitBoard()
        {
            blocks = new Board(N);
        }

        private void DrawBoard()
        {
            cnBoard.Children.Clear();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (blocks.getBlock(i, j) > 0)
                    {
                        ItemCntr cnv = new ItemCntr
                        {
                            IntVal = blocks.getBlock(i, j),
                            Width = cnBoard.Width / N,
                            Height = cnBoard.Height / N,
                            I = i,
                            J = j
                        };
                        Canvas.SetTop(cnv, i * cnBoard.Width / N);
                        Canvas.SetLeft(cnv, j * cnBoard.Width / N);
                        cnBoard.Children.Add(cnv);
                        cnv.MouseLeftButtonUp += new MouseButtonEventHandler(cnv_MouseLeftButtonUp);
                    }
                }
            }
        }

        void cnv_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ItemCntr it = (ItemCntr)sender;
            if (CheckMove(it.I - 1, it.J))
            {
                MoveItemClick(it, it.I - 1, it.J);
            }
            else if (CheckMove(it.I, it.J + 1))
            {
                MoveItemClick(it, it.I, it.J + 1);
            }
            else if (CheckMove(it.I + 1, it.J))
            {
                MoveItemClick(it, it.I + 1, it.J);
            }
            else if (CheckMove(it.I, it.J - 1))
            {
                MoveItemClick(it, it.I, it.J - 1);
            }
        }

        private void MoveItemClick(ItemCntr it, int i, int j)
        {
            blocks.setBlock(blocks.getBlock(it.I, it.J), i, j);
            blocks.setBlock(0, it.I, it.J);
            Storyboard sb = new Storyboard();
            DoubleAnimation da = new DoubleAnimation();
            if (i == it.I)
            {
                da.From = it.J * it.Width;
                da.By = j * it.Width - da.From;
            }
            else
            {
                da.From = it.I * it.Height;
                da.By = i * it.Height - da.From;
            }
            da.Duration = new Duration(TimeSpan.FromSeconds(.2));
            sb.Children.Add(da);
            object prop = it.I == i ? Canvas.LeftProperty : Canvas.TopProperty;
            Storyboard.SetTargetProperty(da, new PropertyPath(prop));
            sb.Begin(it, true);
            sb.Completed += new EventHandler(sb_Completed);
            it.I = i;
            it.J = j;
        }

        void sb_Completed(object sender, EventArgs e)
        {
            DrawBoard();
        }

        private bool CheckMove(int i, int j)
        {
            if (i < 0 || j < 0 || i > N-1 || j > N-1) return false;
            return (blocks.getBlock(i, j) == 0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DrawBoard();
        }

        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {
            int steps = 0;
            _solver = new Solver(
                new GameSuccessorNodesGenerator(),
                new GameGValueCalculator(),
                new GameHValueCalulator());

            var start = new GameNode { Tiles = blocks.stringBoard() };

            NodeInterface result = _solver.Execute(start, Goal);

            var stack = new Stack<NodeInterface>();

            do
            {
                stack.Push(result);
            } while ((result = result.ParentNode) != null);

            new Thread(() => {
                foreach (var node in stack)
                {
                    //The invoke only needs to be used when updating GUI Elements
                    this.Dispatcher.Invoke((MethodInvoker)delegate {
                        //Everything inside of this Invoke runs on the GUI Thread
                        int[,] unstrung = node.unstringNode(node); // turns node of int[] into board of  int[,]
                        blocks.setBoard(unstrung); // sets the board to pass in to the GUI
                        DrawBoard(); // Takes the board (int[,]) and sets the squares on the GUI to match it.
                        txtSteps.Text = "Steps: " + steps;
                        steps++;
                        });
                    Thread.Sleep(500);
                    }
                }).Start();
            }
    
    }
}
