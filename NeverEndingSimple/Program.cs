// ReSharper disable StringLiteralTypo
int maxTodos = 6;
string[] listOfTodo = new string[maxTodos];
var menuSelection = "";
for (int i = 0; i < maxTodos; i++)
{
    string todo;
    switch (i)
    {
        case 0:
            todo = "Kupic mleko";
            break;
        case 1:
            todo = "Kupic mleko";
            break;
        case 2:
            todo = "Kupic mleko";
            break;
        default:
            todo = "";
            break;
    }
    listOfTodo[i] = $"{i}: " + todo;
}

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
    if (input != null)
    {
        menuSelection = input.ToLower();
    }

    switch (menuSelection)
        {
            case "s":
               for (var i = 0; i < maxTodos; i++)
               {
                   Console.WriteLine(listOfTodo[i]);
               }
               Console.WriteLine("Press enter to continue");
               Console.ReadKey();
               break;

           case "a":
                string anotherEntry = "y";
                int todoCount = 0;
                for (int i = 0; i < maxTodos; i++)
                {
                    if (listOfTodo[i] != $"{i}: ")
                    {
                        todoCount += 1;
                    }
                }

                if (todoCount < maxTodos)
                    Console.WriteLine($"{todoCount}We can manage {(maxTodos - todoCount)} more.");
                
                while (anotherEntry == "y" && todoCount < maxTodos)
                {
                    string todoWords = "";
                    bool correctInput;
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
                    listOfTodo[todoCount] = $"{todoCount}: " + todoWords;
                    todoCount += 1;
                    if (todoCount < maxTodos)
                    {
                        Console.WriteLine("Do you want to make another entry?");
                        do
                        {
                            input = Console.ReadLine();
                            if (input != null)
                            {
                                anotherEntry = input.ToLower();
                            }
                            
                        } while (anotherEntry != "y" && anotherEntry != "n");
                    }
                }

                if (todoCount >= maxTodos)
                {
                    Console.WriteLine("Entries are full");
                    Console.WriteLine("Remove old entires to create space");
                }
                Console.WriteLine("Press enter to continue"); 
                Console.ReadKey();
                break;
            case "r":
                for (int i = 0; i < maxTodos; i++)
                {
                    Console.WriteLine(listOfTodo[i]);
                }
                
                Console.WriteLine("Press enter to continue"); 
                Console.ReadKey();
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