using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayInfo  
{

	public int CollectedCoins;
	public float ElapsedTime;
	public string LevelName;

	public int TopScore
	{
		get
		{ 
			return PlayerPrefs.GetInt ("Score_" + LevelName, 0);
		}
		set 
		{ 
			if (value > TopScore)
			{
				PlayerPrefs.SetInt ("Score_" + LevelName, value);

			}
		}
	}

	public PlayInfo (string name)
	{
		LevelName = name;
	}
}	