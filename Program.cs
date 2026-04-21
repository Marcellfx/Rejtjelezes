using static System.Runtime.InteropServices.JavaScript.JSType;

namespace dualis
{
    public class Program
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

        public static List<string> decoding(string message1, string message2)
        {
            var letters = "abcdefghijklmnopqrstuvwxyz ";
            List<string> words = new List<string>(File.ReadAllLines("words.txt"));
            List<string> keys = new List<string>();

            foreach (string word in words)
            {
                string key = "";
                string currentword = "";
                bool reason = false;

                if (word.Length > message1.Length)
                {
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
                        currentword = "";
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
                                key = "";
                                currentword = "";
                                reason = true;
                                break;
                            }
                        }

                        if (reason)
                            break;

                        foreach (var item in words)
                        {
                            if (item.StartsWith(currentword) && item.Length > currentword.Length)
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
                        currentword = "";
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
                                key = "";
                                currentword = "";
                                reason = true;
                                break;
                            }
                        }

                        if (reason)
                            break;

                        foreach (var item in words)
                        {
                            if (item.StartsWith(currentword) && item.Length > currentword.Length)
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

                if (reason)
                    continue;

                keys.Add(key);
            }
            return keys;
        }


        static void Main(string[] args)
        {
        }
    }    
}
