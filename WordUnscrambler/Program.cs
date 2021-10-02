using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)

        {
            bool continues = true;
            while (continues)
            {
                try
                {
                    Console.WriteLine("Enter scrambled word(s) manually or as a file: F - file / M - manual");

                    String option = Console.ReadLine() ?? throw new Exception("String is empty");

                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.WriteLine("Enter full path including the file name: ");
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case "M":
                            Console.WriteLine("Enter word(s) manually (separated by commas if multiple): ");
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine("The entered option was not recognized.");
                            break;
                    }

                    Console.ReadLine();


                }
                catch (Exception ex)
                {
                    Console.WriteLine("The program will be terminated." + ex.Message);

                }
                Console.WriteLine("Continue? Y/N");
                String cont = Console.ReadLine() ?? throw new Exception("String is empty");
                switch (cont.ToUpper())
                {
                    case "Y":
                        continues = true;
                        break;
                    case "N":
                        continues = false;
                        break;
                    default:
                        Console.WriteLine("The entered option was not recognized.");
                        break;
                }
                }
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            var filename = Console.ReadLine();
            string[] scrambledWords = _fileReader.Read(filename);
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            string userInput = Console.ReadLine();
           
            string[] scrambledWords = userInput.Split(',');
            
           DisplayMatchedUnscrambledWords(scrambledWords);

        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {

            string path = @"C:\Users\Misha\Downloads\WordUnscrambler_Startup_Code\WordUnscrambler\wordlist.txt";
            
            //read the list of words from the system file. 
            string[] wordList = _fileReader.Read(path);
            
            //call a word matcher method to get a list of structs of matched words.
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);
            if (matchedWords.Any())
            {
                foreach (var match in matchedWords)
                {
                    Console.WriteLine("your word: "+match.ScrambledWord+ " Matched Word: " +  match.Word);
                }
            }
            else{ 
                Console.WriteLine("no matches found");
            }
        }
    }
}
