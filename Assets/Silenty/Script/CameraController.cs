using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using GDGeek;

namespace Silenty
{
	public class CameraController : SingletonMono<CameraController> 
	{
		public ScreenTransformGesture TwoFingerMoveGesture;
		public Camera camera;

		void OnEnable()
		{
			TwoFingerMoveGesture.Transformed += twoFingerTransformHandler;
		}

		private void twoFingerTransformHandler(object sender, System.EventArgs e)
		{
			if (Flow.Instance.step == Step.Init) {
				//StartSence.Instance.SetMoutainRotate (TwoFingerMoveGesture.DeltaPosition.x*0.5f);
				MainPageHandle.Instance.RotateMine(TwoFingerMoveGesture.DeltaPosition.x * 0.5f);
			}
		}

		public void Reset()
		{
			camera.transform.localPosition = new Vector3 (0, 0, -10);
		}

		public void FocusOn(Transform target)
		{
			TweenLocalPosition.Begin(camera.transform.gameObject, 1.0f, target.position);
			TweenRotation.Begin (camera.transform.gameObject, 1.0f, target.rotation);
		}

		public void ExitFocusOn()
		{
			TweenLocalPosition.Begin(camera.transform.gameObject, 1.0f, new Vector3(0, 0, -10));
		}
	}
}
