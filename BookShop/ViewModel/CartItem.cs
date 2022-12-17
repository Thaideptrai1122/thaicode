namespace BookShop.ViewModel
{
    public class CartItem
    {
        public int pd_ID { get; set; }
        public string TenSP { get; set; }

        public int price { get; set; }

        public int discount { get; set; }

        public string des { get; set; }

        public int quantity { get; set; }

        public double Total => quantity * price;
    }
}
