using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	public CarInfo SelectedCar;
	public GameObject LeaderBoardList;
	public GameObject LeaderBoardItems;
	public LeaderboardEntry ListEntryPrefab;

	// Use this for initialization
	void Start()
	{
		HideList();
	}
	
	// Update is called once per frame
	void Update()
	{
	}

	public void SelectCar(CarInfo info)
	{
		SelectedCar = info;

		GameManager.shared.SelectedCar = info;
	}

	public void ShowList()
	{
		LeaderBoardList.SetActive (true);

		if (LeaderBoardItems.transform.childCount > 0) {
			foreach (Transform child in LeaderBoardItems.transform) {
				Destroy (child.gameObject);
			}
		}

		foreach (string levelName in GameManager.shared.Levels)
		{
			float score = PlayerPrefs.GetFloat ("Score_" + levelName, 0.0f);
			LeaderboardEntry newEntry = Instantiate<LeaderboardEntry> (ListEntryPrefab);
			newEntry.Entry.text = string.Format("Level {0}: {01:00}:{2:00.00}", levelName, score/60, score%60);

			newEntry.transform.parent = LeaderBoardItems.transform;
		}
	}

	public void HideList()
	{
		LeaderBoardList.SetActive (false);
	}

	public void StartGame()
	{
		//Debug.Log ("Start Game");
		GameManager.shared.LoadNextLevel ();
	}
}
