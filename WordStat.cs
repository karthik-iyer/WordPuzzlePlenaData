namespace WordPuzzle
{
    public class WordStat
    {
        public string Letter { get; set; }
        public int  Rank { get; set; }
        public int NumberOfOccurences { get; set; }

        public bool IsUpperCase { get; set; }
    }
}