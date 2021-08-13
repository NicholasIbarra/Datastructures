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

                foreach (char ch in word.ToCharArray())
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
