using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Constants
    {
        public const string HomeMsg = "Enter scrambled word(s) manually or as a file: F - file / M - manual";
        public const string ContinueMsg = "Continue? Y/N";
        public const string EmptyStringErrorMsg = "String is empty";
        public const string CaseFMsg = "Enter full path including the file name: ";
        public const string CaseMMsg = "Enter word(s) manually (separated by commas if multiple): ";
        public const string CaseErrorMsg = "The entered option was not recognized.";
        public const string ContinueErrorMsg = "invalid input try again Y/N";
        public const string TerminationMsg = "The program will be terminated.";
        public const string Path = @"C:\Users\Misha\Downloads\WordUnscrambler_Startup_Code\WordUnscrambler\wordlist.txt";
        public const string ScrambledInput = "your word : ";
        public const string MatchedOutput = " Matched Word: ";
        public const string NoMatchMsg = "No Matches Found";
        public const string File = "F";
        public const string Manual = "M";
        public const string Yes = "Y";
        public const string No = "N";
        public const char Split = ',';
    }
}
