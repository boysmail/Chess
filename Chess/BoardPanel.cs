using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Chess.Pieces;

namespace Chess
{
    public class BoardPanel : Panel
    {
        private Square[][] _squares;
        private Game _game;
        private List<(int, int)> lastPoints = new List<(int, int)>();
        private (int, int) lastPoint;

        public BoardPanel(Game game)
        {
            _game = game;
            _squares = new Square[8][];
            for (int y = 0; y < 8; y++)
            {
                _squares[y] = new Square[8];
                for (int x = 0; x < 8; x++)
                {
                    _squares[y][x] = new Square(x,y,this);
                    Controls.Add(_squares[y][x]);
                }
            }
            SetBoard(game.GetBoard());
        }

        public void OnClick(int x, int y)
        {

            if (lastPoints.Count == 0 || !lastPoints.Contains((x, y)))
            {
                var points = _game.PossibleMoves(x,y);
                ClearSelectedSquares();
            
                foreach (var point in points)
                {
                    int pointX = point.Item1;
                    int pointY = point.Item2;
                    if (_game.HighlightSquares)
                    {
                        if (_game.IsOccupied(pointX, pointY))
                        {
                            if (_game.IsEnemy(_squares[y][x].IsPieceWhite(),pointX,pointY))
                            {
                                _squares[pointY][pointX].SelectEnemySquare();
                            }    
                        }
                        else
                        {
                            _squares[pointY][pointX].SelectSquare();                        
                        }
                    }
                    

                    
                }

                lastPoint = (x, y);
                lastPoints = points;
            }
            else
            {
                _game.Move(lastPoint.Item1, lastPoint.Item2, x, y);
                
                ClearSelectedSquares();
                SetBoard(_game.GetBoard());
                lastPoints.Clear();
                lastPoint = (x, y);
                
            }
            //Debug.Write("Got" + x + y);

        }

        // public void SetSquare(int x,int y, Piece piece)
        // {
        //     
        //     _squares[y][x] = new Square(x, y, piece);
        //     Controls.Add(_squares[y][x]);
        // }

        public void SetBoard(Piece[][] board)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    _squares[y][x].Piece = board[y][x];
                }
            }
        }

        public Square GetSquare(int x, int y)
        {
            return _squares[y][x];
        } 
            
        public Square[][] GetSquares()
        {
            return _squares;
        } 
        
        public void ClearSelectedSquares()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    _squares[i][j].UnSelectSquare();
                }
            }
        }
        
    }
}