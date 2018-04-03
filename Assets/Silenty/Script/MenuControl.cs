using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDGeek;

public class MenuControl : MonoBehaviour 
{	
	public void OnButtonClick(int value)
	{
		switch (value)
		{
		case 1:
			break;
		case 2:
			Tween tween = TweenGroupAlpha.Begin (gameObject, 1f, 0);
			tween.onFinished += delegate(Tween tw) {
				gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
				Flow.Instance.step = Step.InitEnter;	
			};
			break;
		case 3:
			break;
		default:
			Debug.LogError("!!!!!");
			break;
		}
	}
}
