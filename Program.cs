using System;
using System.Security.Cryptography;
using System.Text;


namespace Rock_paper_scissors {
    class Program {

        static void Main(string[] args) {
            string example = "For example: Rock-paper-scissors.exe rock paper scissors";
            if (args.Length < 3) {
                Console.WriteLine("the number of moves is less than 3");
                Console.WriteLine(example);
                return;
            }else
            if (args.Length % 2 == 0) {
                Console.WriteLine("the number of moves is even");
                Console.WriteLine(example);
                return;
            }else
            if (args.Length!= args.Distinct().ToArray().Length) {
                Console.WriteLine("there are the same moves");
                Console.WriteLine(example);
                return;
            }

            Rule rule = new Rule(args);
            Table table = new Table(rule);
            string youMove="0";
            do {
                HmacKey hmacKey = new HmacKey(32);
                int compMove = new Random().Next(0, args.Length);
                Hmac hmac = new Hmac(hmacKey, args[compMove]);
                Console.WriteLine("HMAC: " + hmac.hmacHex);
                Console.WriteLine("Available moves:");
                int i = 1;
                foreach (string move in args) {
                    Console.WriteLine("{0}  -  "+move,i);
                    i++;
                }
                Console.WriteLine("0  -  exit");
                Console.WriteLine("?  -  help");
                Console.Write("Enter your move:");
                youMove = Console.ReadLine();
                if (youMove.Equals("?")) {
                    table.Print();
                    continue;
                }
                try {
                    string youMoveString = rule.winners.Keys.ToArray()[int.Parse(youMove)-1];
                    string compMoveString = rule.winners.Keys.ToArray()[compMove];
                    if (int.Parse(youMove) < args.Length && int.Parse(youMove) > 0) {
                        Console.WriteLine("Your move: " + youMoveString);
                        Console.WriteLine("Computer move: " + compMoveString);
                        if (rule.WhoWin(youMoveString, compMoveString) == 1) {
                            Console.WriteLine("You Win!");
                        }
                        else if(rule.WhoWin(youMoveString, compMoveString) == 2) {
                            Console.WriteLine("You Lose!");
                        }
                        else if (rule.WhoWin(youMoveString, compMoveString) == 0) {
                            Console.WriteLine("Draw!");
                        }
                        Console.WriteLine("HMAC key: " + hmacKey.hmacKeyHex);
                    }
                }
                catch {
                    
                }
            }
            while (!youMove.Equals("0"));
            


            
            
            
            
            
            
           
            
            
            

        }
    }

    

    

    
    
}