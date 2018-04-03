using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

namespace SilentyEvent
{
	public class EventScrp : MonoBehaviour 
	{
		public List<Vector3> anchors = new List<Vector3>();

		public float Length { get ; private set;}
		private int NumPoints {get { return anchors.Count;}}
		private float [] distances;
		private Vector3 []points;

		private int p0n;
		private int p1n;
		private int p2n;
		private int p3n;

		private float i;

		private Vector3 P0;
		private Vector3 P1;
		private Vector3 P2;
		private Vector3 P3;

		public UnityAction actions;

		[Serializable]
		public class EventSilenty : UnityEvent{};

		[SerializeField] EventSilenty OnStart = new EventSilenty();
		[SerializeField] EventSilenty OnPlay = new EventSilenty();
		[SerializeField] EventSilenty OnUpdate = new EventSilenty();
		[SerializeField] EventSilenty OnStep = new EventSilenty();
		[SerializeField] EventSilenty OnCompleted = new EventSilenty();

		void Awake()
		{
			CachePositionAndDistances ();
			Length = distances[distances.Length - 1];
		}

		void OnEnable()
		{
//			Debug.Log(anchors.Count);
//			OnStart.AddListener (actions);
//
//			OnStart.Invoke ();
		}

		void Action1()
		{
			Debug.Log (1);
		}

		protected virtual void OnDrawGizmosSelected()
		{
			if (anchors.Count < 2)
				return;
		
			CachePositionAndDistances ();
			Length = distances[distances.Length - 1];

			Gizmos.color = Color.white;

			Vector3 pre = transform.TransformPoint(anchors[0]);
			for (float i = 0.01f; i < Length; i += (Length / 100)) {
				Vector3 next = GetRoutePosition (i);
				Gizmos.DrawLine (pre, next);
				pre = next;
			}
		}

		public Vector3 GetPos(float time)
		{
			return GetRoutePosition (time);
		}

		public Vector3 GetRoutePosition(float dist)
		{
			int point = 0;

			dist = Mathf.Repeat (dist, Length);

			while (distances [point] < dist) {
				++point;
			}

			if (point == 1) {				
				p1n = point;
				p2n = point + 1;
				p0n = point - 1;
				i = Mathf.InverseLerp (distances [p0n], distances [p1n], dist);

				return CatmullRom (2 * points [p0n] - points [p1n], points [p0n], points [p1n], points [p2n], i);
			} else if (point > 1 && point < points.Length - 1) {
				p2n = point;
				p3n = point + 1;
				p1n = point - 1;
				p0n = point - 2;
				i = Mathf.InverseLerp (distances [p1n], distances [p2n], dist);

				P0 = points [p0n];
				P1 = points [p1n];
				P2 = points [p2n];
				P3 = points [p3n];

				return CatmullRom (P0, P1, P2, P3, i);
			} else{
				p3n = point;
				p2n = point - 1;
				p1n = point - 2;

				i = Mathf.InverseLerp (distances [p2n], distances [p3n], dist);
				return CatmullRom (points [p1n], points [p2n], points [p3n], 2*points [p3n] - points[p2n], i);
			}
		}

		private void CachePositionAndDistances()
		{
			points = new Vector3[anchors.Count];
			distances = new float[anchors.Count];

			float accumulateDistance = 0;

			for (int i = 0; i < points.Length; i++) {
				var t1 = anchors [(i) % anchors.Count];
				var t2 = anchors [(i + 1) % anchors.Count];

				if (t1 != null && t2 != null) {
					t1 = transform.TransformPoint (t1);
					t2 = transform.TransformPoint (t2);

					points [i] = transform.TransformPoint (anchors [i % anchors.Count]);
					distances [i] = accumulateDistance;
					accumulateDistance += (t1 - t2).magnitude;
				}
			}				
		}

		private Vector3 CatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float i)
		{
			return 0.5f*((2*p1) + (-p0 + p2)*i + (2*p0 - 5*p1 + 4*p2 - p3)*i*i +
					(-p0 + 3*p1 - 3*p2 + p3)*i*i*i);
		}

	}
}
