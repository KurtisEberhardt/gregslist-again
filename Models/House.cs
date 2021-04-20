namespace gregslist_again.Models
{
    public class House
    {
        public House(int bedrooms, int bathrooms, int floors, int sqFoot, int yearBuilt, int price, string address)
        {
            this.bedrooms = bedrooms;
            this.bathrooms = bathrooms;
            this.floors = floors;
            this.sqFoot = sqFoot;
            this.yearBuilt = yearBuilt;
            this.price = price;
            this.address = address;

        }
        public int bedrooms { get; set; }
        public int bathrooms { get; set; }
        public int floors { get; set; }
        public int sqFoot { get; set; }
        public int yearBuilt { get; set; }
        public int price { get; set; }
        public string address { get; set; }
        public int Id { get; set; }

    }
}