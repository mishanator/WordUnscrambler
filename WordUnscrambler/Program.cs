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
            bool go = true;
            while (go)
            {
                bool continues = true;
                do
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
                                continues = false;
                                break;
                            case Constants.Manual:
                                Console.WriteLine(Constants.CaseMMsg);
                                ExecuteScrambledWordsManualEntryScenario();
                                continues = false;
                                break;
                            default:
                                Console.WriteLine(Constants.CaseErrorMsg);
                                continues = true;
                                break;
                        }


                    }




                    catch (Exception ex)
                    {
                        Console.WriteLine(Constants.TerminationMsg + ex.Message);

                    }
                }
                while (continues == true);
                bool retry = true;
                do
                {
                    Console.WriteLine(Constants.ContinueMsg);
                    String cont = Console.ReadLine() ?? throw new Exception(Constants.ContinueErrorMsg);
                    switch (cont.ToUpper())
                    {
                        case Constants.Yes:
                            continues = true;
                            retry = false;
                            break;
                        case Constants.No:
                            go = false;
                            retry = false;
                            break;
                        default:
                            Console.WriteLine(Constants.CaseErrorMsg);
                            retry = true;
                            break;
                    }
                }
                while (retry == true);
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

           
            
            //read the list of words from the system file. 
            string[] wordList = _fileReader.Read(Constants.Path);
            
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
