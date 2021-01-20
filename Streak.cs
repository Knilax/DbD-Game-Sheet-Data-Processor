using System;
using System.Collections.Generic;
using System.Text;

/**
 * @author Knilax
 * @desc Represents a streak that can break
 */
public class Streak
{

  // Properties
  public Sheet ParentSheet;
  public string Name;
  public int CurrentStreak = 0;
  public int BestStreak = 0;

  /**
   * @desc Constructor
   * @param name {string} Name of item
   */
  public Streak(Sheet parentSheet, string name)
  {
    ParentSheet = parentSheet;
    Name = name;
  }

  /**
   * @desc PlayNextGame
   * @param won {bool} Whether or not the next game was won
   */
  public void PlayNextGame(bool won)
  {
    if (won)
    {
      CurrentStreak++;
      if (CurrentStreak > BestStreak) BestStreak = CurrentStreak;
    }
    else CurrentStreak = 0;
  }

  /**
   * @desc Write out current streak
   */
  public override string ToString()
  {
    return $"{Name} ({BestStreak})";
  }

}