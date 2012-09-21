using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobotSpil_WebApplikation.RobotBackend
{
    public class Robot
    {

        private String name;
        private List<RoundSetting> roundSettings;
        private int defeats;
        private int victories;
        private int lives;
        private int draws;


        public class RoundSetting
        {
            private int defense;
            private int attack;

            public RoundSetting(int attack, int defense)
            {
                this.attack = attack;
                this.defense = defense;
            }

            public int getDefense() { return defense; }
            public int getAttack() { return attack; }
        }

        public Robot(
            String name,
            List<RoundSetting> roundSettings,
            int defeats,
            int victories,
            int lives,
            int draws
        ) {
            this.name = name;
            this.roundSettings = roundSettings;
            this.defeats = defeats;
            this.victories = victories;
            this.lives = lives;
            this.draws = draws;
        }
        
        public String getName()
        {
            return name;
        }

        public List<RoundSetting> getRoundSettings()
        {
            return roundSettings;
        }

        public int getDefeats()
        {
            return defeats;
        }

        public void increaseDefeats()
        {
            defeats++;
        }

        public int getVictories()
        {
            return victories;
        }

        public void increaseVictories()
        {
            victories++;
        }

        public int getLives()
        {
            return lives;
        }

        public int getDraws()
        {
            return draws;
        }

        public void increaseDraws()
        {
            draws++;
        }
    
    }
}