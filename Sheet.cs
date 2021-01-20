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
			Console.WriteLine($"{num}. {appearanceCounter.ToString()}");

			// Increment number
			num++;

		} // end foreach appearanceCounter in arr

	} // end WriteAppearances

	/**
   * @desc Appearances of all perks ordered
   * @param killer {bool} Whether or not to check killer perks
	 * @return {Killer[]} Sorted array of appearances of each perk
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

		// Array of all Perk instances
		Perk[] allPerks = new Perk[allPerkNames.Count];
		for (int i = 0; i < allPerks.Length; i++)
			allPerks[i] = new Perk(this, allPerkNames[i], killer);

		// Sort array
		SortAppearanceCounters(allPerks);

		// Return
		return allPerks;

	} // end AppearancesPerk

	/**
	 * @desc Appearances of all killers ordered
	 * @return {Killer[]} Sorted array of appearances of each killer
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

	/**
	 * @desc Appearances of all maps/realms ordered
   * @param includeMap {bool} Whether or not to include the map
	 * @return {Realm[]} Sorted array of appearances of each map/realm
	 */
	public Realm[] AppearancesRealm()
	{

		// List of all known maps
		List<string> realmNames = new List<string>();
		foreach (Entry entry in Entries)
		{
			// Add if not already in list
			if (!Realm.IncludeMap)
      {
				if (!realmNames.Contains(Realm.ToMapOnly(entry.Realm)))
					realmNames.Add(Realm.ToMapOnly(entry.Realm));
      }
			else if (!realmNames.Contains(entry.Realm))
				realmNames.Add(entry.Realm);
		}

		// Array of Realm instances
		Realm[] realms = new Realm[realmNames.Count];
		for (int i = 0; i < realmNames.Count; i++)
		{
			realms[i] = new Realm(this, realmNames[i]);
		}

		// Sort array
		SortAppearanceCounters(realms);

		// Return
		return realms;

	} // end AppearancesMap

} // end Sheet