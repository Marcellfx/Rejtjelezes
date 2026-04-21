using static System.Runtime.InteropServices.JavaScript.JSType;

namespace dualis
{
    internal class Program
    {
        public static string encryption(string word, string key)
        {
            var letters = "abcdefghijklmnopqrstuvwxyz ";
            string result = "";

            if (key.Length < word.Length)
                return result = "túl rövid kulcs";

            for (int i = 0; i < word.Count(); i++)
            {
                if (letters.Contains(word[i]) && letters.Contains(key[i]))
                {
                    var charcode = letters.IndexOf(key[i]) + letters.IndexOf(word[i]);
                    if (charcode > 26)
                        result += letters[charcode % 27];
                    else result += letters[charcode];
                }
                else
                    return result = "nem angol abc beűét tartalmaz";
            }

            return result;
        }

        public static string decoding(string message1, string message2)
        {
            var letters = "abcdefghijklmnopqrstuvwxyz ";
            List<string> words = new List<string>(File.ReadAllLines("words.txt"));
            
            foreach (string word in words)
            {
                string result1 = "";
                string result2 = "";
                string key = "";
                string currentword = "";
                bool reason = false;

                if (word.Length > message1.Length)
                {
                    result1 = "";
                    result2 = "";
                    key = "";
                    continue;
                }

                for (int i = 0; i < word.Length; i++)
                {
                    var charcode = letters.IndexOf(message1[i]) - letters.IndexOf(word[i]);
                    if (charcode < 0)
                        key += letters[charcode + 27];
                    else key += letters[charcode];
                }

                bool second = true;
                while (key.Length < message1.Length || key.Length < message2.Length)
                {
                    if (second)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            var charcode = letters.IndexOf(message2[i]) - letters.IndexOf(key[i]);
                            if (charcode < 0)
                                currentword += letters[charcode + 27];
                            else currentword += letters[charcode];

                            bool valid = false;
                            foreach (var item in words)
                            {
                                if (item.StartsWith(currentword))
                                {
                                    valid = true;
                                    break;
                                }
                            }

                            if (!valid)
                            {
                                result1 = "";
                                result2 = "";
                                key = "";
                                currentword = "";
                                reason = true;
                                break;
                            }
                        }

                        if (reason)
                            continue;

                        foreach (var item in words)
                        {
                            if (item.StartsWith(currentword))
                            {
                                currentword = item;
                                break;
                            }
                        }

                        key = "";
                        for (int i = 0; i < currentword.Length; i++)
                        {
                            var charcode = letters.IndexOf(message2[i]) - letters.IndexOf(currentword[i]);
                            if (charcode < 0)
                                key += letters[charcode + 27];
                            else key += letters[charcode];
                        }
                        second = false;
                    }

                    else
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            var charcode = letters.IndexOf(message1[i]) - letters.IndexOf(key[i]);
                            if (charcode < 0)
                                currentword += letters[charcode + 27];
                            else currentword += letters[charcode];

                            bool valid = false;
                            foreach (var item in words)
                            {
                                if (item.StartsWith(currentword))
                                {
                                    valid = true;
                                    break;
                                }
                            }

                            if (!valid)
                            {
                                result1 = "";
                                result2 = "";
                                key = "";
                                currentword = "";
                                reason = true;
                                break;
                            }
                        }

                        if (reason)
                            continue;

                        foreach (var item in words)
                        {
                            if (item.StartsWith(currentword))
                            {
                                currentword = item;
                                break;
                            }
                        }

                        key = "";
                        for (int i = 0; i < currentword.Length; i++)
                        {
                            var charcode = letters.IndexOf(message1[i]) - letters.IndexOf(currentword[i]);
                            if (charcode < 0)
                                key += letters[charcode + 27];
                            else key += letters[charcode];
                        }
                        second = true;
                    }
                }

                //return key;
            }

            static void Main(string[] args)
            {
                Console.WriteLine(encryption("curiosity killed the cat", "xqmvkzpldsaowieurtnbcgyhfj qlpmzoxkcvbnasdertyu"));
                Console.WriteLine(encryption("early bird catches the worm", "xqmvkzpldsaowieurtnbcgyhfj qlpmzoxkcvbnasdertyu"));
                Console.WriteLine("zjccyqxdarkwgtixqlufbiy", "aqcfhyqtuv qwagavkmujkxct l");
            }
        }   
    }
}
