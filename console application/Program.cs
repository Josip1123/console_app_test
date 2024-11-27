using console_application.Models;

List<Todo> todos = [];

var isDone = false;


while (!isDone)
    
{
    Console.WriteLine("Type to add an item to your list, type 'done' to finish a todo item" +
                      " or simply type 'exit' if you would like to exit the app");
    var userInput = Console.ReadLine()!.Trim().ToLower();
    Console.Clear();
    
    switch (userInput)
    {
        case "done":
            CompleteTask(todos);
            break;
        case "exit":
            isDone = true;
            break;
        case "":
            PrintTodoList(todos);
            Console.WriteLine("Field can't be empty");
            break;
        default:
            AddToList(userInput);
            break;
    }

}

Console.WriteLine("You are done for today, press any key to exit");
Console.ReadKey();


void AddToList(string userInput)
{
    var todo = new Todo
    {
        TodoItem = userInput,
        IsFinished = false
    };
    todos.Add(todo);
    PrintTodoList(todos);
}

void PrintTodoList(List<Todo> list)
{
    Console.Clear();
    for (var i = 0; i < list.Count; i++)
    {
        var item = list[i];
        var status = item.IsFinished ? "Completed" : "Active";
        Console.WriteLine($"{i + 1}. {char.ToUpper(item.TodoItem[0]) + item.TodoItem[1..]} ({status})");
    }
}

void CompleteTask(List<Todo> list)
{
    PrintTodoList(list);
    Console.WriteLine("Type the number of the item you would like to complete");
    var userInput = Console.ReadLine()!.Trim().ToLower();
        
    if (int.TryParse(userInput, out var indexToRemove) && indexToRemove > 0 && indexToRemove <= todos.Count)
    {
        todos[indexToRemove - 1].IsFinished = true;
        PrintTodoList(todos);
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}