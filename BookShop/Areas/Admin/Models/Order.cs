namespace BookShop.Areas.Admin.Models
{
    public class Order
    {
        private string Od_ID;
        private string User_ID;
        private string FullName;
        private string Email;
        private string Address;
        private string Phone;
        private string Order_Date;
        private string Status;

        public string od_ID
        {
            get { return Od_ID; }
            set { Od_ID = value; }
        }
        public string user_ID
        {
            get { return User_ID; }
            set { User_ID = value; }
        }
        public string fullname
        {
            get { return FullName; }
            set { FullName = value; }
        }

        public string email
        {
            get { return Email; }
            set { Email = value; }
        }
        public string address
        {
            get { return Address; }
            set { Address = value; }
        }

        public string phone
        {
            get { return Phone; }
            set { Phone = value; }
        }
        public string order_Date
        {
            get { return Order_Date; }
            set { Order_Date = value; }
        }
        public string status
        {
            get { return Status; }
            set { Status = value; }
        }
        public Order()
        {
        }
    }
}
