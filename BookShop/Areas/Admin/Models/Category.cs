namespace BookShop.Areas.Admin.Models
{
    public class Category
    {
        private string Cat_ID;
        private string Name;
        public string cat_ID
        {
            get { return Cat_ID; }
            set { Cat_ID = value; }
        }
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public Category()
        {
        }
    }
}
