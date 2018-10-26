**[Go back to home](https://bogdanalin92.github.io/)**

# Start from the beggin

## Teorie elementara ASP.Net Core 

Pentru inceput vom obtine de la urmatoarea adresa [https://www.microsoft.com/net/download](https://www.microsoft.com/net/download) kit-ul de instalarea a frameworkului .net.

# Schimbarile in C#

Se porneste de la urmatorul program cu sintaxa versiunii 4
```
//Named arguments for clear initialization code
using System.Collections.Generic;
public class Product
{
	readonly string name;
	public string Name { get { return name; } }
	
	readonly decimal price;
	public decimal Price { get { return price; } }
	
	public Product(string name, decimal price)
	{
		this.name = name;
		this.price = price;
	}
	
	public static List<Product> GetSampleProducts()
	{
		return new List<Product>
		{
			new Product( name: "WSStory", price: 9.99m)
		};
	}
	
	public override string ToString()
	{
		return string.Format("{0}: {1}", name, price);
	}
}

```


## Sortare si filtrare
### Sortarea in functie de versiunile de c#

* C# 1
  * Sorteaza un ArrayList folosing IComparer
    ```
    class ProductNameComparer : IComparer
    { 
      public int Compare(object x, object y)
    	{
				Product first = (Product)x; Product second = (Product)y;
    		return first.Name.CompareTo(second.Name); 
			}
		}
    ...
		ArrayList products = Product.GetSampleProducts();
		products.Sort(new ProductNameComparer());
		foreach(Product product in products)
		{
			Console.WriteLine(product);
		}
    ```
  * Some
  
