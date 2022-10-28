using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T2
{
    public partial class Form1 : Form
    {
        int moveCount = 0;
        const int board1Start = 0, board2Start = 9, board3Start = 18, board4Start = 27, board5Start = 36, board6Start = 45, board7Start = 54, board8Start = 63, board9Start = 72, board9End = 80;
        readonly Bitmap o = new(@"o.PNG");
        readonly Bitmap x = new(@"x.PNG");
        readonly int[] gameBoard = new int[81];
        readonly int[] boardWin = new int[9];
        int lastPlayedMove = -1;
        int currentMove;
        int currentBoard = 0;
        int previousBoard = -1;
        int boardOffset;
        bool moveStatus = false;


        public Form1()
        {
            InitializeComponent();
            pictureBox2.Image = x;
        }

        private bool CheckBoardWin()
        {

            boardOffset = currentBoard * 9;
            if (boardWin[currentBoard] == 0)
            {
                if (gameBoard[0 + boardOffset] == gameBoard[1 + boardOffset]
                    && gameBoard[0 + boardOffset] != 0
                    && gameBoard[1 + boardOffset] == gameBoard[2 + boardOffset]
                    && gameBoard[1 + boardOffset] != 0)       //top horizontal win
                {
                    if (moveCount % 2 == 0)
                    {
                        boardWin[currentBoard] = 1;
                    }
                    else
                    {
                        boardWin[currentBoard] = 2;
                    }

                    return true;
                }
                else if (gameBoard[3 + boardOffset] == gameBoard[4 + boardOffset] && gameBoard[3 + boardOffset] != 0 && gameBoard[4 + boardOffset] == gameBoard[5 + boardOffset] && gameBoard[4 + boardOffset] != 0)  //middle horizontal win
                {
                    if (moveCount % 2 == 0)
                    {
                        boardWin[currentBoard] = 1;
                    }
                    else
                    {
                        boardWin[currentBoard] = 2;
                    }

                    return true;
                }
                else if (gameBoard[6 + boardOffset] == gameBoard[7 + boardOffset] && gameBoard[6 + boardOffset] != 0 && gameBoard[7 + boardOffset] == gameBoard[8 + boardOffset] && gameBoard[7 + boardOffset] != 0)  //bottom horizontal win
                {
                    if (moveCount % 2 == 0)
                    {
                        boardWin[currentBoard] = 1;
                    }
                    else
                    {
                        boardWin[currentBoard] = 2;
                    }

                    return true;
                }
                else if (gameBoard[0 + boardOffset] == gameBoard[3 + boardOffset] && gameBoard[0 + boardOffset] != 0 && gameBoard[3 + boardOffset] == gameBoard[6 + boardOffset] && gameBoard[3 + boardOffset] != 0)  //left vertical win
                {
                    if (moveCount % 2 == 0)
                    {
                        boardWin[currentBoard] = 1;
                    }
                    else
                    {
                        boardWin[currentBoard] = 2;
                    }

                    return true;
                }
                else if (gameBoard[1 + boardOffset] == gameBoard[4 + boardOffset] && gameBoard[1 + boardOffset] != 0 && gameBoard[4 + boardOffset] == gameBoard[7 + boardOffset] && gameBoard[4 + boardOffset] != 0)  //middle vertical win
                {
                    if (moveCount % 2 == 0)
                    {
                        boardWin[currentBoard] = 1;
                    }
                    else
                    {
                        boardWin[currentBoard] = 2;
                    }

                    return true;
                }
                else if (gameBoard[2 + boardOffset] == gameBoard[5 + boardOffset] && gameBoard[2 + boardOffset] != 0 && gameBoard[5 + boardOffset] == gameBoard[8 + boardOffset] && gameBoard[5 + boardOffset] != 0)  //right vertical win
                {
                    if (moveCount % 2 == 0)
                    {
                        boardWin[currentBoard] = 1;
                    }
                    else
                    {
                        boardWin[currentBoard] = 2;
                    }

                    return true;
                }
                else if (gameBoard[0 + boardOffset] == gameBoard[4 + boardOffset] && gameBoard[0 + boardOffset] != 0 && gameBoard[4 + boardOffset] == gameBoard[8 + boardOffset] && gameBoard[4 + boardOffset] != 0)  //top->bottom diagonal win
                {
                    if (moveCount % 2 == 0)
                    {
                        boardWin[currentBoard] = 1;
                    }
                    else
                    {
                        boardWin[currentBoard] = 2;
                    }

                    return true;
                }
                else if (gameBoard[2 + boardOffset] == gameBoard[4 + boardOffset] && gameBoard[2 + boardOffset] != 0 && gameBoard[4 + boardOffset] == gameBoard[6 + boardOffset] && gameBoard[4 + boardOffset] != 0) //bottom->top diagonal win
                {
                    if (moveCount % 2 == 0)
                    {
                        boardWin[currentBoard] = 1;
                    }
                    else
                    {
                        boardWin[currentBoard] = 2;
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private void GameStatus(int currentBoard)
        {
            bool status = false;
            if (boardWin[currentBoard] == 0)
            {
                status = CheckBoardWin();
            }

            if (status)
            {
                status = CheckGameWin();
            }

            if (status)
            {
                DeclareWinner();
            }

            if (moveCount % 2 == 0)
            {
                pictureBox2.Image = o;
            }
            else
            {
                pictureBox2.Image = x;
            }
        }

        private bool CheckGameWin()
        {
            if (boardWin[0] == boardWin[1] && boardWin[1] == boardWin[2] && boardWin[0] != 0)       //top horizontal win
            {
                return true;
            }
            else if (boardWin[3] == boardWin[4] && boardWin[4] == boardWin[5] && boardWin[3] != 0)  //middle horizontal win
            {
                return true;
            }
            else if (boardWin[6] == boardWin[7] && boardWin[7] == boardWin[8] && boardWin[6] != 0)  //bottom horizontal win
            {
                return true;
            }
            else if (boardWin[0] == boardWin[3] && boardWin[3] == boardWin[6] && boardWin[0] != 0)  //left vertical win
            {
                return true;
            }
            else if (boardWin[1] == boardWin[4] && boardWin[4] == boardWin[7] && boardWin[1] != 0)  //middle vertical win
            {
                return true;
            }
            else if (boardWin[2] == boardWin[5] && boardWin[5] == boardWin[8] && boardWin[2] != 0)  //right vertical win
            {
                return true;
            }
            else if (boardWin[0] == boardWin[4] && boardWin[4] == boardWin[8] && boardWin[0] != 0)  //top->bottom diagonal win
            {
                return true;
            }
            else if (boardWin[2] == boardWin[4] && boardWin[4] == boardWin[6] && boardWin[2] != 0)  //bottom->top diagonal win
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DeclareWinner()
        {
            pictureBox1.BringToFront();
            if (moveCount % 2 == 0)
            {
                pictureBox1.Image = x;
            }
            else
            {
                pictureBox1.Image = o;
            }
        }

        private void ButtonAction(object sender, EventArgs e, Button button)
        {
            if (boardWin[currentBoard] == 0)
            {
                if (gameBoard[lastPlayedMove] == 0)
                {
                    if (moveCount % 2 == 0)
                    {
                        button.Image = x;
                        gameBoard[lastPlayedMove] = 1;
                        GameStatus(currentBoard);
                        moveCount++;
                    }
                    else
                    {
                        button.Image = o;
                        gameBoard[lastPlayedMove] = 2;
                        GameStatus(currentBoard);
                        moveCount++;
                    }
                }
            }
        }

        private bool ValidateMove(int currentMove)
        {
            boardOffset = lastPlayedMove % 9;
            if (lastPlayedMove == -1)
            {
                return true;
            }
            else if (boardOffset == 0)
            {
                if (currentMove >= board1Start && currentMove < board2Start && boardWin[boardOffset] == 0)
                {
                    return true;
                }
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardOffset] > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (boardOffset == 1)
            {
                if (currentMove >= board2Start && currentMove < board3Start && boardWin[boardOffset] == 0)
                {
                    return true;
                }
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardOffset] > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (boardOffset == 2)
            {
                if (currentMove >= board3Start && currentMove < board4Start && boardWin[boardOffset] == 0)
                {
                    return true;
                }
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardOffset] > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (boardOffset == 3)
            {
                if (currentMove >= board4Start && currentMove < board5Start && boardWin[boardOffset] == 0)
                {
                    return true;
                }
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardOffset] > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (boardOffset == 4)
            {
                if (currentMove >= board5Start && currentMove < board6Start && boardWin[boardOffset] == 0)
                {
                    return true;
                }
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardOffset] > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (boardOffset == 5)
            {
                if (currentMove >= board6Start && currentMove < board7Start && boardWin[boardOffset] == 0)
                {
                    return true;
                }
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardOffset] > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (boardOffset == 6)
            {
                if (currentMove >= board7Start && currentMove < board8Start && boardWin[boardOffset] == 0)
                {
                    return true;
                }
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardOffset] > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (boardOffset == 7)
            {
                if (currentMove >= board8Start && currentMove < board9Start && boardWin[boardOffset] == 0)
                {
                    return true;
                }
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardOffset] > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (boardOffset == 8)
            {
                if (currentMove >= board9Start && currentMove < board9End && boardWin[boardOffset] == 0)
                {
                    return true;
                }
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardOffset] > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        /*private void toYellow(object sender, EventArgs e, Button button)
        {
            if (nextBoard == 0 && boardWin[nextBoard] == 0)
            {

            }
            if (nextBoard == 1 && boardWin[nextBoard] == 0)
            {

            }
            if (nextBoard == 2 && boardWin[nextBoard] == 0)
            {

            }
            if (nextBoard == 3 && boardWin[nextBoard] == 0)
            {

            }
            if (nextBoard == 4 && boardWin[nextBoard] == 0)
            {

            }
            if (nextBoard == 5 && boardWin[nextBoard] == 0)
            {

            }
            if (nextBoard == 6 && boardWin[nextBoard] == 0)
            {

            }
            if (nextBoard == 7 && boardWin[nextBoard] == 0)
            {

            }
            if (nextBoard == 8 && boardWin[nextBoard] == 0)
            {

            }
        }*/

        /*private void toWhite(object sender, EventArgs e, Button button)
        {
            if (previousBoard == 0)
            {

            }
            if (previousBoard == 1)
            {

            }
            if (previousBoard == 2)
            {

            }
            if (previousBoard == 3)
            {

            }
            if (previousBoard == 4)
            {

            }
            if (previousBoard == 5)
            {

            }
            if (previousBoard == 6)
            {

            }
            if (previousBoard == 7)
            {

            }
            if (previousBoard == 8)
            {

            }
        }*/

        /*private void activeBoard(int board)
        {
            if (previousBoard != -1 && nextBoard != currentBoard)
            {
                toWhite();
            }
            toYellow();
        }*/
        
        private void button_Click(object sender, EventArgs e, Button button, int setCurrentMove, int setCurrentBoard)
        {
            currentMove = setCurrentMove;
            moveStatus = ValidateMove(currentMove);
            if (moveStatus)
            {
                lastPlayedMove = currentMove;
                currentBoard = setCurrentBoard;
                ButtonAction(sender, e, button);
                previousBoard = currentBoard;
            }
        }

        private void button1_Click(object sender, EventArgs e) => button_Click(sender, e, button1, 0, 0);

        private void button2_Click(object sender, EventArgs e) => button_Click(sender, e, button2, 2 - 1, 0);

        private void button3_Click(object sender, EventArgs e) => button_Click(sender, e, button3, 3 - 1, 0);

        private void button4_Click(object sender, EventArgs e) => button_Click(sender, e, button4, 4 - 1, 0);

        private void button5_Click(object sender, EventArgs e) => button_Click(sender, e, button5, 5 - 1, 0);

        private void button6_Click(object sender, EventArgs e) => button_Click(sender, e, button6, 6 - 1, 0);

        private void button7_Click(object sender, EventArgs e) => button_Click(sender, e, button7, 7 - 1, 0);

        private void button8_Click(object sender, EventArgs e) => button_Click(sender, e, button8, 8 - 1, 0);

        private void button9_Click(object sender, EventArgs e) => button_Click(sender, e, button9, 9 - 1, 0);

        private void button10_Click(object sender, EventArgs e) => button_Click(sender, e, button10, 10 - 1, 1);

        private void button11_Click(object sender, EventArgs e) => button_Click(sender, e, button11, 11 - 1, 1);

        private void button12_Click(object sender, EventArgs e) => button_Click(sender, e, button12, 12 - 1, 1);

        private void button13_Click(object sender, EventArgs e) => button_Click(sender, e, button13, 13 - 1, 1);

        private void button14_Click(object sender, EventArgs e) => button_Click(sender, e, button14, 14 - 1, 1);

        private void button15_Click(object sender, EventArgs e) => button_Click(sender, e, button15, 15 - 1, 1);

        private void button16_Click(object sender, EventArgs e) => button_Click(sender, e, button16, 16 - 1, 1);

        private void button17_Click(object sender, EventArgs e) => button_Click(sender, e, button17, 17 - 1, 1);

        private void button18_Click(object sender, EventArgs e) => button_Click(sender, e, button18, 18 - 1, 1);

        private void button19_Click(object sender, EventArgs e) => button_Click(sender, e, button19, 19 - 1, 2);

        private void button20_Click(object sender, EventArgs e) => button_Click(sender, e, button20, 20 - 1, 2);

        private void button21_Click(object sender, EventArgs e) => button_Click(sender, e, button21, 21 - 1, 2);

        private void button22_Click(object sender, EventArgs e) => button_Click(sender, e, button22, 22 - 1, 2);

        private void button23_Click(object sender, EventArgs e) => button_Click(sender, e, button23, 23 - 1, 2);

        private void button24_Click(object sender, EventArgs e) => button_Click(sender, e, button24, 24 - 1, 2);

        private void button25_Click(object sender, EventArgs e) => button_Click(sender, e, button25, 25 - 1, 2);

        private void button26_Click(object sender, EventArgs e) => button_Click(sender, e, button26, 26 - 1, 2);

        private void button27_Click(object sender, EventArgs e) => button_Click(sender, e, button27, 27 - 1, 2);

        private void button28_Click(object sender, EventArgs e) => button_Click(sender, e, button28, 28 - 1, 3);

        private void button29_Click(object sender, EventArgs e) => button_Click(sender, e, button29, 29 - 1, 3);

        private void button30_Click(object sender, EventArgs e) => button_Click(sender, e, button30, 30 - 1, 3);

        private void button31_Click(object sender, EventArgs e) => button_Click(sender, e, button31, 31 - 1, 3);

        private void button32_Click(object sender, EventArgs e) => button_Click(sender, e, button32, 32 - 1, 3);

        private void button33_Click(object sender, EventArgs e) => button_Click(sender, e, button33, 33 - 1, 3);

        private void button34_Click(object sender, EventArgs e) => button_Click(sender, e, button34, 34 - 1, 3);

        private void button35_Click(object sender, EventArgs e) => button_Click(sender, e, button35, 35 - 1, 3);

        private void button36_Click(object sender, EventArgs e) => button_Click(sender, e, button36, 36 - 1, 3);

        private void button37_Click(object sender, EventArgs e) => button_Click(sender, e, button37, 37 - 1, 4);

        private void button38_Click(object sender, EventArgs e) => button_Click(sender, e, button38, 38 - 1, 4);

        private void button39_Click(object sender, EventArgs e) => button_Click(sender, e, button39, 39 - 1, 4);

        private void button40_Click(object sender, EventArgs e) => button_Click(sender, e, button40, 40 - 1, 4);

        private void button41_Click(object sender, EventArgs e) => button_Click(sender, e, button41, 41 - 1, 4);

        private void button42_Click(object sender, EventArgs e) => button_Click(sender, e, button42, 42 - 1, 4);

        private void button43_Click(object sender, EventArgs e) => button_Click(sender, e, button43, 43 - 1, 4);

        private void button44_Click(object sender, EventArgs e) => button_Click(sender, e, button44, 44 - 1, 4);

        private void button45_Click(object sender, EventArgs e) => button_Click(sender, e, button45, 45 - 1, 4);

        private void button46_Click(object sender, EventArgs e) => button_Click(sender, e, button46, 46 - 1, 5);

        private void button47_Click(object sender, EventArgs e) => button_Click(sender, e, button47, 47 - 1, 5);

        private void button48_Click(object sender, EventArgs e) => button_Click(sender, e, button48, 48 - 1, 5);

        private void button49_Click(object sender, EventArgs e) => button_Click(sender, e, button49, 49 - 1, 5);

        private void button50_Click(object sender, EventArgs e) => button_Click(sender, e, button50, 50 - 1, 5);

        private void button51_Click(object sender, EventArgs e) => button_Click(sender, e, button51, 51 - 1, 5);

        private void button52_Click(object sender, EventArgs e) => button_Click(sender, e, button52, 52 - 1, 5);

        private void button53_Click(object sender, EventArgs e) => button_Click(sender, e, button53, 53 - 1, 5);

        private void button54_Click(object sender, EventArgs e) => button_Click(sender, e, button54, 54 - 1, 5);

        private void button55_Click(object sender, EventArgs e) => button_Click(sender, e, button55, 55 - 1, 6);

        private void button56_Click(object sender, EventArgs e) => button_Click(sender, e, button56, 56 - 1, 6);

        private void button57_Click(object sender, EventArgs e) => button_Click(sender, e, button57, 57 - 1, 6);

        private void button58_Click(object sender, EventArgs e) => button_Click(sender, e, button58, 58 - 1, 6);

        private void button59_Click(object sender, EventArgs e) => button_Click(sender, e, button59, 59 - 1, 6);

        private void button60_Click(object sender, EventArgs e) => button_Click(sender, e, button60, 60 - 1, 6);

        private void button61_Click(object sender, EventArgs e) => button_Click(sender, e, button61, 61 - 1, 6);

        private void button62_Click(object sender, EventArgs e) => button_Click(sender, e, button62, 62 - 1, 6);

        private void button63_Click(object sender, EventArgs e) => button_Click(sender, e, button63, 63 - 1, 6);

        private void button64_Click(object sender, EventArgs e) => button_Click(sender, e, button64, 64 - 1, 7);

        private void button65_Click(object sender, EventArgs e) => button_Click(sender, e, button65, 65 - 1, 7);

        private void button66_Click(object sender, EventArgs e) => button_Click(sender, e, button66, 66 - 1, 7);

        private void button67_Click(object sender, EventArgs e) => button_Click(sender, e, button67, 67 - 1, 7);

        private void button68_Click(object sender, EventArgs e) => button_Click(sender, e, button68, 68 - 1, 7);

        private void button69_Click(object sender, EventArgs e) => button_Click(sender, e, button69, 69 - 1, 7);

        private void button70_Click(object sender, EventArgs e) => button_Click(sender, e, button70, 70 - 1, 7);

        private void button71_Click(object sender, EventArgs e) => button_Click(sender, e, button71, 71 - 1, 7);

        private void button72_Click(object sender, EventArgs e) => button_Click(sender, e, button72, 72 - 1, 7);

        private void button73_Click(object sender, EventArgs e) => button_Click(sender, e, button73, 73 - 1, 8);

        private void button74_Click(object sender, EventArgs e) => button_Click(sender, e, button74, 74 - 1, 8);

        private void button75_Click(object sender, EventArgs e) => button_Click(sender, e, button75, 75 - 1, 8);

        private void button76_Click(object sender, EventArgs e) => button_Click(sender, e, button76, 76 - 1, 8);

        private void button77_Click(object sender, EventArgs e) => button_Click(sender, e, button77, 77 - 1, 8);

        private void button78_Click(object sender, EventArgs e) => button_Click(sender, e, button78, 78 - 1, 8);

        private void button79_Click(object sender, EventArgs e) => button_Click(sender, e, button79, 79 - 1, 8);

        private void button80_Click(object sender, EventArgs e) => button_Click(sender, e, button80, 80 - 1, 8);

        private void button81_Click(object sender, EventArgs e) => button_Click(sender, e, button81, 81 - 1, 8);

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //nothing
        }
    }
}
