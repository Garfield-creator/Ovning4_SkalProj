using System;
using System.IO.Pipes;

namespace SkalProj_Datastrukturer_Minne;
class Program
{
    /// <summary>
    /// The main method, vill handle the menues for the program
    /// </summary>
    /// <param name="args"></param>
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 0) of your choice"
                + "\n1. Examine a List"
                + "\n2. Examine a Queue"
                + "\n3. Examine a Stack"
                + "\n4. Check Parenthesis"
                + "\n5. Reverse Text"
                + "\n0. Exit the application");
            char input = ' '; //Creates the character input to be used with the switch-case below.
            try
            {
                input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }
            switch (input)
            {
                case '1':
                    ExamineList();
                    break;
                case '2':
                    ExamineQueue();
                    break;
                case '3':
                    ExamineStack();
                    break;
                case '4':
                    CheckParanthesis();
                    break;
                case '5':
                    ReverseText();
                    break;
                /*
                    * Extend the menu to include the recursive 
                    * and iterative exercises.
                    */
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                    break;
            }
        }

    }

       

    /// <summary>
    /// Examines the datastructure List
    /// </summary>
    static void ExamineList()
    {
        List<String> list = [];
        while (true)
        {
            Console.WriteLine($"The lists capacity is {list.Capacity}");
            Console.WriteLine("Please navigate through the menu by inputting" +
                "\n+ followed by what you like to add to the list or" +
                "\n- followed by what you like to remove from the list or" +
                "\n 0 to exit.");
            char choice = ' '; //Creates the character input to be used with the switch-case below.
            string value = "";
            try
            {
                string input = Console.ReadLine() ?? "";
                choice = input![0]; //Tries to set input to the first char in an input line
                value = input[1..];
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }
            switch (choice)
            {
                case '+':
                    if (String.IsNullOrWhiteSpace(value)) Console.WriteLine("You must enter somthing after the +!");
                    else
                    {
                        list.Add(value);
                        Console.WriteLine($"{value} was added to the list!");
                    }
                    break;
                case '-':
                    if (String.IsNullOrWhiteSpace(value)) Console.WriteLine("You must enter somthing after the -!");
                    else if (list.Remove(value))
                    {
                        Console.WriteLine($"{value} was removed to the list!");
                    }
                    else Console.WriteLine($"{value} is not in the list!");
                    break;
                case '0':
                    return;
                default:
                    Console.WriteLine("Please enter some valid input (A string that either starts with + or - or a 0.)");
                    break;
            }
        }
        /*
        List<int> list = [];
        Console.WriteLine($"The list is newly initialized and empty.");
        Console.WriteLine($"The lists capacity is {list.Capacity}");
        for (int i = 1; i < 130; i++)
        {
            list.Add(i);
            Console.WriteLine($"Added a number to the list! It now contains {i} numbers");
            Console.WriteLine($"The lists capacity is {list.Capacity}");
               
        }
        Console.WriteLine("\nConclusion: The list's array doubles in size when it reaches its max size. It starts at 4.\n");
        for (int i = list.Count - 1; i >= 0; i--)
        {
            list.RemoveAt(i);
            Console.WriteLine($"Removed a number from the list! It now contains {i} numbers");
            Console.WriteLine($"The lists capacity is {list.Capacity}");

        }
        Console.WriteLine("\nConclusion: The list's array does not decrease in size as you remove entries.\n");
        */
    }

    /// <summary>
    /// Examines the datastructure Queue
    /// </summary>
    static void ExamineQueue()
    {
        /*
            * Loop this method untill the user inputs something to exit to main menue.
            * Create a switch with cases to enqueue items or dequeue items
            * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
        */
        Queue<String> queue = [];
        while (true)
        {
            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 0) of your choice"
                + "\n1. Add an object to the queue"
                + "\n2. Expedite the first object in the queue"
                + "\n0. Return to main menu");
            char choice = ' ';
            try
            {
                choice = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }
            switch (choice)
            {
                case '1':
                    bool done = false;
                    while (!done)
                    {
                        Console.WriteLine("Enter the name of the new object in the queue:");
                        string input = GetInput("Enter the name of the new object in the queue:");
                        if (String.IsNullOrWhiteSpace(input)) Console.WriteLine("Please enter some input!");
                        else
                        {
                            queue.Enqueue(input);
                            Console.WriteLine($"{input} was added to end of the queue!");
                            string[] test2 = queue.ToArray();
                            foreach (string s in test2) Console.WriteLine(s + " is in the queue.");
                            done = true;
                        }
                    }
                    break;
                case '2':
                    try { Console.WriteLine($"{queue.Dequeue()} was expedited and left the queue!"); }
                    catch (InvalidOperationException) { Console.WriteLine("The queue is empty!"); }
                    string[] test = queue.ToArray();
                    foreach (string s in test) Console.WriteLine(s + " is in the queue.");
                    break;
                case '0':
                    return;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, or 2.)");
                    break;
            }
        }
    }

    /// <summary>
    /// Examines the datastructure Stack
    /// </summary>
    static void ExamineStack()
    {
        /*
            * Loop this method until the user inputs something to exit to main menue.
            * Create a switch with cases to push or pop items
            * Make sure to look at the stack after pushing and and poping to see how it behaves
        */
        Stack<String> stack = [];
        while (true)
        {
            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 0) of your choice"
                + "\n1. Add an object to the top of the stack"
                + "\n2. Remove the top object of the stack"
                + "\n0. Return to main menu");
            char choice = ' ';



            try
            {
                choice = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }
            switch (choice)
            {
                case '1':
                    bool done = false;
                    while (!done)
                    {
                        string input = GetInput("Enter the name of the new object on the stack:");
                        stack.Push(input);
                        Console.WriteLine($"{input} was added to the top of the stack!");
                        string[] test = stack.ToArray();
                        foreach (string s in test) Console.WriteLine(s + " is on the stack.");
                        done = true;
                    }
                    break;
                case '2':
                    try { Console.WriteLine($"{stack.Pop()} was popped from the top of the stack!"); }
                    catch (InvalidOperationException) { Console.WriteLine("The stack is empty!"); }
                    string[] test2 = stack.ToArray();
                    foreach (string s in test2) Console.WriteLine(s + " is on the stack.");
                    break;
                case '0':
                    return;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, or 2.)");
                    break;
            }
        }
    }

    private static string GetInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine() ?? "";
            if (String.IsNullOrWhiteSpace(input)) Console.WriteLine("Please enter some input!");
            else
            {
                return input;
            }
        }
    }

    static void CheckParanthesis()
    {
        /*
            * Use this method to check if the paranthesis in a string is Correct or incorrect.
            * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
            * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
            */
        string input = GetInput("Enter the string you wish to check for proper parentheses.");
        Stack<char> stack = [];
        var pairs = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };
        var openings = new HashSet<char>(pairs.Values);
        foreach (char c in input) 
        {
            if (openings.Contains(c))
            {
                stack.Push(c);
            }
            else if (pairs.ContainsKey(c))
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine("The string's parenthesis are not closed correctly!");
                    return;
                }
                else
                {
                    if (stack.Peek() == pairs[c]) stack.Pop();
                    else
                    {
                        Console.WriteLine("The string's parenthesis are not closed correctly!");
                        return;
                    }
                }
            }
        }
        if (stack.Count != 0)
        {
            Console.WriteLine("The string's parenthesis are not closed correctly!");
            return;
        }
        else Console.WriteLine("The string's parenthesis are closed correctly! Hurray!");
    }
    static void ReverseText()
    {
        string input = GetInput("Enter the string you wish to reverse.");
        Stack<char> stack = [];
        foreach (char c in input)
        {
            stack.Push(c);
        }
        Console.WriteLine("The reversed string is:\n");
        //stack.Reverse(); Skulle kunna använda den här, men det känns som fusk.
        int length = stack.Count;
        for (int i = 0; i < length; i++)   
        {
            char c = stack.Pop();
            Console.Write(c);
        }
        Console.Write("\n");
    }
}

