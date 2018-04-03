using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TouchScript;

public class PressedProgress : SingletonMono<PressedProgress>
{
	public Image progress;
	TouchPoint touchPoint;

	void OnEnable()
	{
		TouchManager.Instance.TouchesBegan += delegate(object sender, TouchEventArgs e) {
			touchPoint = e.Touches[0];
		};
	}

	public void Show ()
	{
		GetComponent<Image> ().enabled = true;

		GetComponent<RectTransform> ().anchoredPosition = touchPoint.Position;
	}

	public void Close()
	{
		GetComponent<Image> ().enabled = false;
	}

	public void AddProgress()
	{
		add = true;
	}

	public void StopAdd()
	{
		add = false;
	}

	public void Reset()
	{
		progress.fillAmount = 0;
		Close ();
	}

	bool add = false;


	void Update()
	{
		if (!add)
			return;
		if (progress.fillAmount == 1) {
			add = false;
			Reset ();
			InterLayer.Instance.EnableInterLayer ();
			Bamboo[] bamboos = GameObject.FindObjectsOfType<Bamboo> ();
			foreach (Bamboo b in bamboos) {
				b.Push ();
			}
			return;
		}
		progress.fillAmount += Time.deltaTime;
	}
}
