using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipLook : MonoBehaviour {
	
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt (Silenty.CameraController.Instance.camera.transform);
		transform.localEulerAngles += new Vector3 (0, 180, 0);

		if (Vector3.Distance (transform.position, Camera.main.transform.position) > 10.5f) {
			Image[] imgs = GetComponentsInChildren<Image> ();
			foreach (var v in imgs) {
				v.enabled = false;
			}
		} else {
			Image[] imgs = GetComponentsInChildren<Image> ();
			foreach (var v in imgs) {
				v.enabled = true;
			}
		}
	}
}
