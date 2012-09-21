using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobotSpil_WebApplikation.RobotBackend
{
    public class RobotGame
    {
        private Robot robot1;
        private Robot robot2;
        private int numRounds;

        public enum Outcome {ROBOT1WINS, ROBOT2WINS, DRAW};

        public class GameResult { // hack: public vars
            public Outcome outcome;
            public List<RoundResult> results;
        }

        public RobotGame(Robot robot1, Robot robot2, int numRounds)
        {
            this.robot1 = robot1;
            this.robot2 = robot2;
            this.numRounds = numRounds;
        }

        public Robot getRobot1() {return robot1;}
        public Robot getRobot2() {return robot2;}

        /// <summary>
        /// The robot objects are mutated (looses, victories, draw)
        /// Returns the result of the rounds.
        /// </summary>
        public GameResult runGame()
        {

            List<RoundResult> results = new List<RoundResult>();

            int robot1LivesLeft = robot1.getLives();
            int robot2LivesLeft = robot2.getLives();

            for (int round = 0; round < numRounds && robot1LivesLeft>=0 && robot2LivesLeft>=0; round++)
            {
                Robot.RoundSetting robot1RoundSetting = getCurrentRoundSetting(robot1, round);
                Robot.RoundSetting robot2RoundSetting = getCurrentRoundSetting(robot2, round);

                bool robot1HitsRobot2 = robot1RoundSetting.getAttack() == robot2RoundSetting.getDefense();
                bool robot2HitsRobot1 = robot2RoundSetting.getAttack() == robot1RoundSetting.getDefense();

                RoundResult roundResult = new RoundResult(
                    robot1RoundSetting.getAttack(),
                    robot1RoundSetting.getDefense(),
                    robot2RoundSetting.getAttack(),
                    robot2RoundSetting.getDefense(),
                    robot1LivesLeft,
                    robot2LivesLeft,
                    robot2HitsRobot1,
                    robot1HitsRobot2
                );
                results.Add(roundResult);

                if (robot1HitsRobot2) robot2LivesLeft--;
                if (robot2HitsRobot1) robot1LivesLeft--;
            }

            // create final result
            GameResult gameResult = new GameResult();
            gameResult.results = results;
            gameResult.outcome = robot1LivesLeft<0 && robot2LivesLeft<0 ? Outcome.DRAW
                               : robot1LivesLeft<0                      ? Outcome.ROBOT2WINS
                               :                                          Outcome.ROBOT1WINS;

            // modify robots win, loose, draw 
            switch (gameResult.outcome)
            {
                case Outcome.ROBOT1WINS:
                    robot1.increaseVictories();
                    robot2.increaseDefeats();
                    break;
                case Outcome.ROBOT2WINS:
                    robot1.increaseDefeats();
                    robot2.increaseVictories();
                    break;
                case Outcome.DRAW:
                    robot1.increaseDraws();
                    robot2.increaseDraws();
                    break;
            }

            return gameResult;
        }

        /// <summary>
        /// Get round setting of the given robot for the given round
        /// 
        /// round is 0-based
        /// </summary>
        /// <param name="robot"></param>
        /// <param name="round"></param>
        private Robot.RoundSetting getCurrentRoundSetting(Robot robot, int round) {
            List<Robot.RoundSetting> roundValues = robot.getRoundSettings();
            int index = round % roundValues.Count();
            return roundValues[index];
        }


    }
}