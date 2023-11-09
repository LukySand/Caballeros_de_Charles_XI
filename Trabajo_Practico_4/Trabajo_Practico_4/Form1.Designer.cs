namespace Trabajo_Practico_4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tb_Table = new TextBox();
            Panel_Menu = new TableLayoutPanel();
            b_Score = new Button();
            b_Exit = new Button();
            b_Play = new Button();
            btContinue = new Button();
            EGamePanel = new Panel();
            Panel_Menu.SuspendLayout();
            SuspendLayout();
            // 
            // tb_Table
            // 
            tb_Table.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            tb_Table.BackColor = SystemColors.Menu;
            Panel_Menu.SetColumnSpan(tb_Table, 3);
            tb_Table.Font = new Font("Stencil", 24F, FontStyle.Regular, GraphicsUnit.Point);
            tb_Table.Location = new Point(54, 0);
            tb_Table.Margin = new Padding(0);
            tb_Table.Name = "tb_Table";
            tb_Table.ReadOnly = true;
            tb_Table.Size = new Size(330, 45);
            tb_Table.TabIndex = 0;
            tb_Table.Text = "Sudoku";
            tb_Table.TextAlign = HorizontalAlignment.Center;
            // 
            // Panel_Menu
            // 
            Panel_Menu.ColumnCount = 3;
            Panel_Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            Panel_Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            Panel_Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            Panel_Menu.Controls.Add(tb_Table, 0, 0);
            Panel_Menu.Controls.Add(b_Score, 1, 2);
            Panel_Menu.Controls.Add(b_Exit, 1, 3);
            Panel_Menu.Controls.Add(b_Play, 1, 1);
            Panel_Menu.Controls.Add(btContinue, 2, 3);
            Panel_Menu.Location = new Point(1, 0);
            Panel_Menu.Name = "Panel_Menu";
            Panel_Menu.RowCount = 5;
            Panel_Menu.RowStyles.Add(new RowStyle(SizeType.Percent, 20.2724972F));
            Panel_Menu.RowStyles.Add(new RowStyle(SizeType.Percent, 20.2724972F));
            Panel_Menu.RowStyles.Add(new RowStyle(SizeType.Percent, 20.2724972F));
            Panel_Menu.RowStyles.Add(new RowStyle(SizeType.Percent, 20.2724972F));
            Panel_Menu.RowStyles.Add(new RowStyle(SizeType.Percent, 18.9100189F));
            Panel_Menu.Size = new Size(439, 635);
            Panel_Menu.TabIndex = 4;
            // 
            // b_Score
            // 
            b_Score.Anchor = AnchorStyles.Top;
            b_Score.Location = new Point(181, 259);
            b_Score.Name = "b_Score";
            b_Score.Size = new Size(75, 23);
            b_Score.TabIndex = 2;
            b_Score.Text = "Score";
            b_Score.UseVisualStyleBackColor = true;
            // 
            // b_Exit
            // 
            b_Exit.Anchor = AnchorStyles.Top;
            b_Exit.Location = new Point(181, 387);
            b_Exit.Name = "b_Exit";
            b_Exit.Size = new Size(75, 23);
            b_Exit.TabIndex = 3;
            b_Exit.Text = "Exit";
            b_Exit.UseVisualStyleBackColor = true;
            // 
            // b_Play
            // 
            b_Play.Anchor = AnchorStyles.Top;
            b_Play.AutoSize = true;
            b_Play.Location = new Point(181, 131);
            b_Play.Name = "b_Play";
            b_Play.Size = new Size(75, 25);
            b_Play.TabIndex = 1;
            b_Play.Text = "Play";
            b_Play.UseVisualStyleBackColor = true;
            b_Play.Click += bPlay_Click;
            // 
            // btContinue
            // 
            btContinue.Anchor = AnchorStyles.Top;
            Panel_Menu.SetColumnSpan(btContinue, 3);
            btContinue.Location = new Point(151, 515);
            btContinue.Name = "btContinue";
            btContinue.Size = new Size(137, 23);
            btContinue.TabIndex = 4;
            btContinue.Text = "Continue";
            btContinue.UseVisualStyleBackColor = true;
            btContinue.Click += btContinue_Click;
            // 
            // EGamePanel
            // 
            EGamePanel.Location = new Point(446, 0);
            EGamePanel.Name = "EGamePanel";
            EGamePanel.Size = new Size(279, 635);
            EGamePanel.TabIndex = 5;
            EGamePanel.Paint += EGamePanel_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 635);
            Controls.Add(EGamePanel);
            Controls.Add(Panel_Menu);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Panel_Menu.ResumeLayout(false);
            Panel_Menu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox tb_Table;
        private TableLayoutPanel Panel_Menu;
        private Button b_Play;
        private Button b_Score;
        private Button b_Exit;
        private Button btContinue;
        private Panel EGamePanel;
    }
}