public class Service : IService
{
    public Service()
    {
        
    }

    public string GetResult(string input)
    {
        string output = ""; // Initialize an empty output string
        string currentWord = ""; // Initialize an empty string to build up the current word

        foreach (char c in input)
        {
            if (Char.IsLetter(c)) // If the character is a letter, add it to the current word
            {
                currentWord += c;
            }
            else // Otherwise, we've hit a word boundary
            {
                // Call ProcessWord on the current word and append the result, along with the non-letter character, to the output string
                output += ProcessWord(currentWord) + c;
                currentWord = ""; // Reset the current word to start building a new word
            }
        }

        // If we've reached the end of the input string but still have a current word, process it and append the result to the output string
        if (currentWord.Length > 0)
        {
            output += ProcessWord(currentWord);
        }

        return output; // Return the modified input string
    }

    public string ProcessWord(string word)
    {
        if (word.Length <= 1) // If the word is one character or less, just return it unchanged
        {
            return word;
        }

        // Otherwise, get the first and last characters of the word, and the number of distinct characters between them
        char first = word[0];
        char last = word[word.Length - 1];
        int distinctChars = GetDistinctCharCount(word.Substring(1, word.Length - 2));
        // Return a string that concatenates the first character, the number of distinct characters, and the last character
        return first + distinctChars.ToString() + last;
    }

    public int GetDistinctCharCount(string str)
    {
        int count = 0; // Initialize a count of distinct characters to zero
        string distinctChars = ""; // Initialize an empty string to keep track of distinct characters

        foreach (char c in str)
        {
            if (!distinctChars.Contains(c.ToString())) // If we haven't seen this character before, add it to the distinctChars string and increment the count
            {
                count++;
                distinctChars += c;
            }
        }

        return count; // Return the count of distinct characters
    }
}
