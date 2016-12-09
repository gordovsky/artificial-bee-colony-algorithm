using ABC;

namespace UI
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
            this.zedGraph = new ZedGraph.ZedGraphControl();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dimensionComboBox = new System.Windows.Forms.ComboBox();
            this.dimensionLabel = new System.Windows.Forms.Label();
            this.initializeButton = new System.Windows.Forms.Button();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // zedGraph
            // 
            this.zedGraph.Location = new System.Drawing.Point(312, 12);
            this.zedGraph.Name = "zedGraph";
            this.zedGraph.ScrollGrace = 0D;
            this.zedGraph.ScrollMaxX = 0D;
            this.zedGraph.ScrollMaxY = 0D;
            this.zedGraph.ScrollMaxY2 = 0D;
            this.zedGraph.ScrollMinX = 0D;
            this.zedGraph.ScrollMinY = 0D;
            this.zedGraph.ScrollMinY2 = 0D;
            this.zedGraph.Size = new System.Drawing.Size(460, 437);
            this.zedGraph.TabIndex = 0;
            this.zedGraph.UseExtendedPrintDialog = true;
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Iterations: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fittnes: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Position: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(19, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(101, 151);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "RosenbrocsSaddle",
            "DeJongs"});
            this.comboBox1.SelectedItem = "RosenbrocsSaddle";
            this.comboBox1.Location = new System.Drawing.Point(19, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(157, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dimensionComboBox
            // 
            this.dimensionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dimensionComboBox.FormattingEnabled = true;
            this.dimensionComboBox.Items.AddRange(new object[] {
            1,
            2,
            3,
            4,
            5,
            10,
            20,
            50});
            this.dimensionComboBox.SelectedItem = 1;
            this.dimensionComboBox.Location = new System.Drawing.Point(80, 43);
            this.dimensionComboBox.Name = "dimensionComboBox";
            this.dimensionComboBox.Size = new System.Drawing.Size(51, 21);
            this.dimensionComboBox.TabIndex = 8;
            this.dimensionComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // dimensionLabel
            // 
            this.dimensionLabel.AutoSize = true;
            this.dimensionLabel.Location = new System.Drawing.Point(18, 46);
            this.dimensionLabel.Name = "dimensionLabel";
            this.dimensionLabel.Size = new System.Drawing.Size(56, 13);
            this.dimensionLabel.TabIndex = 9;
            this.dimensionLabel.Text = "Dimension";
            this.dimensionLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // initializeButton
            // 
            this.initializeButton.Location = new System.Drawing.Point(19, 70);
            this.initializeButton.Name = "initializeButton";
            this.initializeButton.Size = new System.Drawing.Size(75, 23);
            this.initializeButton.TabIndex = 10;
            this.initializeButton.Text = "Initialize";
            this.initializeButton.UseVisualStyleBackColor = true;
            this.initializeButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(16, 274);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(66, 13);
            this.sizeLabel.TabIndex = 11;
            this.sizeLabel.Text = "Swarm size: ";
            this.sizeLabel.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(19, 110);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Enabled = false;
            this.checkBox1.Size = new System.Drawing.Size(96, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Draw on graph";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.initializeButton);
            this.Controls.Add(this.dimensionLabel);
            this.Controls.Add(this.dimensionComboBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zedGraph);
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.Text = "Мертві бджоли don\'t make any noise";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraph;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox dimensionComboBox;
        private System.Windows.Forms.Label dimensionLabel;
        private System.Windows.Forms.Button initializeButton;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

