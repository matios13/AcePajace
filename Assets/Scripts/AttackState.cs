using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackState : State<OrcAI>
{
	private static AttackState _instance;

	private AttackState()
	{
		if(_instance != null)
		{
			return;
		}

		_instance = this;
	}

	public static AttackState Instance
	{
		get
		{
			if(_instance == null)
			{
				new AttackState();
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
				_owner.movement.Move(1f, false, 1);
			}
			else
			{
				_owner.movement.Move(-1f, false, 1);
			}		
		_owner.stateMachine.ChangeState(MoveState.Instance);

	}
}
