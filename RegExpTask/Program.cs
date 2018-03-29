using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegExpTask
{
    class Program
    {
        static void Main(string[] args)
        {


            string text = @"
            A regular expression, regex or regexp[1] (sometimes called a rational expression)[2][3] is, in theoretical computer science and formal language theory, 
            a sequence of characters that define a search pattern. Usually this pattern is then used by string searching algorithms for ""find"" or ""find and replace"" 
            operations on strings.

            The concept arose in the 1950s when the American mathematician Stephen Cole Kleene formalized the description of a regular language.
            The concept came into common use with Unix text - processing utilities.Since the 1980s, different syntaxes for writing regular expressions exist, 
            one being the POSIX standard and another, widely used, being the Perl syntax.

            Regular expressions are used in search engines, search and replace dialogs of word processors and text editors, in text processing utilities 
            such as sed and AWK and in lexical analysis.Many programming languages provide regex capabilities, built -in or via libraries.";

            List<Match> matchedElements = new List<Match>();

            string patternForLinks = @"(\[(\d+)\])";
            Regex regexForLinks = new Regex(patternForLinks);
            MatchCollection links = regexForLinks.Matches(text);

            foreach(Match match in links)
            {
                matchedElements.Add(match);
            }
            string correctedText = Regex.Replace(text, patternForLinks, String.Empty);
            Console.WriteLine(@"Corrected text: {0}" , correctedText.Trim());

            Console.WriteLine("-----------------------------------");
            
            Regex patternForYears = new Regex(@"\d{4}[s]");
            MatchCollection years = patternForYears.Matches(text);

            foreach(Match match in years)
            {
                Console.WriteLine(match);
                matchedElements.Add(match);
            }

            Console.WriteLine("-----------------------------------");

            Regex patternForWordRegular = new Regex(@"\bregular\b", RegexOptions.IgnoreCase);
            MatchCollection wordsRegular = patternForWordRegular.Matches(text);

            foreach(Match match in wordsRegular)
            {
                matchedElements.Add(match);
            }
            Console.WriteLine(@"Regular word is repeated {0} times", wordsRegular.Count);

            Console.WriteLine("-----------------------------------");

            Console.WriteLine("Positions of the regular expressions in text:");

            
            foreach (Match match in matchedElements)
            {
                Console.WriteLine(match.Index);
            }
        }        
    }
}
