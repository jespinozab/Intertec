using System;

public interface IService
{
    string ParseSentence(string input);
    string ProcessWord(string word);
    int GetDistinctCharCount(string str);

}