using System;
using System.Collections.Generic;
using System.Text;

/**
 * @author Knilax
 * @desc Counts the appearance rate of a piece of data
 */
public abstract class AppearanceCounter
{

  // Properties
  public Sheet ParentSheet;
  public string Name;

  // Fields
  protected int dataAppearances;
  protected int dataChecked;

  /**
   * @desc Constructor
   * @param parentSheet {Sheet} Sheet this perk belongs to
   */
  public AppearanceCounter(Sheet parentSheet, string name)
  {
    ParentSheet = parentSheet;
    Name = name;
  }

  /**
  * @desc Sorts an array of AppearanceCounter instances
  * @param myArray {AppearanceCounter[]} Array of AppearanceCounter instances
  */
  public static void Sort(AppearanceCounter[] unsortedArray)
  {
    Array.Sort(unsortedArray,
      delegate (AppearanceCounter x, AppearanceCounter y)
      {
        return y.AppearanceRate().CompareTo(x.AppearanceRate());
      });
  }

  /**
   * @desc Finds how often this piece of data occurs, then calculates
   * appearance rate.
   */
  public virtual void FindAppearances() { }

  /**
   * @desc Displays the name and rate of the AppearanceCounter instance
   * @return {string} Name and rate of instance
   */
  public override string ToString()
  {
    return $"{Name} ({AppearanceRate()}%)";
  }

  /**
   * @desc Calculates appearance rate of this item
   * @return {float} Returns percent rounded to 2 decimal points
   */
  public float AppearanceRate()
  {
    FindAppearances();
    return (float) Math.Round((float) dataAppearances / dataChecked * 100, 2);
  }


}