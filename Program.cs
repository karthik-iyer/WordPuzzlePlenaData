using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WordPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Word in the Word Puzzle");

            var wordPuzzle = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(wordPuzzle))
            {
                Console.WriteLine("Cannot solve the Word Puzzle");
            }
            else if(wordPuzzle.Any(ch => char.IsDigit(ch)))
            {
                Console.WriteLine("Cannot solve the Word Puzzle");
            }
            else
            {
                var wordStatList = new List<WordStat>();
                var position = 0;
                foreach (var ch in wordPuzzle.ToCharArray())
                {
                    var wordStat = wordStatList.FirstOrDefault(x => x.Letter == ch.ToString().ToLower());
                    if (wordStat == null)
                    {
                        wordStatList.Add(new WordStat
                        {
                            Letter = ch.ToString().ToLower(),
                            NumberOfOccurences = 1,
                            Rank = position,
                            IsUpperCase = char.IsUpper(ch)
                        });
                    }
                    else
                    {
                        wordStat.NumberOfOccurences += 1;
                    }

                    position += 1;
                }

                var revisedWordList = wordStatList.OrderBy(x => x.NumberOfOccurences).ThenBy(x => x.Rank);

                Console.WriteLine($"First character from String: {revisedWordList.First().Letter} ");

                var reformattedString = string.Empty;

                foreach (var wordStat in revisedWordList)
                {
                    for (var count = 0; count < wordStat.NumberOfOccurences; count++)
                    {
                        reformattedString +=  wordStat.Letter;
                    }
                }
                Console.WriteLine($"Reformatted Output Word: {reformattedString}");

            }
        }
    }
}