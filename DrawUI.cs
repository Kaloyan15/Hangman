﻿using System;
using Hangman;
using System.Threading;

public class UI
{
    public static int mistakeCounter = 0;
    public static int positionCounter = 0;
    public static string chosenLetter;
    public static ConsoleKey n;
    public static ConsoleKey m;


    
    public static void ShowInitMessages()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(" Hangman v1.0 by Kalin Lalov and Miro Karagyozov");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(" Do you want to play with Bulgarian or English words? Please type 'bg' or 'en':");
        Console.ForegroundColor = ConsoleColor.Cyan;

        
    }


    public static void MistakePhases()
    {
        switch(mistakeCounter)
            {
            case 1:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(30,3);
                Console.Write("┌");
                Console.SetCursorPosition(30,4);
                Console.Write("│");
                Console.SetCursorPosition(30,5);
                Console.Write("│");
                Console.SetCursorPosition(30,6);
                Console.Write("│");
                Console.SetCursorPosition(30,7);
                Console.Write("│");
                Console.SetCursorPosition(30,8);
                Console.Write("│");
                Console.SetCursorPosition(41,3);
                Console.WriteLine(mistakeCounter);
                Console.SetCursorPosition(0, 5 + positionCounter);

            break;

            case 2:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(31,3);
                Console.Write("─");
                Console.SetCursorPosition(32,3);
                Console.Write("─");
                Console.SetCursorPosition(33,3);
                Console.Write("─");
                Console.SetCursorPosition(34,3);
                Console.Write("─");
                Console.SetCursorPosition(35,3);
                Console.Write("┐");
                Console.SetCursorPosition(41,3);
                Console.WriteLine(mistakeCounter);
                Console.SetCursorPosition(0, 5 + positionCounter);

            break;

            case 3:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(35,4);
                Console.Write("0");
                Console.SetCursorPosition(41,3);
                Console.WriteLine(mistakeCounter);
                Console.SetCursorPosition(0, 5 + positionCounter);
            break;

            case 4:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(35,5);
                Console.Write("│");
                Console.SetCursorPosition(35,6);
                Console.Write("│");
                Console.SetCursorPosition(41,3);
                Console.WriteLine(mistakeCounter);
                Console.SetCursorPosition(0, 5 + positionCounter);
            break;

            case 5:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(34,5);
                Console.Write("┌");
                Console.SetCursorPosition(36,5);
                Console.Write("┐");
                Console.SetCursorPosition(41,3);
                Console.WriteLine(mistakeCounter);
                Console.SetCursorPosition(0, 5 + positionCounter);
            break;

            }
    }


    public static void DrawUI()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Enter a letter to guess the word! ");
        
        for (int l = 0; l < Program.chosenWord.Length; l++)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (l == 0)
            {

                Console.WriteLine();
                Console.WriteLine(" " + Program.chosenWord[l]);

            }
            if (Program.chosenWord[l] == Program.firstLetter || Program.chosenWord[l] == Program.lastLetter)
            {
                if (l != 0 && l != Program.chosenWord.Length)
                {
                    Console.SetCursorPosition((l * 2), 2);
                    Console.WriteLine(" " + Program.chosenWord[l]);
                }

            }
            if (l == Program.chosenWord.Length)
            {
                Console.SetCursorPosition((Program.chosenWord.Length * 2) - 2, 2);
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition((l * 2), 3);
            Console.WriteLine(" _");

        }
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine();
        Console.SetCursorPosition(43,3);
        Console.Write("Wrong Guesses ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(41,3);
        Console.WriteLine(mistakeCounter);


            string existingLetters = Program.used_letters.ToString();

        while (true) // win or lose condition
        {
            MistakePhases();
            if(mistakeCounter == 6)
            {
              Console.ForegroundColor = ConsoleColor.Blue;
              Console.SetCursorPosition(34,6);
              Console.Write("┌");
              Console.SetCursorPosition(36,6);
              Console.Write("┐");
              Console.SetCursorPosition(34,7);
              Console.Write("│");
              Console.SetCursorPosition(36,7);
              Console.Write("│");
              Console.SetCursorPosition(41,3);
              Console.WriteLine(mistakeCounter);
              Console.SetCursorPosition(0, 5 + positionCounter);
              Console.ForegroundColor = ConsoleColor.Cyan;
              Console.WriteLine("The word was: " + Program.chosenWord);
              Thread.Sleep(3000);
              Console.Clear();
              Console.ForegroundColor = ConsoleColor.DarkRed;
              Console.WriteLine("YOU LOST!!!");
              Thread.Sleep(3000);
              Console.Clear();
              mistakeCounter = 0;
              positionCounter = 0;
              chosenLetter = "";
              break;
            }

             if (Program.letters_word.Length == Program.used_letters.Length + 2)
             { 
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("YOU WON!!!");
                    Thread.Sleep(4000);
                    Console.Clear();
                    mistakeCounter = 0;
                    positionCounter = 0;
                    chosenLetter = "";
                    break;
             }

             Program.stringLength_counter = 0;
             existingLetters = Program.used_letters.ToString();
             positionCounter++;

            EnteringError:
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            EnterError:
            if(Program.isBG == false)
            {
              do
              {
                if(m != ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(0, 5 + positionCounter - 1);
                    Console.Write("  "); 
                }
                n = ConsoleKey.Clear; 
                m = ConsoleKey.Clear; 
                Console.SetCursorPosition(0, 5 + positionCounter - 1);
                n = Console.ReadKey().Key;
                if(n == ConsoleKey.Enter)
                {
                    goto EnterError;
                }
                chosenLetter = n.ToString().ToLower();
                m = Console.ReadKey().Key;
              }
              while(m != ConsoleKey.Enter);
            }
            if(Program.isBG == true)
            {
              do
              {
                if(m != ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(0, 5 + positionCounter - 1);
                    Console.Write("  "); 
                }
                n = ConsoleKey.Clear;
                m = ConsoleKey.Clear; 
                Console.SetCursorPosition(0, 5 + positionCounter - 1);
                n = Console.ReadKey().Key;
                if(n == ConsoleKey.Enter)
                {
                    goto EnterError;
                }
                chosenLetter = n.ToString().ToLower();
                    switch(n)
                    {
                         case ConsoleKey.Q:
                         chosenLetter = "я";      
                         break;
                         case ConsoleKey.W:
                         chosenLetter = "в";      
                         break;
                         case ConsoleKey.E:
                         chosenLetter = "е";      
                         break;
                         case ConsoleKey.R:
                         chosenLetter = "р";      
                         break;
                         case ConsoleKey.T:
                         chosenLetter = "т";      
                         break;
                         case ConsoleKey.Y:
                         chosenLetter = "ъ";      
                         break;
                         case ConsoleKey.U:
                         chosenLetter = "у";      
                         break;
                         case ConsoleKey.I:
                         chosenLetter = "и";      
                         break;
                         case ConsoleKey.O:
                         chosenLetter = "о";      
                         break;
                         case ConsoleKey.P:
                         chosenLetter = "п";      
                         break;
                         case ConsoleKey.A:
                         chosenLetter = "а";      
                         break;
                         case ConsoleKey.S:
                         chosenLetter = "с";      
                         break;
                         case ConsoleKey.D:
                         chosenLetter = "д";      
                         break;
                         case ConsoleKey.F:
                         chosenLetter = "ф";      
                         break;
                         case ConsoleKey.G:
                         chosenLetter = "г";      
                         break;
                         case ConsoleKey.H:
                         chosenLetter = "х";      
                         break;
                         case ConsoleKey.J:
                         chosenLetter = "й";      
                         break;
                         case ConsoleKey.K:
                         chosenLetter = "к";      
                         break;
                         case ConsoleKey.L:
                         chosenLetter = "л";      
                         break;
                         case ConsoleKey.Z:
                         chosenLetter = "з";      
                         break;
                         case ConsoleKey.X:
                         chosenLetter = "ь";      
                         break;
                         case ConsoleKey.C:
                         chosenLetter = "ц";      
                         break;
                         case ConsoleKey.V:
                         chosenLetter = "ж";      
                         break;
                         case ConsoleKey.B:
                         chosenLetter = "б";      
                         break;
                         case ConsoleKey.N:
                         chosenLetter = "н";      
                         break;
                         case ConsoleKey.M:
                         chosenLetter = "м";      
                         break;
                         case ConsoleKey.Oem3:
                         chosenLetter = "ч";      
                         break;
                         case ConsoleKey.Oem5:
                         chosenLetter = "ю";      
                         break;
                         case ConsoleKey.Oem4:
                         chosenLetter = "ш";
                         break;
                         case ConsoleKey.Oem6:
                         chosenLetter = "щ";      
                         break;
                    }
                m = Console.ReadKey().Key;
              }
              while(m != ConsoleKey.Enter);
            }


            while (Program.CheckForDuplicates())
            {             

                Console.SetCursorPosition(0, 5 + positionCounter - 1);
                 for (int i = 1; i < chosenLetter.Length + 1; i++)
                 {
                     Console.Write(" ");
                 }
                 Console.SetCursorPosition(0, 5 + positionCounter - 1);

                goto EnteringError;               
            }


                for (int i = 0; i < Program.chosenWord.Length; i++)
                {
                    if (chosenLetter[0] == Program.chosenWord[i])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.SetCursorPosition((i * 2) + 1, 2);
                        Console.WriteLine(Program.chosenWord[i]);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.SetCursorPosition(0, 4 + positionCounter);
                        Console.WriteLine(chosenLetter);
                    }


                }

                if (Program.chosenWord.Contains(chosenLetter) == false)
                {

                    mistakeCounter++;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(0, 4 + positionCounter);
                    Console.WriteLine(chosenLetter);
                }


                for (int i = 0; i < Program.letters_word.Length; i++) 
                {
                    if (chosenLetter[0] == Program.letters_word[i])
                    {
                        for (int k = 0; k < existingLetters.Length; k++)
                        {
                            if(chosenLetter[0] != existingLetters[k])
                            {
                                Program.stringLength_counter++;
                            }
                            
                        }
                        if (Program.stringLength_counter == existingLetters.Length) Program.used_letters.Append(chosenLetter);
                    }
                }


        }

    }
}