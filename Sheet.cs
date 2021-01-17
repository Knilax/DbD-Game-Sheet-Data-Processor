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
	 * @desc List of all perks in spreadsheet.
	 * @param killer {bool} Whether or not to search killer perks.
	 * @return {Perk[]} Array of all Perk instances
	 */
	public Perk[] PerksAll(bool killer)
  {

		// List of all names of perks found in spreadsheet
		List<string> allPerkNames = new List<string>();
		foreach(Entry entry in Entries)
    {
			// Survivor
			if (!killer)
			{
				foreach (string perk in entry.PerksSurvivor1)
					if (!allPerkNames.Contains(perk)) allPerkNames.Add(perk);
				foreach (string perk in entry.PerksSurvivor2)
					if (!allPerkNames.Contains(perk)) allPerkNames.Add(perk);
				foreach (string perk in entry.PerksSurvivor3)
					if (!allPerkNames.Contains(perk)) allPerkNames.Add(perk);
				foreach (string perk in entry.PerksSurvivor4)
					if (!allPerkNames.Contains(perk)) allPerkNames.Add(perk);
			}
			// Killer
			else
      {
				foreach (string perk in entry.PerksKiller)
					if (!allPerkNames.Contains(perk)) allPerkNames.Add(perk);
			}
		}

		// Array of all Perk objects
		Perk[] allPerks = new Perk[allPerkNames.Count];
		for(int i = 0; i < allPerks.Length; i++)
    {
			// Create Perk
			Perk perk = new Perk(this, allPerkNames[i], killer);
			allPerks[i] = perk;
    }

		// Sort array
		Array.Sort(allPerks, delegate(Perk x, Perk y) {
			return y.AppearanceRate().CompareTo(x.AppearanceRate());
		} );

		// Return temp
		return allPerks;

	} // end PerksAll

	/**
   * @desc Writes out all perks in spreadsheet in order of appearance rate.
   * @param killer {bool} Whether or not to check killer perks.
   */
	public void WritePerkAppearances(bool killer)
	{
		int num = 1;
		foreach (Perk perk in PerksAll(killer))
		{
			string perkName = perk.Name;

			// Don't include empty and unknown
			if (perkName == "" || perkName == "?") continue;

			Console.WriteLine($"{num}. {perkName} ({perk.AppearanceRate()}%)");
			num++;
		}
	}

} // end Sheet