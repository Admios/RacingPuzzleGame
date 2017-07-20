using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarInfo : MonoBehaviour
{
	public string Name;
	public float MaxSpeed;
	public float BreakPower;
	public GameObject prefab;
	public Text NameLabel;

	public void Awake()
	{
		NameLabel.text = Name;
	}
}
