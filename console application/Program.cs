List<string> items = [];

var isDone = false;

while (isDone == false)
    
{
    Console.WriteLine("Type in to add an item to your list, alternatively type show to print out your list");
    var shoppingItem = Console.ReadLine();
    if (shoppingItem!.Trim().ToLower() == "show")
    {
        for (var i = 0; i < items.Count; i++)
        {
            var item = items[i];
            Console.WriteLine($"{i + 1}. {char.ToUpper(item[0]) + item[1..]}");
        }

        isDone = true;
        
        Console.WriteLine("Would you like to add more items ? Type Y/n");
        var addMore = Console.ReadLine();
        if (addMore!.Trim().ToLower() == "y")
        {
            isDone = false;
        }
    }
    else
    { 
        items.Add(shoppingItem!);
    }

}


    
Console.ReadKey();
