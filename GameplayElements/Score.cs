﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using System.Drawing;
using System.Diagnostics;

namespace GameplayElements
{
    public class Score
    {
        public Bot PlayerBot;
        public Bot EnemyBot;

        public int playerScore = 0;
        public int enemyScore = 0;

        public Score(Bot playerBot, Bot enemyBot)
        {
            PlayerBot = playerBot;
            EnemyBot = enemyBot;
        }

        public void Reset()
        {
            playerScore = 0;
            enemyScore = 0;
        }

        public void Update()
        {
            
            if (isHit(EnemyBot, PlayerBot.SpikeLocation))
            {
                playerScore += 10;
            }
            else if (isHit(PlayerBot, EnemyBot.SpikeLocation))
            {
                enemyScore += 10;
            }
        }

        private bool isHit(Bot target, PointF spikeLocation)
        {
            if (GetSpikeDistance(target, spikeLocation) < 90f)
            {
                return true;
            }
            return false;
        }

        private float GetSpikeDistance(Bot target, PointF spikeLocation)
        {
            float spikeDistancetoTarget = ((spikeLocation.X - target.Position.X) * (spikeLocation.X - target.Position.X)
                           + (spikeLocation.Y - target.Position.Y) * (spikeLocation.Y - target.Position.Y));

            return spikeDistancetoTarget;
        }
    }
}