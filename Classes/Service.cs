namespace _2LABORAS.Classes
{
    public class Service
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Service()
        {

        }
        /// <summary>
        /// constructor for the service
        /// </summary>
        /// <param name="serviceid">serviceID</param>
        /// <param name="servicetitle">Title of the service</param>
        /// <param name="serviceprice">Service fee</param>
        public Service(string id, string title, double price)
        {
            this.ID = id;
            this.Title = title;
            this.Price = price;
        }

        /// <summary>
        /// method to format string line
        /// </summary>
        /// <returns>string line</returns>
        public string StringFormat()
        {
            return string.Format("|{0, -6}|{1, 16}|{2,7}|", "ID", "Title", "Price");
        }
        /// <summary>
        /// method to format the data
        /// </summary>
        /// <returns>formatted data</returns>
        public override string ToString()
        {
            return string.Format("|{0, -6}|{1, 16}|{2,7}|", this.ID, this.Title, this.Price);
        }

    }
}
