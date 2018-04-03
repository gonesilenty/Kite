using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GDGeek;
using Silenty;

public class StartSence : SingletonMono<StartSence> 
{
	public GameObject mountain;
	public GameObject buttons;

	public Transform mineV;
	public Transform makeV;
	public Transform historyV;

	public Button mine;
	public Button history;
	public Button make;

	public Transform initPos;
	public Transform targetPos;

	void Start()
	{
		Init ();
	}

	void OnEnable()
	{
		mine.onClick.AddListener (HandleToMine);
		history.onClick.AddListener (HandleToHistory);
		make.onClick.AddListener (HandleToMake);
	}

	public void Init()
	{
		TweenLocalPosition.Begin (mountain, 1.0f, targetPos.localPosition);
		TweenRotation.Begin (mountain, 1.0f, targetPos.localRotation);
		TweenScale.Begin (mountain, 1.0f, targetPos.localScale);
		TweenGroupAlpha.Begin (buttons, 1.0f, 1);
	}

	public void SetMoutainRotate(float delta)
	{
		mountain.transform.localEulerAngles += new Vector3 (0, delta, 0);
	}

	void OnDisable()
	{
		mine.onClick.RemoveListener (HandleToMine);
		history.onClick.RemoveListener (HandleToHistory);
		make.onClick.RemoveListener (HandleToMake);
	}

	public void HandleToMine()
	{
		CameraController.Instance.FocusOn (mineV);
		Flow.Instance.step = Step.InitMine;
		TweenGroupAlpha.Begin (buttons, 1.0f, 0);
	}

	public void HandleToHistory()
	{
		CameraController.Instance.FocusOn (historyV);
		Flow.Instance.step = Step.InitHistroy;
		TweenGroupAlpha.Begin (buttons, 1.0f, 0);
	}

	public void HandleToMake()
	{
		CameraController.Instance.FocusOn (makeV);
		Flow.Instance.step = Step.InitMake;
		TweenGroupAlpha.Begin (buttons, 1.0f, 0);
	}

	public void HandleFinished(Tween tween)
	{
		CameraController.Instance.Reset ();
	}
}
