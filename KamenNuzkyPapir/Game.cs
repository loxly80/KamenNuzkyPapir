using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows.Threading;

namespace KamenNuzkyPapir
{
    public class Game
    {
        private DispatcherTimer timer;
        public Player Player1 { get; }
        public Player Player2 { get; }

        public event Action FightFinished;

        public Game(int money)
        {
            Player1 = new Player(money);
            Player2 = new Player(money);
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Tick += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, EventArgs e)
        {
            var p1 = Player1.GetState();
            var p2 = Player2.GetState();

            if(p1 != p2)
            {
                if (p1 == PlayerState.Kámen)
                {
                    if(p2 == PlayerState.Nůžky)
                    {
                        Player1.Win();
                        Player2.Lose();
                    }
                    else
                    {
                        Player1.Lose();
                        Player2.Win();
                    }
                }
                else if (p1 == PlayerState.Nůžky)
                {
                    if (p2 == PlayerState.Kámen)
                    {
                        Player1.Lose();
                        Player2.Win();
                    }
                    else
                    {
                        Player1.Win();
                        Player2.Lose();
                    }
                }
                else
                {
                    if (p2 == PlayerState.Nůžky)
                    {
                        Player1.Lose();
                        Player2.Win();
                    }
                    else
                    {
                        Player1.Win();
                        Player2.Lose();
                    }
                }
            }
            FightFinished?.Invoke();
        }

        public void Start()
        {
            timer.Start();
        }
    }
}
