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

        private bool PieceChoosed = false;
        private bool WhiteTurn = true;
        private Button PieceToMove = null;

        private void PaintingTheBoard()
        {
            foreach (Control cntrl in tableLayoutPanel1.Controls)
            {

                if (cntrl is Panel)
                {
                    int row = tableLayoutPanel1.GetRow(cntrl);
                    int column = tableLayoutPanel1.GetColumn(cntrl);

                    if ((row + column) % 2 != 0)
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

        private void btn_Click(object sender, EventArgs e)
        {
            if (!PieceChoosed)
            {
                if (((Button)sender).Tag.ToString().Substring(0, 1) == "w" && WhiteTurn)
                {
                    ((Button)sender).BackColor = Color.FromArgb(255, 185, 204, 54);
                    PieceChoosed = true;

                    PieceToMove = ((Button)sender);
                }

                else if (((Button)sender).Tag.ToString().Substring(0, 1) == "b" && !WhiteTurn)
                {
                    ((Button)sender).BackColor = Color.FromArgb(255, 185, 204, 54);
                    PieceChoosed = true;

                    PieceToMove = ((Button)sender);
                }


            }

            else if (PieceChoosed && (((Button)sender).BackColor == Color.FromArgb(255, 185, 204, 54)))
            {
                ((Button)sender).BackColor = Color.Transparent;
                PieceChoosed = false;

                PieceToMove = null;
            }

            //else if (PieceChoosed && (((Button)sender).BackColor != Color.FromArgb(255, 185, 204, 54)))
            //{

            //    PieceToMove.Parent = ((Button)sender).Parent;
            //    ((Button)sender).Parent = null;
            //    PieceChoosed = false;

            //    PieceToMove = null;
            //}

        }

        private void panel_Click(object sender, EventArgs e)
        {

            if (PieceChoosed)
            {
                byte Old_Position = Convert.ToByte(PieceToMove.Parent.Tag);
                byte New_Position = Convert.ToByte(((Panel)sender).Tag);


                if (PieceToMove.Tag.ToString() == "w_Pawn" && WhiteTurn)
                {
                    if ((Old_Position + 10 == New_Position))
                    {
                        PieceToMove.Parent = ((Panel)sender);
                        PieceToMove.BackColor = Color.Transparent;
                        PieceChoosed = false;
                        WhiteTurn = false;
                    }

                    else if ((Old_Position + 20 == New_Position)
                        &&
                        (Convert.ToByte(PieceToMove.Parent.Tag) == 21
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 22
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 23
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 24
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 25
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 26
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 27
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 28))
                    {
                        PieceToMove.Parent = ((Panel)sender);
                        PieceToMove.BackColor = Color.Transparent;
                        PieceChoosed = false;
                        WhiteTurn = false;
                    }
                }



                if (PieceToMove.Tag.ToString() == "b_Pawn" && !WhiteTurn)
                {
                    if ((Old_Position - 10 == New_Position))
                    {
                        PieceToMove.Parent = ((Panel)sender);
                        PieceToMove.BackColor = Color.Transparent;
                        PieceChoosed = false;
                        WhiteTurn = true;
                    }

                    else if ((Old_Position - 20 == New_Position) &&
                        (Convert.ToByte(PieceToMove.Parent.Tag) == 71
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 72
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 73
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 74
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 75
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 76
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 77
                        || Convert.ToByte(PieceToMove.Parent.Tag) == 78))
                    {
                        PieceToMove.Parent = ((Panel)sender);
                        PieceToMove.BackColor = Color.Transparent;
                        PieceChoosed = false;
                        WhiteTurn = true;
                    }
                }




                if ((PieceToMove.Tag.ToString() == "w_Knight" && WhiteTurn)
                 && (

                 (Old_Position + 12 == New_Position || Old_Position + 21 == New_Position
                 || Old_Position + 8 == New_Position || Old_Position + 19 == New_Position

                 ||

                 Old_Position - 8 == New_Position || Old_Position - 19 == New_Position
                 || Old_Position - 12 == New_Position || Old_Position - 21 == New_Position)

                 ))
                {
                    PieceToMove.BackColor = Color.Transparent;
                    PieceToMove.Parent = ((Panel)sender);
                    PieceChoosed = false;
                    WhiteTurn = false;
                }



                if ((PieceToMove.Tag.ToString() == "b_Knight" && !WhiteTurn)
                && (

                (Old_Position + 8 == New_Position || Old_Position + 19 == New_Position
                || Old_Position + 12 == New_Position || Old_Position + 21 == New_Position

                ||

                Old_Position - 8 == New_Position || Old_Position - 19 == New_Position
                || Old_Position - 12 == New_Position || Old_Position - 21 == New_Position)

                ))
                {
                    PieceToMove.BackColor = Color.Transparent;
                    PieceToMove.Parent = ((Panel)sender);
                    PieceChoosed = false;
                    WhiteTurn = true;
                }



                if (

                    (PieceToMove.Tag.ToString() == "w_Rook" && WhiteTurn)

                    && ((tableLayoutPanel1.GetColumn(PieceToMove.Parent) == tableLayoutPanel1.GetColumn(sender as Panel))

                    || (tableLayoutPanel1.GetRow(PieceToMove.Parent) == tableLayoutPanel1.GetRow(sender as Panel)))

                   )
                {
                    PieceToMove.BackColor = Color.Transparent;
                    PieceToMove.Parent = ((Panel)sender);
                    PieceChoosed = false;
                    WhiteTurn = false;
                }


                if (

                    (PieceToMove.Tag.ToString() == "b_Rook" && !WhiteTurn)

                    && ((tableLayoutPanel1.GetColumn(PieceToMove.Parent) == tableLayoutPanel1.GetColumn(sender as Panel))

                    || (tableLayoutPanel1.GetRow(PieceToMove.Parent) == tableLayoutPanel1.GetRow(sender as Panel)))

                    )
                {
                    PieceToMove.BackColor = Color.Transparent;
                    PieceToMove.Parent = ((Panel)sender);
                    PieceChoosed = false;
                    WhiteTurn = true;
                }


                if (

                  (PieceToMove.Tag.ToString() == "w_Bishop_WhiteSide" && WhiteTurn)

                  &&

                  ((New_Position == Old_Position + 11 || New_Position == Old_Position + 22 || New_Position == Old_Position + 33
                  || New_Position == Old_Position + 44 || New_Position == Old_Position + 55 || New_Position == Old_Position + 66
                  || New_Position == Old_Position + 77)

                  ||

                  (New_Position == Old_Position - 11 || New_Position == Old_Position - 22 || New_Position == Old_Position - 33
                  || New_Position == Old_Position - 44 || New_Position == Old_Position - 55 || New_Position == Old_Position - 66
                  || New_Position == Old_Position - 77)

                  ||

                  (New_Position == Old_Position + 9 || New_Position == Old_Position + 18 || New_Position == Old_Position + 27
                  || New_Position == Old_Position + 36 || New_Position == Old_Position + 45 || New_Position == Old_Position + 54
                  || New_Position == Old_Position + 63)

                  ||

                  (New_Position == Old_Position - 9 || New_Position == Old_Position - 18 || New_Position == Old_Position - 27
                  || New_Position == Old_Position - 36 || New_Position == Old_Position - 45 || New_Position == Old_Position - 54
                  || New_Position == Old_Position - 63)

                 ) &&
                  ((sender as Panel).BackColor == Color.White))
                {
                    PieceToMove.BackColor = Color.Transparent;
                    PieceToMove.Parent = ((Panel)sender);
                    PieceChoosed = false;
                    WhiteTurn = false;
                }



                if (

                  (PieceToMove.Tag.ToString() == "w_Bishop_BlackSide" && WhiteTurn)

                  &&

                  ((New_Position == Old_Position + 11 || New_Position == Old_Position + 22 || New_Position == Old_Position + 33
                  || New_Position == Old_Position + 44 || New_Position == Old_Position + 55 || New_Position == Old_Position + 66
                  || New_Position == Old_Position + 77)

                  ||

                  (New_Position == Old_Position - 11 || New_Position == Old_Position - 22 || New_Position == Old_Position - 33
                  || New_Position == Old_Position - 44 || New_Position == Old_Position - 55 || New_Position == Old_Position - 66
                  || New_Position == Old_Position - 77)

                  ||

                  (New_Position == Old_Position + 9 || New_Position == Old_Position + 18 || New_Position == Old_Position + 27
                  || New_Position == Old_Position + 36 || New_Position == Old_Position + 45 || New_Position == Old_Position + 54
                  || New_Position == Old_Position + 63)

                  ||

                  (New_Position == Old_Position - 9 || New_Position == Old_Position - 18 || New_Position == Old_Position - 27
                  || New_Position == Old_Position - 36 || New_Position == Old_Position - 45 || New_Position == Old_Position - 54
                  || New_Position == Old_Position - 63)

                 ) &&
                  ((sender as Panel).BackColor == Color.Gray))
                {
                    PieceToMove.BackColor = Color.Transparent;
                    PieceToMove.Parent = ((Panel)sender);
                    PieceChoosed = false;
                    WhiteTurn = false;
                }


                if (

                  (PieceToMove.Tag.ToString() == "b_Bishop_WhiteSide" && !WhiteTurn)

                  &&

                  ((New_Position == Old_Position + 11 || New_Position == Old_Position + 22 || New_Position == Old_Position + 33
                  || New_Position == Old_Position + 44 || New_Position == Old_Position + 55 || New_Position == Old_Position + 66
                  || New_Position == Old_Position + 77)

                  ||

                  (New_Position == Old_Position - 11 || New_Position == Old_Position - 22 || New_Position == Old_Position - 33
                  || New_Position == Old_Position - 44 || New_Position == Old_Position - 55 || New_Position == Old_Position - 66
                  || New_Position == Old_Position - 77)

                  ||

                  (New_Position == Old_Position + 9 || New_Position == Old_Position + 18 || New_Position == Old_Position + 27
                  || New_Position == Old_Position + 36 || New_Position == Old_Position + 45 || New_Position == Old_Position + 54
                  || New_Position == Old_Position + 63)

                  ||

                  (New_Position == Old_Position - 9 || New_Position == Old_Position - 18 || New_Position == Old_Position - 27
                  || New_Position == Old_Position - 36 || New_Position == Old_Position - 45 || New_Position == Old_Position - 54
                  || New_Position == Old_Position - 63)

                 ) &&
                  ((sender as Panel).BackColor == Color.White))
                {
                    PieceToMove.BackColor = Color.Transparent;
                    PieceToMove.Parent = ((Panel)sender);
                    PieceChoosed = false;
                    WhiteTurn = true;
                }



                if (

                  (PieceToMove.Tag.ToString() == "b_Bishop_BlackSide" && !WhiteTurn)

                  &&

                  ((New_Position == Old_Position + 11 || New_Position == Old_Position + 22 || New_Position == Old_Position + 33
                  || New_Position == Old_Position + 44 || New_Position == Old_Position + 55 || New_Position == Old_Position + 66
                  || New_Position == Old_Position + 77)

                  ||

                  (New_Position == Old_Position - 11 || New_Position == Old_Position - 22 || New_Position == Old_Position - 33
                  || New_Position == Old_Position - 44 || New_Position == Old_Position - 55 || New_Position == Old_Position - 66
                  || New_Position == Old_Position - 77)

                  ||

                  (New_Position == Old_Position + 9 || New_Position == Old_Position + 18 || New_Position == Old_Position + 27
                  || New_Position == Old_Position + 36 || New_Position == Old_Position + 45 || New_Position == Old_Position + 54
                  || New_Position == Old_Position + 63)

                  ||

                  (New_Position == Old_Position - 9 || New_Position == Old_Position - 18 || New_Position == Old_Position - 27
                  || New_Position == Old_Position - 36 || New_Position == Old_Position - 45 || New_Position == Old_Position - 54
                  || New_Position == Old_Position - 63)

                 ) &&
                  ((sender as Panel).BackColor == Color.Gray))
                {
                    PieceToMove.BackColor = Color.Transparent;
                    PieceToMove.Parent = ((Panel)sender);
                    PieceChoosed = false;
                    WhiteTurn = true;
                }


                if ((PieceToMove.Tag.ToString() == "w_Queen" && WhiteTurn)

                    && ((tableLayoutPanel1.GetColumn(PieceToMove.Parent) == tableLayoutPanel1.GetColumn(sender as Panel))

                    || (tableLayoutPanel1.GetRow(PieceToMove.Parent) == tableLayoutPanel1.GetRow(sender as Panel))

                    ||


                  ((New_Position == Old_Position + 11 || New_Position == Old_Position + 22 || New_Position == Old_Position + 33
                  || New_Position == Old_Position + 44 || New_Position == Old_Position + 55 || New_Position == Old_Position + 66
                  || New_Position == Old_Position + 77)

                  ||

                  (New_Position == Old_Position - 11 || New_Position == Old_Position - 22 || New_Position == Old_Position - 33
                  || New_Position == Old_Position - 44 || New_Position == Old_Position - 55 || New_Position == Old_Position - 66
                  || New_Position == Old_Position - 77)

                  ||

                  (New_Position == Old_Position + 9 || New_Position == Old_Position + 18 || New_Position == Old_Position + 27
                  || New_Position == Old_Position + 36 || New_Position == Old_Position + 45 || New_Position == Old_Position + 54
                  || New_Position == Old_Position + 63)

                  ||

                  (New_Position == Old_Position - 9 || New_Position == Old_Position - 18 || New_Position == Old_Position - 27
                  || New_Position == Old_Position - 36 || New_Position == Old_Position - 45 || New_Position == Old_Position - 54
                  || New_Position == Old_Position - 63)))

                  )
                {
                    PieceToMove.BackColor = Color.Transparent;
                    PieceToMove.Parent = ((Panel)sender);
                    PieceChoosed = false;
                    WhiteTurn = false;
                }



                if ((PieceToMove.Tag.ToString() == "b_Queen" && !WhiteTurn)

                && ((tableLayoutPanel1.GetColumn(PieceToMove.Parent) == tableLayoutPanel1.GetColumn(sender as Panel))

                || (tableLayoutPanel1.GetRow(PieceToMove.Parent) == tableLayoutPanel1.GetRow(sender as Panel))

                ||


                ((New_Position == Old_Position + 11 || New_Position == Old_Position + 22 || New_Position == Old_Position + 33
                || New_Position == Old_Position + 44 || New_Position == Old_Position + 55 || New_Position == Old_Position + 66
                || New_Position == Old_Position + 77)

                ||

                (New_Position == Old_Position - 11 || New_Position == Old_Position - 22 || New_Position == Old_Position - 33
                || New_Position == Old_Position - 44 || New_Position == Old_Position - 55 || New_Position == Old_Position - 66
                || New_Position == Old_Position - 77)

                ||

                (New_Position == Old_Position + 9 || New_Position == Old_Position + 18 || New_Position == Old_Position + 27
                || New_Position == Old_Position + 36 || New_Position == Old_Position + 45 || New_Position == Old_Position + 54
                || New_Position == Old_Position + 63)

                ||

                (New_Position == Old_Position - 9 || New_Position == Old_Position - 18 || New_Position == Old_Position - 27
                || New_Position == Old_Position - 36 || New_Position == Old_Position - 45 || New_Position == Old_Position - 54
                || New_Position == Old_Position - 63)))

                )
                {
                    PieceToMove.BackColor = Color.Transparent;
                    PieceToMove.Parent = ((Panel)sender);
                    PieceChoosed = false;
                    WhiteTurn = true;
                }



                if ((PieceToMove.Tag.ToString() == "w_King" && WhiteTurn)
                    &&
                    (New_Position == Old_Position + 1 || New_Position == Old_Position - 1 || New_Position == Old_Position + 10
                    || New_Position == Old_Position - 10 || New_Position == Old_Position + 11 || New_Position == Old_Position - 11
                    || New_Position == Old_Position + 9 || New_Position == Old_Position - 9)
                    )
                {
                    PieceToMove.BackColor = Color.Transparent;
                    PieceToMove.Parent = ((Panel)sender);
                    PieceChoosed = false;
                    WhiteTurn = false;
                }

                if ((PieceToMove.Tag.ToString() == "b_King" && !WhiteTurn)
                   &&
                   (New_Position == Old_Position + 1 || New_Position == Old_Position - 1 || New_Position == Old_Position + 10
                    || New_Position == Old_Position - 10 || New_Position == Old_Position + 11 || New_Position == Old_Position - 11
                    || New_Position == Old_Position + 9 || New_Position == Old_Position - 9)
                   )
                {
                    PieceToMove.BackColor = Color.Transparent;
                    PieceToMove.Parent = ((Panel)sender);
                    PieceChoosed = false;
                    WhiteTurn = true;
                }

                //PieceToMove.BackColor = Color.Transparent;
                //PieceToMove = null;
                //PieceChoosed = false;
            }

            else
            {
                return;
            }

        }

    }
}
