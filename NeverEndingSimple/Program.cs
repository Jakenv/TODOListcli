// ReSharper disable StringLiteralTypo

var listOfTodo = new List<string>();
listOfTodo.AddRange(new[] { "Kupic mleko", "Kupic something also", "Kupic something" });
var menuSelection = "";

do
{
    Console.Clear();

    Console.WriteLine("Hello!");
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    var input = Console.ReadLine();
    if (input != null) menuSelection = input.ToLower();

    switch (menuSelection)
    {
        case "s":
            ListAllTodos();
            PressEnterToContinue();
            break;
        case "a":
            AddNewTodo();
            HandleAnotherEntry(AddNewTodo);
            PressEnterToContinue();
            break;
        case "r":
            RemoveTodo();
            HandleAnotherEntry(RemoveTodo);
            PressEnterToContinue();
            break;
        case "e":
            Exit();
            break;
        default:
            Console.Clear();
            Console.WriteLine("Incorrect input");
            break;
    }
} while (menuSelection != "exit");

return;


void ListIsEmpty()
{
    Console.WriteLine("There are no TODOs on the list");
}


void ListAllTodos()
{
    if (listOfTodo.Count == 0)
        ListIsEmpty();
    else
        for (var i = 0; i < listOfTodo.Count; i++)
            Console.WriteLine($"{i + 1}. {listOfTodo[i]}");
}


void PressEnterToContinue()
{
    Console.WriteLine("Press enter to continue");
    Console.ReadKey();
}


void AddNewTodo()
{
    Console.WriteLine("What do you want to add?");
    var input = Console.ReadLine();
    if (!string.IsNullOrEmpty(input) && input != " ")
    {
        if (listOfTodo.Contains(input) == false)
        {
            listOfTodo.Add(input);
            Console.WriteLine("Entry added");
        }
        else
        {
            Console.WriteLine("This TODO already exists");
        }
    }
    else
    {
        Console.WriteLine("Input can't be empty");
    }
}


void HandleAnotherEntry(Action todoAction)
{
    while (true)
    {
        Console.WriteLine("Do you want to make another entry? (y/n)");
        var input = Console.ReadLine();
        if (input != null)
        {
            if (input.ToLower() == "y")
                todoAction.Invoke();
            else if (input.ToLower() == "n")
                break;
        }
    }
}


void RemoveTodo()
{
    if (listOfTodo.Count == 0)
    {
        ListIsEmpty();
        return;
    }

    Console.WriteLine("Which TODO you want to remove?\n");
    ListAllTodos();
    var input = Console.ReadLine();
    if (input != null && int.TryParse(input, out var index))
    {
        if (index <= listOfTodo.Count)
        {
            listOfTodo.RemoveAt(index - 1);
            Console.WriteLine("Entry removed");
        }
        else
        {
            Console.WriteLine($"Number must be between 1 and {listOfTodo.Count - 1}");
        }
    }
    else
    {
        Console.WriteLine("Incorrect input, must declare number");
    }
}


void Exit()
{
    Console.Clear();
    Console.WriteLine("Exiting");
    menuSelection = "exit";
}