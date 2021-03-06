﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WinePicker.Repo;
using WinePicker.Shared.Models;

namespace WinePicker.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var wineList = GetWineList();

            Console.WriteLine("Press any key to begin!");
            Console.ReadKey();
            ClearCurrentConsoleLine();

            AsciiArtWineTime();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Randomly selecting our wine!");
            Console.WriteLine("");
            Console.WriteLine("");

            var resultWine = GetResultWithRandomDisplay(wineList, 7);

            Console.WriteLine("We are going to drink...");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"~~~~~~~~~~     {resultWine}     ~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("");

            AsciiArtCelebrate();

            Console.ReadKey();
        }

        private static List<WineModel> GetWineList()
        {
            var mongo = new MongoDatabase();
            return mongo.GetAllWines();
        }

        private static void AsciiArtWineTime()
        {
            Console.WriteLine(@"          _                _   _                ");
            Console.WriteLine(@"         (_)              | | (_)               ");
            Console.WriteLine(@"__      ___ _ __   ___    | |_ _ _ __ ___   ___ ");
            Console.WriteLine(@"\ \ /\ / / | '_ \ / _ \   | __| | '_ ` _ \ / _ \");
            Console.WriteLine(@" \ V  V /| | | | |  __/   | |_| | | | | | |  __/");
            Console.WriteLine(@"  \_/\_/ |_|_| |_|\___|    \__|_|_| |_| |_|\___|");
        }

        private static string GetResultWithRandomDisplay(List<WineModel> wineList, int seconds)
        {
            var randomWine = string.Empty;
            for (var i = 0; i < seconds * 10; i++)
            {
                var rng = new Random();
                var index = rng.Next(0, wineList.Count() - 1);
                randomWine = wineList[index].Name;
                ClearCurrentConsoleLine();
                Console.Write(randomWine);
                Thread.Sleep(100);
            }
            ClearCurrentConsoleLine();
            return randomWine;
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");
            Console.SetCursorPosition(0, currentLineCursor);
        }

        private static void AsciiArtCelebrate()
        {
            Console.WriteLine(@"                           (");
            Console.WriteLine(@"*                           )   *");
            Console.WriteLine(@"              )     *      (");
            Console.WriteLine(@"    )        (                   (");
            Console.WriteLine(@"   (          )     (             )");
            Console.WriteLine(@"    )    *           )        )  (");
            Console.WriteLine(@"   (                (        (      *");
            Console.WriteLine(@"    )          H     )        )");
            Console.WriteLine(@"              [ ]            (");
            Console.WriteLine(@"       (  *   |-|       *     )    (");
            Console.WriteLine(@" *      )     |_|        .          )");
            Console.WriteLine(@"       (      | |    .  ");
            Console.WriteLine(@" )           /   \     .    ' .        *");
            Console.WriteLine(@"(           |_____|  '  .    .  ");
            Console.WriteLine(@" )          | ___ |  \~~~/  ' .   (");
            Console.WriteLine(@"        *   | \ / |   \_/  \~~~/   )");
            Console.WriteLine(@"            | _Y_ |    |    \_/   (");
            Console.WriteLine(@"*           |-----|  __|__   |      *");
            Console.WriteLine(@"            `-----`        __|__");
        }
    }
}