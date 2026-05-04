using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace StringUtilities{
    public class StringProcessor{
        public static List<string> GetUniqueWords(string input){
            var words = input.Split(new char[]{' ', '.', ',', '!', '?'}, StringSplitOptions.RemoveEmptyEntries);
            return words.Select(word => word.ToLower()).Distinct().ToList();
        }
        public static string ReverseString(string input){
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static int CountVowels(string input){
            return input.Count(c => "aeiouAEIOU".Contains(c));
        }
        public static int CountConsonants(string input){
            return input.Count(c => char.IsLetter(c) && !"aeiouAEIOU".Contains(c));
        }
        public static Dictionary<char, int> CountCharacterFrequency(string input){
            return input.Where(char.IsLetter).GroupBy(c => char.ToLower(c)).ToDictionary(g => g.Key, g => g.Count());
        }
        public static string RemoveWhitespace(string input){
            return string.Concat(input.Where(c => !char.IsWhiteSpace(c)));
        }
        public static string ToTitleCase(string input){
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }
        public static void Main(){
            string testString = "Hello, World! This is a test string."
;            var uniqueWords = GetUniqueWords(testString);
            var reversed = ReverseString(testString);
            var vowelCount = CountVowels(testString);
            var consonantCount = CountConsonants(testString);
            var frequency = CountCharacterFrequency(testString);
            var noWhitespace = RemoveWhitespace(testString);
            var titleCased = ToTitleCase(testString);
            Console.WriteLine(string.Join(", ", uniqueWords));
            Console.WriteLine(reversed);
            Console.WriteLine(vowelCount);
            Console.WriteLine(consonantCount);
            Console.WriteLine(string.Join(", ", frequency.Select(kv => kv.Key + ": " + kv.Value)));
            Console.WriteLine(noWhitespace);
            Console.WriteLine(titleCased);
        }
    }
}
