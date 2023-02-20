using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            input_word();
            while (lives > 0)
            {
                under_score();
                gess();
                PrintHangman(lives);
            }

        }

        public static string user_word { get; set; } = "";
        public static int user_word_length { get; set; } = 0;
        public static string word_lines { get; set; } = "";
        public static int word_line_count { get; set; } = 0;
        public static string user_gess { get; set; } = "";
        public static int lives { get; set; } = 10;

        public static List<char> answer = new List<char>();
        public static int user_gess_length { get; set; } = 0;
        public static char user_gess_char { get; set;}
        public static List<char> Correct_gess = new List<char>();


        static void input_word()
        {
            Console.WriteLine("welkom to the Hangman game");
            
            while (true)
            {
                //makes user inpute invisebel 
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                user_word += key.KeyChar;
                //answer.Add(key.KeyChar);

                //couts the lengt of het users input
                user_word_length = user_word.Length;
            }
            //put each letter of the ginven word in a list
            // letter is a local varialbal is this the reason  it cant be call outside the loop?

            //List<char> answer = new List<char>();
            answer.AddRange(user_word);

            //Console.BackgroundColor = ConsoleColor.Blue;
                // Console.WriteLine the list of letters
            //Console.WriteLine(string.Join(" ", answer));
                //Console.WriteLine(answer);
            //Console.WriteLine("user_word = " + user_word + "  user_word_length = " + user_word_length);
            //Console.ResetColor();
        }
        public static void under_score()
        {
            foreach (char letter in answer)
            {
                if (Correct_gess.Contains(letter))
                {
                    Console.Write(letter);
                }
                else
                {
                    Console.Write('_');
                }
            }
            Console.Write( "\r\n");
        }
        //als de lente langer is dan 1 -> contorleer de heel worden --> correct? -> einde game -- incorect? - 1 leven, raad opnieuw 
        //is de lengte 1 lang --> controleer of de letter in het woord zit --> correct? zet woord in lijst met letters --> raad op nieuw.
        //              incorect? -1 leven --> sla letter op in lijst, -->
        //              levens 0? nee ga verder -- ja, einde geme verlooren.
        //
        static void gess()
        {
            user_gess = Console.ReadLine();
            //Console.WriteLine("user_gess = " + user_gess);
            //Console.BackgroundColor = ConsoleColor.Blue;
            user_gess_length = user_gess.Length;

            if (user_gess_length == 1)
            {
                user_gess_char = Convert.ToChar(user_gess);
                //Console.WriteLine("user_gess_char = " + user_gess_char);
                if (answer.Contains(user_gess_char))
                {
                    Console.WriteLine("nice");
                    Correct_gess.Add(user_gess_char);
                }
                else
                {
                    lives -= 1;
                    Console.WriteLine();
                }
            }
            else if (user_gess == user_word)
            {
                Console.WriteLine("noice you win the game");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("nope");
                lives -= 1;
            }
        }
        //user input - word
        //make input invisebel word
        // Console.WriteLine lines
        //user gess
        //user lives

        public static void PrintHangman(int lives)
        {
            char[] lineChars = new[] // https://www.asciitable.com/ alt + cijfer code...
            {
                '└', //0
                '┐', //1
                '┘', //2
                '┌', //3
                '─', //4
                '│', //5
                ' ', //6
                '┬', //7
                'O', //8
                '┴', //9
            };
            int width = 9;
            int height = 9;
            int[,] hangman = new int[,]
            {
                { 3, 4, 4, 4, 7, 4, 4, 4, 1 },
                { 5, 6, 6, 6, 5, 6, 6, 6, 5 },
                { 5, 6, 6, 6, 8, 6, 6, 6, 5 },
                { 5, 6, 6, 3, 7, 1, 6, 6, 5 },
                { 5, 6, 6, 5, 5, 5, 6, 6, 5 },
                { 5, 6, 6, 3, 9, 1, 6, 6, 5 },
                { 5, 6, 6, 5, 6, 5, 6, 6, 5 },
                { 5, 6, 6, 6, 6, 6, 6, 6, 5 },
                { 0, 4, 4, 4, 4, 4, 4, 4, 2 },
            };
            int[,] livesMask = new int[,]
            {
                { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
                { -1, -1, -1, -1,  9, -1, -1, -1, -1 },
                { -1, -1, -1, -1,  8, -1, -1, -1, -1 },
                { -1, -1, -1,  6,  7,  4, -1, -1, -1 },
                { -1, -1, -1,  5,  7,  3, -1, -1, -1 },
                { -1, -1, -1,  1,  2,  0, -1, -1, -1 },
                { -1, -1, -1,  1, -1,  0, -1, -1, -1 },
                { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
                { -1, -1, -1, -1, -1, -1, -1, -1, -1 },
            };
            for (int x = 0; x < width; x++)
            {

                for (int y = 0; y < height; y++)
                {
                    if (livesMask[x, y] >= lives || livesMask[x, y] == -1)
                    {
                        Console.Write(lineChars[hangman[x, y]]);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("lives:" + lives);
        }

    }
}