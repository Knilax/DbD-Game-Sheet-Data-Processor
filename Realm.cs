using System;
using System.Collections.Generic;
using System.Text;

/**
 * @author Knilax
 * @desc Represents a realm (map)
 */
public class Realm : AppearanceCounter
{

  // Properties
  public static bool IncludeMap = true;

  /**
   * @desc Constructor
   * @param sheet {Sheet} Parent sheet
   * @param name {Name} Name of piece of data
   */
  public Realm(Sheet sheet, string name) : base(sheet, name) { }

  /**
   * @desc Converts "map (realm)" to just "map"
   * @param str {string} Full string to convert
   * @return {string} Converted string
   */
  public static string ToMapOnly(string str)
  {
    int ind = str.IndexOf("(", 0);
    if (ind != -1)
    {
      str = str.Substring(ind + 1);
      str = str.Substring(0, str.Length - 1);
    }
    return str;
  }

  /**
   * @desc Find how often map appears
   * @param {bool} includeMap
   * @return {float} Percentage appearance rate
   */
  public override void FindAppearances()
  {
    // Look through all entries
    foreach (Entry entry in ParentSheet.Entries)
    {
      // Checked
      dataChecked++;

      // Names match
      if (!Realm.IncludeMap)
      {
        if (Realm.ToMapOnly(entry.Realm).ToLower() == Name.ToLower())
          dataAppearances++;
      }
      else if (entry.Realm.ToLower() == Name.ToLower())
        dataAppearances++;

    } // end foreach entry in Entries

  } // end FindAppearances

} // end Realm