using ConsoleApp1;
using System;
class HelloWorld
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Game game = new Game();
        game.Start();
        game.Next();
        while (true)
        {
            try
            {
                game.GetKey(Convert.ToChar(Console.ReadLine()));
            }
            catch
            {
                Console.WriteLine("Вы ввели не клавишу");
            }
        }
    }
}