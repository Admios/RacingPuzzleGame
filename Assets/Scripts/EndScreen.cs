using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
	public Text TimeLabel;
	public Text BestScoreLabel;
	public Text ScoreLabel;
	public Button Continue;

	// Use this for initialization
	void Start () 
	{
		TimeLabel.text = " " ;
		BestScoreLabel.text = GameManager.shared.CurrentInfo.TopScore;
		ScoreLabel.text = GameManager.shared.CurrentInfo.CollectedCoins;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
		
	public void OnClickContinue()
	{
		GameManager.shared.LoadNextLevel ();
	}
}
