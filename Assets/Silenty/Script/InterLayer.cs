using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDGeek;

public class InterLayer : SingletonMono<InterLayer> 
{
	public float duration;

	void Start()
	{
		EnableInterLayer ();
		DisableInterLayer ();
	}

	public void EnableInterLayer()
	{
		TweenAlpha.Begin (gameObject, duration, 0.6f);
	}

	public void DisableInterLayer()
	{
		TweenAlpha.Begin (gameObject, duration, 0);
	}
}
