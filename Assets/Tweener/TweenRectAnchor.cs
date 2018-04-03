using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDGeek
{
	public class TweenRectAnchor :  Tween
	{
		public Vector2 anchorMinFrom = Vector2.one;
		public Vector2 anchorMinto = Vector2.zero;

		public Vector2 anchorMaxFrom = Vector2.one;
		public Vector2 anchorMaxto = Vector2.zero;

		private RectTransform rt = null;

		public RectTransform cacheRt {get { if (rt == null)
				rt = this.gameObject.GetComponent<RectTransform> (); return rt;}}

		public Vector2 anchorMin{get { return cacheRt.anchorMin;}
		
			set { cacheRt.anchorMin = value;
			}
		}

		public Vector2 anchorMax{get { return cacheRt.anchorMax;}
		
			set { cacheRt.anchorMax = value;
			}
		}

		protected override void OnUpdate (float factor, bool isFinished)
		{
			anchorMin = anchorMinFrom * (1f - factor) + anchorMinto * factor;
			anchorMax = anchorMaxFrom * (1f - factor) + anchorMaxto * factor;
		}

		static public TweenRectAnchor Begin(GameObject go, float duration, Vector2 anchorMin, Vector2 anchorMax)
		{
			TweenRectAnchor ra = Tween.Begin<TweenRectAnchor> (go, duration);
			ra.anchorMinFrom = ra.anchorMin;
			ra.anchorMinto = anchorMin;
			ra.anchorMaxFrom = ra.anchorMax;
			ra.anchorMaxto = anchorMax;

			if (duration <= 0) {
				ra.Sample (1f, true);
				ra.enabled = false;
			}

			return ra;
		}

	}
}
