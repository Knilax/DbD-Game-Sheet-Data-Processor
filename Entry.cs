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
	public string Date { get; set; }
	public string TimeAdded { get; set; }
	public string Role { get; set; }
	public string SurvivorNumber { get; set; }
	public string Killer { get; set; }
	public string Map { get; set; }
	public string VODSurvivor { get; set; }
	public string VODKiller { get; set; }
	public string StreamingSelf { get; set; }
	public string StreamingOther { get; set; }
	public string PerformanceKiller { get; set; }
	public string PerformanceSurvivor { get; set; }
	public string GreetedStreamer { get; set; }
	public string ToxicEnemy { get; set; }
	public string ToxicFriendly { get; set; }
	public string DCSuicide { get; set; }
	public string[] RankDistribution { get; set; }
	public string[] Items { get; set; }
	public string[] Offerings { get; set; }
	public string[] PerksSurvivor1 { get; set; }
	public string[] PerksSurvivor2 { get; set; }
	public string[] PerksSurvivor3 { get; set; }
	public string[] PerksSurvivor4 { get; set; }
	public string[] PerksKiller { get; set; }
	public string Notes { get; set; }

	/**
   * @desc Constructor
   */
	public Entry(string stringEntry)
	{

		// Split stringEntry into array
		// TODO: Currently splits ANY comma in the string, including one in the
		// "Notes" cell
		string[] rawEntry = stringEntry.Split(",");

		// Initialize arrays
		Items = new string[4];
		Offerings = new string[5];
		PerksSurvivor1 = new string[4];
		PerksSurvivor2 = new string[4];
		PerksSurvivor3 = new string[4];
		PerksSurvivor4 = new string[4];
		PerksKiller = new string[4];

		// Starting index for raw entry
		int ind = 0;
		// Set properties
		Date = rawEntry[ind++];
		TimeAdded = rawEntry[ind++];
		Role = rawEntry[ind++];
		SurvivorNumber = rawEntry[ind++];
		Killer = rawEntry[ind++];
		Map = rawEntry[ind++];
		VODSurvivor = rawEntry[ind++];
		VODKiller = rawEntry[ind++];
		StreamingSelf = rawEntry[ind++];
		StreamingOther = rawEntry[ind++];
		PerformanceKiller = rawEntry[ind++];
		PerformanceSurvivor = rawEntry[ind++];
		GreetedStreamer = rawEntry[ind++];
		ToxicEnemy = rawEntry[ind++];
		ToxicFriendly = rawEntry[ind++];
		DCSuicide = rawEntry[ind++];
		RankDistribution = CopyData(ref rawEntry, ref ind, 5);
		Items = CopyData(ref rawEntry, ref ind, 4);
		Offerings = CopyData(ref rawEntry, ref ind, 5);
		PerksSurvivor1 = CopyData(ref rawEntry, ref ind, 4);
		PerksSurvivor2 = CopyData(ref rawEntry, ref ind, 4);
		PerksSurvivor3 = CopyData(ref rawEntry, ref ind, 4);
		PerksSurvivor4 = CopyData(ref rawEntry, ref ind, 4);
		PerksKiller = CopyData(ref rawEntry, ref ind, 4);
		Notes = rawEntry[ind];

	} // end Entry constructor

	/**
	 * @desc Copy given number of elements from starting position and add to
	 * starting index.
	 * @param source {string[]} [ref] Source to copy from
	 * @param startIndex {ind} [ref] Starting index
	 * @param elementsCount {ind} Number of elements to copy
	 * @return (string[]) Copied array
	 */
	private string[] CopyData(ref string[] source, ref int startIndex,
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
		Console.WriteLine($"Date: {Date}");
		Console.WriteLine($"Time Added: {TimeAdded}");
		Console.WriteLine($"  Role: {Role}");
		Console.WriteLine($"  Which # survivor was I?: {SurvivorNumber}");
		Console.WriteLine($"  Killer: {Killer}");
		Console.WriteLine($"  Map: {Map}");
		Console.WriteLine($"  Survivor VOD: {VODSurvivor}");
		Console.WriteLine($"  Killer VOD: {VODKiller}");
		Console.WriteLine($"  Was I streaming?: {StreamingSelf}");
		Console.WriteLine($"  Was someone else streaming?: {StreamingOther}");
		Console.WriteLine($"  Killer performance: {PerformanceKiller}");
		Console.WriteLine($"  Survivor performance: {PerformanceSurvivor}");
		Console.WriteLine($"  Streamer greated?: {GreetedStreamer}");
		Console.WriteLine($"  Was your enemy toxic?: {ToxicEnemy}");
		Console.WriteLine($"  Was your team toxic?: {ToxicFriendly}");
		Console.WriteLine($"  Was there a DC/Suicide?: {DCSuicide}");
		Console.WriteLine("  Rank distribution: " +
			string.Join(", ", RankDistribution));
		Console.WriteLine($"  Items: {string.Join(", ", Items)}");
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
	} // end WriteAll

} // end Entry