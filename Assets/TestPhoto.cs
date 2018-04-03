using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPhoto : MonoBehaviour {

	// Use this for initialization
	void Start () {
		OpenPhoto ();
	}

    public void OpenPhoto()  
    {  
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");  
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");  
        jo.Call("OpenGallery");         
    }  
	// Update is called once per frame
	void Update () {
		
	}
}
