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

    // Write all entries
    foreach (Entry entry in sheet.Entries)
      if(entry.HasCompleteInfo.ToLower() == "yes")
        entry.WriteAll();

    // DS Appearance rate
    Console.WriteLine("Decisive strike: " +
      sheet.PerkAppearanceRate(false, "Decisive Strike") + "%");
    Console.WriteLine("Prove Thyself: " +
      sheet.PerkAppearanceRate(false, "Prove Thyself") + "%");
    Console.WriteLine("Unbreakable: " +
      sheet.PerkAppearanceRate(false, "Unbreakable") + "%"); 
    Console.WriteLine("Dead Hard: " +
      sheet.PerkAppearanceRate(false, "Dead Hard") + "%");
    Console.WriteLine("HEX: Ruin: " +
      sheet.PerkAppearanceRate(true, "HEX: Ruin") + "%");

  }

}