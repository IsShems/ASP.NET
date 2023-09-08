namespace ASP.NET_Core_.Model
{


    public class Result : Quote
    {
        public List<Quote> quotes { get; set; }
    }

    public class Quote
    {
        public int id { get; set; }
        public string quote { get; set; }
        public string author { get; set; }
    }

}
