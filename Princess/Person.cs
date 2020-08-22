using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // класс игрока, у которого есть здоровье и координаты на поле
    class Player
    {
        public int oldX, oldY;
        public int x, y;
        public int lives;
        public void Reset()
        {
            x = 0;
            y = 0;
            lives = 10;
        }
    }
}
