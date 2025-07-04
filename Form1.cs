using Microsoft.Data.SqlClient;
using NetSpell.SpellChecker;
using NetSpell.SpellChecker.Dictionary;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace WordGenerator
{
    public partial class Form1 : Form
    {
        private const string ConnectionString = "Server=DESKTOP-S7ECFH7\\SQLEXPRESS;Database=WordGenerator;Integrated Security=True;TrustServerCertificate=True;";
        private Spelling spellChecker;

        public Form1()
        {
            InitializeComponent();
            spellChecker = new Spelling();
            WordDictionary dict = new WordDictionary
            {
                DictionaryFile = "dic/en-US.dic"
            };
            dict.Initialize();
            spellChecker.Dictionary = dict;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string letters = textBox1.Text.ToLower();
            string requiredLetters = textBox2.Text.ToLower();
            int minLength = int.Parse(textBox3.Text);

            listView1.Items.Clear();

            // check if already cached then load from db
            List<string> cachedWords = GetCachedWords(letters, requiredLetters, minLength);
            if (cachedWords != null)
            {
                foreach (var word in cachedWords)
                {
                    listView1.Items.Add(word);
                }
                MessageBox.Show("Results loaded from cache");
                return;
            }


            // otheriwse geenrating if not cached
            List<string> validWords = GenerateWords(letters, requiredLetters, minLength);

            // cache the words
            CacheWords(letters, requiredLetters, minLength, validWords);


            // show results
            foreach (var word in validWords)
            {
                listView1.Items.Add(word);
            }

        }

        private string SortLetters(string letters)
        {
            // to lwoercase and in alphabetical order
            char[] chars = letters.ToLower().ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }

        // loading cached words from db
        private List<string> GetCachedWords(string letters, string requiredLetters, int minLength)
        {
            string sortedLetters = SortLetters(letters);
            string sortedRequiredLetters = SortLetters(requiredLetters);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = @"
            SELECT word
            FROM CachedWords
            WHERE letters = @letters
              AND requiredLetters = @requiredLetters
              AND minLength = @minLength";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@letters", sortedLetters);
                    command.Parameters.AddWithValue("@requiredLetters", sortedRequiredLetters);
                    command.Parameters.AddWithValue("@minLength", minLength);

                    var cachedWords = new List<string>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cachedWords.Add(reader["word"].ToString());
                        }
                    }
                    //  use optional to return null?
                    return cachedWords.Any() ? cachedWords : null;
                }
            }
        }

        // saving to db uncached words
        private void CacheWords(string letters, string requiredLetters, int minLength, List<string> words)
        {

            string sortedLetters = SortLetters(letters);
            string sortedRequiredLetters = SortLetters(requiredLetters);


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = @"
            INSERT INTO CachedWords (letters, requiredLetters, minLength, word)
            VALUES (@letters, @requiredLetters, @minLength, @word)";

                foreach (var word in words)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@letters", sortedLetters);
                        command.Parameters.AddWithValue("@requiredLetters", sortedRequiredLetters);
                        command.Parameters.AddWithValue("@minlength", minLength);
                        command.Parameters.AddWithValue("@Word", word);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }


        // to generate correct words based on inputs
        //private List<string> GenerateWords(string letters, string requiredLetters, int minLength)
        //{
        //    var validWords = new List<string>();

        //    // Get all words from NetSpell's dictionary
        //    var netSpellWords = spellChecker.Dictionary.BaseWords.Keys;

        //    // Filter for min length and required letters against dict
        //    foreach (string word in netSpellWords)
        //    {
        //        //Parallel.ForEach(netSpellWords, word =>
        //        //{

        //        if (word.Length < minLength) 
        //        {
        //            continue;
        //        }

        //        // Skip words that do not have required letter
        //        bool containsRequired = requiredLetters.All(letter => word.Contains(letter));
        //        if (!containsRequired)
        //        {
        //            continue;
        //        }

        //        // Skip words that contain letters not in the input letters
        //        bool usesOnlyInputLetters = word.All(letter => letters.Contains(letter));
        //        if (!usesOnlyInputLetters)
        //        {
        //            continue;
        //        }

        //        // add to validWord List
        //        validWords.Add(word);
        //    }

        //    return validWords;
        //}




        private List<string> GenerateWords(string letters, string requiredLetters, int minLength)
        {
            var validWords = new ConcurrentBag<string>();

            // netspell dict 
            var netSpellWords = spellChecker.Dictionary.BaseWords.Keys;

            // trying paralell processing
            Parallel.ForEach(netSpellWords.Cast<string>(), word =>
            {
                
                if (word.Length < minLength)
                {
                    return;
                }

                bool containsRequired = requiredLetters.All(letter => word.Contains(letter));
                if (!containsRequired)
                {
                    return;
                }

                bool usesOnlyInputLetters = word.All(letter => letters.Contains(letter));
                if (!usesOnlyInputLetters)
                {
                    return;
                }

                validWords.Add(word);
            });

            return validWords.ToList();
        }


    }
}
