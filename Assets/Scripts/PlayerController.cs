using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float timePerItem = 5.0f;
	public float timeRemaining = 10.0f;

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
		timerText.text = string.Format("{0:####} seconds", timeRemaining);
		SetCountText();
	}

	void Update()
	{
		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0.0f)
		{
			GameManager.shared.PlayerDied();
		}

		timerText.text = string.Format("{0:####} seconds", timeRemaining);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Pick Up")) 
		{
			other.gameObject.SetActive(false);
			count = count + 10;

			timeRemaining += timePerItem;

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

		GameManager.shared.PlayerDied();
	}
	void SetCountText()
	{		
		countText.text = string.Format("Count: {0}", count);
		if (count >= 100)
		{
			winText.text = "You Win!";
			GameManager.shared.LoadNextLevel();
		}

	}
}