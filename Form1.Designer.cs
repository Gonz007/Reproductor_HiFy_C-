
namespace Reproductor

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnPlay = new Button();
            btnNext = new Button();
            btnPrevious = new Button();
            lblFileName = new Label();
            lstFiles = new ListBox();
            label1 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            pictureSong = new PictureBox();
            textBox1 = new TextBox();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            volumeTrackBar = new TrackBar();
            trackBar1 = new TrackBar();
            label2 = new Label();
            trackBar2 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)pictureSong).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)volumeTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Enabled = false;
            btnPlay.Location = new Point(110, 366);
            btnPlay.Margin = new Padding(4, 3, 4, 3);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(88, 27);
            btnPlay.TabIndex = 1;
            btnPlay.Text = "▶️";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnNext
            // 
            btnNext.Enabled = false;
            btnNext.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnNext.Location = new Point(206, 366);
            btnNext.Margin = new Padding(4, 3, 4, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(88, 27);
            btnNext.TabIndex = 2;
            btnNext.Text = "⏩";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Enabled = false;
            btnPrevious.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrevious.Location = new Point(16, 366);
            btnPrevious.Margin = new Padding(4, 3, 4, 3);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(88, 27);
            btnPrevious.TabIndex = 3;
            btnPrevious.Text = "⏪";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Location = new Point(138, 156);
            lblFileName.Margin = new Padding(4, 0, 4, 0);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(0, 15);
            lblFileName.TabIndex = 4;
            // 
            // lstFiles
            // 
            lstFiles.FormattingEnabled = true;
            lstFiles.ItemHeight = 15;
            lstFiles.Location = new Point(341, 44);
            lstFiles.Margin = new Padding(4, 3, 4, 3);
            lstFiles.Name = "lstFiles";
            lstFiles.Size = new Size(373, 334);
            lstFiles.TabIndex = 5;
            lstFiles.SelectedIndexChanged += lstFiles_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 286);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 6;
            label1.Text = "//////////////";
            label1.Click += label1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.Location = new Point(264, 259);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(52, 29);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "🔀";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox2.Location = new Point(264, 286);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(52, 29);
            checkBox2.TabIndex = 8;
            checkBox2.Text = "🔁";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged_1;
            // 
            // pictureSong
            // 
            pictureSong.Location = new Point(54, 44);
            pictureSong.Name = "pictureSong";
            pictureSong.Size = new Size(215, 209);
            pictureSong.TabIndex = 9;
            pictureSong.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(341, 14);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(373, 23);
            textBox1.TabIndex = 11;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveBorder;
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(783, 24);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(90, 22);
            openToolStripMenuItem.Text = "file";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // volumeTrackBar
            // 
            volumeTrackBar.Location = new Point(0, 0);
            volumeTrackBar.Name = "volumeTrackBar";
            volumeTrackBar.Size = new Size(104, 45);
            volumeTrackBar.TabIndex = 0;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(16, 315);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(284, 45);
            trackBar1.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 348);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 14;
            label2.Text = "//////////////";
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(0, 44);
            trackBar2.Name = "trackBar2";
            trackBar2.Orientation = Orientation.Vertical;
            trackBar2.RightToLeft = RightToLeft.No;
            trackBar2.Size = new Size(45, 209);
            trackBar2.TabIndex = 15;
            trackBar2.TickStyle = TickStyle.Both;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(783, 458);
            Controls.Add(trackBar2);
            Controls.Add(label2);
            Controls.Add(trackBar1);
            Controls.Add(textBox1);
            Controls.Add(pictureSong);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label1);
            Controls.Add(lstFiles);
            Controls.Add(btnPlay);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(lblFileName);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "MusicWasp";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureSong).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)volumeTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ListBox lstFiles;
        private TrackBar volumeTrackBar;

        private Label label1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private PictureBox pictureSong;
        private TextBox textBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private TrackBar trackBar1;
        private Label label2;
        private TrackBar trackBar2;
    }
}