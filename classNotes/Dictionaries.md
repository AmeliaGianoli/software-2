# Software Design II
## Dictionaries

<!-- TODO: Look up 'big O notation' -->

```csharp
shoppingCart  
3 apples  
5 steaks  
8 bananas  
2 potatoes  

quantity = [3, 5, 8, 2]  
items=["Apples", "steaks", "bananas", "potatoes"]  

shoppingCart = [  
  "apples" => 3,  
  "steaks" => 5,  
  "bananas" => 8,  
  "potatoes" => 2,  
  ]  

int numItem = shoppingCart["bananas"]  
```

  - uses manual keys instead of index to reference an item in array  
```csharp
Dictionary<TKey, TValue> example = new Dictionary<TKey, TValue>();
```


```csharp
Dictionary<string, int> shoppingCart = new Dictionary<string, int>();

shoppingCart.Add("apples", 30);
shoppingCart.Add("berries", 25);
```

  - key must be unique, so we use TryAdd
```csharp
bool added = shoppingCart.TryAdd("oranges", 8); // true

added = capitals.TryAdd("oranges", 8); // false, key already exists
```
- there is no set order to dictionaries; there is no designated first or last 
  - all the 'things' exist together in the cart; there is no inherent order
- Can iterate through in several ways:
```csharp
foreach (KeyValuePair<string, int> item in shoppingCart) {
    Console.WriteLine($"Item: {item.Key}, Number of Items: {item.Value}");
}

foreach (var itemName in shoppingCart.Keys) {
    Console.WriteLine($"Item: {itemName}");
}

foreach (var itemCount in shoppingCart.Values) {
    Console.WriteLine($"Item Count: {itemCount}");
}
```




