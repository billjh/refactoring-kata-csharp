using RefactoringKata.Enums;

namespace RefactoringKata
{
    public class Product
    {
        public string Code { get; set; }
        public ProductColor Color { get; set; }
        public ProductSize Size { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }

        public Product(string code, int color, int size, double price, string currency)
        {
            Code = code;
            Color = (ProductColor) color;
            Size = (ProductSize) size;
            Price = price;
            Currency = currency;
        }
    }
}
