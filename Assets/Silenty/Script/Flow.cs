using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Step
{
	Null,
	Init,
	InitMine,
	InitMake,
	InitHistroy,
	InitEnter,
	PickBamboo
}

public class Flow : SingletonMono<Flow> 
{

	public Step step;

	void Update()
	{
		switch (step) {
		case Step.Init:
			break;
		case Step.InitMake:
			PickBamboo.Instance.Init ();
			step = Step.PickBamboo;
			break;
		case Step.InitEnter:
			break;
		case Step.PickBamboo:
			break;
		default:
			break;

		}
	}
}
