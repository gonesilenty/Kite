using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPageHandle : SingletonMono<MainPageHandle> 
{
	public float maxAngle;
	public float minAngle;

	public void RotateMine(float delta)
	{
		Vector3 angle = transform.localEulerAngles;
		angle.y += delta;

		angle.y = Mathf.Clamp (angle.y, minAngle, maxAngle);

		transform.localEulerAngles = angle;
	}
}
