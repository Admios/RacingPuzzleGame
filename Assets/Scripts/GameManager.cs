using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public static GameManager shared { get; private set; }

	public CarInfo SelectedCar;
	public PlayInfo CurrentInfo;

	public List<string> Levels;
	public AudioSource Source;
	private int currentLevelIndex = 0;

	public void Logger(CarInfo info)
	{
		SelectedCar = info;
		//Debug.Log ("Selected " + info.Name);

		GameManager.shared.SelectedCar = info;
	}

	void Awake()
	{
		shared = this;
		DontDestroyOnLoad (gameObject);
		//DontDestroyOnLoad (DirectionalLight);

	}

	// Use this for initialization
	void Start ()
	{
		SceneManager.LoadScene ("Start");
		SceneManager.sceneLoaded += (Scene scene, LoadSceneMode mode) => {
			if (scene.name == "Start")
			{
				Source.Stop();
				Button button = FindObjectOfType<Button>();

				button.onClick.AddListener( () => { LoadNextLevel(); } );
			}
			else
			{
				//Source.clip = Resources.Load<AudioClip>("New");
				Source.Play();
			}
		};
	}

	public void PlayerDied()
	{
		SceneManager.LoadScene ("Start");
		currentLevelIndex = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void LoadNextLevel()
	{
		string nextLevel = string.Empty;
		if (currentLevelIndex == Levels.Count) {
			nextLevel = "Start";
			currentLevelIndex = 0;
		}
		else
		{
			nextLevel = Levels [currentLevelIndex];
			currentLevelIndex += 1;

			CurrentInfo = new PlayInfo (nextLevel);
		}

	}
}