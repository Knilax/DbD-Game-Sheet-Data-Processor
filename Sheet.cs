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
	public string Update;

	/**
   * @desc Constructor
   * @param path {string} Path of .csv file
   * @param update {string} Game update of entries to save
   */
	public Sheet(string path, string update)
	{

		// Properties
		Update = update;

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
			if(entry.LastMajorUpdate == Update) Entries.Add(entry);
    }

		// Close input file
		sheetFile.Close();

	} // end Sheet constructor

	/**
	 * @desc Sorts an array of AppearanceCounter instances
	 * @param myArray {AppearanceCounter[]} Array of AppearanceCounter instances
	 */
	private void SortAppearanceCounters(AppearanceCounter[] unsortedArray)
  {
		Array.Sort(unsortedArray,
			delegate (AppearanceCounter x, AppearanceCounter y)
		{
			return y.AppearanceRate().CompareTo(x.AppearanceRate());
		});
	}

	/**
	 * @desc Writes out array of AppearanceCounter instances ordered
	 * @param arr {AppearanceCounter[]} Array of AppearanceCounter instances
	 */
	public void WriteAppearances(AppearanceCounter[] arr)
  {

		// Write all perks
		int num = 1;
		foreach (AppearanceCounter appearanceCounter in arr)
		{

			string name = appearanceCounter.Name;

			// Don't include empty and unknown
			if (name == "" || name == "?") continue;

			// Write
			Console.WriteLine($"{num}. {name} " +
				$"({appearanceCounter.AppearanceRate()}%)");
			num++;

		} // end foreach appearanceCounter in arr

	} // end WriteAppearances

	/**
   * @desc Returns array of all perks, sorted
   * @param killer {bool} Whether or not to check killer perks.
   */
	public Perk[] AppearancesPerk(bool killer)
	{

		// List of all names of perks found in spreadsheet
		List<string> allPerkNames = new List<string>();
		foreach (Entry entry in Entries)
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
		for (int i = 0; i < allPerks.Length; i++)
			allPerks[i] = new Perk(this, allPerkNames[i], killer);

		// Sort array
		SortAppearanceCounters(allPerks);

		// Return
		return allPerks;

	} // end WritePerkAppearances

	/**
	 * @desc Writes out all killers in order of how often they are used
	 */
	public Killer[] AppearancesKiller()
  {

		// List of all known killers
		List<string> killerNames = new List<string>();
		foreach (Entry entry in Entries)
			if (!killerNames.Contains(entry.Killer))
				killerNames.Add(entry.Killer);

		// Array of Killer objects
		Killer[] killers = new Killer[killerNames.Count];
		for (int i = 0; i < killerNames.Count; i++)
			killers[i] = new Killer(this, killerNames[i]);

		// Sort array
		SortAppearanceCounters(killers);

		// Return
		return killers;

	} // end AppearancesKiller

} // end Sheet