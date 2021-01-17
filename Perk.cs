using System;
using System.Collections.Generic;
using System.Text;

/**
 * @author Knilax
 * @desc Represents a perk
 */
public class Perk
{

  // Properties
  public string Name;

  // Fields
  private int appearances;
  private int perksChecked;
  private Sheet sheet;
  private bool isKiller;

  /**
   * @desc Constructor
   * @param sheet {Sheet} Sheet this perk belongs to
   * @param name {string} Name of the perk
   * @param isKiller {bool} Whether or not this is a killer perk
   */
  public Perk(Sheet sheet, string name, bool isKiller)
  {
    this.sheet = sheet;
    Name = name;
    this.isKiller = isKiller;
  }

  /**
   * @desc Check an array of four perks and see if contains this perk
   * @param perks {string[]} Array of four perks to check
   */
  public void CheckPerks(string[] perks)
  {
    bool encounteredUnknown = false;
    bool appeared = false;
    foreach (string perk in perks)
    {
      // Checks
      if (perk == "?") encounteredUnknown = true;
      else if (perk.ToLower() == Name.ToLower()) appeared = true;
    }
    // Add appearances/checks if no unknown perks
    if(!encounteredUnknown)
    {
      if(appeared) appearances++;
      perksChecked++;
    }
  } // end CheckSurvivor

  /**
   * @desc 
   */
  public float AppearanceRate()
  {
		// Check entries
		foreach(Entry entry in sheet.Entries)
    {

			// Save scorescreen slot of spreadsheet contributor if survivor
			// (To ignore the contributor so they do not interfere with data)
			int slotToIgnore = -1;
			if (int.TryParse(entry.ScorescreenSlot, out _))
				slotToIgnore = int.Parse(entry.ScorescreenSlot);

      // Survivor
      if (!isKiller)
      {
        if (slotToIgnore != 1) CheckPerks(entry.PerksSurvivor1);
        if (slotToIgnore != 2) CheckPerks(entry.PerksSurvivor2);
        if (slotToIgnore != 3) CheckPerks(entry.PerksSurvivor3);
        if (slotToIgnore != 4) CheckPerks(entry.PerksSurvivor4);
      }

      // Killer
      else
      {
        if (slotToIgnore != 5) CheckPerks(entry.PerksKiller);
      }

    } // end foreach entry in Entries

    // Return
    return (float) Math.Round( (float) appearances / perksChecked * 100, 2 );

  } // end FindAppearanceRate

} // end Perk