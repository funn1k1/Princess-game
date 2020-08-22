using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Game
    {
        Player player;
        Random rnd;
        const int size = 10;
        public int[,] field = new int[size, size];
        public Game()
        {
            player = new Player();
            rnd = new Random();
        }
        public void Start()
        {
            player.Reset();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = 0;

                }
            }
            field[player.x, player.y] = 1;
            field[size - 1, size - 1] = 3;
            SetBombs();
        }
        public void GetKey(char ch)
        {
            player.oldX = player.x;
            player.oldY = player.y;
            switch (Char.ToLower(ch))
            {
                case 'w':
                    if (player.x > 0)
                        player.x--;
                    break;
                case 'a':
                    if (player.y > 0)
                        player.y--;
                    break;
                case 's':
                    if (player.x < size - 1)
                        player.x++;
                    break;
                case 'd':
                    if (player.y < size - 1)
                        player.y++;
                    break;
            }
            Next();
        }
        public void Next()
        {
            field[player.oldX, player.oldY] = 0;
            switch (field[player.x, player.y])
            {
                case 2:
                    Shot();
                    break;
                case 3:
                    Win();
                    break;
            }
            field[player.x, player.y] = 1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    switch (field[i, j])
                    {
                        case 1:
                            Console.Write("P");
                            break;
                        case 3:
                            Console.Write("Q");
                            break;
                        default:
                            Console.Write("#");
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Здоровье = " + player.lives);
        }
        public void SetBombs()
        {
            int i = 0;
            while (i < size)
            {
                int x = rnd.Next(0, size);
                int y = rnd.Next(0, size);
                if (x == size - 1 && y == size - 1) continue;
                if (x == 0 && y == 0) continue;
                field[x, y] = 2;
                i++;
            }
        }
        public void Shot()
        {
            int damage = rnd.Next(0, size);
            if (player.lives > damage) player.lives -= damage;
            else player.lives = 0;
            Console.WriteLine("Вы наткнулись на мину");
            if (player.lives == 0)
            {
                GameOver();
            }
        }
        public void GameOver()
        {
            Console.WriteLine("Вы проиграли игру");
            Start();
        }
        public void Win()
        {
            Console.WriteLine("Вы выиграли игру");
            Start();
        }
    }
}
