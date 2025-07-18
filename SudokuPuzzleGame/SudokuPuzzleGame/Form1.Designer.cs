namespace SudokuPuzzleGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            btnCheck = new Button();
            btnReset = new Button();
            btnSolve = new Button();
            btnHint = new Button();
            btnRestart = new Button();
            SuspendLayout();

            //
            // tableLayoutPanel1
            //
            tableLayoutPanel1.ColumnCount = 9;
            for (int i = 0; i < 9; i++)
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.111111F));
            tableLayoutPanel1.RowCount = 9;
            for (int i = 0; i < 9; i++)
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.111111F));
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Size = new Size(400, 400);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;

            //
            // Buttons
            //
            btnCheck.Location = new Point(480, 50);
            btnCheck.Size = new Size(150, 40);
            btnCheck.Text = "✅ Check Answer";
            btnCheck.Click += btnCheck_Click;

            btnReset.Location = new Point(480, 100);
            btnReset.Size = new Size(150, 40);
            btnReset.Text = "♻️ Reset";
            btnReset.Click += btnReset_Click;

            btnHint.Location = new Point(480, 150);
            btnHint.Size = new Size(150, 40);
            btnHint.Text = "💡 Hint";
            btnHint.Click += btnHint_Click;

            btnSolve.Location = new Point(480, 200);
            btnSolve.Size = new Size(150, 40);
            btnSolve.Text = "🧮 Solve";
            btnSolve.Click += btnSolve_Click;

            btnRestart.Location = new Point(480, 250);
            btnRestart.Size = new Size(150, 40);
            btnRestart.Text = "🔁 Restart Game";
            btnRestart.Click += btnRestart_Click;

            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 480);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(btnCheck);
            Controls.Add(btnReset);
            Controls.Add(btnHint);
            Controls.Add(btnSolve);
            Controls.Add(btnRestart);
            Name = "Form1";
            Text = "Sudoku Puzzle Game";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1 = null!;
        private Button btnCheck = null!;
        private Button btnReset = null!;
        private Button btnHint = null!;
        private Button btnSolve = null!;
        private Button btnRestart = null!;
    }
}