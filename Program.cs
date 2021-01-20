﻿using System;

/**
 * @author Knilax
 */
class Program
{
  /**
   * @desc Main
   */
  static void Main(string[] args)
  {

    // Create sheet
    Sheet sheet = new Sheet("..\\..\\..\\sheet.csv", "Twins");

    // List of all survivor perks ordered
    Console.WriteLine("\nSurvivor perks");
    sheet.OutputRatesPerk(false);

    // List of all killer perks ordered
    Console.WriteLine("\nKiller perks");
    sheet.OutputRatesPerk(true);

    // List realm appearances ordered
    Console.WriteLine("\nMost visited realms:");
    sheet.OutputRatesRealm();

    // List map appearances ordered
    Console.WriteLine("\nMost visited maps:");
    sheet.OutputRatesMap();

    // List most played killers
    Console.WriteLine("\nMost played killers");
    sheet.OutputRatesKiller();

    // List best killer streaks
    Console.WriteLine("\nCurrent best killer streaks");
    sheet.OutputStreakWinKiller();

  }

}