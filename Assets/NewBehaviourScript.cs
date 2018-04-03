using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

public class NewBehaviourScript : MonoBehaviour {

	void OnEnable()
	{
		GetComponent<TapGesture>().Tapped +=  delegate(object sender, System.EventArgs e) {
			Debug.Log("caomima");
		};
	}
}
