using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCode
{
    class Key
    {
        public int key { get; set; }
        public char value { get; set; }

        public Key(int key, char _value)
        {
            this.key = key;
            this.value = _value;
        }
        
    }
    class Word
    {
        public int key { set; get; }
        public char value { set; get; }
        public Word(int key, char _value)
        {
            this.key = key;
            this.value = _value;
        }
        public Word()
        {
            this.key = 0;
            this.value = ' ';
        }
    }
    class Vigenere
    {
        
        static Dictionary<int, char> conformityTable { get; set; }
        static List<Key> keyValue { get; set; }
        static List<Word> wordValue { get; set; }
        static List<Key> newKeyValue { get; set; }
        public static List<Word> newWordValue { get; set; }



        /// <summary>
        /// Метод установки алфавита
        /// </summary>
        /// <param name="abc">RU\EN</param>
        public static void setConformityTable(string abc)
        {
            
            conformityTable = new Dictionary<int, char>();
            int numb = 0;
            if (abc == "RU" || abc == "ru" || abc =="Ru")
            {
                for (int code = 'а'; code <= 'я'; code++)
                {
                    conformityTable.Add(numb++, (char)code);
                }
            }
            else if (abc == "EN" || abc == "en" || abc == "En")
            {
                for (int code = 'a'; code <= 'z'; code++)
                {
                    conformityTable.Add(numb++, (char)code);
                }
            }
            else throw new setConformityTableException("Введённое значение не соответсвует выбору \"RU\\EN\"!");
            
        }

        /// <summary>
        /// Метод для установки ключа
        /// </summary>
        /// <param name="key">Ключ</param>
        public static void setKey(string key)
        {
            if (key.Length == 0) throw new setKeyException("Ключ не может быть пустым! Измените ключ...");

            key = key.ToLower();
            

            keyValue = new List<Key>();
            foreach(char symbol in key)
            {
                
                foreach (KeyValuePair<int, char> pair in conformityTable)
                {
                    if (pair.Value == symbol)
                    {
                        keyValue.Add(new Key(pair.Key, pair.Value));
                    }
                }
            }
            if (keyValue.Count == 0) throw new setKeyException("Ключ введён на алфавите отличном от выбранного! Измените ключ...");
        }
       
        /// <summary>
        /// Метод для формирования окончательного ключа
        /// </summary>
        /// <param name="oldKey"></param>
        public static void setNewKey(string oldKey)
        {
            
            oldKey = oldKey.ToLower();

            newKeyValue = new List<Key>();
            foreach (char symbol in oldKey)
            {

                foreach (KeyValuePair<int, char> pair in conformityTable)
                {
                    if (pair.Value == symbol)
                    {
                        newKeyValue.Add(new Key(pair.Key, pair.Value));
                    }
                }
            }
        }

        /// <summary>
        /// Метод для установки строки для кодирования
        /// </summary>
        /// <param name="word">Слово</param>
        public static void setWord(string word)
        {
            if (word.Length == 0) throw new setWordException("Нет слова для кодирования!");

            word = word.ToLower();

            wordValue = new List<Word>();
            foreach (char symbol in word)
            {

                foreach (KeyValuePair<int, char> pair in conformityTable)
                {
                    if (pair.Value == symbol)
                    {
                        wordValue.Add(new Word(pair.Key, pair.Value));
                    }
                }
            }
            if (wordValue.Count == 0) throw new setWordException("Слово введено на алфавите отличном от выбранного! Измените слово...");

        }

        /// <summary>
        /// Метод для кодирования строки
        /// </summary>
        public static void Encode()
        {
            int count = 0;
            int abcMod = conformityTable.Count;
            int newKey;
            Word[] wordKey = new Word[wordValue.Count];
            Key[] keyKey = new Key[newKeyValue.Count];
            Word[] newWordKey = new Word[wordValue.Count];

            wordKey = wordValue.ToArray();
            keyKey = newKeyValue.ToArray();

            while (count != wordKey.Length)
            {
                newKey = wordKey[count].key + keyKey[count].key;
                if (newKey >= abcMod)
                {
                    newKey = abcMod - newKey;
                }
                newWordKey[count] = new Word();
                newWordKey[count].key = newKey;
                char Value;
                conformityTable.TryGetValue(newKey, out Value);
                newWordKey[count].value = Value;
                count++;
            }

            newWordValue = new List<Word>();
            foreach (Word value in newWordKey)
            {
                newWordValue.Add(value);
            }
            
        }

        /// <summary>
        /// Метод для декодирования строки
        /// </summary>
        /// <param name="encodeString">Закодированная строка</param>
        public static void Decode(string encodeString)
        {

            
        }
        /// <summary>
        /// Метод для вывода закодированной строки на экран
        /// </summary>
        public static void printEncodeWord()
        {
            foreach (Word symbol in newWordValue)
            {
                Console.Write(symbol.value);
            }
        }

    }
    class setConformityTableException : Exception
    {
        public setConformityTableException(string message)
            : base(message)
        { }

    }
    class setKeyException : Exception
    {
        public setKeyException(string message)
            : base(message)
        { }

    }
    class setWordException : Exception
    {
        public setWordException(string message)
            : base(message)
        { }

    }
}
