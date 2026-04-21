namespace dualis
{
    internal class Program
    {
        public static string encryption(string word,string key)
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
            string result1 = "";
            string result2 = "";

            foreach (string word in words) 
            {
                for (int i = 0; i < word.Count(); i++)
                {
                    var charcode = letters.IndexOf(message1[i]) - letters.IndexOf(word[i]);
                    if (charcode < 0)
                        result1 += letters[charcode + 27];
                    else result1 += letters[charcode];
                }

                for (int i = 0; i < result1.Length; i++)
                {
                    var charcode = letters.IndexOf(message2[i]) - letters.IndexOf(result1[i]);
                    if (charcode < 0)
                        result2 += letters[charcode + 27];
                    else result2 += letters[charcode];
                }
                if (words.Contains(result2))
                {
                    
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(encryption("curiosity killed the cat", "xqmvkzpldsaowieurtnbcgyhfj qlpmzoxkcvbnasdertyu"));
            Console.WriteLine(encryption("early bird catches the worm", "xqmvkzpldsaowieurtnbcgyhfj qlpmzoxkcvbnasdertyu"));
            Console.WriteLine("zjccyqxdarkwgtixqlufbiy", "aqcfhyqtuv qwagavkmujkxct l");
        }
    }
}
