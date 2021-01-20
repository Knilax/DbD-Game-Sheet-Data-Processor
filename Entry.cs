using System;
using System.Collections.Generic;
using System.Text;

/**
 * @author Knilax
 * @desc Single row in sheet
 */
public class Entry
{

	// Properties
	public string LastMajorUpdate;
	public string Date;
	public string TimeAdded;
	public string Role;
	public string ScorescreenSlot;
	public string Killer;
	public string Realm;
	public string VODSurvivor;
	public string VODKiller;
	public string StreamingSelf;
	public string StreamingOther;
	public string GreetedStreamer;
	public string ToxicEnemy;
	public string ToxicFriendly;
	public string PerformanceKiller;
	public string PerformanceSurvivor;
	public string PipResult;
	public string InParty;
	public string DCSuicide;
	public string[] Escaped;
	public string[] PCPlayer;
	public string Cheating;
	public string[] RankDistribution;
	public string[] Items;
	public string[] AddonsKiller;
	public string[] Offerings;
	public string[] PerksSurvivor1;
	public string[] PerksSurvivor2;
	public string[] PerksSurvivor3;
	public string[] PerksSurvivor4;
	public string[] PerksKiller;
	public string Notes;

	/**
   * @desc Constructor
   */
	public Entry(string stringEntry)
	{

		// Split stringEntry into array
		// TODO: Currently splits ANY comma in the string, including one in the
		// "Notes" cell
		string[] rawEntry = splitIgnoreQuotes(stringEntry, ',');

		// Initialize arrays
		Escaped = new string[4];
		PCPlayer = new string[5];
		Items = new string[4];
		AddonsKiller = new string[2];
		Offerings = new string[5];
		PerksSurvivor1 = new string[4];
		PerksSurvivor2 = new string[4];
		PerksSurvivor3 = new string[4];
		PerksSurvivor4 = new string[4];
		PerksKiller = new string[4];

		// The reason I do it like this is because I add/change header names
		//   a lot. This allows me to flexibly change the order of headers.
		//   If there's a better way, I either do not know it because I am dumb or
		//   I choose not to because I do not find the work necessary.
		// Starting index for raw entry
		int ind = 0;
		// Set properties
		LastMajorUpdate = rawEntry[ind++];
		Date = rawEntry[ind++];
		TimeAdded = rawEntry[ind++];
		Role = rawEntry[ind++];
		ScorescreenSlot = rawEntry[ind++];
		Killer = rawEntry[ind++];
		Realm = rawEntry[ind++];
		VODSurvivor = rawEntry[ind++];
		VODKiller = rawEntry[ind++];
		StreamingSelf = rawEntry[ind++];
		StreamingOther = rawEntry[ind++];
		GreetedStreamer = rawEntry[ind++];
		ToxicEnemy = rawEntry[ind++];
		ToxicFriendly = rawEntry[ind++];
		PerformanceKiller = rawEntry[ind++];
		PerformanceSurvivor = rawEntry[ind++];
		PipResult = rawEntry[ind++];
		InParty = rawEntry[ind++];
		DCSuicide = rawEntry[ind++];
		Escaped = CopyData(ref rawEntry, ref ind, 4);
		PCPlayer = CopyData(ref rawEntry, ref ind, 5);
		Cheating = rawEntry[ind++];
		RankDistribution = CopyData(ref rawEntry, ref ind, 5);
		Items = CopyData(ref rawEntry, ref ind, 4);
		AddonsKiller = CopyData(ref rawEntry, ref ind, 2);
		Offerings = CopyData(ref rawEntry, ref ind, 5);
		PerksSurvivor1 = CopyData(ref rawEntry, ref ind, 4);
		PerksSurvivor2 = CopyData(ref rawEntry, ref ind, 4);
		PerksSurvivor3 = CopyData(ref rawEntry, ref ind, 4);
		PerksSurvivor4 = CopyData(ref rawEntry, ref ind, 4);
		PerksKiller = CopyData(ref rawEntry, ref ind, 4);
		Notes = rawEntry[ind++];

	} // end Entry constructor

	/**
	 * @desc Split but ignore delimiters within quotes
	 * @param str {string} Raw string
	 * @param delim {char} Delimiter
	 * @return {string[]} Array of strings
	 */
	private static string[] splitIgnoreQuotes(string str, char delim)
  {
		// If first and last character of string are quote, remove them
		if(str[0] == '"' && str[str.Length - 1] == '"')
			str = str.Substring(0, str.Length - 1);

		// Create temporary list for row
		List<string> row = new List<string>();

		// Split string by delimiter (but ignore things within quotes)
		//	I know this is inefficient (like most things in this program)
		//  but I don't foresee it mattering. This program mostly exists to
		//  run once and enter the results to the second tab of the spreadsheet.
		string currentString = "";
		bool ignoreDelimiters = false;
		foreach(char c in str)
    {
			// If meet quote, toggle ignoring string
			if(c == '"') ignoreDelimiters = !ignoreDelimiters;

			// If ignoring delimiter
			if (ignoreDelimiters) currentString += c;
			// If not currently ignoring delimiter
			else
			{
				// Split if meeting delimiter
				if (c == delim)
				{
					row.Add(currentString);
					currentString = "";
				}
				// Add to current string
				else currentString += c;
			}
    }
		// Add last string to list
		row.Add(currentString);

		// Return
		return row.ToArray();
  } // end splitIgnoreQuotes

	/**
	 * @desc Copy given number of elements from starting position and add to
	 * starting index.
	 * @param source {string[]} [ref] Source to copy from
	 * @param startIndex {ind} [ref] Starting index
	 * @param elementsCount {ind} Number of elements to copy
	 * @return (string[]) Copied array
	 */
	private static string[] CopyData(ref string[] source, ref int startIndex,
		int elementsCount)
	{
		string[] destination = new string[elementsCount];
		Array.Copy(source, startIndex, destination, 0, elementsCount);
		startIndex += elementsCount;
		return destination;

	} // end CopyData

	/**
	 * @desc Writes all information to console
	 */
	public void WriteAll()
	{
		Console.WriteLine();
		Console.WriteLine($"Most recent major update: {LastMajorUpdate}");
		Console.WriteLine($"Date: {Date}");
		Console.WriteLine($"Time Added: {TimeAdded}");
		Console.WriteLine($"  Role: {Role}");
		Console.WriteLine($"  Which scorescreen slot was I in?: " +
			$"{ScorescreenSlot}");
		Console.WriteLine($"  Killer: {Killer}");
		Console.WriteLine($"  Realm (map): {Realm}");
		Console.WriteLine($"  Survivor VOD: {VODSurvivor}");
		Console.WriteLine($"  Killer VOD: {VODKiller}");
		Console.WriteLine($"  Was I streaming?: {StreamingSelf}");
		Console.WriteLine($"  Was someone else streaming?: {StreamingOther}");
		Console.WriteLine($"  Streamer greated?: {GreetedStreamer}");
		Console.WriteLine($"  Was your enemy toxic?: {ToxicEnemy}");
		Console.WriteLine($"  Was your team toxic?: {ToxicFriendly}");
		Console.WriteLine($"  Killer performance: {PerformanceKiller}");
		Console.WriteLine($"  Survivor performance: {PerformanceSurvivor}");
		Console.WriteLine($"  Emblem result: {PipResult}");
		Console.WriteLine($"  Was there a DC/Suicide?: {DCSuicide}");
		Console.WriteLine($"  Escaped: {string.Join(", ", Escaped)}");
		Console.WriteLine($"  PC Player?: {string.Join(", ", PCPlayer)}");
		Console.WriteLine($"  Cheater?: {Cheating}");
		Console.WriteLine("  Rank distribution: " +
			string.Join(", ", RankDistribution));
		Console.WriteLine($"  Items: {string.Join(", ", Items)}");
		Console.WriteLine($"  Killer Addons: {string.Join(", ", AddonsKiller)}");
		Console.WriteLine($"  Offerings: {string.Join(", ", Offerings)}");
		Console.WriteLine("  Survivor 1 perks: " +
			string.Join(", ", PerksSurvivor1));
		Console.WriteLine("  Survivor 2 perks: " +
			string.Join(", ", PerksSurvivor2));
		Console.WriteLine("  Survivor 3 perks: " +
				string.Join(", ", PerksSurvivor3));
		Console.WriteLine("  Survivor 4 perks: " +
			string.Join(", ", PerksSurvivor4));
		Console.WriteLine($"  Killer perks: {string.Join(", ", PerksKiller)}");
		Console.WriteLine($"  Notes: {Notes}");

	} // end WriteAll

} // end Entry