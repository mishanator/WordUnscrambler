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
                    Console.WriteLine(Constants.HomeMsg);

                    String option = Console.ReadLine() ?? throw new Exception(Constants.EmptyStringErrorMsg);

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.WriteLine(Constants.CaseFMsg);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case Constants.Manual:
                            Console.WriteLine(Constants.CaseMMsg);
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine(Constants.CaseErrorMsg);
                            break;
                    }

                    


                }
                catch (Exception ex)
                {
                    Console.WriteLine(Constants.TerminationMsg + ex.Message);

                }
                Console.WriteLine(Constants.ContinueMsg);
                String cont = Console.ReadLine() ?? throw new Exception(Constants.ContinueErrorMsg);
                switch (cont.ToUpper())
                {
                    case Constants.Yes:
                        continues = true;
                        break;
                    case Constants.No:
                        continues = false;
                        break;
                    default:
                        Console.WriteLine(Constants.CaseErrorMsg);
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
           
            string[] scrambledWords = userInput.Split(Constants.Split);
            
                DisplayMatchedUnscrambledWords(scrambledWords);
            

        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {

            string path = Constants.Path;
            
            //read the list of words from the system file. 
            string[] wordList = _fileReader.Read(path);
            
            //call a word matcher method to get a list of structs of matched words.
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);
            
            if (matchedWords.Any()){
                foreach (var match in matchedWords)
                {
                    Console.WriteLine(Constants.ScrambledInput+match.ScrambledWord+Constants.MatchedOutput+match.Word);
                }
            }
            else{ 
                Console.WriteLine(Constants.NoMatchMsg);
            }
        }
    }
}
