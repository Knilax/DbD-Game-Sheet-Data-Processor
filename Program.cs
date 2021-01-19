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

    // List all favorite killers ordered
    Console.WriteLine();
    sheet.WriteAppearances(sheet.AppearancesKiller());

  }

}