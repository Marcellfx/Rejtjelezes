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
                var charcode = letters.IndexOf(key[i]) + letters.IndexOf(word[i]);
                if (charcode > 26)
                    result += letters[charcode % 27];
                else result += letters[charcode];
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(encryption("helloworld", "abcdefgijkl"));
        }
    }
}
