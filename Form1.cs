using System;
using System.Drawing;
using System.Windows.Forms;

namespace SudokuPuzzleGame
{
    public partial class Form1 : Form
    {
        private int[,] initialPuzzle;
        private int difficultyLevel;

        public Form1(int difficulty)
        {
            InitializeComponent();
            this.difficultyLevel = difficulty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create grid
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    TextBox tb = new TextBox
                    {
                        Dock = DockStyle.Fill,
                        Font = new Font("Segoe UI", 16, FontStyle.Bold),
                        TextAlign = HorizontalAlignment.Center,
                        MaxLength = 1,
                        Tag = new Point(row, col)
                    };

                    tb.KeyPress += TextBox_KeyPress;
                    tableLayoutPanel1.Controls.Add(tb, col, row);
                }
            }

            LoadPuzzle();
        }

        private void LoadPuzzle()
        {
            int[,] board = new int[9, 9];
            GenerateFullBoard(board);

            int cellsToRemove = difficultyLevel switch
            {
                1 => 30, // Easy
                2 => 45, // Medium
                3 => 55, // Hard
                _ => 40
            };

            RemoveCells(board, cellsToRemove);
            initialPuzzle = board;

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    SetCell(i, j, initialPuzzle[i, j]);
        }

        private void GenerateFullBoard(int[,] board)
        {
            SolveSudoku(board); // Uses your existing backtracking solver
        }

        private void RemoveCells(int[,] board, int count)
        {
            Random rand = new Random();
            while (count > 0)
            {
                int row = rand.Next(9);
                int col = rand.Next(9);
                if (board[row, col] != 0)
                {
                    board[row, col] = 0;
                    count--;
                }
            }
        }

        private void SetCell(int row, int col, int value)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox tb && ((Point)tb.Tag) == new Point(row, col))
                {
                    tb.ReadOnly = value != 0;
                    tb.Text = value == 0 ? "" : value.ToString();
                    tb.BackColor = value != 0 ? Color.LightGray : Color.White;
                    break;
                }
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < '1' || e.KeyChar > '9'))
                e.Handled = true;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            int width = tableLayoutPanel1.Width;
            int height = tableLayoutPanel1.Height;
            int cellWidth = width / 9;
            int cellHeight = height / 9;

            // Use anti-aliasing for crisper lines
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (Pen thickPen = new Pen(Color.Black, 4)) // make it thicker and darker
            {
                for (int i = 0; i <= 9; i++)
                {
                    if (i % 3 == 0)
                    {
                        // Vertical line
                        e.Graphics.DrawLine(thickPen, i * cellWidth, 0, i * cellWidth, height);
                        // Horizontal line
                        e.Graphics.DrawLine(thickPen, 0, i * cellHeight, width, i * cellHeight);
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadPuzzle();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            bool valid = true;
            ClearHighlights();

            int[,] board = ReadBoard();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] == 0 || !IsValid(board, i, j, board[i, j]))
                    {
                        HighlightCell(i, j, Color.LightPink);
                        valid = false;
                    }
                }
            }

            MessageBox.Show(valid ? "✅ Correct solution!" : "❌ There are mistakes in the puzzle.");
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            int[,] board = ReadBoard();
            if (SolveSudoku(board))
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                        SetCell(i, j, board[i, j]);
            }
            else
            {
                MessageBox.Show("❌ No solution found!");
            }
        }

        private int[,] ReadBoard()
        {
            int[,] board = new int[9, 9];
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox tb)
                {
                    Point p = (Point)tb.Tag;
                    board[p.X, p.Y] = int.TryParse(tb.Text, out int val) ? val : 0;
                }
            }
            return board;
        }

        private bool SolveSudoku(int[,] board)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row, col] == 0)
                    {
                        for (int num = 1; num <= 9; num++)
                        {
                            if (IsValid(board, row, col, num))
                            {
                                board[row, col] = num;
                                if (SolveSudoku(board)) return true;
                                board[row, col] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsValid(int[,] board, int row, int col, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != col && board[row, i] == num) return false; // check row
                if (i != row && board[i, col] == num) return false; // check column
            }

            int startRow = 3 * (row / 3);
            int startCol = 3 * (col / 3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int r = startRow + i;
                    int c = startCol + j;
                    if ((r != row || c != col) && board[r, c] == num)
                        return false;
                }
            }

            return true;
        }


        private void HighlightCell(int row, int col, Color color)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox tb && ((Point)tb.Tag) == new Point(row, col))
                {
                    tb.BackColor = color;
                }
            }
        }

        private void ClearHighlights()
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox tb && !tb.ReadOnly)
                    tb.BackColor = Color.White;
            }
        }
    }
}
