using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilentyEvent;

namespace Silenty
{
	public class Tweener : MonoBehaviour 
	{
		protected float amountPerDelta = 1;
		protected float duration = 0;
		/// <summary>
		/// 0-1
		/// </summary>
		protected float factor = 0;
		protected bool  start = false;

		public float inputDuration = 1;
		public EventScrp path;
		public GameObject target;

		public float AmountPerDelta
		{
			get 
			{ 
				if (inputDuration != duration) {
					duration = inputDuration;
					amountPerDelta = Mathf.Abs ((duration > 0) ? 1f / duration : 1000f);
				}
				return amountPerDelta;
			}
		}

		void Update()
		{
			
			float delta = Time.deltaTime;	//can fixed the delta for increse the number

			factor += AmountPerDelta * delta;

			if (factor >= 1 || factor < 0) {
				enabled = false;
				var angle = transform.localEulerAngles;
				//angle.x = -90;
				transform.localEulerAngles = angle;
				return;
			}

			transform.localPosition = path.GetPos (factor * path.Length);
			if (target != null) {
				transform.LookAt (target.transform);
			} else {
				transform.LookAt (path.GetPos (factor * path.Length + 0.01f), Vector3.up);
			}
		}
	}
}
