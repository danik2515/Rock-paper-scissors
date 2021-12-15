
using ConsoleTables;

namespace Rock_paper_scissors {
    public class Table {
        public Rule rule { get; set; }
        public Table(Rule _rule) {
            rule = _rule;
        }
        public void Print() {
            string[] colum = { "    ", "You:" };
            var arg = rule.winners.Keys.ToArray();
            colum = colum.Concat(arg).ToArray();
            var table = new ConsoleTable(colum);
            string[] row = new string[rule.countOfMove + 2];
            row[0] = "Computer:";
            table.AddRow(row);
            
            for (int i = 0; i < rule.countOfMove; i++) {
                row= new string[rule.countOfMove + 2];
                row[0]=arg[i];
                row[1]=" ";
                for (int j = 0; j < rule.countOfMove; j++) {
                    if (rule.WhoWin(arg[i], arg[j]) == 0) {
                        row[j+2]="draw";
                    }
                    else if (rule.WhoWin(arg[i], arg[j]) == 2) {
                        row[j + 2] = "win";
                    }
                    else {
                        row[j + 2]="lose";
                    }
                }
                table.AddRow(row);
            }
            table.Write();
        }
    }
}
