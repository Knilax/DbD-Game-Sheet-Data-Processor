using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/**
 * @author Knilax
 * @desc Sheet in total, consisting of Entries
 */
public class Sheet
{

	// Properties
	public List<Entry> Entries = new List<Entry>();

	/**
   * @desc Constructor
   */
	public Sheet(string path)
	{

		// Open input file
		StreamReader sheetFile = null;
		try
		{
			sheetFile = new StreamReader(
				new FileStream(path, FileMode.Open));
		}
		catch (Exception exc)
		{
			Environment.Exit(1);
		}

		// Skip header
		for(int i = 0; i < 5; i++) sheetFile.ReadLine();

		// Add entries
		string currentLine;
		while ((currentLine = sheetFile.ReadLine()) != null)
    {
			Entry entry = new Entry(currentLine);
			Entries.Add(entry);
    }

		// Close input file
		sheetFile.Close();

	} // end Sheet constructor

	/**
	 * @desc Finds percent of perk appearance
	 * @param killer {bool} If killer perk
	 * @param perkName {string} Name of perk
	 */
	public float PerkAppearanceRate(bool killer, string perkToFind)
  {
		perkToFind = perkToFind.ToLower();
		int totalEntries = 0;
		int totalAppearances = 0;
		foreach (Entry entry in Entries)
    {
			// Don't include a killer/survivor if they have an unknown perk
			bool hasUnknownPerks = false;
			int currentAppearances = 0;

			// Save scorescreen slot of spreadsheet contributor if survivor
			// (To ignore the contributor so they do not interfere with data)
			int slotToIgnore = -1;
			if (int.TryParse(entry.ScorescreenSlot, out _))
				slotToIgnore = int.Parse(entry.ScorescreenSlot);

			// Search killer's perks
			if (killer && slotToIgnore != 5)
      {
				// Find appearance rates
				foreach (string perk in entry.PerksKiller)
				{
					// This killer has an unknown perk so don't include this entry
					if (perk == "?")
          {
						hasUnknownPerks = true;
						currentAppearances = 0;
						break;
					}
					
					// As normal
					else if (perk.ToLower() == perkToFind) currentAppearances++;
				}

				// No unknown perks so entry was fine
				if (!hasUnknownPerks)
        {
					totalEntries += 1;
					totalAppearances += currentAppearances;
        }
      } // end searching killer perks

			// Search survivors' perks
			else
			{
				// Merge all survivor perks into one list
				List<string> allPerks = new List<string>();
				if (slotToIgnore != 1) allPerks.AddRange(entry.PerksSurvivor1);
				if (slotToIgnore != 2) allPerks.AddRange(entry.PerksSurvivor2);
				if (slotToIgnore != 3) allPerks.AddRange(entry.PerksSurvivor3);
				if (slotToIgnore != 4) allPerks.AddRange(entry.PerksSurvivor4);

				// Find appearance rates
				foreach (string perk in allPerks)
				{
					// A survivor has an unknown perk so don't include this entry
					if (perk == "?")
					{
						hasUnknownPerks = true;
						currentAppearances = 0;
						break;
					}
					// As normal
					else if (perk.ToLower() == perkToFind) currentAppearances++;
				}

				// No unknown perks so entry was fine
				if(!hasUnknownPerks)
        {
					totalEntries += allPerks.Count / 4;
					totalAppearances += currentAppearances;
				}

			} // end searching survivor perks

		} // end foreach of each entry

		// Return percent
		return (float) Math.Round((double) totalAppearances / totalEntries * 100,
			2);

	} // end PerkAppearanceRate



} // end Sheet