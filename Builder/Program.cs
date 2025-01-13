
var product = Product.Builder.Init()
.SetItem(builder =>builder.SetTitle("some  item title").SetScore(10).Build())
.SetTitle("Some title for Prodcut")
.SetDescription("Some description for producdt")
.Build();


Console.WriteLine($"Product with title : {product.Title}, Description : {product.Description} item.title : {product.Item.Title} , item.score : {product.Item.Score}");



class Product
{
    public string Title { get;private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Item Item { get; private set; }
    
    private Product(){}
    public class Builder : IItemStep,ITitleStep,IDescriptionStep
    {
        private readonly Product _product = new Product();
        public Product Build()
        {
            return _product;
        }

        private Builder(){}

        public static IItemStep Init()
        {
            return new Builder();
        }

        public Builder SetDescription(string description)
        {
            
            _product.Description = description;
            return this;
        }

        public IDescriptionStep SetTitle(string title)
        {
        
            _product.Title = title;
            return this;
        }

        public ITitleStep SetItem(Func<Item.ItemBuilder,Item> funcItemBuilder)
        {
            _product.Item = funcItemBuilder( new Item.ItemBuilder());
            return this;
        }
    }
}

interface IItemStep
{
    ITitleStep SetItem(Func<Item.ItemBuilder,Item> funcItemBuilder);
}
interface ITitleStep
{
    IDescriptionStep SetTitle(string title);
}
interface IDescriptionStep
{
    Product.Builder SetDescription(string description);
}


class Item
{
    public string Title { get; private set; } = string.Empty;
    public int Score { get; private set; }

    private Item(){}

    public class ItemBuilder
    {
        private readonly Item _item = new Item();

        public ItemBuilder SetTitle(string title)
        {
            _item.Title = title;
            return this;
        }

        public ItemBuilder SetScore(int score)
        {
            _item.Score = score;
            return this;
        }

        public Item Build()
        {
            return _item;
        }
    }
}
