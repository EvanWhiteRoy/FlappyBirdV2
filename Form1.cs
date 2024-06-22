using FlappyBirdV2.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace FlappyBirdV2
{
    public partial class flappyBird : Form
    {
        //Player rectangle
        Rectangle player1 = new Rectangle(80, 90, 20, 20);
        

        SolidBrush greenBrush = new SolidBrush(Color.Black);

        //Variables
        int gravity = 23;
        int playerScore = 0;
        int pipeWidth = 40;
        int pipeHeight = 120;
        int pipeGap = 120; // Gap between top and bottom pipes
        int minPipeDistance = 200; // Minimum dstance between pipes
        int time = 0;


        Image birdImg = Properties.Resources.Bird;
        Image topPipeImg = Properties.Resources.topPipe;
        Image bottomPipeImg = Properties.Resources.bottomPipe;


        //Sounds for interactions

        SoundPlayer jump = new SoundPlayer(Properties.Resources.Jump);
        SoundPlayer lose = new SoundPlayer(Properties.Resources.Lose);





        //Lists of pipes
        List<Rectangle> topPipes = new List<Rectangle>();
        List<Rectangle> bottomPipes = new List<Rectangle>();

        //Player keybinds
        bool spacePressed = false;

        //Random generator
        Random randGen = new Random();
        



        public flappyBird()
        {
            InitializeComponent();
            GameIntialize();
        }


        //paint the game
        private void flappyBird_Paint(object sender, PaintEventArgs e)
        {
            if (gameTimer.Enabled == false && time == 0 )
            {
                //Starting screen
                titleLabel.Text = "Flappy Bird";
                subLabel.Text = "Press Space to Start or Esc to Exit";

            }
            else if (gameTimer.Enabled == true)
            {
                //Update score display
                scorelabel.Text = $"{time}";
                e.Graphics.DrawImage(birdImg, player1);




                for (int i = 0; i < topPipes.Count; i++)
                {
                    e.Graphics.DrawImage(topPipeImg, topPipes[i]);
                }

                for (int i = 0; i < bottomPipes.Count; i++)
                {
                    e.Graphics.DrawImage(bottomPipeImg, bottomPipes[i]);
                }
            }
            else if (gameTimer.Enabled == false && time != 0)
            {
                titleLabel.Text = "Game Over";
                subLabel.Text = "Press space to play again or esc to exit";
            }

        }

        //Spawn the pipe so that there are spaces between the bottom pipes and the top pipes.
        private void SpawnPipes()
        {
            if (topPipes.Count == 0 || topPipes.Last().X < 470)
            {
                int randY = randGen.Next(-50, 0); // Random height for top pipe
                Rectangle topPipe1 = new Rectangle(600, randY, pipeWidth, pipeHeight);
                topPipes.Add(topPipe1);

                // Bottom pipe with a gap from the top pipe
                Rectangle bottomPipe1 = new Rectangle(600, randY + pipeHeight + pipeGap - 50 , pipeWidth, pipeHeight);
                bottomPipes.Add(bottomPipe1);
            }

            
        }

        

        private void PlayerIntersection()
        {
            for (int i = 0; i < topPipes.Count; i++)
            {
                if (player1.IntersectsWith(topPipes[i]) || player1.IntersectsWith(bottomPipes[i]))
                {
                    gameTimer.Stop();
                    lose.Play();

                }

            }
        }



        //bird movement
        private void flappyBird_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Space:
                    spacePressed = true;
                    

                    if (gameTimer.Enabled == false && time== 0)
                    {
                        GameIntialize();
                    }
                    if (gameTimer.Enabled == false && time != 0)
                    {
                        GameIntialize();
                    }

                    break;

                //escape button for exiting before the game starts and space button for starting the game
                case Keys.Escape:
                    if (gameTimer.Enabled == false)
                    {
                        Application.Exit();
                    }
                    break;

            }
                    
        }

        private void flappyBird_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Space:
                    spacePressed = false;
                    break;
            }
        }


        //initialize game when timer is true
        public void GameIntialize()
        {
            //Reset
            topPipes.Clear();
            bottomPipes.Clear();
            time = 0;
            titleLabel.Text = "";
            subLabel.Text = "";

            gameTimer.Enabled = true;

            playerScore = 0;
           
           
            topPipes.Clear();
            bottomPipes.Clear();
            

            player1 = new Rectangle(80, 90, 20, 20);
           

        }

        //the main game mechanic
        private void gameTimer_Tick_1(object sender, EventArgs e)
        {
            time++;
            PlayerIntersection();
            SpawnPipes();
            if (player1.Y < this.Height - player1.Height)
            {
                player1.Y += 3;
            }

            for (int i = 0; i < topPipes.Count; i++)
            {
                topPipes[i] = new Rectangle(topPipes[i].X - 2, topPipes[i].Y, topPipes[i].Width, topPipes[i].Height);
            }

            for (int i = 0; i < bottomPipes.Count; i++)
            {
                bottomPipes[i] = new Rectangle(bottomPipes[i].X - 2, bottomPipes[i].Y, bottomPipes[i].Width, bottomPipes[i].Height);
            }

            // Remove pipes that have moved off screen
            if (topPipes.Count > 0 && topPipes[0].X < - pipeWidth)
            {
                topPipes.RemoveAt(0);
                bottomPipes.RemoveAt(0);
            }


            if (spacePressed == true)
            {
                jump.Play();
                player1.Y -= gravity;
            }
            Refresh();
        
        }
    }
}
