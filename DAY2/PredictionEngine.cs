﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictionEngine
{
    public class PredictionEngine
    {
        private ILanguageModelAlgo languageModelAlgo;

        public PredictionEngine(ILanguageModelAlgo algo)
        {
            this.languageModelAlgo = algo;
        }

        public string Predict(string inputPhrase)
        {
            string lastWord = GetLAstWord(inputPhrase);

            if(inputPhrase.EndsWith(" "))
            {
                return languageModelAlgo.predictUsingBigram(lastWord);
            }
            else
            {
               return languageModelAlgo.predictUsingMonogram(lastWord);
            }
        }

        private static string GetLAstWord(string inputPhrase)
        {
            string[] words = inputPhrase.Trim().Split(" ");
            string lastWord = words[words.Length - 1];
            return lastWord;
        }
    }
}
