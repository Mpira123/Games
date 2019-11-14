using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Labirinth
{
    class Labirinth
    {
        static Random r = new Random();
        static int height = 20, width = 10, freq = 30, dx, dy, newX, newY;
        static int CharX = r.Next(1, width), CharY = r.Next(1, height);
        static int FinishX = r.Next(1, width), FinishY = r.Next(1, height);
        static char[,] Map = new char[width, height];







        static void Init()
        {
            FileStream fs = new FileStream("XMLFile1.xml") ;
            int height1 = fs.height;
            int width1 = fs.width;
            int freq1 = fs.freq;
            GenerateMap();
            PlaceCharacter();
        }
        static char[,] GenerateMap()
        {
            int RandNum;
            for (int i = 0; i < height; i++) 
            {
                for (int j = 0; i < width; j++) 
                {
                    RandNum = r.Next(100);
                    if (RandNum < freq) Map[i, j] = '#';
                    else Map[i, j] = ' ';
                }
            }
            Map[FinishX, FinishY] = 'F';
            return Map;

        }
        static char[,] PlaceCharacter()
        {
            Map[CharX, CharY] = '@';
            return Map;
        }





        static void TryMove()
        {
            newX = CharX + dx;
            newY = CharY + dy;
            if (CanGoTo() == true) GoTo();
        }
        static bool IsWalkable()
        {
            return Map[newX, newY] != '#';
        }
        static bool CanGoTo()
        {
            if (newX > width && newY > height) return false;
            if (!IsWalkable()) return false;
            return true;
        }
        static void GoTo()
        {
            CharX = newX;
            CharY = newY;
        }
        static bool IsEndgame()
        {
            if (Map[CharX, CharY] == 'F') return true;
            return false;
        }
        










        static void Draw()
        {
            for (int i = 0; i < height; i++) 
            {
                for (int j = 0; j < width; j++) 
                {
                    if (i == CharX && j == CharY) Map[i, j] = '@';
                    Console.Write(Map[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Input()
        {
            dx = 0;
            dy = 0;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    dy = -1;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    dy = 1;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    dx = 1;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    dx = -1;
                    break;
            }
        }
        static void Logic()
        {
            TryMove();
            IsEndgame();
        }








        static void Main(string[] args)
        {
            Init();
            while (!IsEndgame())
            {
                Draw();
                Input();
                Logic();
            }
            Console.WriteLine("!!!WIN!!!");
        }
    }
}
