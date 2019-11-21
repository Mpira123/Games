using System;
using System.Xml;

namespace Labirinth
{
    class Labirinth
    {
        static Random r = new Random();
        static int dx, dy, newX, newY;
        static int CharX, CharY;
        static int FinishX, FinishY;
        static char[,] Map;
        static int height, width, freq;

        public static void LoadParams()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Parametrs.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                switch (xnode.Name)
                {
                    case "height":
                        height = Int32.Parse(xnode.InnerText);
                        break;
                    case "width":
                        width = Int32.Parse(xnode.InnerText);
                        break;
                    case "freq":
                        freq = Int32.Parse(xnode.InnerText);
                        break;
                }
            }
        }


        public static void Init()
        {
            LoadParams();
            CharX = r.Next(1, width);
            CharY = r.Next(1, height);
            FinishX = r.Next(1, width);
            FinishY = r.Next(1, height);
            Map = new char[width, height];
            GenerateMap();
            PlaceCharacter();
        }
        static char[,] GenerateMap()
        {
            int RandNum;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    RandNum = r.Next(100);
                    if (RandNum < freq) Map[j, i] = '#';
                    else Map[j, i] = ' ';
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
            if (CanGoTo()) GoTo();
        }
        static bool IsWalkable()
        {

            if (newX >= width || newY >= height) return false;
            return Map[newX, newY] != '#';
        }
        static bool CanGoTo()
        {

            if (!IsWalkable()) return false;
            return true;
        }
        static void GoTo()
        {
            Map[CharX, CharY] = ' ';
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
            Console.Clear();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == CharY && j == CharX) Map[j, i] = '@';
                    Console.Write(Map[j, i]);
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
