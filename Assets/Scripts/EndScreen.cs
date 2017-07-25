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
		TimeLabel.text = PlayerController.shared.Timer.ElapsedTime.ToString() ;
		BestScoreLabel.text = GameManager.shared.CurrentInfo.TopScore.ToString();
		ScoreLabel.text = GameManager.shared.CurrentInfo.CollectedCoins.ToString();
	}

	public void OnClickContinue()
	{
		GameManager.shared.LoadNextLevel ();
	}
}