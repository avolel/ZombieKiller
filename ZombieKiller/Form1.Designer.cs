namespace ZombieKiller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblAmmo = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblHealth = new System.Windows.Forms.Label();
            this.healthbar = new System.Windows.Forms.ProgressBar();
            this.player1 = new System.Windows.Forms.PictureBox();
            this.gametimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.player1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAmmo
            // 
            this.lblAmmo.AutoSize = true;
            this.lblAmmo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmmo.ForeColor = System.Drawing.Color.White;
            this.lblAmmo.Location = new System.Drawing.Point(12, 9);
            this.lblAmmo.Name = "lblAmmo";
            this.lblAmmo.Size = new System.Drawing.Size(128, 31);
            this.lblAmmo.TabIndex = 0;
            this.lblAmmo.Text = "Ammo: 0";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(388, 9);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(102, 31);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "Kills: 0";
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHealth.ForeColor = System.Drawing.Color.White;
            this.lblHealth.Location = new System.Drawing.Point(575, 9);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(108, 31);
            this.lblHealth.TabIndex = 2;
            this.lblHealth.Text = "Health:";
            // 
            // healthbar
            // 
            this.healthbar.Location = new System.Drawing.Point(689, 17);
            this.healthbar.Name = "healthbar";
            this.healthbar.Size = new System.Drawing.Size(223, 23);
            this.healthbar.Step = 1;
            this.healthbar.TabIndex = 3;
            this.healthbar.Value = 100;
            // 
            // player1
            // 
            this.player1.Image = global::ZombieKiller.Properties.Resources.up;
            this.player1.Location = new System.Drawing.Point(469, 287);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(71, 100);
            this.player1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player1.TabIndex = 4;
            this.player1.TabStop = false;
            // 
            // gametimer
            // 
            this.gametimer.Enabled = true;
            this.gametimer.Interval = 20;
            this.gametimer.Tick += new System.EventHandler(this.MainTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(924, 661);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.healthbar);
            this.Controls.Add(this.lblHealth);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblAmmo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Zombie Killer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.player1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAmmo;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.ProgressBar healthbar;
        private System.Windows.Forms.PictureBox player1;
        private System.Windows.Forms.Timer gametimer;
    }
}

