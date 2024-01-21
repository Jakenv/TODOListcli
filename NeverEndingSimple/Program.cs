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

    bool correctInput;
    string anotherEntry;
    switch (menuSelection)
    {
        case "s":
            ListAllTodos();
            PressEnterToContinue();
            break;

        case "a":
            anotherEntry = "y";

            while (anotherEntry == "y")
            {
                var todoWords = "";
                do
                {
                    Console.WriteLine("What do you want to add?");
                    input = Console.ReadLine();
                    if (input != null)
                    {
                        todoWords = input;
                        correctInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Input can't be empty");
                        correctInput = false;
                    }
                } while (correctInput == false);

                listOfTodo.Add(todoWords);
                do
                {
                    Console.WriteLine("Do you want to make another entry?(y/n)");
                    input = Console.ReadLine();
                    if (input != null)
                        anotherEntry = input.ToLower();
                } while (anotherEntry != "y" && anotherEntry != "n");
            }

            PressEnterToContinue();
            break;
        case "r":
            anotherEntry = "y";
            correctInput = false;
            ListAllTodos();

            while (anotherEntry == "y")
            {
                do
                {
                    Console.WriteLine("Which TODO you want to remove?");
                    ListAllTodos();
                    input = Console.ReadLine();
                    if (input != null && int.TryParse(input, out var index))
                    {
                        if (index < listOfTodo.Count)
                        {
                            listOfTodo.RemoveAt(index);
                            Console.WriteLine("Entry removed");
                            correctInput = true;
                        }
                        else
                        {
                            Console.WriteLine($"Number must be between 0 and {listOfTodo.Count - 1}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input, must declare number");
                        correctInput = false;
                    }
                } while (correctInput != true && anotherEntry == "y");

                do
                {
                    Console.WriteLine("Do you want to remove another entry?(y/n)");
                    input = Console.ReadLine();
                    if (input != null) anotherEntry = input.ToLower();
                } while (anotherEntry != "y" && anotherEntry != "n");
            }

            PressEnterToContinue();
            break;
        case "e":
            Console.Clear();
            Console.WriteLine("Exiting");
            menuSelection = "exit";
            break;

        default:
            Console.Clear();
            Console.WriteLine("Incorrect input");
            break;
    }
} while (menuSelection != "exit");

return;

void ListAllTodos()
{
    foreach (var todo in listOfTodo)
        Console.WriteLine(listOfTodo.IndexOf(todo) + "\t" + todo);
    Console.WriteLine("\n");
}


void PressEnterToContinue()
{
    Console.WriteLine("Press enter to continue");
    Console.ReadKey();
}