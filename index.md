**[Go back to home](https://bogdanalin92.github.io/)**

# Start from the beggin

# Schimbarile in C#
![graph1](/20181026_105852.jpg)
## Se porneste de la urmatorul program cu sintaxa versiunii 4
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

* Urmatoarea listare implementeaza IComparer, dupa sorteaza lista si o afiseaza.
  * Sorteaza un ArrayList folosind IComparer
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
  * Sortarea unei colectii List<Product> utilizand IComparer<Product>
	```
	class ProductNameComparer : **IComparer<Product>**
	{
		public int Compare(**Product x, Product y**)
		{
			return x.Name.CompareTo(y.Name);
		}
	}
	...
	**List<Product> products = Product.GetSampleProducts();**
	products.Sort(delegate(Product x, Product y){
		return x.Name.CompareTo(y.Name);
	});
	foreach(Product product in products)
	{
		Console.WriteLine(product);
	}
	```
	### Am folosit IComparer<Product> pentru a crea o clasa de comparare a doua produse, si am folosit in metoda Sort ca parametru Comparison<Product> ce are ca parametrii doua obiecte Product.
	
  * Sortarea folosind Comparison<Product> din o expresie lambda
	```
	List<Product> products = Product.GetSampleProducts();
	products.Sort((x,y) => x.Name.CompareTo(y.Name));
	foreach(Product product in products)
	{
		Console.WriteLine(product);
	}
	```
	![graph2](/images/C1_12pg.png) 

## Colectii de interogare

Urmatorul cod arata cum in C# 1, trebuie sa folosesti o bucla, sa testezi fiecare element si sa afisezi cand este nevoie.


> ArrayList products = **Product**.GetSampleProducts();
> foreach(Product product in products) {
> 	if(product.Price > 10m)
>	{ Console.WriteLine(product); }
> }

### Separarea testarii de afisare (C#2)
```
List<Product> products = Product.GetSampleProducts();
Predicate<Product> test = delegate(Product p) { return p.Price > 10m; }
List<Product> matches = products.FindAll(test);

Action<Product> print = Console.WriteLine;
matches.ForEach(print);
```
_**Forma redusa a codului de mai sus este urmatoarea**_

```
	List<Product> products = Product.GetSampleProducts();
        products.FindAll(delegate (Product p) { return p.Price > 10; })
                .ForEach(Console.WriteLine);
```
