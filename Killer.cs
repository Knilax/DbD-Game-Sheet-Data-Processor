using System;
using System.Collections.Generic;
using System.Text;

/**
 * @author Knilax
 * @desc Represents a killer
 */
public class Killer : AppearanceCounter
{

  /**
   * @desc Constructor
   * @param sheet {Sheet} Parent sheet
   * @param name {Name} Name of piece of data
   */
  public Killer(Sheet sheet, string name) : base(sheet, name) { }

  /**
   * @desc Find how often perk appears in entries
   * @return {float} Percentage appearance rate
   */
  public override void FindAppearances()
  {
    // Look through all entries
    foreach(Entry entry in ParentSheet.Entries)
    {

      // Only count owner playing killer
      if (entry.Role.ToLower() != "killer") continue;

      // Checked
      dataChecked++;

      // Names match
      if (entry.Killer.ToLower() == Name.ToLower())
        dataAppearances++;

    } // end foreach entry in Entries

  } // end FindAppearances

} // end Killer