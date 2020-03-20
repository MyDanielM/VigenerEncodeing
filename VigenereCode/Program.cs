using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCode
{
    class Program
    {
        static string key;
        static string word;
        static string getNewKey(string oldKey, string word)
        {
            string newKey = "";
            int n = 0;
            if (oldKey.Length < word.Length)
            {

                while (newKey.Length != word.Length)
                {
                    if (n == oldKey.Length) n = 0;
                    newKey += oldKey[n++];
                }
            }
            else
            {
                newKey = oldKey;
                while (newKey.Length != word.Length)
                {
                    newKey = newKey.Substring(0,newKey.Length-1);
                }
            }
            return newKey;

        }

        static void Main()
        {
            try
            {
                //Установка языка
                Console.Write("Выберете язык(RU\\EN): ");
                string abc = Console.ReadLine();
                Vigenere.setConformityTable(abc);

                //Установка ключа шифрования
                Console.Write("Введите ключ кодирования: ");
                key = Console.ReadLine();
                Vigenere.setKey(key);

                //Установка строки для шифрования
                Console.Write("Введите строку для кодирования: ");
                word = Console.ReadLine();
                Vigenere.setWord(word);

                //Получение нового ключа
                string newKey = getNewKey(key, word);
                Vigenere.setNewKey(newKey);
                
                //Кодированиние строки по методу Вижинера
                Vigenere.Encode();

                Console.Write("Закодированная строка: ");
                Console.Write("\"");
                Vigenere.printEncodeWord();
                Console.Write("\"");


                Console.Write("\nПопробуем ещё?(y\\n) ");
                if (Console.ReadLine() == "y")
                { Console.Clear(); Program.Main(); }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Program.Main();
            }
        }
    }
}
