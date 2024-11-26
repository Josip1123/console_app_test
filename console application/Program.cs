using System.Reflection.Metadata;
using console_application.Models;

List<Todo> todos = [];

var isDone = false;

void PrintTodoList(List<Todo> todos)
{
    for (var i = 0; i < todos.Count; i++)
    {
        var item = todos[i];
        var status = item.IsFinished ? "Completed" : "Active";
        Console.WriteLine($"{i + 1}. {char.ToUpper(item.TodoItem[0]) + item.TodoItem[1..]} ({status})");
    }
}

while (!isDone)
    
{
    
    Console.WriteLine("Type in to add an item to your list, alternatively type show to print out your list");
    Todo todo = new Todo();
    todo.TodoItem = Console.ReadLine()!;
    
    
    Console.Clear();
    
    if (todo.TodoItem!.Trim().ToLower() == "show")
    {
        PrintTodoList(todos);

        
        Console.WriteLine("Would you like to add more items ? Type 'y' " +
                          "to complete a task type in done or exit to exit program");
        var addMore = Console.ReadLine();
        if (addMore!.Trim().ToLower() == "y")
        {
            Console.Clear();
        }
        else if (addMore!.Trim().ToLower() == "done")
        {
            Console.Clear();
            Console.WriteLine("Type the number of the item you would like to complete");
            
                PrintTodoList(todos);
            
            if (int.TryParse(Console.ReadLine(), out int indexToRemove) && indexToRemove > 0 && indexToRemove <= todos.Count)
            {
                Console.Clear();
                todos[indexToRemove - 1].IsFinished = true;
                
                PrintTodoList(todos);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        
        else if (addMore!.Trim().ToLower() == "exit")
        {
            isDone = true;
        }
    }
    
    else
    { 
        todos.Add(todo);
    }

}

Console.WriteLine("You are done for today, press any key to exit");
Console.ReadKey();
