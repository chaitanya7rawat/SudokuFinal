using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuPuzzleGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            int difficulty = cmbDifficulty.SelectedIndex + 1; // 0=Easy → 1
            Form1 gameForm = new Form1(difficulty); // You must modify Form1 to accept this if not already
            gameForm.Show();
            this.Hide();
        }
    }
}