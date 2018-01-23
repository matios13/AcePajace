using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaitState : State<OrcAI>
{
	private static WaitState _instance;

	private WaitState()
	{
		if(_instance != null)
		{
			return;
		}

		_instance = this;
	}

	public static WaitState Instance
	{
		get
		{
			if(_instance == null)
			{
				new WaitState();
			}

			return _instance;
		}
	}

	public override void EnterState(OrcAI _owner)
	{
//		Debug.Log("Entering First State");
	}

	public override void ExitState(OrcAI _owner)
	{
//		Debug.Log("Exiting First State");
	}

	public override void UpdateState(OrcAI _owner)
	{
		float distance = _owner.transform.localPosition.x - _owner.playerMovement.localPosition.x;
		if (distance < 20)
		{
			_owner.stateMachine.ChangeState(MoveState.Instance);
		}
	}
}
