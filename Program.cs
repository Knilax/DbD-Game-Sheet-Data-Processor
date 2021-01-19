using System;

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
    sheet.WriteAppearances(sheet.AppearancesPerk(false));

    // List of all killer perks ordered
    Console.WriteLine("\nKiller perks");
    sheet.WriteAppearances(sheet.AppearancesPerk(true));

    // List most played killers
    Console.WriteLine("\nMost played killers");
    sheet.WriteAppearances(sheet.AppearancesKiller());

  }

}