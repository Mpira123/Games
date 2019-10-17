using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class Program
    {
        static char[,] Map;
        static int TurnN = 0, newX, newY, x, y;
        static char winner;






        static char[,] GenerateMap(char[,] Map)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Map[i, j] = '^';
                    Console.Write(Map[i, j]);
                }
                Console.WriteLine();
            }
            return Map;
        }
        static bool CanPut(int newX, int newY)
        {
            if (Map[newX, newY] != 'X' && Map[newX, newY] != 'Y' && newX >= 0 && newY >= 0) return true;
            return false;
        }
        static void Put()
        {
            x = newX;
            y = newY;
        }
        static bool WhoseTurn(int TurnN)
        {
            if (TurnN % 2 == 0) return true;
            else return false;
        }
        static void TryPut(int newX, int newY)
        {
            if (CanPut(newX, newY)) Put();
        }
        static bool IsEndgame()
        {
            if (Map[0, 0] == Map[0, 1] && Map[0, 1] == Map[0, 2] && Map[0, 2] == 'X') { winner = '1'; return true; }
            else if (Map[1, 0] == Map[1, 1] && Map[1, 1] == Map[1, 2] && Map[0, 2] == 'X') { winner = '1'; return true; }
            else if (Map[2, 0] == Map[2, 1] && Map[2, 1] == Map[2, 2] && Map[2, 2] == 'X') { winner = '1'; return true; }
            else if (Map[0, 0] == Map[1, 0] && Map[1, 0] == Map[2, 0] && Map[2, 0] == 'X') { winner = '1'; return true; }
            else if (Map[0, 1] == Map[1, 1] && Map[1, 1] == Map[2, 1] && Map[2, 1] == 'X') { winner = '1'; return true; }
            else if (Map[0, 2] == Map[1, 2] && Map[1, 2] == Map[2, 2] && Map[2, 2] == 'X') { winner = '1'; return true; }
            else if (Map[0, 0] == Map[1, 1] && Map[1, 1] == Map[2, 2] && Map[2, 2] == 'X') { winner = '1'; return true; }
            else if (Map[2, 0] == Map[1, 1] && Map[1, 1] == Map[0, 2] && Map[0, 2] == 'X') { winner = '1'; return true; }
            else if (Map[0, 0] == Map[0, 1] && Map[0, 1] == Map[0, 2] && Map[0, 2] == 'Y') { winner = '2'; return true; }
            else if (Map[1, 0] == Map[1, 1] && Map[1, 1] == Map[1, 2] && Map[1, 2] == 'Y') { winner = '2'; return true; }
            else if (Map[2, 0] == Map[2, 1] && Map[2, 1] == Map[2, 2] && Map[2, 2] == 'Y') { winner = '2'; return true; }
            else if (Map[0, 0] == Map[1, 0] && Map[1, 0] == Map[2, 0] && Map[2, 0] == 'Y') { winner = '2'; return true; }
            else if (Map[0, 1] == Map[1, 1] && Map[1, 1] == Map[2, 1] && Map[2, 1] == 'Y') { winner = '2'; return true; }
            else if (Map[0, 2] == Map[1, 2] && Map[1, 2] == Map[2, 2] && Map[2, 2] == 'Y') { winner = '2'; return true; }
            else if (Map[0, 0] == Map[1, 1] && Map[1, 1] == Map[2, 2] && Map[2, 2] == 'Y') { winner = '2'; return true; }
            else if (Map[2, 0] == Map[1, 1] && Map[1, 1] == Map[0, 2] && Map[0, 2] == 'Y') { winner = '2'; return true; }
            else { winner = 'D'; return false; }
        }
        







        static void Draw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == x && i == y)
                    {
                        if (WhoseTurn(TurnN) == true) Map[i, j] = 'X';
                        else Map[i, j] = 'O';
                    }
                    Console.Write(Map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Input()
        {
            Console.WriteLine("Player " + (TurnN % 2 + 1) + " write coordinates");
            var input = Console.ReadLine().Split(' ');
            newX = int.Parse(input[0]);
            newY = int.Parse(input[1]);
        }
        static void Logic()
        {
            TryPut(newX, newY);
            IsEndgame();
        }






        static void Main()
        {
            Map=new char[3,3];
            GenerateMap(Map);
            while (!IsEndgame())
            {
                Input();
                Draw();
                Logic();
                TurnN++;
            }
            switch (winner)
            {
                case '1':
                    Console.WriteLine("Player 1 wins!!!");
                    break;
                case '2':
                    Console.WriteLine("Player 2 wins!!!");
                    break;
                case 'D':
                    Console.WriteLine("Draw");
                    break;
            }
        }
    }
}
