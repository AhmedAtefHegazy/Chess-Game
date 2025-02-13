using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PaintingTheBoard();
        }

        private void PaintingTheBoard()
        {
            foreach (Control cntrl in tableLayoutPanel1.Controls)
            {

                if (cntrl is Panel)
                {
                    int row = tableLayoutPanel1.GetRow(cntrl);
                    int column = tableLayoutPanel1.GetColumn(cntrl);

                    if ((row + column) % 2 == 0)
                    {
                        cntrl.BackColor = Color.Gray;
                    }

                    else
                    {
                        cntrl.BackColor = Color.White;
                    }
                }
            }
        }

        private bool PieceChoosed = false;
        private Button PieceToMove = null;


        private void btn_Click(object sender, EventArgs e)
        {
            if (!PieceChoosed)
            {
                ((Button)sender).BackColor = Color.Green;
                PieceChoosed = true;

                PieceToMove = ((Button)sender);

            }

            else if (PieceChoosed && (((Button)sender).BackColor == Color.Green))
            {
                ((Button)sender).BackColor = Color.Transparent;
                PieceChoosed = false;

                PieceToMove = null;

            }
        }

        private void panel_Click(object sender, EventArgs e)
        {
            //if (PieceChoosed)
            //{
            //    PieceToMove.BackColor = Color.Transparent;
            //    PieceToMove.Parent = ((Panel)sender);
            //    PieceToMove.BringToFront();
            //    PieceChoosed = false;
            //}

            if (PieceChoosed)
            {
                byte Old_Position = Convert.ToByte(PieceToMove.Parent.Tag);
                byte New_Position = Convert.ToByte(((Panel)sender).Tag);


                if (PieceToMove.Tag.ToString() == "w_Pawn")
                {
                    if ((Old_Position + 8 == New_Position))
                    {
                        PieceToMove.Parent = ((Panel)sender);
                        PieceToMove.BackColor = Color.Transparent;
                        PieceChoosed = false;
                    }

                    else if ((Old_Position + 16 == New_Position)
                        &&
                        (Convert.ToByte(PieceToMove.Parent.Tag) == 16
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 15
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 14
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 13
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 12
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 11
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 10
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 9))
                    {
                        PieceToMove.Parent = ((Panel)sender);
                        PieceToMove.BackColor = Color.Transparent;
                        PieceChoosed = false;
                    }
                }

                if (PieceToMove.Tag.ToString() == "b_Pawn")
                {
                    if ((Old_Position - 8 == New_Position))
                    {
                        PieceToMove.Parent = ((Panel)sender);
                        PieceToMove.BackColor = Color.Transparent;
                        PieceChoosed = false;
                    }

                    else if ((Old_Position - 16 == New_Position) &&
                        (Convert.ToByte(PieceToMove.Parent.Tag) == 56
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 55
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 54
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 53
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 52
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 51
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 50
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 49))
                    {
                        PieceToMove.Parent = ((Panel)sender);
                        PieceToMove.BackColor = Color.Transparent;
                        PieceChoosed = false;
                    }
                }


                if (PieceToMove.Tag.ToString() == "w_Bishop_WhiteSide"
               && ((Old_Position + 7 == New_Position || Old_Position + 9 == New_Position)
               || (Old_Position - 7 == New_Position || Old_Position - 9 == New_Position)
               ))
                {
                    PieceToMove.BackColor = Color.Transparent;
                    PieceToMove.Parent = ((Panel)sender);
                    PieceToMove.BringToFront();
                    PieceChoosed = false;

                }

                PieceToMove.BackColor = Color.Transparent;
                PieceToMove = null;
                PieceChoosed = false;

            }

            else
            {
                return;
            }

        }
    }
}
