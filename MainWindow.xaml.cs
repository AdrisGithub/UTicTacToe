using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace UltimateTicTacToe {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        
        private Cell[,] Board;
        private char currentMove;
        private char[,] bigBoard;
        private int[] nextPos;
        private bool ended;
        public MainWindow() {
            InitBoard();
            InitComp();
            InitializeComponent();
        }

        private void InitComp() {
            nextPos = new[] { -1, -1 };
            bigBoard = new char[3, 3];
            currentMove = '0';
            ended = false;
        }
        private void InitBoard() {
            Board = new Cell[9, 9];
            for (int x = 0; x < Board.GetLength(0); x++) {
                for (int y = 0; y < Board.GetLength(1); y++) {
                    Board[x, y] = new Cell();
                }
            }
        }

        private void DrawBlock(int xPos, int yPos, char owner) {
            if (owner == 'X') {
                Line leftTop = new Line {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 10,
                    X1 = xPos * 100 + 10,
                    Y1 = yPos * 100 + 10,
                    X2 = xPos * 100 + 90,
                    Y2 = yPos * 100 + 90
                };
                Line rightTop = new Line {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 10,
                    X1 = xPos * 100 + 10,
                    Y1 = yPos * 100 + 90,
                    X2 = xPos * 100 + 90,
                    Y2 = yPos * 100 + 10
                };
                Canvas.Children.Add(leftTop);
                Canvas.Children.Add(rightTop);
            }else{
                Ellipse blackCircle = new Ellipse {
                    Width = 80,
                    Height = 80,
                    Fill = new SolidColorBrush(Colors.Black),
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 10,
                };
                Canvas.SetTop(blackCircle,yPos * 100 + 10);
                Canvas.SetLeft(blackCircle,xPos * 100 + 10);
                Ellipse whiteCircle = new Ellipse {
                    Width = 80,
                    Height = 80,
                    Fill = new SolidColorBrush(Colors.White),
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 10,
                };
                Canvas.SetTop(whiteCircle,yPos * 100 + 10);
                Canvas.SetLeft(whiteCircle,xPos * 100 + 10);
                Canvas.Children.Add(blackCircle);
                Canvas.Children.Add(whiteCircle);
            }
        }

        private void Canvas_OnMouseDown(object sender, MouseButtonEventArgs e) {
            var pos = e.GetPosition(sender as Grid);
            int x = (int)pos.X/100, y = (int)pos.Y/100;
            if (!Board[x, y].IsSet() && IsValid(x/3,y/3) && !ended) {
                changeCurrentMove();
                DrawBlock(x,y,currentMove);
                Board[x,y].SetOwner(currentMove);
                CheckWinner(x/3,y/3);
                nextPos[0] = x % 3;
                nextPos[1] = y % 3;
            }
        }

        private void CheckWinner(int x ,int y) {
            if (CheckRowsSmall() || CheckDiagonalsSmall() || CheckColumnsSmall()) {
                bigBoard[x, y] = currentMove;
                if (CheckRowsBig() || CheckDiagonalsBig() || CheckColumnsBig())
                    ended = true;
            }
        }

        private bool CheckRowsBig() {
            throw new NotImplementedException();
        }

        private bool CheckDiagonalsBig() {
            throw new NotImplementedException();
        }

        private bool CheckColumnsBig() {
            throw new NotImplementedException();
        }

        private bool CheckColumnsSmall() {
            throw new NotImplementedException();
        }

        private bool CheckDiagonalsSmall() {
            throw new NotImplementedException();
        }

        private bool CheckRowsSmall() {
            throw new NotImplementedException();
        }

        private bool IsValid(int x,int y) {
            return (nextPos[0] == x && nextPos[1] == y)||nextPos[0]==-1;
        }

        private void changeCurrentMove() {
            currentMove = currentMove == 'O' ? 'X' : 'O';
        }
    }
}