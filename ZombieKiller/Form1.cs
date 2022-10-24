using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieKiller
{
    public partial class Form1 : Form
    {
        const int AMMOSIZE = 100;
        const int NUMBEROFZOMBIESTOSPAWN = 4;

        bool GoLeft { get; set; }
        bool GoRight { get; set; }
        bool GoUp { get; set; }
        bool GoDown { get; set; }
        bool IsGameOver { get; set; }

        string PlayerFacing = "up";
        int PlayerHealth = 100;
        int GameSpeed = 10;
        int PlayerAmmo = AMMOSIZE;
        int PlayerScore = 0;
        int ZombieSpeed = 1;

        Random randomGenerator = new Random();

        List<PictureBox> walkers = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            Restart();            
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (PlayerHealth > 1)
                healthbar.Value = PlayerHealth;
            else
            {
                IsGameOver = true;
                player1.Image = Properties.Resources.dead;
                gametimer.Stop();
            }

            lblAmmo.Text = $"Ammo: {PlayerAmmo}";
            lblScore.Text = $"Kills: {PlayerScore}";

            //Move Player Left
            if (GoLeft == true && player1.Left > 0)
                player1.Left -= GameSpeed;
            //Move Player Right
            if (GoRight == true && player1.Left + player1.Width < this.ClientSize.Width)
                player1.Left += GameSpeed;
            //Move Player Up
            if (GoUp == true && player1.Top > 40)
                player1.Top -= GameSpeed;
            //Move Player Down
            if (GoDown == true && player1.Top + player1.Height < this.ClientSize.Height)
                player1.Top += GameSpeed;

            foreach (Control control in this.Controls)
            {
                //Pick Up Ammo
                if(control is PictureBox && (string)control.Tag == "ammo")
                {
                    if (player1.Bounds.IntersectsWith(control.Bounds))
                    {
                        this.Controls.Remove(control);
                        ((PictureBox)control).Dispose();
                        PlayerAmmo += 5;
                    }
                }

                //If Walker Causes Damage to Player decrease Health by 1.
                if (control is PictureBox && (string)control.Tag == "walker")
                {                   
                    if (player1.Bounds.IntersectsWith(control.Bounds))
                    {
                        PlayerHealth -= 1;
                    }
                }

                //Walkers Chases Player
                if(control is PictureBox && (string)control.Tag == "walker")
                {
                    if(control.Left > player1.Left)
                    {
                        control.Left -= ZombieSpeed;
                        ((PictureBox)control).Image = Properties.Resources.zleft;
                    }
                    if (control.Left < player1.Left)
                    {
                        control.Left += ZombieSpeed;
                        ((PictureBox)control).Image = Properties.Resources.zright;
                    }
                    if (control.Top > player1.Top)
                    {
                        control.Top -= ZombieSpeed;
                        ((PictureBox)control).Image = Properties.Resources.zup;
                    }
                    if (control.Top < player1.Top)
                    {
                        control.Top += ZombieSpeed;
                        ((PictureBox)control).Image = Properties.Resources.zdown;
                    }
                }

                foreach(Control item in this.Controls)
                {
                    //Check for Bullets and Walkers
                    if(item is PictureBox && (string)item.Tag == "bullet" && control is PictureBox && (string)control.Tag == "walker")
                    {
                        //If Bullet Hits Walker Increment Kill Score.
                        if (control.Bounds.IntersectsWith(item.Bounds))
                        {
                            PlayerScore++;
                            //Remove the Bullet from the screen and Dispose of bullet object.
                            this.Controls.Remove(item);
                            ((PictureBox)item).Dispose();
                            //Remove the Walker that was shot from the screen and Dispose of walker object.
                            this.Controls.Add(control);
                            walkers.Remove(((PictureBox)control));
                            ((PictureBox)control).Dispose();
                            //Spawn More Wlakers.
                            SpawnZombies();
                        }
                    }
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (IsGameOver)
                return;

            //Turn player in a different direction when the appropiate key is pressed (Left, Right, Up or Down).
            switch (e.KeyCode)
            {
                case Keys.Left:
                    GoLeft = true;
                    PlayerFacing = "left";
                    player1.Image = Properties.Resources.left;
                    break;
                case Keys.Right:
                    GoRight = true;
                    PlayerFacing= "right";
                    player1.Image = Properties.Resources.right;
                    break;
                case Keys.Up:
                    GoUp = true;
                    PlayerFacing = "up";
                    player1.Image = Properties.Resources.up;
                    break;
                case Keys.Down:
                    GoDown = true;
                    PlayerFacing = "down";
                    player1.Image = Properties.Resources.down;
                    break;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    GoLeft = false;
                    break;
                case Keys.Right:
                    GoRight = false;
                    break;
                case Keys.Up:
                    GoUp = false;
                    break;
                case Keys.Down:
                    GoDown = false;
                    break;
            }

            //Press Space Bar to Fire Gun
            if(e.KeyCode == Keys.Space && PlayerAmmo > 0 && IsGameOver == false)
            {
                PlayerAmmo--;
                Shoot(PlayerFacing);
                if(PlayerAmmo < 1)
                    DropAmmo();
            }

            //Press Enter Key to Restart
            if(e.KeyCode == Keys.Enter && IsGameOver == true)
                Restart();
        }

        private void Shoot(string direction)
        {
            Bullet bullet = new Bullet();
            bullet.Direction = direction;
            bullet.BulletLeft = player1.Left + (player1.Width / 2);
            bullet.BulletTop  = player1.Top + (player1.Height / 2);
            bullet.BulletCreate(this);
        }

        private void SpawnZombies()
        {
            PictureBox walker = new PictureBox();
            walker.Tag = "walker";
            walker.Image = Properties.Resources.zdown;
            walker.Left = randomGenerator.Next(0, 900);
            walker.Top = randomGenerator.Next(0, 700);
            walker.SizeMode = PictureBoxSizeMode.AutoSize;
            walkers.Add(walker);
            this.Controls.Add(walker);
            player1.BringToFront();
        }

        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = randomGenerator.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = randomGenerator.Next(60, this.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);
            ammo.BringToFront();
            player1.BringToFront();
        }

        private void Restart()
        {
            player1.Image = Properties.Resources.up;

            foreach(PictureBox item in walkers)
                this.Controls.Remove(item);

            walkers.Clear();

            for(int i = 0; i < NUMBEROFZOMBIESTOSPAWN; i++)
                SpawnZombies();

            GoUp = false;
            GoDown = false;
            GoLeft = false;
            GoRight = false;
            IsGameOver = false;

            PlayerHealth = 100;
            PlayerScore = 0;
            PlayerAmmo = AMMOSIZE;

            gametimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            healthbar.SetState(2);
        }
    }
}