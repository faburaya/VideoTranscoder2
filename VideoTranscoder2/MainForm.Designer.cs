namespace VideoTranscoder2
{
    partial class MainForm
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
            statusStrip = new StatusStrip();
            toolStripProgressBar = new ToolStripProgressBar();
            toolStripStatusLabel = new ToolStripStatusLabel();
            splitContainerMain = new SplitContainer();
            groupBoxForFiles = new GroupBox();
            tableLayoutPanelForFiles = new TableLayoutPanel();
            textBoxForInput = new TextBox();
            buttonForInput = new Button();
            buttonForOutput = new Button();
            textBoxForOutput = new TextBox();
            tableLayoutPanelBottom = new TableLayoutPanel();
            checkBoxForAlgo = new CheckBox();
            comboBoxForAlgo = new ComboBox();
            buttonToStartStop = new Button();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            groupBoxForFiles.SuspendLayout();
            tableLayoutPanelForFiles.SuspendLayout();
            tableLayoutPanelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripProgressBar, toolStripStatusLabel });
            statusStrip.Location = new Point(0, 167);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(782, 26);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            toolStripProgressBar.Name = "toolStripProgressBar";
            toolStripProgressBar.Size = new Size(450, 18);
            toolStripProgressBar.Step = 2;
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(34, 20);
            toolStripStatusLabel.Text = "Idle";
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Name = "splitContainerMain";
            splitContainerMain.Orientation = Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(groupBoxForFiles);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(tableLayoutPanelBottom);
            splitContainerMain.Size = new Size(782, 167);
            splitContainerMain.SplitterDistance = 129;
            splitContainerMain.TabIndex = 1;
            // 
            // groupBoxForFiles
            // 
            groupBoxForFiles.Controls.Add(tableLayoutPanelForFiles);
            groupBoxForFiles.Location = new Point(12, 3);
            groupBoxForFiles.Name = "groupBoxForFiles";
            groupBoxForFiles.Size = new Size(758, 100);
            groupBoxForFiles.TabIndex = 0;
            groupBoxForFiles.TabStop = false;
            groupBoxForFiles.Text = "Files";
            // 
            // tableLayoutPanelForFiles
            // 
            tableLayoutPanelForFiles.ColumnCount = 2;
            tableLayoutPanelForFiles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.68421F));
            tableLayoutPanelForFiles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.31579F));
            tableLayoutPanelForFiles.Controls.Add(textBoxForInput, 0, 0);
            tableLayoutPanelForFiles.Controls.Add(buttonForInput, 1, 0);
            tableLayoutPanelForFiles.Controls.Add(buttonForOutput, 1, 1);
            tableLayoutPanelForFiles.Controls.Add(textBoxForOutput, 0, 1);
            tableLayoutPanelForFiles.Location = new Point(6, 26);
            tableLayoutPanelForFiles.Name = "tableLayoutPanelForFiles";
            tableLayoutPanelForFiles.RowCount = 2;
            tableLayoutPanelForFiles.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelForFiles.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelForFiles.Size = new Size(746, 66);
            tableLayoutPanelForFiles.TabIndex = 0;
            // 
            // textBoxForInput
            // 
            textBoxForInput.Dock = DockStyle.Fill;
            textBoxForInput.Location = new Point(3, 3);
            textBoxForInput.Name = "textBoxForInput";
            textBoxForInput.ReadOnly = true;
            textBoxForInput.Size = new Size(543, 27);
            textBoxForInput.TabIndex = 0;
            textBoxForInput.Text = "Input file path";
            // 
            // buttonForInput
            // 
            buttonForInput.Dock = DockStyle.Fill;
            buttonForInput.Location = new Point(552, 3);
            buttonForInput.Name = "buttonForInput";
            buttonForInput.Size = new Size(191, 27);
            buttonForInput.TabIndex = 1;
            buttonForInput.Text = "Choose input";
            buttonForInput.UseVisualStyleBackColor = true;
            buttonForInput.Click += OnClickButtonForInput;
            // 
            // buttonForOutput
            // 
            buttonForOutput.Dock = DockStyle.Fill;
            buttonForOutput.Location = new Point(552, 36);
            buttonForOutput.Name = "buttonForOutput";
            buttonForOutput.Size = new Size(191, 27);
            buttonForOutput.TabIndex = 2;
            buttonForOutput.Text = "Choose output";
            buttonForOutput.UseVisualStyleBackColor = true;
            buttonForOutput.Click += OnClickButtonForOutput;
            // 
            // textBoxForOutput
            // 
            textBoxForOutput.Dock = DockStyle.Fill;
            textBoxForOutput.Location = new Point(3, 36);
            textBoxForOutput.Name = "textBoxForOutput";
            textBoxForOutput.ReadOnly = true;
            textBoxForOutput.Size = new Size(543, 27);
            textBoxForOutput.TabIndex = 3;
            textBoxForOutput.Text = "Output file path";
            // 
            // tableLayoutPanelBottom
            // 
            tableLayoutPanelBottom.ColumnCount = 3;
            tableLayoutPanelBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanelBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanelBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanelBottom.Controls.Add(checkBoxForAlgo, 0, 0);
            tableLayoutPanelBottom.Controls.Add(comboBoxForAlgo, 1, 0);
            tableLayoutPanelBottom.Controls.Add(buttonToStartStop, 2, 0);
            tableLayoutPanelBottom.Dock = DockStyle.Fill;
            tableLayoutPanelBottom.Location = new Point(0, 0);
            tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            tableLayoutPanelBottom.RowCount = 1;
            tableLayoutPanelBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelBottom.Size = new Size(782, 34);
            tableLayoutPanelBottom.TabIndex = 0;
            // 
            // checkBoxForAlgo
            // 
            checkBoxForAlgo.AutoSize = true;
            checkBoxForAlgo.Dock = DockStyle.Right;
            checkBoxForAlgo.Location = new Point(39, 3);
            checkBoxForAlgo.Name = "checkBoxForAlgo";
            checkBoxForAlgo.Size = new Size(192, 28);
            checkBoxForAlgo.TabIndex = 0;
            checkBoxForAlgo.Text = "Favor speed over quality";
            checkBoxForAlgo.UseVisualStyleBackColor = true;
            // 
            // comboBoxForAlgo
            // 
            comboBoxForAlgo.Dock = DockStyle.Fill;
            comboBoxForAlgo.FormattingEnabled = true;
            comboBoxForAlgo.Location = new Point(237, 3);
            comboBoxForAlgo.Name = "comboBoxForAlgo";
            comboBoxForAlgo.Size = new Size(228, 28);
            comboBoxForAlgo.TabIndex = 1;
            comboBoxForAlgo.SelectedIndexChanged += OnSelectedIndexChangedComboBoxForAlgo;
            // 
            // buttonToStartStop
            // 
            buttonToStartStop.Dock = DockStyle.Fill;
            buttonToStartStop.Enabled = false;
            buttonToStartStop.Location = new Point(471, 3);
            buttonToStartStop.Name = "buttonToStartStop";
            buttonToStartStop.Size = new Size(308, 28);
            buttonToStartStop.TabIndex = 2;
            buttonToStartStop.Text = "Please choose first the files";
            buttonToStartStop.UseVisualStyleBackColor = true;
            buttonToStartStop.Click += OnClickButtonToStartStop;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 193);
            Controls.Add(splitContainerMain);
            Controls.Add(statusStrip);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Video Transcoder 2";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            groupBoxForFiles.ResumeLayout(false);
            tableLayoutPanelForFiles.ResumeLayout(false);
            tableLayoutPanelForFiles.PerformLayout();
            tableLayoutPanelBottom.ResumeLayout(false);
            tableLayoutPanelBottom.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private SplitContainer splitContainerMain;
        private GroupBox groupBoxForFiles;
        private TableLayoutPanel tableLayoutPanelForFiles;
        private ToolStripProgressBar toolStripProgressBar;
        private TextBox textBoxForInput;
        private Button buttonForInput;
        private Button buttonForOutput;
        private TextBox textBoxForOutput;
        private ToolStripStatusLabel toolStripStatusLabel;
        private TableLayoutPanel tableLayoutPanelBottom;
        private CheckBox checkBoxForAlgo;
        private ComboBox comboBoxForAlgo;
        private Button buttonToStartStop;
    }
}
