List<string> items = [];


while (items.Count < 10) 
{
      Console.WriteLine("What would you like to buy? " );
      var shoppingItem = Console.ReadLine();
      items.Add(shoppingItem!);
      
            for (var i = 0; i < items.Count; i++)
            {
                var item = items[i];
                Console.WriteLine($"{i + 1}. {char.ToUpper(item[0]) + item[1..]}");
            }
}


Console.ReadKey();
