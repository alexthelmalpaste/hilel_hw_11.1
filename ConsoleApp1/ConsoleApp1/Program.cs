using System;
using System.Collections.Generic;

class Hangman
{
    static void Main()
    {
        string secretWord = "гит";
        char[] guessedWord = new char[secretWord.Length];
        for (int i = 0; i < guessedWord.Length; i++)
        {
            guessedWord[i] = '_';
        }

        int attemptsRemaining = 3;
        HashSet<char> guessedLetters = new HashSet<char>();

        Console.WriteLine("Вітаємо! Спробуйте вгадати зашифроване слово!");
        Console.WriteLine($"Кількість літер у слові: {secretWord.Length}");
        Console.WriteLine($"Кількість можливих невірних спроб: {attemptsRemaining}");

        while (attemptsRemaining > 0 && Array.Exists(guessedWord, c => c == '_'))
        {
            Console.WriteLine("\nЗашифроване слово: " + string.Join(" ", guessedWord));
            Console.Write("Введіть вашу літеру: ");
            string input = Console.ReadLine()?.ToLower();

            if (string.IsNullOrEmpty(input) || input.Length != 1 || !char.IsLetter(input[0]))
            {
                Console.WriteLine("Будь ласка, введіть одну літеру.");
                continue;
            }

            char guess = input[0];

            if (guessedLetters.Contains(guess))
            {
                Console.WriteLine("Ви вже пробували цю літеру!");
                continue;
            }

            guessedLetters.Add(guess);

            if (secretWord.Contains(guess))
            {
                Console.Write("Така літера є у слові! Позиція літери: ");
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == guess)
                    {
                        guessedWord[i] = guess;
                        Console.Write((i + 1) + " ");
                    }
                }
                Console.WriteLine();
            }
            else
            {
                attemptsRemaining--;
                Console.WriteLine($"Такої літери немає! Залишилось спроб: {attemptsRemaining}");
            }
        }

        if (!Array.Exists(guessedWord, c => c == '_'))
        {
            Console.WriteLine($"\nВітаємо, ви вгадали слово! Зашифроване слово: {secretWord}");
        }
        else
        {
            Console.WriteLine($"\nНа жаль, ви програли. Зашифроване слово було: {secretWord}");
        }

        Console.WriteLine("Дякуємо за гру!");
    }
}
