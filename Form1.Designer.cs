namespace FlappyBirdV2
{
    partial class flappyBird
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.subLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.scorelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick_1);
            // 
            // subLabel
            // 
            this.subLabel.BackColor = System.Drawing.Color.Transparent;
            this.subLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subLabel.ForeColor = System.Drawing.Color.Orange;
            this.subLabel.Location = new System.Drawing.Point(222, 159);
            this.subLabel.Name = "subLabel";
            this.subLabel.Size = new System.Drawing.Size(333, 43);
            this.subLabel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Orange;
            this.titleLabel.Location = new System.Drawing.Point(286, 112);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(189, 23);
            this.titleLabel.TabIndex = 1;
            // 
            // scorelabel
            // 
            this.scorelabel.BackColor = System.Drawing.Color.Transparent;
            this.scorelabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scorelabel.ForeColor = System.Drawing.Color.Orange;
            this.scorelabel.Location = new System.Drawing.Point(308, 20);
            this.scorelabel.Name = "scorelabel";
            this.scorelabel.Size = new System.Drawing.Size(100, 23);
            this.scorelabel.TabIndex = 2;
            // 
            // flappyBird
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FlappyBirdV2.Properties.Resources.OIP__1_;
            this.ClientSize = new System.Drawing.Size(734, 261);
            this.Controls.Add(this.scorelabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.subLabel);
            this.DoubleBuffered = true;
            this.Name = "flappyBird";
            this.Text = "Flappy Bird";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.flappyBird_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flappyBird_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.flappyBird_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label subLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label scorelabel;
    }
}

