using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace SilentyEvent
{	
	[CustomEditor(typeof(EventScrp))]
	public class EventScrpEditor :  Editor
	{
		SerializedProperty onStart;
		SerializedProperty onPlay;
		SerializedProperty onUpdate;
		SerializedProperty onStep;
		SerializedProperty onCompleted;
		bool startClicked;
		bool playClicked;
		bool updateClicked;
		bool stepClicked;
		bool completedClicked;

		EventScrp eventSilenty;
		protected readonly Handles.CapFunction SphereCap = Handles.SphereHandleCap;
		protected const float nodeSize = 0.1f;
		protected const float buttonSize = 0.2f;
		protected const float buttonOffset = 0.3f;

		void OnEnable()
		{
			onStart = serializedObject.FindProperty ("OnStart");
			onPlay = serializedObject.FindProperty ("OnPlay");
			onUpdate = serializedObject.FindProperty ("OnUpdate");
			onStep = serializedObject.FindProperty ("OnStep");
			onCompleted = serializedObject.FindProperty ("OnCompleted");
			eventSilenty =  target as EventScrp;
		}

		public override void OnInspectorGUI ()
		{
			serializedObject.Update ();
			GUILayout.Label ("OnEvent");
			//GUILayout.Space (1);
			EditorGUILayout.Space ();
			EditorGUILayout.BeginHorizontal ();
			if(GUILayout.Button ("OnStart")){				
				startClicked = !startClicked;
			}
			if(GUILayout.Button ("OnPlay")){	
				playClicked = !playClicked;
			}
			if (GUILayout.Button ("OnUpdate")) {
				updateClicked = !updateClicked;
			}
			if (GUILayout.Button ("OnStep")) {
				stepClicked = !stepClicked;
			}
			if (GUILayout.Button ("OnCompleted")) {
				completedClicked = !completedClicked;
			}
			EditorGUILayout.EndHorizontal ();
			if (startClicked) {
				EditorGUILayout.PropertyField (onStart, true);
			}
			if (playClicked) {
				EditorGUILayout.PropertyField (onPlay, true);
			}
			if (updateClicked) {
				EditorGUILayout.PropertyField (onUpdate, true);
			}
			if (stepClicked) {
				EditorGUILayout.PropertyField (onStep, true);
			}
			if (completedClicked) {
				EditorGUILayout.PropertyField (onCompleted, true);
			}
			serializedObject.ApplyModifiedProperties ();
			Repaint ();
		}

		protected virtual void OnSceneGUI()
		{
			if (Application.isPlaying)
				return;

			for (int i = 0; i < eventSilenty.anchors.Count; i++) {
				var anchorPos = eventSilenty.transform.TransformPoint (eventSilenty.anchors[i]);
				var handleSize = HandleUtility.GetHandleSize (anchorPos);

				Handles.color = Color.blue;
				if (Event.current.type == EventType.Repaint) {
					Handles.SphereHandleCap (0, anchorPos, Quaternion.identity, handleSize * 0.1f, EventType.Repaint);
				}

				EditorGUI.BeginChangeCheck ();
				var postion = Handles.PositionHandle (anchorPos, Quaternion.identity);
				postion = eventSilenty.transform.InverseTransformPoint (postion);
				Handles.Label (eventSilenty.transform.TransformPoint(postion), "lp" + postion.ToString ());
				Handles.BeginGUI ();
				GUILayout.BeginArea (new Rect (0, 30 * i, 1000, 30));
				postion = EditorGUILayout.Vector3Field ("lp", postion);
				GUILayout.EndArea ();
				Handles.EndGUI ();
				if (EditorGUI.EndChangeCheck ()) {						
					eventSilenty.anchors [i] = postion;
					EditorSceneManager.MarkAllScenesDirty ();
				}
				var constOffset = handleSize * buttonOffset;
				var constSize = handleSize * buttonSize;
				if (Event.current.control) {
					if (Handles.Button (anchorPos + Vector3.one * constOffset, Quaternion.identity, constSize, constSize, SphereCap)) {						
						var anchorOffset = new Vector3 (0, 0, handleSize);
						eventSilenty.anchors.Insert (i + 1, eventSilenty.anchors [i] + anchorOffset);
						EditorSceneManager.MarkAllScenesDirty ();
					}
				} else if (Event.current.shift) {
					Handles.color = Color.red;
					if (Handles.Button (anchorPos + Vector3.one * constOffset, Quaternion.identity, constSize, constSize, SphereCap)) {
						eventSilenty.anchors.RemoveAt (i);
						EditorSceneManager.MarkAllScenesDirty ();
					}
				}
			}

			if (eventSilenty.anchors.Count == 0) {
				var handleSize = HandleUtility.GetHandleSize (eventSilenty.transform.position);
				var constOffset = handleSize * buttonOffset;
				var constSize = handleSize * buttonSize;

				Handles.color = Color.blue;
				if (Handles.Button (eventSilenty.transform.position + Vector3.one * constOffset, Quaternion.identity, constSize, constSize, SphereCap)) {
					eventSilenty.anchors.Insert (0, new Vector3 (0, 0, handleSize));
					EditorSceneManager.MarkAllScenesDirty ();
				}
			}
		}
	}
}
