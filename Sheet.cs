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

		// Header
		sheetFile.ReadLine();

		// Add entries
		string currentLine;
		while ((currentLine = sheetFile.ReadLine()) != null)
    {
			Entries.Add(new Entry(currentLine));
    }

		// Close input file
		sheetFile.Close();

	} // end Sheet constructor

} // end Sheet