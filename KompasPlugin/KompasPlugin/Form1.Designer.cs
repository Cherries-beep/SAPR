
namespace KompasPlugin
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
			this.components = new System.ComponentModel.Container();
			this.BuilderButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.HeadHeightTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.BodyHeightTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.InnerRingDiameterTextBox = new System.Windows.Forms.TextBox();
			this.OuterRingDiameterTextBox = new System.Windows.Forms.TextBox();
			this.ThreadDiameterTextBox = new System.Windows.Forms.TextBox();
			this.HeadDiameterTextBox = new System.Windows.Forms.TextBox();
			this.BodyHeightErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.InnerRingDiameterErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.OuterRingDiameterErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.ThreadDiameterErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.HeadDiameterErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.HeadHeightErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// BuilderButton
			// 
			this.BuilderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BuilderButton.Location = new System.Drawing.Point(203, 294);
			this.BuilderButton.Name = "BuilderButton";
			this.BuilderButton.Size = new System.Drawing.Size(75, 23);
			this.BuilderButton.TabIndex = 7;
			this.BuilderButton.Text = "Построить";
			this.BuilderButton.UseVisualStyleBackColor = true;
			this.BuilderButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BuilderButton_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
			this.tableLayoutPanel1.Controls.Add(this.HeadHeightTextBox, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.BodyHeightTextBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label8, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label9, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.label10, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.label11, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.label12, 2, 5);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.InnerRingDiameterTextBox, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.OuterRingDiameterTextBox, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.ThreadDiameterTextBox, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.HeadDiameterTextBox, 1, 4);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(266, 276);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// HeadHeightTextBox
			// 
			this.HeadHeightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.HeadHeightTextBox.Location = new System.Drawing.Point(173, 240);
			this.HeadHeightTextBox.Name = "HeadHeightTextBox";
			this.HeadHeightTextBox.Size = new System.Drawing.Size(56, 20);
			this.HeadHeightTextBox.TabIndex = 6;
			this.HeadHeightTextBox.TextChanged += new System.EventHandler(this.HeadHeightTextBox_TextChanged);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Длина болта:";
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 244);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(121, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "Высота шляпки болта:";
			// 
			// BodyHeightTextBox
			// 
			this.BodyHeightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.BodyHeightTextBox.BackColor = System.Drawing.Color.White;
			this.BodyHeightTextBox.Location = new System.Drawing.Point(173, 12);
			this.BodyHeightTextBox.Name = "BodyHeightTextBox";
			this.BodyHeightTextBox.Size = new System.Drawing.Size(56, 20);
			this.BodyHeightTextBox.TabIndex = 1;
			this.BodyHeightTextBox.TextChanged += new System.EventHandler(this.BodyHeightTextBox_TextChanged);
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(235, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(69, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "мм";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(235, 61);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(69, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "мм";
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(235, 106);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(69, 13);
			this.label9.TabIndex = 14;
			this.label9.Text = "мм";
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(235, 151);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(69, 13);
			this.label10.TabIndex = 15;
			this.label10.Text = "мм";
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(235, 196);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(69, 13);
			this.label11.TabIndex = 16;
			this.label11.Text = "мм";
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(235, 244);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(69, 13);
			this.label12.TabIndex = 17;
			this.label12.Text = "мм";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(161, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Диаметр внутреннего кольца:";
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 106);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(147, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Диаметр внешнего кольца:";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 151);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(97, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Диаметр резьбы:";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 196);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(129, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Диаметр шляпки болта:";
			// 
			// InnerRingDiameterTextBox
			// 
			this.InnerRingDiameterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.InnerRingDiameterTextBox.Location = new System.Drawing.Point(173, 57);
			this.InnerRingDiameterTextBox.Name = "InnerRingDiameterTextBox";
			this.InnerRingDiameterTextBox.Size = new System.Drawing.Size(56, 20);
			this.InnerRingDiameterTextBox.TabIndex = 2;
			this.InnerRingDiameterTextBox.TextChanged += new System.EventHandler(this.InnerRingDiameterTextBox_TextChanged);
			// 
			// OuterRingDiameterTextBox
			// 
			this.OuterRingDiameterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.OuterRingDiameterTextBox.Location = new System.Drawing.Point(173, 102);
			this.OuterRingDiameterTextBox.Name = "OuterRingDiameterTextBox";
			this.OuterRingDiameterTextBox.Size = new System.Drawing.Size(56, 20);
			this.OuterRingDiameterTextBox.TabIndex = 3;
			this.OuterRingDiameterTextBox.TextChanged += new System.EventHandler(this.OuterRingDiameterTextBox_TextChanged);
			// 
			// ThreadDiameterTextBox
			// 
			this.ThreadDiameterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.ThreadDiameterTextBox.Location = new System.Drawing.Point(173, 147);
			this.ThreadDiameterTextBox.Name = "ThreadDiameterTextBox";
			this.ThreadDiameterTextBox.Size = new System.Drawing.Size(56, 20);
			this.ThreadDiameterTextBox.TabIndex = 4;
			this.ThreadDiameterTextBox.TextChanged += new System.EventHandler(this.ThreadDiameterTextBox_TextChanged);
			// 
			// HeadDiameterTextBox
			// 
			this.HeadDiameterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.HeadDiameterTextBox.Location = new System.Drawing.Point(173, 192);
			this.HeadDiameterTextBox.Name = "HeadDiameterTextBox";
			this.HeadDiameterTextBox.Size = new System.Drawing.Size(56, 20);
			this.HeadDiameterTextBox.TabIndex = 5;
			this.HeadDiameterTextBox.TextChanged += new System.EventHandler(this.HeadDiameterTextBox_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(290, 324);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.BuilderButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "Болт с внутренней резьбой";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BuilderButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox HeadHeightTextBox;
        private System.Windows.Forms.TextBox OuterRingDiameterTextBox;
        private System.Windows.Forms.TextBox ThreadDiameterTextBox;
        private System.Windows.Forms.TextBox InnerRingDiameterTextBox;
        private System.Windows.Forms.TextBox HeadDiameterTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BodyHeightTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ToolTip BodyHeightErrorToolTip;
		private System.Windows.Forms.ToolTip InnerRingDiameterErrorToolTip;
		private System.Windows.Forms.ToolTip OuterRingDiameterErrorToolTip;
		private System.Windows.Forms.ToolTip ThreadDiameterErrorToolTip;
		private System.Windows.Forms.ToolTip HeadDiameterErrorToolTip;
		private System.Windows.Forms.ToolTip HeadHeightErrorToolTip;
	}
}

