using System;
using System.Drawing;
using System.Windows.Forms;

namespace ZombieKiller
{
    public class Bullet
    {
        public string Direction { get; set; }
        public int BulletLeft { get; set; }
        public int BulletTop { get; set; }

        private int BulletSpeed { get; set; } = 20;
        private PictureBox bullet = new PictureBox();
        private Timer bulletTimer = new Timer();

        public void BulletCreate(Form form)
        {
            bullet.BackColor = Color.Gold;
            bullet.Size = new Size(6, 6);
            bullet.Tag = "bullet";
            bullet.Left = BulletLeft;
            bullet.Top = BulletTop;
            bullet.BringToFront();

            form.Controls.Add(bullet);
            bulletTimer.Interval = BulletSpeed;
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);
            bulletTimer.Start();
        }

        private void BulletTimerEvent(object sender, EventArgs e)
        {
            switch (Direction)
            {
                case "left":
                    bullet.Left -= BulletSpeed;
                    break;
                case "right":
                    bullet.Left += BulletSpeed;
                    break;
                case "up":
                    bullet.Top -= BulletSpeed;
                    break;
                case "down":
                    bullet.Top += BulletSpeed;
                    break;
            }

            if(bullet.Left < 10 || bullet.Left > 860 || bullet.Top < 10 || bullet.Top > 600)
            {
                bulletTimer.Stop();
                bulletTimer.Dispose();
                bullet.Dispose();
                bulletTimer = null;
                bullet = null;
            }
        }
    }
}