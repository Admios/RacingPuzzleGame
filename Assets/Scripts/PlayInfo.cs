using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayInfo  
{

	public int CollectedCoins;
	public float ElapsedTime;
	public string LevelName;

	public float TopScore
	{
		get
		{ 
			return PlayerPrefs.GetFloat ("Score_" + LevelName, 0.0f);
		}
		set 
		{ 
			if (value > TopScore)
			{
				PlayerPrefs.SetFloat ("Score_" + LevelName, value);
				PlayerPrefs.Save ();

			}
		}
	}

	public PlayInfo (string name)
	{
		LevelName = name;
	}
}	