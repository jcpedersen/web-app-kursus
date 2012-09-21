using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    
    
    public class RobotGame
    {
        private Robot r1;
        private Robot r2;
        private int rounds;

        private Gamedata gdata;

        public RobotGame(Robot _r1, Robot _r2, int _rounds, Gamedata _Gdata) {
            r1 = _r1;
            r2 = _r2;
            rounds = _rounds;
            gdata = _Gdata;
        }

        public int fight() {

            int score_r1 = 0;
            int score_r2 = 0;
            for (int i = 0; i < rounds; i++ )
            {
                int r1_v = r1.getVaaben(i);
                int r1_s = r1.getSkjold(i);
                int r2_v = r2.getVaaben(i);
                int r2_s = r2.getSkjold(i);

                // r1 skyder mod r2, hit or miss
                if (r1_v > r2_s) score_r1++;
                gdata.TilfoejKamp("r1 skyder mod r2", r1_v, r2_s);

                // r2 skyder mod r1, hit or miss
                if (r2_v > r1_s) score_r2++;
                gdata.TilfoejKamp("r2 skyder mod r1", r1_s, r2_v);

            }

            // Score gøres op
            if (score_r1 > score_r2)
            {
                r1.newWin();
                r2.newLoose();
            }
            else
            {
                if (score_r2 > score_r1)
                {
                    r2.newWin();
                    r1.newLoose();
                }
                else
                {
                    r1.newUafgjort();
                    r2.newUafgjort();
                }
            }

            save();
            return 0;
        }

        private void save() {
            r1.saveRobot();
            r2.saveRobot();
        }
    }
}