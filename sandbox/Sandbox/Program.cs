using System;

class Program
{
    static void Main(string[] args)
    {
        Course course1 = new Course();
        course1._className = "Prog. w/Classes";
        course1._color = "CSE 201";
        course1._numberOfCredits = 2;
        course1.Display();
    }
}