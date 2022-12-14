namespace BookShop.Areas.Admin.Models
{
    public class Product
    {
        private string Pd_ID;
        private string Cat_ID;
        private string Title;
        private int Price;
        private string Thumbnail;
        private float Discount;
        private string Des;
        private string Created_At;
        private string Updated_At;
        private int Quantity;

        public string pd_ID
        {
            get { return Pd_ID; }
            set { Pd_ID = value; }
        }
        public string cat_ID
        {
            get { return Cat_ID; }
            set { Cat_ID = value; }
        }
        public string title
        {
            get { return Title; }
            set { Title = value; }
        }
        public int price
        {
            get { return Price; }
            set { Price = value; }
        }

        public string thumbnail
        {
            get { return Thumbnail; }
            set { Thumbnail = value; }
        }
        public float discount
        {
            get { return Discount; }
            set { Discount = value; }
        }

        public string des
        {
            get { return Des; }
            set { Des = value; }
        }
        public string created_at
        {
            get { return Created_At; }
            set { Created_At = value; }
        }
        public string updated_at
        {
            get { return Updated_At; }
            set { Updated_At = value; }
        }
        public int quantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }
        public Product()
        {
        }
    }
}
