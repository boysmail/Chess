using System.Text;
using System.Windows.Forms;
using Chess.Pieces;

namespace Chess
{
    public class Fen
    {
        // standart fen rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1 


        // public Board Fen2Board(string fenPiecePlacement)
        // {
        //   
        //     //setup board
        //     Board board = new Board();
        //     
        //     char[] piecePlacementChar = fenPiecePlacement.ToCharArray();
        //     int x = 0, y = 0;
        //     for (int i = 0; i < piecePlacementChar.Length; i++)
        //     {
        //         switch (piecePlacementChar[i])
        //         {
        //             // black pawn
        //             case 'p':
        //                 board.SetSquare(x,y,new Pawn(false));
        //                 //board.Squares[x][y] = new Square(x,y, new Pawn(false));
        //                 x++;
        //                 break;
        //             // black rook
        //             case 'r':
        //                 board.SetSquare(x,y,new Rook(false));
        //                 x++;
        //                 break;
        //             // black knight (horse)
        //             case 'n':
        //                 board.SetSquare(x,y,new Knight(false));
        //                 x++;
        //                 break;
        //             // black bishop
        //             case 'b':
        //                 board.SetSquare(x,y,new Bishop(false));
        //                 x++;
        //                 break;
        //             // black queen
        //             case 'q':
        //                 board.SetSquare(x,y,new Queen(false));
        //                 x++;
        //                 break;
        //             // black king
        //             case 'k':
        //                 board.SetSquare(x,y,new King(false));
        //                 x++;
        //                 break;
        //             
        //             
        //             // white pawn
        //             case 'P':
        //                 board.SetSquare(x,y,new Pawn(true));
        //                 x++;
        //                 break;
        //             //white rook
        //             case 'R':
        //                 board.SetSquare(x,y,new Rook(true));
        //                 x++;
        //                 break;
        //             // white knight (horse)
        //             case 'N':
        //                 board.SetSquare(x,y,new Knight(true));
        //                 x++;
        //                 break;
        //             // white bishop
        //             case 'B':
        //                 board.SetSquare(x,y,new Bishop(true));
        //                 x++;
        //                 break;
        //             // white queen
        //             case 'Q':
        //                 board.SetSquare(x,y,new Queen(true));
        //                 x++;
        //                 break;
        //             // white king
        //             case 'K':
        //                 board.SetSquare(x,y,new King(true));
        //                 x++;
        //                 break;
        //             
        //             // line change after line ended
        //             case '/':
        //                 x = 0;
        //                 y++;
        //                 break;
        //             
        //             // skipping blank spaces by creating null squares
        //             default:
        //                 for (int j = 0; j < piecePlacementChar[i] - '0'; j++)
        //                 {
        //                     board.SetSquare(x,y,new Blank(true));
        //                     x++;
        //                 }
        //                 break;
        //         }
        //         
        //     }
        //     
        //     
        //     return board;
        // }


        public static Piece[][] Fen2Board(string fenPiecePlacement)
        {
            var board = new Piece[8][];
            for (var i = 0; i < 8; i++)
            {
                board[i] = new Piece[8];
            }

            int x = 0, y = 0;
            foreach (var c in fenPiecePlacement.ToCharArray())
            {
                Piece newPiece = null;

                switch (c)
                {
                    // black pawn
                    case 'p':
                        newPiece = new Pawn(false);
                        break;
                    // black rook
                    case 'r':
                        newPiece = new Rook(false);
                        break;
                    // black knight (horse)
                    case 'n':
                        newPiece = new Knight(false);
                        break;
                    // black bishop
                    case 'b':
                        newPiece = new Bishop(false);
                        break;
                    // black queen
                    case 'q':
                        newPiece = new Queen(false);
                        break;
                    // black king
                    case 'k':
                        newPiece = new King(false);
                        break;

                    // white pawn
                    case 'P':
                        newPiece = new Pawn(true);
                        break;
                    // white rook
                    case 'R':
                        newPiece = new Rook(true);
                        break;
                    // white knight (horse)
                    case 'N':
                        newPiece = new Knight(true);
                        break;
                    // white bishop
                    case 'B':
                        newPiece = new Bishop(true);
                        break;
                    // white queen
                    case 'Q':
                        newPiece = new Queen(true);
                        break;
                    // white king
                    case 'K':
                        newPiece = new King(true);
                        break;

                    // line change after line ended
                    case '/':
                        x = 0;
                        y++;
                        break;

                    // skipping blank spaces by creating null squares
                    default:
                        x += c - '0';
                        break;
                }

                if (newPiece != null)
                {
                    board[y][x] = newPiece;
                    x++;
                }
            }
            return board;
        }
        
        public static string Game2Fen(Game game)
        {
            var board = game.GetBoard();
            StringBuilder sb = new StringBuilder();
            int blank = 0;
            // board position
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (game.IsOccupied(x, y))
                    {
                        if (blank != 0)
                        {
                            sb.Append(blank);
                            blank = 0;
                        }
                        switch (board[y][x].GetPieceType())
                        {
                            case PieceType.Pawn:
                                sb.Append(board[y][x].IsWhite ? "P" : "p");
                                break;
                            case PieceType.Rook:
                                sb.Append(board[y][x].IsWhite ? "R" : "r");
                                break;
                            case PieceType.Knight:
                                sb.Append(board[y][x].IsWhite ? "N" : "n");
                                break;
                            case PieceType.Bishop:
                                sb.Append(board[y][x].IsWhite ? "B" : "b");
                                break;
                            case PieceType.Queen:
                                sb.Append(board[y][x].IsWhite ? "Q" : "q");
                                break;
                            case PieceType.King:
                                sb.Append(board[y][x].IsWhite ? "K" : "k");
                                break;
                        }
                    }
                    else
                    {
                        blank++;
                    }
                }
                if (blank != 0)
                {
                    sb.Append(blank);
                    blank = 0;
                }

                if (y != 7)
                {
                    sb.Append("/");                    
                }
                
            }
            
            sb.Append(" ");
            // active side
            sb.Append(game.IsWhiteTurn ? "w" : "b");
            sb.Append(" ");
            
            // castles

            if (game.KingCastle[1])
            {
                sb.Append(game.RookCastle[1][1] ? "K" : "-");
                sb.Append(game.RookCastle[1][0] ? "Q" : "-");
            }
            if (game.KingCastle[0])
            {
                sb.Append(game.RookCastle[0][1] ? "k" : "-");
                sb.Append(game.RookCastle[0][0] ? "q" : "-");
            }
            sb.Append(" ");
            // en passant
            sb.Append(game.GetMoveByCoordinatesList(game.EnPassant));
            sb.Append(" ");
            // half move
            sb.Append(game.HalfMoves);
            sb.Append(" ");
            // moves
            sb.Append(game.Moves);
            return sb.ToString();
        }
    }
}