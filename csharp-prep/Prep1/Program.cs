using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string fname = Console.ReadLine();
        Console.WriteLine(fname);

        Console.Write("What is your last name?" );
        string lname = Console.ReadLine();
        Console.WriteLine(lname);

        Console.WriteLine($"Your name is {lname}, {fname} {lname}. ");

    }
}