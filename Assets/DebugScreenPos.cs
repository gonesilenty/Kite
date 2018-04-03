using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScreenPos : MonoBehaviour {	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(Camera.main.WorldToScreenPoint(transform.position));	
	}
}
