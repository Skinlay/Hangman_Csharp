﻿using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            input_word();
            under_score();
        }

        public static string answer { get; set; } = "";
        public static string user_word { get; set; } = "";
        public static int user_word_length { get; set; } = 0;
        public static string word_lines { get; set; } = "";
        public static int word_line_count { get; set; } = 0;
        public static string letter { get; set; } = "";

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
                //couts the lengt of het users input
                user_word_length = user_word.Length;
                //put each letter of the ginven word in a list
                // letter is a local varialbal is this the reason  it cant be call outside the loop?
                List<char> letter = new List<char>();
                letter.AddRange(user_word);
                //print the list of letters
                Console.WriteLine(string.Join(" ", letter));
            }
            Console.WriteLine(string.Join(" ", letter));
            Console.WriteLine(user_word + " " + user_word_length + " " + letter);
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
        //user input - word
        //make input invisebel word
        //print lines
        //user gess
        //user lives
    }

    internal class Letter
    {
    }
}