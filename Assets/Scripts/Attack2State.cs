using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Attack2State : State<OrcAI>
{
	private static Attack2State _instance;

	private Attack2State()
	{
		if(_instance != null)
		{
			return;
		}

		_instance = this;
	}

	public static Attack2State Instance
	{
		get
		{
			if(_instance == null)
			{
				new Attack2State();
			}

			return _instance;
		}
	}

	public override void EnterState(OrcAI _owner)
	{
		//		Debug.Log("Entering Attack State");
	}

	public override void ExitState(OrcAI _owner)
	{
		//		Debug.Log("Exiting Attack State");
	}

	public override void UpdateState(OrcAI _owner)
	{
		var deltaX = _owner.transform.localPosition.x - _owner.playerMovement.localPosition.x;
		if (deltaX < 0)
		{
			_owner.movement.Move(1f, false, 2);
		}
		else
		{
			_owner.movement.Move(-1f, false, 2);
		}		
		_owner.stateMachine.ChangeState(MoveState.Instance);

	}
}
