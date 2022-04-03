namespace WordleClone
{
   public class Word
   {
        private string wordString;

        public Word(string wordString)
        {
            this.wordString = wordString;
            this.WordLength = wordString.Length;
            System.Console.WriteLine(this.wordString);
        }



        // create getter setter
        public string GetWordString()
        {
            return wordString;
        }

        // create getter setter

        public int WordLength { get;  }

   }
}