using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobotSpil_WebApplikation.RobotBackend
{
    public class RoundResult
    {
        private int robot1Attack;
        private int robot1Defense;
        private int robot2Attack;
        private int robot2Defense;
        private int robot1LivesBefore;
        private int robot2LivesBefore;
        private bool robot1LoosesALife;
        private bool robot2LoosesALife;

        public RoundResult(int robot1Attack, int robot1Defense, int robot2Attack, int robot2Defense, int robot1LivesBefore, int robot2LivesBefore, bool robot1LoosesALife, bool robot2LoosesALife)
        {
            this.robot1Attack = robot1Attack;
            this.robot1Defense = robot1Defense;
            this.robot2Attack = robot2Attack;
            this.robot2Defense = robot2Defense;
            this.robot1LivesBefore = robot1LivesBefore;
            this.robot2LivesBefore = robot2LivesBefore;
            this.robot1LoosesALife = robot1LoosesALife;
            this.robot2LoosesALife = robot2LoosesALife;
        }

        public int getRobot1Attack() {
            return robot1Attack;
        }

        public int getRobot1Defense()
        {
            return robot1Defense;
        }

        public int getRobot2Attack()
        {
            return robot2Attack;
        }

        public int getRobot2Defense()
        {
            return robot2Defense;
        }

        public int getRobot1LivesBefore()
        {
            return robot1LivesBefore;
        }

        public int getRobot2LivesBefore()
        {
            return robot2LivesBefore;
        }

        public bool getRobot1LoosesALife()
        {
            return robot1LoosesALife;
        }

        public bool getRobot2LoosesALife()
        {
            return robot2LoosesALife;
        }
    }
}