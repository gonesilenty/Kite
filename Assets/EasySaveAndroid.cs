using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySaveAndroid : MonoBehaviour {


	public UnityEngine.UI.Text text;

	// Use this for initialization
	void Start () 
	{
		ES2.Save (123, "myfile.txt?tag=ch");	

		int myint = ES2.Load<int> ("myfile.txt?tag=ch");

		text.text = myint.ToString();
		Debug.Log (myint);
	}
}
