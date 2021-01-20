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

    // List realm appearances ordered
    Console.WriteLine("\nMost visited realms:");
    Realm.IncludeMap = false;
    sheet.WriteAppearances(sheet.AppearancesRealm());

    // List map appearances ordered
    Console.WriteLine("\nMost visited maps:");
    Realm.IncludeMap = true;
    sheet.WriteAppearances(sheet.AppearancesRealm());

    // List most played killers
    Console.WriteLine("\nMost played killers");
    sheet.WriteAppearances(sheet.AppearancesKiller());

  }

}