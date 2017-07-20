using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
	public WheelCollider leftWheel;
	public WheelCollider rightWheel;
	public bool motor;
	public bool steering;
}

public class SimpleCarController : MonoBehaviour
{
	public List<AxleInfo> axleInfos; 
	public float maxMotorTorque;
	public float breakTorque;
	public float maxSteeringAngle;
	public GameObject centerOfMass;
	public Rigidbody rigidbody;

	public void Start()
	{
		rigidbody.centerOfMass = centerOfMass.transform.position;
	}

	public void FixedUpdate()
	{
		float motor = maxMotorTorque * Input.GetAxis("Vertical");
		float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
		float brake = Input.GetButton("Jump") ? breakTorque : 0.0f;

		for (int i = 0; i < axleInfos.Count; ++i)
		{
			AxleInfo axleInfo = axleInfos[i];
			if (axleInfo.steering)
			{
				axleInfo.leftWheel.steerAngle = steering;
				axleInfo.rightWheel.steerAngle = steering;
			}

			if (axleInfo.motor)
			{
				axleInfo.leftWheel.motorTorque = motor;
				axleInfo.rightWheel.motorTorque = motor;
			}

			axleInfo.leftWheel.brakeTorque = brake;
			axleInfo.rightWheel.brakeTorque = brake;

			ApplyLocalPositionToVisuals(axleInfo.leftWheel);
			ApplyLocalPositionToVisuals(axleInfo.rightWheel);
		}
	}

	// finds the corresponding visual wheel
	// correctly applies the transform
	public void ApplyLocalPositionToVisuals(WheelCollider collider)
	{
		if (collider.transform.childCount == 0)
		{
			return;
		}

		Transform visualWheel = collider.transform.GetChild(0);

		Vector3 position;
		Quaternion rotation;
		collider.GetWorldPose(out position, out rotation);

		visualWheel.transform.position = position;
		visualWheel.transform.rotation = rotation;
	}
}