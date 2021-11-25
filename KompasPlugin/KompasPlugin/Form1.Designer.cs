
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
			this.BoltHeadHeightTextBox = new System.Windows.Forms.TextBox();
			this.BoltBodyHeightLabel = new System.Windows.Forms.Label();
			this.BoltHeadHeightLabel = new System.Windows.Forms.Label();
			this.BoltBodyHeightTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.InnerRingDiameterLabel = new System.Windows.Forms.Label();
			this.OuterRingDiameterLabel = new System.Windows.Forms.Label();
			this.ThreadDiameterLabel = new System.Windows.Forms.Label();
			this.HeadDiameterLabel = new System.Windows.Forms.Label();
			this.InnerRingDiameterTextBox = new System.Windows.Forms.TextBox();
			this.OuterRingDiameterTextBox = new System.Windows.Forms.TextBox();
			this.ThreadDiameterTextBox = new System.Windows.Forms.TextBox();
			this.HeadDiameterTextBox = new System.Windows.Forms.TextBox();
			this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
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
			this.tableLayoutPanel1.Controls.Add(this.BoltHeadHeightTextBox, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.BoltBodyHeightLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.BoltHeadHeightLabel, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.BoltBodyHeightTextBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label8, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label9, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.label10, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.label11, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.label12, 2, 5);
			this.tableLayoutPanel1.Controls.Add(this.InnerRingDiameterLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.OuterRingDiameterLabel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.ThreadDiameterLabel, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.HeadDiameterLabel, 0, 4);
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
			// BoltHeadHeightTextBox
			// 
			this.BoltHeadHeightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.BoltHeadHeightTextBox.Location = new System.Drawing.Point(173, 240);
			this.BoltHeadHeightTextBox.Name = "BoltHeadHeightTextBox";
			this.BoltHeadHeightTextBox.Size = new System.Drawing.Size(56, 20);
			this.BoltHeadHeightTextBox.TabIndex = 6;
			this.BoltHeadHeightTextBox.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
			this.BoltHeadHeightTextBox.Enter += new System.EventHandler(this.AnyTextBox_Enter);
			// 
			// BoltBodyHeightLabel
			// 
			this.BoltBodyHeightLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.BoltBodyHeightLabel.AutoSize = true;
			this.BoltBodyHeightLabel.Location = new System.Drawing.Point(3, 16);
			this.BoltBodyHeightLabel.Name = "BoltBodyHeightLabel";
			this.BoltBodyHeightLabel.Size = new System.Drawing.Size(75, 13);
			this.BoltBodyHeightLabel.TabIndex = 0;
			this.BoltBodyHeightLabel.Text = "Длина болта:";
			// 
			// BoltHeadHeightLabel
			// 
			this.BoltHeadHeightLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.BoltHeadHeightLabel.AutoSize = true;
			this.BoltHeadHeightLabel.Location = new System.Drawing.Point(3, 244);
			this.BoltHeadHeightLabel.Name = "BoltHeadHeightLabel";
			this.BoltHeadHeightLabel.Size = new System.Drawing.Size(121, 13);
			this.BoltHeadHeightLabel.TabIndex = 5;
			this.BoltHeadHeightLabel.Text = "Высота шляпки болта:";
			// 
			// BoltBodyHeightTextBox
			// 
			this.BoltBodyHeightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.BoltBodyHeightTextBox.BackColor = System.Drawing.Color.White;
			this.BoltBodyHeightTextBox.Location = new System.Drawing.Point(173, 12);
			this.BoltBodyHeightTextBox.Name = "BoltBodyHeightTextBox";
			this.BoltBodyHeightTextBox.Size = new System.Drawing.Size(56, 20);
			this.BoltBodyHeightTextBox.TabIndex = 1;
			this.BoltBodyHeightTextBox.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
			this.BoltBodyHeightTextBox.Enter += new System.EventHandler(this.AnyTextBox_Enter);
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
			// InnerRingDiameterLabel
			// 
			this.InnerRingDiameterLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.InnerRingDiameterLabel.AutoSize = true;
			this.InnerRingDiameterLabel.Location = new System.Drawing.Point(3, 61);
			this.InnerRingDiameterLabel.Name = "InnerRingDiameterLabel";
			this.InnerRingDiameterLabel.Size = new System.Drawing.Size(161, 13);
			this.InnerRingDiameterLabel.TabIndex = 2;
			this.InnerRingDiameterLabel.Text = "Диаметр внутреннего кольца:";
			// 
			// OuterRingDiameterLabel
			// 
			this.OuterRingDiameterLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.OuterRingDiameterLabel.AutoSize = true;
			this.OuterRingDiameterLabel.Location = new System.Drawing.Point(3, 106);
			this.OuterRingDiameterLabel.Name = "OuterRingDiameterLabel";
			this.OuterRingDiameterLabel.Size = new System.Drawing.Size(147, 13);
			this.OuterRingDiameterLabel.TabIndex = 4;
			this.OuterRingDiameterLabel.Text = "Диаметр внешнего кольца:";
			// 
			// ThreadDiameterLabel
			// 
			this.ThreadDiameterLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.ThreadDiameterLabel.AutoSize = true;
			this.ThreadDiameterLabel.Location = new System.Drawing.Point(3, 151);
			this.ThreadDiameterLabel.Name = "ThreadDiameterLabel";
			this.ThreadDiameterLabel.Size = new System.Drawing.Size(97, 13);
			this.ThreadDiameterLabel.TabIndex = 3;
			this.ThreadDiameterLabel.Text = "Диаметр резьбы:";
			// 
			// HeadDiameterLabel
			// 
			this.HeadDiameterLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.HeadDiameterLabel.AutoSize = true;
			this.HeadDiameterLabel.Location = new System.Drawing.Point(3, 196);
			this.HeadDiameterLabel.Name = "HeadDiameterLabel";
			this.HeadDiameterLabel.Size = new System.Drawing.Size(129, 13);
			this.HeadDiameterLabel.TabIndex = 1;
			this.HeadDiameterLabel.Text = "Диаметр шляпки болта:";
			// 
			// InnerRingDiameterTextBox
			// 
			this.InnerRingDiameterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.InnerRingDiameterTextBox.Location = new System.Drawing.Point(173, 57);
			this.InnerRingDiameterTextBox.Name = "InnerRingDiameterTextBox";
			this.InnerRingDiameterTextBox.Size = new System.Drawing.Size(56, 20);
			this.InnerRingDiameterTextBox.TabIndex = 2;
			this.InnerRingDiameterTextBox.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
			this.InnerRingDiameterTextBox.Enter += new System.EventHandler(this.AnyTextBox_Enter);
			// 
			// OuterRingDiameterTextBox
			// 
			this.OuterRingDiameterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.OuterRingDiameterTextBox.Location = new System.Drawing.Point(173, 102);
			this.OuterRingDiameterTextBox.Name = "OuterRingDiameterTextBox";
			this.OuterRingDiameterTextBox.Size = new System.Drawing.Size(56, 20);
			this.OuterRingDiameterTextBox.TabIndex = 3;
			this.OuterRingDiameterTextBox.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
			this.OuterRingDiameterTextBox.Enter += new System.EventHandler(this.AnyTextBox_Enter);
			// 
			// ThreadDiameterTextBox
			// 
			this.ThreadDiameterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.ThreadDiameterTextBox.Location = new System.Drawing.Point(173, 147);
			this.ThreadDiameterTextBox.Name = "ThreadDiameterTextBox";
			this.ThreadDiameterTextBox.Size = new System.Drawing.Size(56, 20);
			this.ThreadDiameterTextBox.TabIndex = 4;
			this.ThreadDiameterTextBox.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
			this.ThreadDiameterTextBox.Enter += new System.EventHandler(this.AnyTextBox_Enter);
			// 
			// HeadDiameterTextBox
			// 
			this.HeadDiameterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.HeadDiameterTextBox.Location = new System.Drawing.Point(173, 192);
			this.HeadDiameterTextBox.Name = "HeadDiameterTextBox";
			this.HeadDiameterTextBox.Size = new System.Drawing.Size(56, 20);
			this.HeadDiameterTextBox.TabIndex = 5;
			this.HeadDiameterTextBox.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
			this.HeadDiameterTextBox.Enter += new System.EventHandler(this.AnyTextBox_Enter);
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
        private System.Windows.Forms.TextBox BoltHeadHeightTextBox;
        private System.Windows.Forms.TextBox OuterRingDiameterTextBox;
        private System.Windows.Forms.TextBox ThreadDiameterTextBox;
        private System.Windows.Forms.TextBox InnerRingDiameterTextBox;
        private System.Windows.Forms.TextBox HeadDiameterTextBox;
        private System.Windows.Forms.Label BoltBodyHeightLabel;
        private System.Windows.Forms.Label HeadDiameterLabel;
        private System.Windows.Forms.Label InnerRingDiameterLabel;
        private System.Windows.Forms.Label ThreadDiameterLabel;
        private System.Windows.Forms.Label OuterRingDiameterLabel;
        private System.Windows.Forms.Label BoltHeadHeightLabel;
        private System.Windows.Forms.TextBox BoltBodyHeightTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ToolTip ToolTip;
	}
}

