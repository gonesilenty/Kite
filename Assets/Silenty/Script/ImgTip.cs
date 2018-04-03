using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GDGeek;

public class ImgTip : SingletonMono<ImgTip> 
{
	public Image img;
	public Image imgchild;
	
	public void EnableImgTip()
	{
		img.color = Color.white;
		img.enabled = true;
		imgchild.enabled = true;
		TweenGroupAlpha.Begin (img.gameObject, 1.0f, 0.7f);
	}
}
