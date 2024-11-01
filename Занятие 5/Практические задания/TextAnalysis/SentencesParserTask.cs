﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var sentenceSeparators = new char[] { '.', '!', '?', ';', ':', '(', ')' };
            var sentences = text.Split(sentenceSeparators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var sentence in sentences)
            {
                var words = ExtractWordsFromSentence(sentence);
                if (words.Count > 0)
                {
                    sentencesList.Add(words);
                }
            }

            return sentencesList;
        }

        private static List<string> ExtractWordsFromSentence(string sentence)
        {
            var words = new List<string>();
            var currentWord = new StringBuilder();

            foreach (var ch in sentence)
            {
                if (char.IsLetter(ch) || ch == '\'')
                {
                    currentWord.Append(char.ToLower(ch));
                }
                else if (currentWord.Length > 0)
                {
                    words.Add(currentWord.ToString());
                    currentWord.Clear();
                }
            }

            if (currentWord.Length > 0)
            {
                words.Add(currentWord.ToString());
            }

            return words;
        }
    }
}
