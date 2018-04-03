using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipAlpha : MonoBehaviour 
{
	void OnEnable()
	{
		GetComponent<Text> ().color = Color.white;
	}		
}
