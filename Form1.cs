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
        int move = 0;
        const int board1Start = 0, board2Start = 9, board3Start = 18, board4Start = 27, board5Start = 36, board6Start = 45, board7Start = 54, board8Start = 63, board9Start = 72, board9End = 80;
        Bitmap o = new Bitmap(@"C:\Users\trent\This PC\Documents\Visual Studio 2019\projects\T2\o.PNG");
        Bitmap x = new Bitmap(@"C:\Users\trent\This PC\Documents\Visual Studio 2019\projects\T2\x.PNG");
        int[] gameBoard = new int[81];
        int[] boardWin = new int[9];
        int lastPlayedMove = -1;
        int currentMove;
        int currentBoard = 0;
        int previousBoard = -1;
        int boardModifier;
        bool moveStatus = false;


        public Form1()
        {
            InitializeComponent();
            pictureBox2.Image = x;
        }

        private bool checkBoardWin()
        {

            boardModifier = currentBoard * 9;
            if (boardWin[currentBoard] == 0) { 
                if ((gameBoard[0 + boardModifier] == gameBoard[1 + boardModifier] && gameBoard[0+ boardModifier] != 0) && (gameBoard[1 + boardModifier] == gameBoard[2 + boardModifier] && gameBoard[1 + boardModifier] != 0))       //top horizontal win
                {
                    if (move % 2 == 0)
                        boardWin[currentBoard] = 1;
                    else boardWin[currentBoard] = 2;
                    return true;
                }
                else if ((gameBoard[3 + boardModifier] == gameBoard[4 + boardModifier] && gameBoard[3 + boardModifier] != 0) && (gameBoard[4 + boardModifier] == gameBoard[5 + boardModifier] && gameBoard[4 + boardModifier] != 0))  //middle horizontal win
                {
                    if (move % 2 == 0)
                        boardWin[currentBoard] = 1;
                    else boardWin[currentBoard] = 2;
                    return true;
                }
                else if ((gameBoard[6 + boardModifier] == gameBoard[7 + boardModifier] && gameBoard[6 + boardModifier] != 0) && (gameBoard[7 + boardModifier] == gameBoard[8 + boardModifier] && gameBoard[7 + boardModifier] != 0))  //bottom horizontal win
                {
                    if (move % 2 == 0)
                        boardWin[currentBoard] = 1;
                    else boardWin[currentBoard] = 2;
                    return true;
                }
                else if ((gameBoard[0 + boardModifier] == gameBoard[3 + boardModifier] && gameBoard[0 + boardModifier] != 0) && (gameBoard[3 + boardModifier] == gameBoard[6 + boardModifier] && gameBoard[3 + boardModifier] != 0))  //left vertical win
                {
                    if (move % 2 == 0)
                        boardWin[currentBoard] = 1;
                    else boardWin[currentBoard] = 2;
                    return true;
                }
                else if ((gameBoard[1 + boardModifier] == gameBoard[4 + boardModifier] && gameBoard[1 + boardModifier] != 0) && (gameBoard[4 + boardModifier] == gameBoard[7 + boardModifier] && gameBoard[4 + boardModifier] != 0))  //middle vertical win
                {
                    if (move % 2 == 0)
                        boardWin[currentBoard] = 1;
                    else boardWin[currentBoard] = 2;
                    return true;
                }
                else if ((gameBoard[2 + boardModifier] == gameBoard[5 + boardModifier] && gameBoard[2 + boardModifier] != 0) && (gameBoard[5 + boardModifier] == gameBoard[8 + boardModifier] && gameBoard[5 + boardModifier] != 0))  //right vertical win
                {
                    if (move % 2 == 0)
                        boardWin[currentBoard] = 1;
                    else boardWin[currentBoard] = 2;
                    return true;
                }
                else if ((gameBoard[0 + boardModifier] == gameBoard[4 + boardModifier] && gameBoard[0 + boardModifier] != 0) && (gameBoard[4 + boardModifier] == gameBoard[8 + boardModifier] && gameBoard[4 + boardModifier] != 0))  //top->bottom diagonal win
                {
                    if (move % 2 == 0)
                        boardWin[currentBoard] = 1;
                    else boardWin[currentBoard] = 2;
                    return true;
                }
                else if ((gameBoard[2 + boardModifier] == gameBoard[4 + boardModifier] && gameBoard[2 + boardModifier] != 0) && (gameBoard[4 + boardModifier] == gameBoard[6 + boardModifier] && gameBoard[4 + boardModifier] != 0)) //bottom->top diagonal win
                {
                    if (move % 2 == 0)
                        boardWin[currentBoard] = 1;
                    else boardWin[currentBoard] = 2;
                    return true;
                }
                else return false;
            }
            return false;
        }

        private void gameStatus(int currentBoard)
        {
            bool status = false;
            if (boardWin[currentBoard] == 0)
                status = checkBoardWin();
            if (status == true)
                status = CheckGameWin();
            if(status == true)
            {
                declareWinner();
            }
            if (move % 2 == 0)
            {
                pictureBox2.Image = o;
            }
            else pictureBox2.Image = x;
        }

        private bool CheckGameWin()
        {
            if (boardWin[0] == boardWin[1] && boardWin[1] == boardWin[2] && boardWin[0] != 0)       //top horizontal win
                return true;
            else if (boardWin[3] == boardWin[4] && boardWin[4] == boardWin[5] && boardWin[3] != 0)  //middle horizontal win
                return true;
            else if (boardWin[6] == boardWin[7] && boardWin[7] == boardWin[8] && boardWin[6] != 0)  //bottom horizontal win
                return true;
            else if (boardWin[0] == boardWin[3] && boardWin[3] == boardWin[6] && boardWin[0] != 0)  //left vertical win
                return true;
            else if (boardWin[1] == boardWin[4] && boardWin[4] == boardWin[7] && boardWin[1] != 0)  //middle vertical win
                return true;
            else if (boardWin[2] == boardWin[5] && boardWin[5] == boardWin[8] && boardWin[2] != 0)  //right vertical win
                return true;
            else if (boardWin[0] == boardWin[4] && boardWin[4] == boardWin[8] && boardWin[0] != 0)  //top->bottom diagonal win
                return true;
            else if (boardWin[2] == boardWin[4] && boardWin[4] == boardWin[6] && boardWin[2] != 0)  //bottom->top diagonal win
                return true;
            else return false;
        }

        private void declareWinner()
        {
            pictureBox1.BringToFront();
            if (move % 2 == 0)
            {
                pictureBox1.Image = x;
            }
            else pictureBox1.Image = o;
        }

        private void buttonAction(object sender, EventArgs e, Button button)
        {
            if (boardWin[currentBoard] == 0)
            {
                if (gameBoard[lastPlayedMove] == 0)
                {
                    if (move % 2 == 0)
                    {
                        button.Image = x;
                        gameBoard[lastPlayedMove] = 1;
                        gameStatus(currentBoard);
                        move++;
                    }
                    else
                    {
                        button.Image = o;
                        gameBoard[lastPlayedMove] = 2;
                        gameStatus(currentBoard);
                        move++;
                    }
                }
            }
        }

        private bool validateMove(int currentMove)
        {
            boardModifier = lastPlayedMove % 9;
            if (lastPlayedMove == -1)
                return true;
            else if (boardModifier == 0)
            {
                if (currentMove >= board1Start && currentMove < board2Start && boardWin[boardModifier] == 0)
                    return true;
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardModifier] > 0)
                    return true;
                else return false;
            }
            else if (boardModifier == 1)
            {
                if (currentMove >= board2Start && currentMove < board3Start && boardWin[boardModifier] == 0)
                    return true;
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardModifier] > 0)
                    return true;
                else return false;
            }
            else if (boardModifier == 2)
            {
                if (currentMove >= board3Start && currentMove < board4Start && boardWin[boardModifier] == 0)
                    return true;
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardModifier] > 0)
                    return true;
                else return false;
            }
            else if (boardModifier == 3)
            {
                if (currentMove >= board4Start && currentMove < board5Start && boardWin[boardModifier] == 0)
                    return true;
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardModifier] > 0)
                    return true;
                else return false;
            }
            else if (boardModifier == 4)
            {
                if (currentMove >= board5Start && currentMove < board6Start && boardWin[boardModifier] == 0)
                    return true;
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardModifier] > 0)
                    return true;
                else return false;
            }
            else if (boardModifier == 5)
            {
                if (currentMove >= board6Start && currentMove < board7Start && boardWin[boardModifier] == 0)
                    return true;
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardModifier] > 0)
                    return true;
                else return false;
            }
            else if (boardModifier == 6)
            {
                if (currentMove >= board7Start && currentMove < board8Start && boardWin[boardModifier] == 0)
                    return true;
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardModifier] > 0)
                    return true;
                else return false;
            }
            else if (boardModifier == 7)
            {
                if (currentMove >= board8Start && currentMove < board9Start && boardWin[boardModifier] == 0)
                    return true;
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardModifier] > 0)
                    return true;
                else return false;
            }
            else if (boardModifier == 8)
            {
                if (currentMove >= board9Start && currentMove < board9End && boardWin[boardModifier] == 0)
                    return true;
                else if (lastPlayedMove / 9 == currentMove / 9 && boardWin[boardModifier] > 0)
                    return true;
                else return false;
            }
            else return false;
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


        private void button1_Click(object sender, EventArgs e)
        {
            currentMove = 0;
            moveStatus = validateMove(lastPlayedMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 0;
                buttonAction(sender, e, button1);
                previousBoard = currentBoard;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentMove = 1;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 0;
                buttonAction(sender, e, button2);
                previousBoard = currentBoard;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentMove = 2;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 0;
                buttonAction(sender, e, button3);
                previousBoard = currentBoard;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentMove = 3;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            { 
                lastPlayedMove = currentMove;
                currentBoard = 0;
                buttonAction(sender, e, button4);
                previousBoard = currentBoard;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentMove = 4;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 0;
                buttonAction(sender, e, button5);
                previousBoard = currentBoard;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentMove = 5;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 0;
                buttonAction(sender, e, button6);
                previousBoard = currentBoard;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentMove = 6;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 0;
                buttonAction(sender, e, button7);
                previousBoard = currentBoard;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentMove = 7;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 0;
                buttonAction(sender, e, button8);
                previousBoard = currentBoard;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentMove = 8;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 0;
                buttonAction(sender, e, button9);
                previousBoard = currentBoard;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            currentMove = 9;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 1;
                buttonAction(sender, e, button10);
                previousBoard = currentBoard;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            currentMove = 10;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 1;
                buttonAction(sender, e, button11);
                previousBoard = currentBoard;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            currentMove = 11;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 1;
                buttonAction(sender, e, button12);
                previousBoard = currentBoard;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            currentMove = 12;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 1;
                buttonAction(sender, e, button13);
                previousBoard = currentBoard;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            currentMove = 13;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 1;
                buttonAction(sender, e, button14);
                previousBoard = currentBoard;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            currentMove = 14;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 1;
                buttonAction(sender, e, button15);
                previousBoard = currentBoard;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            currentMove = 15;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 1;
                buttonAction(sender, e, button16);
                previousBoard = currentBoard;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            currentMove = 16;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 1;
                buttonAction(sender, e, button17);
                previousBoard = currentBoard;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            currentMove = 17;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 1;
                buttonAction(sender, e, button18);
                previousBoard = currentBoard;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            currentMove = 18;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 2;
                buttonAction(sender, e, button19);
                previousBoard = currentBoard;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            currentMove = 19;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 2;
                buttonAction(sender, e, button20);
                previousBoard = currentBoard;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            currentMove = 20;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 2;
                buttonAction(sender, e, button21);
                previousBoard = currentBoard;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            currentMove = 21;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 2;
                buttonAction(sender, e, button22);
                previousBoard = currentBoard;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            currentMove = 22;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 2;
                buttonAction(sender, e, button23);
                previousBoard = currentBoard;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            currentMove = 23;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 2;
                buttonAction(sender, e, button24);
                previousBoard = currentBoard;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            currentMove = 24;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 2;
                buttonAction(sender, e, button25);
                previousBoard = currentBoard;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            currentMove = 25;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 2;
                buttonAction(sender, e, button26);
                previousBoard = currentBoard;
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            currentMove = 26;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 2;
                buttonAction(sender, e, button27);
                previousBoard = currentBoard;
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            currentMove = 27;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 3;
                buttonAction(sender, e, button28);
                previousBoard = currentBoard;
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            currentMove = 28;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 3;
                buttonAction(sender, e, button29);
                previousBoard = currentBoard;
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            currentMove = 29;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 3;
                buttonAction(sender, e, button30);
                previousBoard = currentBoard;
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            currentMove = 30;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 3;
                buttonAction(sender, e, button31);
                previousBoard = currentBoard;
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            currentMove = 31;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 3;
                buttonAction(sender, e, button32);
                previousBoard = currentBoard;
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            currentMove = 32;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 3;
                buttonAction(sender, e, button33);
                previousBoard = currentBoard;
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            currentMove = 33;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 3;
                buttonAction(sender, e, button34);
                previousBoard = currentBoard;
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            currentMove = 34;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 3;
                buttonAction(sender, e, button35);
                previousBoard = currentBoard;
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            currentMove = 35;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 3;
                buttonAction(sender, e, button36);
                previousBoard = currentBoard;
            }

        }

        private void button37_Click(object sender, EventArgs e)
        {
            currentMove = 36;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 4;
                buttonAction(sender, e, button37);
                previousBoard = currentBoard;
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            currentMove = 37;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 4;
                buttonAction(sender, e, button38);
                previousBoard = currentBoard;
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            currentMove = 38;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 4;
                buttonAction(sender, e, button39);
                previousBoard = currentBoard;
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            currentMove = 39;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 4;
                buttonAction(sender, e, button40);
                previousBoard = currentBoard;
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            currentMove = 40;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 4;
                buttonAction(sender, e, button41);
                previousBoard = currentBoard;
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            currentMove = 41;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 4;
                buttonAction(sender, e, button42);
                previousBoard = currentBoard;
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            currentMove = 42;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 4;
                buttonAction(sender, e, button43);
                previousBoard = currentBoard;
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            currentMove = 43;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 4;
                buttonAction(sender, e, button44);
                previousBoard = currentBoard;
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            currentMove = 44;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 4;
                buttonAction(sender, e, button45);
                previousBoard = currentBoard;
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            currentMove = 45;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 5;
                buttonAction(sender, e, button46);
                previousBoard = currentBoard;
            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            currentMove = 46;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 5;
                buttonAction(sender, e, button47);
                previousBoard = currentBoard;
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            currentMove = 47;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 5;
                buttonAction(sender, e, button48);
                previousBoard = currentBoard;
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            currentMove = 48;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 5;
                buttonAction(sender, e, button49);
                previousBoard = currentBoard;
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            currentMove = 49;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 5;
                buttonAction(sender, e, button50);
                previousBoard = currentBoard;
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            currentMove = 50;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 5;
                buttonAction(sender, e, button51);
                previousBoard = currentBoard;
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            currentMove = 51;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 5;
                buttonAction(sender, e, button52);
                previousBoard = currentBoard;
            }
        }

        private void button53_Click(object sender, EventArgs e)
        {
            currentMove = 52;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 5;
                buttonAction(sender, e, button53);
                previousBoard = currentBoard;
            }
        }

        private void button54_Click(object sender, EventArgs e)
        {
            currentMove = 53;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 5;
                buttonAction(sender, e, button54);
                previousBoard = currentBoard;
            }
        }

        private void button55_Click(object sender, EventArgs e)
        {
            currentMove = 54;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 6;
                buttonAction(sender, e, button55);
                previousBoard = currentBoard;
            }
        }

        private void button56_Click(object sender, EventArgs e)
        {
            currentMove = 55;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 6;
                buttonAction(sender, e, button56);
                previousBoard = currentBoard;
            }
        }

        private void button57_Click(object sender, EventArgs e)
        {
            currentMove = 56;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 6;
                buttonAction(sender, e, button57);
                previousBoard = currentBoard;
            }
        }

        private void button58_Click(object sender, EventArgs e)
        {
            currentMove = 57;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 6;
                buttonAction(sender, e, button58);
                previousBoard = currentBoard;
            }
        }

        private void button59_Click(object sender, EventArgs e)
        {
            currentMove = 58;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 6;
                buttonAction(sender, e, button59);
                previousBoard = currentBoard;
            }
        }

        private void button60_Click(object sender, EventArgs e)
        {
            currentMove = 59;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 6;
                buttonAction(sender, e, button60);
                previousBoard = currentBoard;
            }
        }

        private void button61_Click(object sender, EventArgs e)
        {
            currentMove = 60;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 6;
                buttonAction(sender, e, button61);
                previousBoard = currentBoard;
            }
        }

        private void button62_Click(object sender, EventArgs e)
        {
            currentMove = 61;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 6;
                buttonAction(sender, e, button62);
                previousBoard = currentBoard;
            }
        }

        private void button63_Click(object sender, EventArgs e)
        {
            currentMove = 62;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 6;
                buttonAction(sender, e, button63);
                previousBoard = currentBoard;
            }
        }

        private void button64_Click(object sender, EventArgs e)
        {
            currentMove = 63;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 7;
                buttonAction(sender, e, button64);
                previousBoard = currentBoard;
            }
        }

        private void button65_Click(object sender, EventArgs e)
        {
            currentMove = 64;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 7;
                buttonAction(sender, e, button65);
                previousBoard = currentBoard;
            }
        }

        private void button66_Click(object sender, EventArgs e)
        {
            currentMove = 65;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 7;
                buttonAction(sender, e, button66);
                previousBoard = currentBoard;
            }
        }

        private void button67_Click(object sender, EventArgs e)
        {
            currentMove = 66;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 7;
                buttonAction(sender, e, button67);
                previousBoard = currentBoard;
            }
        }

        private void button68_Click(object sender, EventArgs e)
        {
            currentMove = 67;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 7;
                buttonAction(sender, e, button68);
                previousBoard = currentBoard;
            }
        }

        private void button69_Click(object sender, EventArgs e)
        {
            currentMove = 68;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 7;
                buttonAction(sender, e, button69);
                previousBoard = currentBoard;
            }
        }

        private void button70_Click(object sender, EventArgs e)
        {
            currentMove = 69;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 7;
                buttonAction(sender, e, button70);
                previousBoard = currentBoard;
            }
        }

        private void button71_Click(object sender, EventArgs e)
        {
            currentMove = 70;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 7;
                buttonAction(sender, e, button71);
                previousBoard = currentBoard;
            }
        }

        private void button72_Click(object sender, EventArgs e)
        {
            currentMove = 71;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 7;
                buttonAction(sender, e, button72);
                previousBoard = currentBoard;
            }
        }

        private void button73_Click(object sender, EventArgs e)
        {
            currentMove = 72;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 8;
                buttonAction(sender, e, button73);
                previousBoard = currentBoard;
            }
        }

        private void button74_Click(object sender, EventArgs e)
        {
            currentMove = 73;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 8;
                buttonAction(sender, e, button74);
                previousBoard = currentBoard;
            }
        }

        private void button75_Click(object sender, EventArgs e)
        {
            currentMove = 74;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 8;
                buttonAction(sender, e, button75);
                previousBoard = currentBoard;
            }
        }

        private void button76_Click(object sender, EventArgs e)
        {
            currentMove = 75;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 8;
                buttonAction(sender, e, button76);
                previousBoard = currentBoard;
            }
        }

        private void button77_Click(object sender, EventArgs e)
        {
            currentMove = 76;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 8;
                buttonAction(sender, e, button77);
                previousBoard = currentBoard;
            }

        }

        private void button78_Click(object sender, EventArgs e)
        {
            currentMove = 77;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 8;
                buttonAction(sender, e, button78);
                previousBoard = currentBoard;
            }
        }

        private void button79_Click(object sender, EventArgs e)
        {
            currentMove = 78;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 8;
                buttonAction(sender, e, button79);
                previousBoard = currentBoard;
            }
        }

        private void button80_Click(object sender, EventArgs e)
        {
            currentMove = 79;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 8;
                buttonAction(sender, e, button80);
                previousBoard = currentBoard;
            }
        }

        private void button81_Click(object sender, EventArgs e)
        {
            currentMove = 80;
            moveStatus = validateMove(currentMove);
            if (moveStatus == true)
            {
                lastPlayedMove = currentMove;
                currentBoard = 8;
                buttonAction(sender, e, button81);
                previousBoard = currentBoard;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //nothing
        }
    }
}
