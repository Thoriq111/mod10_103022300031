namespace Modul10_103022300031
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public List<string> Stars { get; set; }
        public string Description { get; set; }

        public Movie(string Title, string Director, List<string> Stars, string Description) 
        {
            this.Title = Title;
            this.Director = Director;
            this.Stars = Stars;
            this.Description = Description;
        }
    }
}
