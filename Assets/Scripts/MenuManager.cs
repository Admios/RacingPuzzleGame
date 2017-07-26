using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	public CarInfo SelectedCar;

	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
	}

	public void Logger(CarInfo info)
	{
		SelectedCar = info;
		//Debug.Log ("Selected " + info.Name);

		GameManager.shared.SelectedCar = info;
	}

	public void StartGame()
	{
		Debug.Log ("Start Game");
		GameManager.shared.LoadNextLevel ();
	}
}
