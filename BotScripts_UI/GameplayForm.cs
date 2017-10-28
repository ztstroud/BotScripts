﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Engine;

namespace BotScripts_UI
{
    public partial class GameplayForm : Form
    {
        World world;
        bool inEditor = true;
        /// <summary>
        /// Initializes Form and bots
        /// </summary>
        public GameplayForm()
        {
            InitializeComponent();
            
            world = new World(new Bot(new PointF(50, 300), 0.0f, new Renderable(new List<PointF>(), true)), new Bot(new PointF(350, 200), (float)Math.PI, new Renderable(new List<PointF>(), true)));

            ResizePanels();
        }

        /// <summary>
        /// Gets calles when a paint event triggers, and renders all of the on screen elements using
        /// the graphics objects passed in.
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            world.Update();
            world.Render(e.Graphics);

            startButton.Update();
            PlayerInputTexBox.Update();

            System.Threading.Thread.Sleep(16);
            gamePanel.Invalidate();
        }

        /// <summary>
        /// Resizes the code panels.
        /// </summary>
        private void ResizePanels()
        {
            int panelWidth = Width / 4;
            
            if(panelWidth > 1000)
                panelWidth = 1000;

            playerCodePanel.Width = panelWidth;

            if (inEditor)
            {
                botCodePanel.Width = panelWidth * 2;
            }
            else
                botCodePanel.Width = panelWidth;

        }

        /// <summary>
        /// Called when the window resizes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameplayForm_Resize(object sender, EventArgs e)
        {
            ResizePanels();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (inEditor)
            {
                PlayerInputTexBox.ReadOnly = true;
                startButton.Text = "Stop";

                world.setPlayerCode(PlayerInputTexBox.Lines);

                inEditor = false;
            }
            else
            {
                startButton.Text = "Fight";
                PlayerInputTexBox.ReadOnly = false;

                world.setPlayerCode(new string[] { "" });

                inEditor = true;
            }
            ResizePanels();
        }
    }
}
