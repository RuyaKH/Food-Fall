using UnityEngine;
using System.Collections;

public static class Difficulty
{
    public static float secondsToMaxDifficulty = 180; //global float that sets the seconds counting down until the max difficulty of level chosen has been reached

    public static float GetDifficultyPercent() //global function that can be called on in any script
    {
        if (Settings.bEasy == true)  //if bool in settings script is true 
        {
            Settings.bMedium = false; //set other bools in settings to false to make sure there are no overlaps
            Settings.bHard = false;
            secondsToMaxDifficulty = 180; //setting seconds for easy difficulty
        }
        else if (Settings.bMedium == true)
        {
            Settings.bEasy = false; //set other bools in settings to false to make sure there are no overlaps
            Settings.bHard = false;
            secondsToMaxDifficulty = 120; //setting seconds for medium difficulty
        }
        else if (Settings.bHard == true)
        {
            Settings.bEasy = false; //set other bools in settings to false to make sure there are no overlaps
            Settings.bMedium = false;
            secondsToMaxDifficulty = 90; //setting seconds for hard difficulty
        }
        else
        {
            secondsToMaxDifficulty = 180; //default
        }
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty); //maths for the difficulty percentage, time passed since level loaded divided by the seconds set based on difficulty
    }
}
