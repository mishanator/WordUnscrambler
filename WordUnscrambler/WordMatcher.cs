using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (string scrambledWord in scrambledWords)
                foreach (var word in wordList)
                {
                    //scrambledWord already matches word
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase)) {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                       
                    }
                    else
                    {
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();
                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);
                        var sortedScrambled = new String(scrambledWordArray);
                        var sortedWord = new String(wordArray);
                        if (sortedScrambled.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                    }
                }
                return matchedWords;
            }

             MatchedWord BuildMatchedWord(string scrambledWord, string word)
            {
                MatchedWord matchedWord = new MatchedWord
                {
                    ScrambledWord = scrambledWord,
                    Word = word
                };

                return matchedWord;
                
            }
          

     } 
 }


