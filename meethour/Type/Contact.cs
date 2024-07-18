public class Contact
    {
        public int exclude_hosts { get; set; }
        public int limit { get; set; }
        public int page { get; set; }

        public Contact(int exclude_hosts1, int limit1, int page1)
        {
            exclude_hosts = exclude_hosts1;
            limit = limit1;
            page = page1;
        }
        public object Prepare()
        {
            return new
            {
                exclude_hosts = exclude_hosts,
                limit = limit,
                page = page
            };
        }
    }