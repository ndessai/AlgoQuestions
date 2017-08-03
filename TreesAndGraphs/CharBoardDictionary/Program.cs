using System;
using System.Collections.Generic;

/*
Write a method 

List<string> GetMatchingWords(char [,] board, HashSet<string> words);

words is a dictionary of valid char combinations.
board is NxN matrix of characters. 

The method should return all valid words that can be found in the board. 
You get a string combination on the board by selecting a cell and then iterating through neighbor cells.

Clarifications:
1. While building a string, can we use the same cell already used: NO
2. We can assume all chars to be small letters - to avoid case sensitive comparison: YES

//This looks more like a standard DFS algo with repetitively applying it on every cell. 
//Every cell selection could be O(N2). 
//DFS is O(v+E) - here no of vertices is N2 a
//          => no of vertices is N2
            => no of edges is little complex
                -> from first cell you go to 8 edges, second you got 7, and so on.. so i think (?) it 
                    will be CN2 (C is constant)
            => so graph itself will be O(N2 + CN2) => O(N2)
// So it would be O(N2 * N2) -> O(N4) ??

// a few optimizations to consider:
1. If we can get max_size that is the maximum length of any word in dictionary, then we use that and abort
2. We abort the outer loop once we exchaust all words in dictionary

General outline
1. bool IsValidEdge(bool [,] searchPath, int r, int c) //return true if row, column is not in search path
2. bool IsPrefixMatching(string prefix, HashSet<string> words) // return if prefix is worth considering
3. List<string> GetMatchedStrings(char[,] board, HashSet<string> words, bool [,] searchPath, string prefix, int r, int c) // get strings for each cell 
4. Invoke #3 for each cell

*/


class Program
{
    private int MAX_WORD_SIZE = 5;
    private int BOARD_SIZE = 10;

    static void Main(string[] args)
    {
        char[,] board = new char[, ]
        { {'a', 'b', 'c', 'd' },
            {'e', 'f', 'g', 'h' },
            {'i', 'j', 'k', 'l' },
            {'m', 'n', 'o', 'p' }
        };
        
        HashSet<string> words = new HashSet<string>();
        words.Add("a");
        words.Add("ab");
        words.Add("aa");
        words.Add("af");
        words.Add("kfb");
        words.Add("kfba");
        words.Add("kopl");
        words.Add("jnoklp");
        words.Add("p");

        words.Add("gp");
        words.Add("bp");

        var p = new Program();
        p.BOARD_SIZE = 4;
        p.MAX_WORD_SIZE = 6;
        var result = new List<string>();

        for(int i =0; i<4; i++)
        {
            for(int j=0; j< 4; j++)
            {
                bool[,] searchPath = new bool[4,4];
                for (int x = 0; x < 4; x++) for (int y = 0; y < 4; y++) searchPath[x, y] = false;
                searchPath[i, j] = true;
                string prefix = board[i, j].ToString();
                if (words.Contains(prefix))
                {
                    result.Add(prefix);
                }
                else if (!p.IsPrefixMatching(prefix, words)) continue;
                result.AddRange(p.GetMatchedStrings(board, words, searchPath, prefix, i, j));
            }
        }

        foreach(var str in result)
        {
            Console.WriteLine(str);

        }
        Console.Read();

    }

    private bool IsValidEdge(bool [,] searchPath, int r, int c)
    {
        return r>=0 && c>= 0 && r< BOARD_SIZE && c< BOARD_SIZE && !searchPath[r, c];
    }

    private IEnumerable<KeyValuePair<int, int>> GetNextNode(bool[,] searchPath, int r, int c)
    {
        if (IsValidEdge(searchPath, r - 1, c - 1)) yield return new KeyValuePair<int, int>(r - 1, c - 1);
        if (IsValidEdge(searchPath, r - 1, c )) yield return new KeyValuePair<int, int>(r - 1, c);
        if (IsValidEdge(searchPath, r - 1, c + 1)) yield return new KeyValuePair<int, int>(r - 1, c + 1);
        if (IsValidEdge(searchPath, r , c - 1)) yield return new KeyValuePair<int, int>(r, c - 1);
        if (IsValidEdge(searchPath, r, c + 1)) yield return new KeyValuePair<int, int>(r, c + 1);
        if (IsValidEdge(searchPath, r + 1, c - 1)) yield return new KeyValuePair<int, int>(r + 1, c - 1);
        if (IsValidEdge(searchPath, r + 1, c)) yield return new KeyValuePair<int, int>(r + 1, c);
        if (IsValidEdge(searchPath, r + 1, c + 1)) yield return new KeyValuePair<int, int>(r + 1, c + 1);
        yield break;
    }

    private bool IsPrefixMatching(string prefix, HashSet<string> words)
    {
        foreach(var word in words)
        {
            if (word.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) return true;
        }
        return false;
    }

    private List<string> GetMatchedStrings(char[,] board, HashSet<string> words, bool[,] searchPath, string prefix, int r, int c)
    {
        var result = new List<string>();
        if (MAX_WORD_SIZE <= prefix.Length) return result;

        foreach(var nextNode in GetNextNode(searchPath, r, c))
        {
            string newString = prefix + board[nextNode.Key, nextNode.Value];
            if(words.Contains(newString))
            {
                result.Add(newString);
            }
            else if (!IsPrefixMatching(newString, words)) continue;
            searchPath[nextNode.Key, nextNode.Value] = true;
            var subResult = GetMatchedStrings(board, words, searchPath, newString, nextNode.Key, nextNode.Value);
            result.AddRange(subResult);
        }
        return result;
    }
}

