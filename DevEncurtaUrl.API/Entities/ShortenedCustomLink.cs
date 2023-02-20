namespace DevEncurtaUrl.API.Entities
{
    public class ShortenedCustomLink
    {
        public ShortenedCustomLink(string title, string shortenedLink)
        {
            var code = title.Split(" ")[0];

            Title = title;
            ShortenedLink = shortenedLink;
            DestinationLink = $"localhost:3000/{code}";
            Code = code;
            CreateAt = DateTime.Now.ToShortDateString();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortenedLink { get; set; }
        public string DestinationLink { get; set; }
        public string Code { get; set; }
        public string CreateAt { get; set; }

        public void Update(string title, string destinationLink)
        {
            Title = title;
            DestinationLink = destinationLink;
        }

    }
}
