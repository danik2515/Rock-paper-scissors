using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_paper_scissors {
    public class Rule {
        public Dictionary<string, string[]> winners { get; set; }
        public int countOfMove;
        public Rule(string[] args) {
            winners = new Dictionary<string, string[]>(args.Length);
            countOfMove = args.Length;
            for (int winI = 0; winI < args.Length; winI++) {
                string[] losers = new string[(args.Length - 1) / 2];
                for (int loseI = 0; loseI < (args.Length - 1) / 2; loseI++) {
                    losers[loseI] = args[((winI - loseI - 1) + args.Length) % args.Length];
                }
                winners.Add(args[winI], losers);
            }
        }
        public int WhoWin(string youMove, string compMove) {
            if (Array.IndexOf(winners.Keys.ToArray(), youMove) == -1 || Array.IndexOf(winners.Keys.ToArray(), compMove) == -1) {
                return -1;
            }
            if (youMove.Equals(compMove)) {
                //Console.WriteLine("Draw!");
                return 0;
            }
            if (Array.IndexOf(winners[compMove].ToArray(), youMove) == -1) {
                //Console.WriteLine("You Win!");
                return 1;
            }
            else {
                //Console.WriteLine("You lose!");
                return 2;
            }
        }
    }
}
