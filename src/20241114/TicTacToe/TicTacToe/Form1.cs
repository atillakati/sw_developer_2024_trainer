using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private Button[] _buttonList;
        private bool _playerOneIsActive;

        public Form1()
        {
            InitializeComponent();

            _buttonList = new Button[]
            {
                button1, button2, button3,
                button4, button5, button6,
                button7, button8, button9
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //clear all button content
            ClearButtonContent();

            //disable all buttons
            EnableButtons(false);

            //update output label
            lbl_output.Text = "Starten Sie ein Spiel!";
        }

        private void EnableButtons(bool isEnabled)
        {
            foreach (var btt in _buttonList)
            {
                btt.Enabled = isEnabled;
            }
        }

        private void ClearButtonContent()
        {
            foreach (var btt in _buttonList)
            {
                btt.Text = string.Empty;
            }
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbl_output.Text = "Spieler 1 ist am Zug!";
            EnableButtons(true);

            _playerOneIsActive = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                if(clickedButton.Text != string.Empty)
                {
                    return;
                }

                if (_playerOneIsActive)
                {
                    clickedButton.Text = "X";
                }
                else
                {
                    clickedButton.Text = "O";
                }

                //check win condition
                if (CheckWinConditions())
                {
                    EnableButtons(false);
                    UpdateGlobalPlayerInfo(true);
                    return;
                }

                //switch the current player
                _playerOneIsActive = !_playerOneIsActive;

                //update global info label
                UpdateGlobalPlayerInfo(false);
            }
        }

        private bool CheckWinConditions()
        {
            var winString = string.Empty;

            //"XXX" oder "OOO"
            //horizontal
            for (int i = 0; i < _buttonList.Length; i+=3)
            {
                winString = CreateString(_buttonList.ToList().GetRange(i, 3));
                if(winString == "XXX" || winString == "OOO")
                {
                    return true;
                }
            }

            //vertical
            winString = CreateString(new[] { _buttonList[0], _buttonList[3], _buttonList[6] });
            if (winString == "XXX" || winString == "OOO")
            {
                return true;
            }

            winString = CreateString(new[] { _buttonList[1], _buttonList[4], _buttonList[7] });
            if (winString == "XXX" || winString == "OOO")
            {
                return true;
            }

            winString = CreateString(new[] { _buttonList[2], _buttonList[5], _buttonList[8] });
            if (winString == "XXX" || winString == "OOO")
            {
                return true;
            }

            //diagonal
            winString = CreateString(new[] { _buttonList[0], _buttonList[4], _buttonList[8] });
            if (winString == "XXX" || winString == "OOO")
            {
                return true;
            }

            winString = CreateString(new[] { _buttonList[2], _buttonList[4], _buttonList[6] });
            if (winString == "XXX" || winString == "OOO")
            {
                return true;
            }

            return false;
        }

        private string CreateString(IEnumerable<Button> buttons)
        {
            string text = string.Empty;

            buttons.ToList().ForEach(x => text += x.Text);

            return text;
        }

        private void UpdateGlobalPlayerInfo(bool winConditionReached)
        {
            string msg = "ist am Zug!";

            if(winConditionReached)
            {
                msg = "hat GEWONNEN!";
            }

            if (_playerOneIsActive)
            {
                lbl_output.Text = "Spieler 1 " + msg;
            }
            else
            {
                lbl_output.Text = "Spieler 2 " + msg;
            }
        }
    }
}
