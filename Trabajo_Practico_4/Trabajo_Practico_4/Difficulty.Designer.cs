namespace Trabajo_Practico_4
{
    partial class Difficulty
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
            Panel_difficultity=new TableLayoutPanel();
            btEasy=new Button();
            btMedium=new Button();
            btHard=new Button();
            Panel_difficultity.SuspendLayout();
            SuspendLayout();
            // 
            // Panel_difficultity
            // 
            Panel_difficultity.BackColor=SystemColors.ControlLight;
            Panel_difficultity.ColumnCount=3;
            Panel_difficultity.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            Panel_difficultity.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            Panel_difficultity.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            Panel_difficultity.Controls.Add(btEasy, 1, 0);
            Panel_difficultity.Controls.Add(btMedium, 1, 1);
            Panel_difficultity.Controls.Add(btHard, 1, 2);
            Panel_difficultity.Location=new Point(0, 1);
            Panel_difficultity.Name="Panel_difficultity";
            Panel_difficultity.RowCount=3;
            Panel_difficultity.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            Panel_difficultity.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            Panel_difficultity.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            Panel_difficultity.Size=new Size(306, 226);
            Panel_difficultity.TabIndex=4;
            // 
            // btEasy
            // 
            btEasy.Font=new Font("Agency FB", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btEasy.Location=new Point(104, 3);
            btEasy.Name="btEasy";
            btEasy.Size=new Size(96, 55);
            btEasy.TabIndex=0;
            btEasy.Text="Easy";
            btEasy.UseVisualStyleBackColor=true;
            btEasy.Click+=btEasy_Click;
            // 
            // btMedium
            // 
            btMedium.Font=new Font("Agency FB", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btMedium.Location=new Point(104, 78);
            btMedium.Name="btMedium";
            btMedium.Size=new Size(96, 53);
            btMedium.TabIndex=1;
            btMedium.Text="Medium";
            btMedium.UseVisualStyleBackColor=true;
            btMedium.Click+=btMedium_Click;
            // 
            // btHard
            // 
            btHard.Font=new Font("Agency FB", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btHard.Location=new Point(104, 153);
            btHard.Name="btHard";
            btHard.Size=new Size(96, 51);
            btHard.TabIndex=2;
            btHard.Text="Hard";
            btHard.UseVisualStyleBackColor=true;
            btHard.Click+=btHard_Click;
            // 
            // Difficulty
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(306, 228);
            Controls.Add(Panel_difficultity);
            Name="Difficulty";
            Text="Difficulty";
            Panel_difficultity.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel Panel_difficultity;
        private Button btEasy;
        private Button btMedium;
        private Button btHard;
    }
}