using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDGeek;
using TouchScript.Gestures;

public enum BambooType
{
	Good,
	Bad
}

public class Bamboo : MonoBehaviour 
{
	public BambooType type;
	public float duration;

	Vector3 initPos;
	float pressTimer;

	void Start()
	{
		initPos = transform.localPosition;
	}

	void OnEnable()
	{		
		if (type == BambooType.Good) {
			GetComponent<PressGesture> ().Pressed += delegate(object sender, System.EventArgs e) {
				if(transform.localPosition == new Vector3(0, 6, 6))
				{
					return;
				}
				PressedProgress.Instance.Show ();
				PressedProgress.Instance.AddProgress ();
				pressTimer = Time.time;
			};

			GetComponent<ReleaseGesture> ().Released += delegate(object sender, System.EventArgs e) {
				PressedProgress.Instance.StopAdd ();
			};
		}
	}

	public void Push()
	{
		if (type == BambooType.Good) {
			var pos = new Vector3 (0, 6, 6);
			Tween tweenl = TweenLocalPosition.Begin (gameObject, duration, pos);
			tweenl.onFinished += delegate(Tween tween) {
				ImgTip.Instance.EnableImgTip();	
			};
		} else {
			gameObject.SetActive(false);
		}
	}

	public void Pull()
	{
		if (type == BambooType.Good) {
			var pos = transform.localPosition;
			pos.z += 1;
			TweenLocalPosition.Begin (gameObject, duration, pos);
		} else {
			var pos = transform.localPosition;
			pos.z -= 2;
			TweenLocalPosition.Begin (gameObject, duration, pos);
		}
	}

	public void Reset()
	{
		transform.localPosition = initPos;
		gameObject.SetActive (true);
	}
}
