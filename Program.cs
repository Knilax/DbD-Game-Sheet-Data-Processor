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
    Sheet sheet = new Sheet("..\\..\\..\\sheet.csv");

    // List all survivor perks ordered
    Console.WriteLine();
    sheet.WritePerkAppearances(false);

    // List all killer perks ordered
    Console.WriteLine();
    sheet.WritePerkAppearances(true);

  }

}