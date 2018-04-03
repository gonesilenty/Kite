using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GDGeek;

public class PickBamboo : SingletonMono<PickBamboo>
{
//	public GameObject bamboo;
//	public Image img;
//	public Image imgchild;
//
//	public void Init()
//	{
//		img.enabled = true;
//		imgchild.enabled = true;
//		TweenGroupAlpha tween = img.gameObject.AddComponent<TweenGroupAlpha> ();
//		tween.to = 0;
//		tween.duration = 1.0f;
//		tween.delay = 2.0f;
//		tween.onFinished += delegate(Tween tw) {
//			img.enabled = false;
//			imgchild.enabled = false;		
//		};
//	}

	public Canvas interCanvas;
	public Image makeImg;

	bool action = false;

	public void Init()
	{
		action = true;
		TweenAlpha.Begin (makeImg.gameObject, 1.0f, 1.0f);
	}

	void Update()
	{
		if (!action)
			return;
		if (interCanvas.planeDistance < 5) {
			action = false;
			return;
		}
		interCanvas.planeDistance -= Time.deltaTime*2.5f;
	}

	public void Reset()
	{
		action = false;
		Tween tween = TweenAlpha.Begin (makeImg.gameObject, 1.0f, 0f);
		tween.onFinished += delegate(Tween tw) {
			interCanvas.planeDistance = 17.5f;
		};
	}
}
