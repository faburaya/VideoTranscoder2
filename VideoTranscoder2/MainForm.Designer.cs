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
            buttonToStartStop = new Button();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            groupBoxForFiles.SuspendLayout();
            tableLayoutPanelForFiles.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripProgressBar, toolStripStatusLabel });
            statusStrip.Location = new Point(0, 152);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(782, 26);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            toolStripProgressBar.Name = "toolStripProgressBar";
            toolStripProgressBar.Size = new Size(550, 18);
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(204, 20);
            toolStripStatusLabel.Text = "Please choose the media files";
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
            splitContainerMain.Panel2.Controls.Add(buttonToStartStop);
            splitContainerMain.Size = new Size(782, 152);
            splitContainerMain.SplitterDistance = 116;
            splitContainerMain.TabIndex = 1;
            // 
            // groupBoxForFiles
            // 
            groupBoxForFiles.Controls.Add(tableLayoutPanelForFiles);
            groupBoxForFiles.Dock = DockStyle.Fill;
            groupBoxForFiles.Location = new Point(0, 0);
            groupBoxForFiles.Name = "groupBoxForFiles";
            groupBoxForFiles.Size = new Size(782, 116);
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
            tableLayoutPanelForFiles.Location = new Point(12, 26);
            tableLayoutPanelForFiles.Name = "tableLayoutPanelForFiles";
            tableLayoutPanelForFiles.RowCount = 2;
            tableLayoutPanelForFiles.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelForFiles.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelForFiles.Size = new Size(760, 70);
            tableLayoutPanelForFiles.TabIndex = 0;
            // 
            // textBoxForInput
            // 
            textBoxForInput.Dock = DockStyle.Fill;
            textBoxForInput.Location = new Point(3, 3);
            textBoxForInput.Name = "textBoxForInput";
            textBoxForInput.ReadOnly = true;
            textBoxForInput.Size = new Size(554, 27);
            textBoxForInput.TabIndex = 0;
            textBoxForInput.Text = "Input file path";
            // 
            // buttonForInput
            // 
            buttonForInput.Dock = DockStyle.Fill;
            buttonForInput.Location = new Point(563, 3);
            buttonForInput.Name = "buttonForInput";
            buttonForInput.Size = new Size(194, 29);
            buttonForInput.TabIndex = 1;
            buttonForInput.Text = "Choose input";
            buttonForInput.UseVisualStyleBackColor = true;
            buttonForInput.Click += OnClickButtonForInput;
            // 
            // buttonForOutput
            // 
            buttonForOutput.Dock = DockStyle.Fill;
            buttonForOutput.Location = new Point(563, 38);
            buttonForOutput.Name = "buttonForOutput";
            buttonForOutput.Size = new Size(194, 29);
            buttonForOutput.TabIndex = 2;
            buttonForOutput.Text = "Choose output";
            buttonForOutput.UseVisualStyleBackColor = true;
            // 
            // textBoxForOutput
            // 
            textBoxForOutput.Dock = DockStyle.Fill;
            textBoxForOutput.Location = new Point(3, 38);
            textBoxForOutput.Name = "textBoxForOutput";
            textBoxForOutput.ReadOnly = true;
            textBoxForOutput.Size = new Size(554, 27);
            textBoxForOutput.TabIndex = 3;
            textBoxForOutput.Text = "Output file path";
            // 
            // buttonToStartStop
            // 
            buttonToStartStop.Dock = DockStyle.Fill;
            buttonToStartStop.Enabled = false;
            buttonToStartStop.Location = new Point(0, 0);
            buttonToStartStop.Name = "buttonToStartStop";
            buttonToStartStop.Size = new Size(782, 32);
            buttonToStartStop.TabIndex = 0;
            buttonToStartStop.Text = "Transcode to HEVC (H.265)";
            buttonToStartStop.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 178);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private SplitContainer splitContainerMain;
        private GroupBox groupBoxForFiles;
        private TableLayoutPanel tableLayoutPanelForFiles;
        private Button buttonToStartStop;
        private ToolStripProgressBar toolStripProgressBar;
        private TextBox textBoxForInput;
        private Button buttonForInput;
        private Button buttonForOutput;
        private TextBox textBoxForOutput;
        private ToolStripStatusLabel toolStripStatusLabel;
    }
}
