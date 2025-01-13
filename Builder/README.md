# Builder Design Pattern
[![Builder](https://img.youtube.com/vi/https://www.youtube.com/watch?v=WRmFukIJf9g&list=PLhD5YGv8gWSyYlm9oNto3xxZ5yYk12K1b&index=7&pp=gAQBiAQB/0.jpg)](https://www.youtube.com/watch?v=https://www.youtube.com/watch?v=WRmFukIJf9g&list=PLhD5YGv8gWSyYlm9oNto3xxZ5yYk12K1b&index=7&pp=gAQBiAQB)

## Intent

The Builder pattern is used to separate the construction of a complex object from its representation, allowing the same construction process to create different representations.

### Key Components of the Builder Pattern

`Builder`: An interface that defines methods for creating part objects of a complex object.
`Concrete Builder`: A class that implements the Builder interface, providing specific implementations for the construction steps.
`Director`: A class that constructs an object using the Builder interface. It controls the building process.
`Product`: The complex object that is being built.

## Table of Contents  

- [Simple Builder](#simple-builder)  
- [Fluent Builder](#fluent-Builder-Pattern)  
- [Nested Builder](#nested-builder-pattern)  
- [Function Parameter Builder](#function-parameter-builder)  
- [Step Builder](#step-builder-pattern)  


## Simple Builder

```cs
 IProductBuilder productBuilder = new ProductBuilderCapital();
 productBuilder.SetTitle("Title 1");
 productBuilder.SetDescription("Some Description");
 Product product = productBuilder.Build();


class Product
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

interface IProductBuilder
{
    void SetTitle(string title);
    void SetDescription(string description);
    Product Build();
}

class ProductBuilder : IProductBuilder
{
    private readonly Product _product = new Product();
    public Product Build()
    {
        return _product;
    }

    public void SetDescription(string description)
    {
        _product.Description = description;
    }

    public void SetTitle(string title)
    {
        _product.Title= title;
    }
}

class ProductBuilderCapital : IProductBuilder
{
    private readonly Product _product = new Product();
    public Product Build()
    {
        return _product;
    }

    public void SetDescription(string description)
    {
        _product.Description = description.ToUpper();
    }

    public void SetTitle(string title)
    {
        _product.Title= title.ToUpper();
    }
}
```

## Fluent Builder Pattern

```cs
var product = new ProductBuilder()
.SetTitle("Title 1")
.SetDescription("Some Description")
.Build();

Console.WriteLine($"Product with Titel : {product.Title}, Description : {product.Description}");
//  productBuilder.SetTitle("Title 1");
//  productBuilder.SetDescription("Some Description");
//  Product product = productBuilder.Build();


class Product
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

interface IProductBuilder
{
    ProductBuilder SetTitle(string title);
    ProductBuilder SetDescription(string description);
    Product Build();
}

class ProductBuilder : IProductBuilder
{
    private readonly Product _product = new Product();
    public Product Build()
    {
        return _product;
    }

    public ProductBuilder SetDescription(string description)
    {
        _product.Description = description;
        return this;
    }

    public ProductBuilder SetTitle(string title)
    {
        _product.Title = title;
        return this;
    }
}
```

## Nested Builder Pattern :

```cs
var product = new Product.Builder()
.SetTitle("Title 1")
.SetDescription("Some Description")
.Build();

Console.WriteLine($"Product with Titel : {product.Title}, Description : {product.Description}");
//  productBuilder.SetTitle("Title 1");
//  productBuilder.SetDescription("Some Description");
//  Product product = productBuilder.Build();


class Product
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public class Builder
    {
        private readonly Product _product = new Product();
        public Product Build()
        {
            return _product;
        }

        public Builder SetDescription(string description)
        {

            _product.Description = description;
            return this;
        }

        public Builder SetTitle(string title)
        {

            _product.Title = title;
            return this;
        }
    }

}
```

## Function Parameter Builder

```cs
var product = new Product.Builder()
.SetTitle("Title 1")
.SetDescription("Some Description")
.SetItem(builder =>builder.SetTitle("some title").SetScore(10).Build())
.Build();

//product = new Product();
//product.Title="asdfa";
Console.WriteLine($"Product with Titel : {product.Title}, Description : {product.Description}");
//  productBuilder.SetTitle("Title 1");
//  productBuilder.SetDescription("Some Description");
//  Product product = productBuilder.Build();


class Product
{
    public string Title { get;private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Item Item { get; private set; }

    private Product(){}
    public class Builder
    {
        private readonly Product _product = new Product();
        public Product Build()
        {
            return _product;
        }

        public Builder SetDescription(string description)
        {

            _product.Description = description;
            return this;
        }

        public Builder SetTitle(string title)
        {

            _product.Title = title;
            return this;
        }

        public Builder SetItem(Func<Item.ItemBuilder,Item> funcItemBuilder)
        {
            _product.Item = funcItemBuilder( new Item.ItemBuilder());
            return this;
        }
    }

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
```

## Step Builder Pattern :

```cs

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
```
