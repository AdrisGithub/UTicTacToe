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
        
        public MainWindow() {
            InitBoard();
            InitializeComponent();
            //DrawBlock(6,3,'X');
            //DrawBlock(4,3,'O');
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
            Label.Content += xPos + " " + yPos + " ";
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
        //Test Purpose
        private bool didX;

        private void Canvas_OnMouseDown(object sender, MouseButtonEventArgs e) {
            var pos = e.GetPosition(sender as Grid);
            int x = (int)pos.X/100, y = (int)pos.Y/100;
            if (didX) {
                DrawBlock(x,y,'O');
                didX = false;
            }
            else {
                DrawBlock(x,y,'X');
                didX = true;
            }
        }
    }
}