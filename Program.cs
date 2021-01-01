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

    // Debug
    Sheet sheet = new Sheet("..\\..\\..\\sheet.csv");

    // DS appearance rate
    Console.WriteLine("Decisive strike appearance rate: " +
      sheet.PerkAppearanceRate(false, "Decisive Strike") + "%");

  }

}