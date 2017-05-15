using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {

	private Vector3 originalPosition;
	public Vector3 speed = Vector3.right;

	void Start()
	{
		originalPosition = transform.position;
	}

	void Update () 
	{
		float sine = Mathf.Sin (Time.realtimeSinceStartup);
		Vector3 objectSpeed = speed * sine;
		transform.position = originalPosition + objectSpeed;
	}

} 