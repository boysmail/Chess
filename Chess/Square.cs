using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using Chess.Pieces;

namespace Chess
{
    public class Square : PictureBox
    {
        private int _x;
        private int _y;
        private Piece _piece;
        private bool _selected = false;
        public delegate void ClickedDelegate(object sender, EventArgs e);
        private BoardPanel _boardPanel;
            
        public Square(int x, int y, BoardPanel boardPanel)
        {
            _x = x;
            _y = y;
            _boardPanel = boardPanel;
            Location = new Point(x * 80, y * 80);
            Size = new Size(80, 80);
            
            BackColor = Color.Transparent;
            this.Click += new EventHandler(SquareClick);
        }
        
        public event ClickedDelegate ClickEvent;
        private void SquareClick(object sender, EventArgs e)
        {
            _boardPanel.OnClick(_x,_y);
            // Square sqr = (Square)sender;
            // Debug.Write("[!] You clicked on " + sqr.Y + " " + sqr.X + " Figure = " + sqr.Piece + "\n\r");
            // ClickEvent.Invoke(sender,e);
            
        }

        public void SelectSquare()
        {
            _selected = true;
            Image = Textures.Dot;

        }
        public void SelectEnemySquare()
        {
            _selected = true;
            Image = Textures.Attack;
        }
        public void UnSelectSquare()
        {
            if (_selected)
            {
                _selected = false;
                Image = null;    
            }

        }

        public bool IsPieceWhite()
        {
            return _piece.IsWhite;
        }
        
        
        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }

        public Piece Piece
        {
            get => _piece;
            set
            {
                _piece = value;
                if (_piece == null)
                {
                    BackgroundImage = null;
                }
                else
                {
                    BackgroundImage = _piece.Texture();
                }
            }
            
        }

        public void Test()
        {
            
        }

        
    }
}