using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
    Design a data structure that supports adding new words and finding if a string matches any previously added string.

    Implement the WordDictionary class:

    WordDictionary() Initializes the object.
    void addWord(word) Adds word to the data structure, it can be matched later.
    bool search(word) Returns true if there is any string in the data structure that matches word or false otherwise. word may contain dots '.' where dots can be matched with any letter.

     */

    class DesignAddAndSearchWordsDataStructure
    {
        public static void Test()
        {
            WordDictionary obj = new WordDictionary();

            List<string> words = new List<string>() { "WordDictionary", "addWord", "addWord", "addWord", "search", "search", "search", "search" };
            
            words.ForEach(word => obj.AddWord(word));

            List<string> searchable = new List<string> { "", "bad", "dad", "mad", "pad", "bad", ".ad", "b.."};

            foreach(var word in searchable)
            {
                Console.WriteLine(word + " : " + obj.Search(word));
            }
        }

        public class WordDictionary
        {
            TrieNode trie;

            public WordDictionary()
            {
                trie = new TrieNode();
            }

            public void AddWord(string word)
            {
                TrieNode node = trie;

                foreach (char ch in word)
                {
                    if (!node.children.ContainsKey(ch))
                    {
                        node.children.Add(ch, new TrieNode());
                    }

                    node = node.children[ch];
                }

                node.isWord = true;
            }

            public bool Search(string word)
            {
                return searchInNode(word, trie);
            }

            private bool searchInNode(string word, TrieNode node)
            {
                for (int i = 0; i < word.Length; ++i)
                {
                    char ch = word[i];

                    if (!node.children.ContainsKey(ch))
                    {
                        // Check all nodes at this level
                        if (ch == '.')
                        {
                            foreach (char x in node.children.Keys)
                            {
                                TrieNode child = node.children[x];
                                if (searchInNode(word.Substring(i + 1), child))
                                {
                                    return true;
                                }
                            }
                        }

                        // if no nodes lead to an answer or the current != '.'
                        return false;
                    }
                    else
                    {
                        // if the character is found, go down to the next level
                        node = node.children[ch];
                    }
                }

                return node.isWord;
            }
        }

        class TrieNode
        {
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public bool isWord;
        }
    }
}
