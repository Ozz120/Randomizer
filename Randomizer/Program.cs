
using System;
using System.Collections.Generic;

namespace TwentyOneGame
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("=== Игра '21' ===");

            int playerScore = 0;
            int dealerScore = 0;

            // Ход игрока
            while (true)
            {
                int card = GetCard();
                playerScore += card;

                Console.WriteLine($"\nВы вытянули: {card}");
                Console.WriteLine($"Ваш текущий счет: {playerScore}");

                if (playerScore > 21)
                {
                    Console.WriteLine("Перебор! Вы проиграли.");
                    break;
                }
                else if (playerScore == 21)
                {
                    Console.WriteLine("21! Отличный результат!");
                    break;
                }

                Console.Write("Еще карту? (д/н): ");
                if (Console.ReadLine().ToLower() != "д")
                    break;
            }

            if (playerScore <= 21)
            {
                // Ход дилера
                Console.WriteLine("\n=== Ход дилера ===");
                while (dealerScore < 17 && playerScore <= 21)
                {
                    int card = GetCard();
                    dealerScore += card;
                    Console.WriteLine($"Дилер вытянул: {card}");
                    Console.WriteLine($"Счет дилера: {dealerScore}");
                }

                // Определение победителя
                Console.WriteLine("\n=== Результат ===");
                Console.WriteLine($"Ваш счет: {playerScore}");
                Console.WriteLine($"Счет дилера: {dealerScore}");

                if (dealerScore > 21 || playerScore > dealerScore)
                    Console.WriteLine("🎉 Вы победили!");
                else if (playerScore < dealerScore)
                    Console.WriteLine("💀 Вы проиграли!");
                else
                    Console.WriteLine("🤝 Ничья!");
            }

            Console.ReadKey();
        }

        static int GetCard()
        {
            // Карты от 2 до 11 (туз = 11)
            return random.Next(2, 12);
        }
    }
}