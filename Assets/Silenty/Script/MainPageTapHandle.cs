using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using Silenty;

public class MainPageTapHandle : MonoBehaviour 
{
	public Transform target;
	public Step step;

	void OnEnable()
	{
		GetComponent<TapGesture> ().Tapped += TapHandle;
	}

	void TapHandle(object sender, System.EventArgs e)
	{
		CameraController.Instance.FocusOn (target);
		Invoke ("DelayAction", 1.0f);
	}

	void OnDisable()
	{
		GetComponent<TapGesture> ().Tapped -= TapHandle;
	}

	void DelayAction()
	{
		Flow.Instance.step = step;
	}
}
