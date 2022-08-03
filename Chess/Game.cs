using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Chess.Pieces;
using Chess.Properties;
using Microsoft.Win32.SafeHandles;

namespace Chess
{
    public class Game
    {
        //private Board board;
        private Piece[][] board;
        private bool _isWhiteTurn = true;

        private Form1 _form1;

        private string[] _letters = new[] { "a", "b", "c", "d", "e", "f", "g", "h"};

        private bool[] _kingCastle = new bool[] { true, true };

        private List<string> _fenStorage = new List<string>();

        //first
        // k = 0 - black pieces, k = 1 - white pieces
        // second
        // 0 - queen side - long castle; 1 - king side - short castle;
        // everything false as it's setup in fen parsing
        private bool[][] _rookCastle = new bool[][] { new bool[] { false, false }, new bool[] { false, false} };
        
        private List<(int, int)> _enPassant = new List<(int, int)>();

        private int _halfMoves;
        private int _moves;
        private bool _highlightSquares;
        private bool _isPuzzle;
        private List<string> _puzzleMoves;

        public bool HighlightSquares => _highlightSquares;
        

        // private string castle;
        // private string enPassant;
        // private int halfMoves;
        // private int moves;
        // private string turn;
        
        /*private Player[] players;
        private Player currentTurn;
        private GameStatus status;
        private List<Move> movesPlayed;*/


        public Piece[][] GetBoard()
        {
            return board;
        }
        
        public Game(string fen, Form1 form1, bool highlightSquares, bool isPuzzle, List<string> puzzleMoves = null)
        {
            string[] fenSplit = fen.Split(' ');
            board = Fen.Fen2Board(fenSplit[0]);
            _form1 = form1;

            _isWhiteTurn = fenSplit[1] == "w";
            
            foreach (var c in fenSplit[2].ToCharArray())
            {
                switch (c)
                {
                    case 'K':
                        _rookCastle[1][1] = true;
                        break;
                    case 'Q':
                        _rookCastle[1][0] = true;
                        break;
                    case 'k':
                        _rookCastle[0][1] = true;
                        break;
                    case 'q':
                        _rookCastle[0][0] = true;
                        break;
                }
            }
            
            _enPassant.AddRange(GetCoordinatesByMove(fenSplit[3]));
            
            _halfMoves = Convert.ToInt32(fenSplit[4]);
            _moves = Convert.ToInt32(fenSplit[5]);

            _highlightSquares = highlightSquares;
            _isPuzzle = isPuzzle;
            _puzzleMoves = puzzleMoves;
            // for (int i = 0; i < 8; i++)
            // {
            //     board[i] = new Piece[8];
            // }


            //string[] fenSplit = fen.Split(' ');
            // Fen f = new Fen();
            // board = f.Fen2Board(fenSplit[0]);

            // turn = fenSplit[1];
            // castle = fenSplit[2];
            // enPassant = fenSplit[3];
            // halfMoves = Convert.ToInt32(fenSplit[4]);
            // moves = Convert.ToInt32(fenSplit[5]);
            // for (int i = 0; i < 8; i++)
            // {
            //     for (int j = 0; j < 8; j++)
            //     {
            //         board.GetSquares()[i][j].ClickEvent += ClickHandler;
            //     }
            // }

        }



        // for game to fen
        public bool IsWhiteTurn => _isWhiteTurn;
        public bool[] KingCastle => _kingCastle;
        public bool[][] RookCastle => _rookCastle;
        
        public List<(int, int)> EnPassant => _enPassant;
        
        public int HalfMoves => _halfMoves;

        public int Moves => _moves;
        
        public List<(int, int)> PossibleMoves(int x, int y)
        {
            Piece piece = board[y][x];
            if (piece == null)
            {
                return new List<(int, int)>();
            }

            if (piece.IsWhite != _isWhiteTurn)
            {
                return new List<(int, int)>();
            }
            
            return piece.GetMoves(this,x,y);
        }

        public void Move(int x1, int y1, int x2, int y2)
        {
            if (_isPuzzle)
            {
                if (GetMoveByCoordinates(x1,y1,x2,y2) != _puzzleMoves[_moves-1])
                {
                    _form1.DisplayMessage("Wrong Move!");
                    return;
                }
            }
            
            
            // if king captured
            if (IsOccupied(x2, y2))
            {
                if (board[y2][x2].GetPieceType() == PieceType.King)
                {
                    if (_isWhiteTurn)
                    {
                        MessageBox.Show("White won!");
                    }
                    else
                    {
                        MessageBox.Show("Black won!");
                    }
                    _form1.GameEnd();
                }
            }
            // un castle after rook moves
            int k = 0;
            k = _isWhiteTurn ? 1 : 0;
            int y = 0 + k * 7;
            if (board[y1][x1].GetPieceType() == PieceType.Rook)
            {
                if (x1 == 0 && y1 == y)
                {
                    _rookCastle[k][0] = false;
                }
                if (x1 == 7 && y1 == y)
                {
                    _rookCastle[k][1] = false;
                }
            }
            
            _enPassant.Clear();
            // en passant
            if (board[y1][x1].GetPieceType() == PieceType.Pawn && Math.Abs(y2 - y1) == 2)
            {
                _enPassant.Add((x2,y2));
            }
            
            
            
            // all if's result in a move
            // castle king
            if (board[y1][x1].GetPieceType() == PieceType.King)
            {
                if (x2 == 2 && y2 == y)
                {
                    // 0-0-0
                    AddMove("0-0-0");
                    board[y2][x2] = board[y1][x1];
                    board[y1][x1] = null;
                    board[y][3] = board[y][0];
                    board[y][0] = null;
                }
                else if (x2 == 6 && y2 == y)
                {
                    //0-0
                    AddMove("0-0");
                    board[y2][x2] = board[y1][x1];
                    board[y1][x1] = null;
                    board[y][5] = board[y][7];
                    board[y][7] = null;
                }
                else
                {
                    AddMove(GetMoveByCoordinates(x1, y1, x2, y2));
                    board[y2][x2] = board[y1][x1];
                    board[y1][x1] = null;
                }
                _kingCastle[k] = false;
            }
            // promotion
            else if (board[y1][x1].GetPieceType() == PieceType.Pawn && y2 == 0 + (1-k) * 7)
            {
                PawnPromotionPicker pwn = new PawnPromotionPicker();
                int result = pwn.Show(_isWhiteTurn);
                switch (result)
                {
                    case 0:
                        board[y2][x2] = new Queen(_isWhiteTurn);
                        break;
                    case 1:
                        board[y2][x2] = new Knight(_isWhiteTurn);
                        break;
                    case 2:
                        board[y2][x2] = new Bishop(_isWhiteTurn);
                        break;
                    case 3:
                        board[y2][x2] = new Rook(_isWhiteTurn);
                        break;
                }
                board[y1][x1] = null;
            }
            // enPassant
            else if (board[y1][x1].GetPieceType() == PieceType.Pawn && !IsOccupied(x2,y2) && Math.Abs(x2-x1)==1 && Math.Abs(y2-y1) == 1)
            {
                
                AddMove(GetMoveByCoordinates(x1, y1, x2, y2).Insert(2,"x"));
                board[y2][x2] = board[y1][x1];
                board[y1][x1] = null;
                board[y1][x1 + (x2-x1)] = null;
            }
            else
            {
                AddMove(GetMoveByCoordinates(x1, y1, x2, y2));
                board[y2][x2] = board[y1][x1];
                board[y1][x1] = null;
            }
            _isWhiteTurn = !_isWhiteTurn;
            _moves++;

            _fenStorage.Add(Fen.Game2Fen(this));



            if (_isPuzzle)
            {
                if ((_moves % 2 == 0) && _moves != _puzzleMoves.Count + 1)
                {
                    _form1.DisplayMessage("Nice Move!");
                    PlayNextMove();
                    // play black move
                }
                // TODO unfortunatly it finishes too fast, maybe rework game end?
                if (_moves == _puzzleMoves.Count + 1)
                {
                    MessageBox.Show("Puzzle Solved!");
                    _form1.GameEnd();
                }
            }
        }

        private void PlayNextMove()
        {
            List<int> coords = GetCoordinatesByFullMove(_puzzleMoves[_moves - 1]);
            Move(coords[0],coords[1],coords[2],coords[3]);
        }
        
        public string GetFenById(int id)
        {
            return _fenStorage[id];
        }
        public void AddMove(string move)
        {
            // maybe add to array?
            move = _moves + ": " + move;
            _form1.AddMoveToList(move);
            
        }

        public void UpdateGame(int id)
        {
            var fen = _fenStorage[id];
            string[] fenSplit = fen.Split(' ');
            board = Fen.Fen2Board(fenSplit[0]);
            _isWhiteTurn = fenSplit[1] == "w";
            
            foreach (var c in fenSplit[2].ToCharArray())
            {
                switch (c)
                {
                    case 'K':
                        _rookCastle[1][1] = true;
                        break;
                    case 'Q':
                        _rookCastle[1][0] = true;
                        break;
                    case 'k':
                        _rookCastle[0][1] = true;
                        break;
                    case 'q':
                        _rookCastle[0][0] = true;
                        break;
                }
            }
            _enPassant.AddRange(GetCoordinatesByMove(fenSplit[3]));
            _halfMoves = Convert.ToInt32(fenSplit[4]);
            _moves = Convert.ToInt32(fenSplit[5]);
            
            _fenStorage.RemoveRange(id + 1,_fenStorage.Count - (id+1));
            
        } 
        
        private string GetMoveByCoordinates(int x1, int y1, int x2, int y2)
        {
            string Move = "";
            switch (board[y1][x1].GetPieceType())
            {  
                case PieceType.Pawn:
                    break;
                case PieceType.Bishop:
                    Move += "B";
                    break;
                case PieceType.Knight:
                    Move += "N";
                    break;
                case PieceType.Rook:
                    Move += "R";
                    break;
                case PieceType.Queen:
                    Move += "Q";
                    break;
                case PieceType.King:
                    Move += "K";
                    break;
            }
            Move += _letters[x1] + (8 - y1);
            if (IsOccupied(x2, y2))
            {
                Move += "x";
            }

            Move += _letters[x2] + (8 - y2);
            //if king checked add "+"
            return Move;
        }
        public string GetMoveByCoordinatesList(List<(int, int)> list)
        {
            if (list.Count == 0)
            {
                return "-";
            }
            string Move = "";
            int x = list[0].Item1;
            int y = list[0].Item2;
            switch (board[y][x].GetPieceType())
            {  
                case PieceType.Pawn:
                    break;
                case PieceType.Bishop:
                    Move += "B";
                    break;
                case PieceType.Knight:
                    Move += "N";
                    break;
                case PieceType.Rook:
                    Move += "R";
                    break;
                case PieceType.Queen:
                    Move += "Q";
                    break;
                case PieceType.King:
                    Move += "K";
                    break;
            }
            Move += _letters[x] + (8 - y);
            //if king checked add "+"
            return Move;
        }
        private List<(int, int)> GetCoordinatesByMove(string move)
        {
            if (move == "-")
            {
                return new List<(int, int)>();
            }
            return new List<(int, int)>{(Array.IndexOf(_letters,move[0]),Convert.ToInt32(move[1]))};    

        }

        private List<int> GetCoordinatesByFullMove(string move)
        {
            List<int> coords = new List<int>();
            foreach (var c in move.ToCharArray())
            {
                if (c >= 'a' && c <= 'h')
                {
                    coords.Add(Array.IndexOf(_letters,char.ToString(c)));
                }

                if (char.IsDigit(c))
                {
                    coords.Add(8-( c - '0'));
                }
            }

            return coords;
        }
        

        public void SetPanel(BoardPanel boardPanel,Panel panel)
        {
            boardPanel.Location = new Point(70, 50);
            boardPanel.Size = new Size(640, 640);
            boardPanel.BackgroundImage = Textures.Board;
            panel.Controls.Add(boardPanel);
        }

        public bool IsEnemy(bool isWhite, int x,int y)
        {
            if (x < 0 || 7 < x || y < 0 || 7 < y)
            {
                return false;
            }
            
            if (board[y][x] == null)
            {
                return false;
            }

            if (board[y][x].IsWhite == isWhite)
            {
                return false;
            }

            return true;
        }
        
        public bool IsOccupied(int x,int y)
        {
            if (x < 0 || 7 < x || y < 0 || 7 < y)
            {
                return true;
            }

            if (board[y][x] == null)
            {
                return false;
            }

            return true;
        }

        public List<(int, int)> GetEnPassantMoves(bool IsWhite, int x,int y)
        {
            List<(int, int)> moves = new List<(int, int)>();
            if (_enPassant.Any())
            {
                int k = IsWhite ? -1 : 1;
                if (_enPassant[0] == (x - 1, y) && IsEnemy(IsWhite, x - 1, y))
                {
                    moves.Add((x - 1, y + k));
                }
                if (_enPassant[0] == (x + 1, y) && IsEnemy(IsWhite, x + 1, y))
                {
                    moves.Add((x + 1, y + k));
                }
            }
            return moves;
        }
        public List<(int, int)> GetCastleMoves(bool isWhite)
        {
            // 0,2  0,6
            List<(int, int)> moves = new List<(int, int)>();
            int k = 0;
            k = isWhite ? 1 : 0;
            int y = 0 + k * 7;

            if (_kingCastle[k])
            {
                if (_rookCastle[k][0] && !IsOccupied(1,y) && !IsOccupied(2,y) && !IsOccupied(3,y) )
                {
                    moves.Add((2, y));
                }
                if (_rookCastle[k][1] && !IsOccupied(5,y) && !IsOccupied(6,y))
                {
                    moves.Add((6, y));
                }
            }
            return moves;
        }
        
        // public void ClickHandler(object sender, EventArgs eventArgs)
        // {
        //     Square sqr = (Square)sender;
        //     Debug.Write("[!] Got " + sqr.Piece + " with Y - " + sqr.Y + " and X - " + sqr.X+ "\n\r");
        //     board.ClearSelectedSquares();
        //     sqr.Piece.DrawMoves(board, sqr);
        // }
    }
}