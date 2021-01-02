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

  }

}