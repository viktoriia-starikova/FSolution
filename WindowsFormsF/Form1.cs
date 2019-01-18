using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsF
{
    public partial class Form1 : Form
    {
        Game game;
        const int size = 4;
        public Form1()
        {
            InitializeComponent();
            game = new Game(size);
            HideButtons();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //game.Start(10);
            game.Start(1000 + DateTime.Now.DayOfYear);
            ShowButtons();
            //game.Start(1000 + DateTime.Now.DayOfYear);
        }
        void HideButtons()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    ShowDigitAt(0, x, y);
            label1.Text = "Welcome to Game F";

        }
        void ShowButtons()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    ShowDigitAt(game.GetDigitAt(x,y), x, y);
            label1.Text = game.moves + " moves";
        }
        void ShowDigitAt(int digit, int x, int y)
        {
            Button button = (Button)Controls["b" + x + y];
            button.Text = DecToHex(digit);
            button.Visible = digit > 0;
        }

        private void b00_Click(object sender, EventArgs e)
        {
            if (game.Solved()) return;
            Button button = (Button)sender;
            int x = int.Parse(button.Name.Substring(1, 1));
            int y = int.Parse(button.Name.Substring(2, 1));
            game.PressAt(x, y);
            ShowButtons();
            if (game.Solved())
                label1.Text="Game finished in "+ game.moves +" moves";
        }
        string DecToHex(int digit)
        {
            if (digit == 0) return "";
            if (digit < 10) return digit.ToString();
            return ((char)('A' + digit - 10)).ToString();
        }
    }
}
