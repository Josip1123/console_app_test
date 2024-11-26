using System.Reflection.Metadata;
using console_application.Models;

List<Todo> todos = [];

var isDone = false;

void AddToList(string userInput)
{
    Todo todo = new Todo();
    todo.TodoItem = userInput;
    todos.Add(todo);
    PrintTodoList(todos);
}

void PrintTodoList(List<Todo> todos)
{
    Console.Clear();
    for (var i = 0; i < todos.Count; i++)
    {
        var item = todos[i];
        var status = item.IsFinished ? "Completed" : "Active";
        Console.WriteLine($"{i + 1}. {char.ToUpper(item.TodoItem[0]) + item.TodoItem[1..]} ({status})");
    }
}

while (!isDone)
    
{
    
    Console.WriteLine("Type to add an item to your list, type 'done' to finish a todo item or simply type 'exit' if you would like to exit the app");
    var userInput = Console.ReadLine()!.Trim().ToLower();
    Console.Clear();
    
    if (userInput == "done")
    {
        PrintTodoList(todos);
        Console.WriteLine("Type the number of the item you would like to complete");
        userInput = Console.ReadLine()!.Trim().ToLower();
        
        if (int.TryParse(userInput, out int indexToRemove) && indexToRemove > 0 && indexToRemove <= todos.Count)
        {
            todos[indexToRemove - 1].IsFinished = true;
            PrintTodoList(todos);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
       
    } 
    else if (userInput == "exit")
    {
        isDone = true;
        
    }
    else
    {
        AddToList(userInput);
    }

}

Console.WriteLine("You are done for today, press any key to exit");
Console.ReadKey();