++﻿using System;
using System.Collections.Generic;



namespace war
{
    class War
    {
        public static int cardsnum1, cardsnum2, count;
        public static bool pat = true;
        public static Queue<int> deck1 =null, deck2 = null;
        static void Main()
            //Сейчас я придерживаюсь полиморфизма
        {
            Read();
            while (!IsEndgame() && pat == false)
            {
                int card1 = deck1.Dequeue();
                int card2 = deck2.Dequeue();
                Battle(card1, card2);
                count++;
            }
            if (deck1.Count == 0)
                Console.WriteLine("1 " + count);
            else if (deck2.Count == 0)
                Console.WriteLine("2 " + count);
            else
                Console.WriteLine("PAT");
        }
        static void Read()
        {
            cardsnum1 = int.Parse(Console.ReadLine());
            for(int i=0;i<cardsnum1;i++)
            {
                string card = Console.ReadLine();
                card = card.Substring(card.Length-1);
                if (Int32.TryParse(card, out int res) == false)
                    
                {
                    switch (card)
                    {
                        case "J":
                            deck1.Enqueue(11);
                            break;
                        case "Q":
                            deck1.Enqueue(12);
                            break;
                        case "K":
                            deck1.Enqueue(13);
                            break;
                        case "A":
                            deck1.Enqueue(14);
                            break;
                    }
                }
                else
                    deck1.Enqueue(int.Parse(card));
            }
            cardsnum2 = int.Parse(Console.ReadLine());
            for (int i = 0; i < cardsnum2; i++)
            {
                string card = Console.ReadLine();
                card = card.Substring(card.Length - 1);
                if (Int32.TryParse(card, out int res) == false)
                {
                    switch (card)
                    {
                        case "J":
                            deck2.Enqueue(11);
                            break;
                        case "Q":
                            deck2.Enqueue(12);
                            break;
                        case "K":
                            deck2.Enqueue(13);
                            break;
                        case "A":
                            deck2.Enqueue(14);
                            break;
                    }
                }
                else
                    deck2.Enqueue(int.Parse(card));
            }
        }



        static void Battle(int card1, int card2)
        {
            if (card1 > card2)
                deck1.Enqueue(card2);
            else if (card1 < card2)
                deck2.Enqueue(card1);
            else
                War_(card1, card2);
        }
        static void War_(int card1, int card2)
        {
            if (deck1.Count < 3 || deck2.Count < 3)
                pat = false;
            int[] army1 = new int[] {card1,deck1.Dequeue(), deck1.Dequeue(), deck1.Dequeue(), deck1.Dequeue() };
            int[] army2 = new int[] { card2, deck2.Dequeue(), deck2.Dequeue(), deck2.Dequeue(), deck2.Dequeue() };
            for(int i=0;i<army1.Length;i++)
                Battle(army1[i], army2[i]);
        }
        
        static bool IsEndgame()
        {
            if (deck1.Count == 0 || deck2.Count == 0)
                return true;
            return false;
        }
    }
}
