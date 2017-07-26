using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public static PlayerController shared { get; private set; }

	public float ElapsedTime = 0.0f;

	public float speed; 
	public Text countText;
	public Text winText;
	public Text timerText;
	public Rigidbody rigidbody;
	public ParticleSystem explosionEffect;

	private int count;


	void Start()
	{
		count = 0;
		winText.text = "";
		timerText.text =string.Format("{0:0}:{1:00}", Mathf.Floor(ElapsedTime/60), ElapsedTime % 60);
		SetCountText();
	}

	void Update()
	{
		ElapsedTime += Time.deltaTime;

		timerText.text = string.Format("{0:0}:{1:00}", Mathf.Floor(ElapsedTime/60), ElapsedTime % 60);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Pick Up")) 
		{
			other.gameObject.SetActive(false);
			count = count + 10;

			SetCountText();
		}
		else if (other.gameObject.CompareTag("Death"))
		{
			StartCoroutine("DeathSequence");

			rigidbody.AddRelativeForce(500.0f * Vector3.up);
			rigidbody.AddExplosionForce(2000.0f, other.gameObject.transform.position, 1500.0f, 1000.0f);
		}
	}

	private IEnumerator DeathSequence()
	{
		explosionEffect.Play();
		yield return rigidbody.IsSleeping();

		GameManager.shared.LevelEnded(GameManager.EndLevelStatus.Death, ElapsedTime);
	}
	void SetCountText()
	{		
		countText.text = string.Format("Count: {0}", count);
		if (count >= 110)
		{
			winText.text = "You Win!";
			GameManager.shared.LevelEnded (GameManager.EndLevelStatus.Win, ElapsedTime);
		}
	}
}
