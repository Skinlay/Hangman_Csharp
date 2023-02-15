using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            input_word();
            under_score();
            gess();
        }

        public static string answer { get; set; } = "";
        public static string user_word { get; set; } = "";
        public static int user_word_length { get; set; } = 0;
        public static string word_lines { get; set; } = "";
        public static int word_line_count { get; set; } = 0;
        //public static var letter { get; set; } = "";
        public static string user_gess { get; set; } = "";
        public static int lives { get; set; } = 10;

        public static List<char> letter = new List<char>();


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
                //letter.Add(key.KeyChar);

                //couts the lengt of het users input
                user_word_length = user_word.Length;
            }
            //put each letter of the ginven word in a list
            // letter is a local varialbal is this the reason  it cant be call outside the loop?

            //List<char> letter = new List<char>();
            letter.AddRange(user_word);

            

            //print the list of letters
            Console.WriteLine(string.Join(" ", letter));
            //Console.WriteLine(letter);
            Console.WriteLine(user_word + " " + user_word_length);
        }
        static void under_score()
        {
            //print lins the lengt of the given word
            while (word_line_count < user_word_length)
            {
                word_lines += ("_");
                word_line_count++;
            }
            Console.WriteLine(word_lines);
        }

         static void gess()
        {
            user_gess = Console.ReadLine();
            Console.WriteLine(user_gess);
        }
        //user input - word
        //make input invisebel word
        //print lines
        //user gess
        //user lives
    }
}