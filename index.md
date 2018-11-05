<style>
	.gotop {
		position:fixed;
		bottom:0;
		margin-left:-120px;
		margin-bottom: 20px;
		border: none; 
    outline: none; 
    background-color: red; 
    color: white; 
    cursor: pointer; 
    padding: 15px; 
    border-radius: 10px; 
    font-size: 18px; 
	}
</style>

<a href="#cuprins" class="gotop">Top</a>
**[Go back to home](https://bogdanalin92.github.io/)**

### Cuprins
1. [Operatori standard de interogare LINQ](#operatori-standard-de-interogare-linq)
	- [A.1 Agregarea](#a1-agregarea-aggregation)
	- [A.2 Concatenarea](#a2-concatenation)
2. [Introducere in LINQ](#introducere-in-linq)
3. [Fundamentele de baza](#fundamentele-de-baza)

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
### Separarea testarii de afisare cu Lambda (C#3)
```
foreach(Product product in products.Where(p => p.Price > 10))
            {
                Console.WriteLine(product);
            }
```
Pentru lista urmatoare de produse,
```
		new Product(name: "WSStory", price: 9.99m),
                new Product(name: "Humpty", price: 3.99m),
                new Product(name: "C# In Deapth", price: 15.99m),
                new Product(name: "WSStory HardCover", price: 10.29m)
```
avem urmatorul rezultat: 
> C# In Deapth: 15,99

> WSStory HardCover: 10,29

![graph3](/images/SmartSelect_20181026-164835_miMind.jpg) 

## Operatori standard de interogare LINQ
Vom folosii urmatoarele exemple de secvente:
```
string[] words = {"zero", "one", "two", "three", "four"};
int[] numbers = {0,1,2,3,4};
```

### A.1 Agregarea (Aggregation)
Operatorii de agregare rezulta intr-o singura valoare in schimbul unei secvente.

|Expresie|Rezultat|
|--------|--------|
|numbers.Sum()				|10						 |
|numbers.Count()			|5 						 |
|numbers.Average()			|2 						 |
|numbers.LongCount(x=>x % 2 == 0)	|3 (as a **long**; there are three evene numbers)|
|words.Min(word => word.Length)		|3 ("one" and "two")				 |
|words.Max(word => word.Length)		|5						 |
|numbers.Aggregate("seed",(current, item)=>current + item, result=> result.ToUpper()) |"SEED01234|

### A.2 Concatenation

|||
|-|-|
|numbers.Concat(new[] {2,3,4,5,6})|0,1,2,3,4,2,3,4,5,6|

### A.3 Conversion

```
object[] allStrings = {"These","are","all","strings"};
object[] notAllStrings = {"Number", "at", "the", "end", 5};
```

|Expresie|Rezultat|
|--------|--------|
|notAllStrings.OfType<string>()|"Number","at","the","end"(as IEnumerable<string>)|
|words.ToDictionary(w => w.Substring(0,2))|Dictionary contents: "ze":"zero","on":"one"|
|words.ToLookup(word=>word[0])|Lookup contents: 'z':"zero", 'o': "one", 't':"two", "three"|
|words.ToDictionary(word => word[0])|Exceptie: poate sa fie doar o intrare pe cheie, cedeaza la 't'|
	
*ToDictionary* si *ToLookup* primesc un delegat ca sa obtina cheiea pentru orice element.

*ToLookup* returneaza un tip corespunzator cu ILookup<,>. 
Un *lookup* este ca un dictionar unde valoarea asociata cu o cheie nu este doar un element, dar o secventa de elemente.

Lookups este in general folosit cand sunt asteptate sa apara chei duplicat ca facand parte dintr-o operatie normala, unde un dictionar ridica o exceptie.


Putem sa fortam o expresie de interogare ca tipul de la compilare sa fie *IEnumarable\<User\>* in schimbul *IQueryble\<User\>*.
```
//Filtrarea utilizatorului in baza de date cu LIKE
from user in context.Users
where user.Name.StartWith("Tim")
select user;
```
```
//Filtrarea utilizatorului in memorie
from user in context.Users.AsEnumerable()
where user.Name.StartWith("Tim")
select user;
```

### A.4 Exemple GroupBy 
___
Fiecare element dintr-un tipe IGrouping\<,\> are o cheie si o secventa de elemente ce se potrivesc cu cheia. Ordinea in care grupurile sunt returnate este ordinea in care cheile lor sunt descoperite.

|Expresie|Rezultat|
|---|---|
|words.GroupBy(word => word.Length)|Key: 4; Sequence: "zero", "four"|
|words.GroupBy(word => word.Length, word => word.ToUpper());| Key: 4; Sequence: "zero","four" ; Key: 3; Sequence: "one", "two"|

### A.5 Exemple Joins

|Expresie|Rezultat|
|---|---|
|names.GroupJoin(colors, name => name[0], color => color[0],(name,matches) => name + ": " + string.Join("/", matches.ToArray()))|"Robin: Red","Bob: Blue/Beige"|

___
# Introducere in LINQ

## Expresii de interogare si in-process queries

* Filtrarea unei colectii
   ```
   List<Product> products = Product.GetSampleProducts();
   var filtered = from Product p in products
   		where p.Price > 10
		select p;
   foreach(Product product in filtered)
   {
   	Console.WriteLine(product);
   }
   ```
   
   S-a folosit aici scrierea implicita a tipului de variabila locala, pentru a da voie compilatorului sa substraga timpul variabilei din valoarea atribuita initial. In acest caz *filtered* este *IEnumerable\<Product\>*
* Inerogarea unui fisier XML
   Se presupune ca avem urmatorul fisier XML:
   ```
   <?xml version="1.0"?>
   <Data>
   	<Products>
		<Product Name="" Price="" SupplierID=""/>
	</Products>
	
	<Suppliers>
	</Suppliers>
   </Data>
   ```



# Fundamentele de baza
___
## Delegates
#### (Functie la un pointer)

Un tip delegat este o singura interfata a unei metode, si o instanta delegat ca un obiect ce implementeaza acea interfata. Delegate este folosit deobicei atunci cand codul care vrea sa execute actiunile nu cunoaste detaliile privind acele actiuni.

Ca un delegat sa faca ceva, trebuie sa indeplinim urmatoarele puncte:
   * Tipul delegatului trebuie sa fie declarat.
   * Codul ce va fii executat trebuie sa fie intr-o metoda.
   * O instanta a delegatului trebuie creata.
   * Instanta delegatului trebuie sa fie invocata (*invoked*)

Un tip delegat este o lista de tipuri de parametrii si un tip de returnat. Specifica ce fel de actiune poate fi reprezentat de o instanta: ``` delegate void StringProcessor(string input); ```

