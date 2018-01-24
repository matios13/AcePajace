using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;
using UnityEngine;

public class MoveState : State<OrcAI>
{
	private static MoveState _instance;

	private MoveState()
	{
		if(_instance != null)
		{
			return;
		}

		_instance = this;
	}

	public static MoveState Instance
	{
		get
		{
			if(_instance == null)
			{
				new MoveState();
			}

			return _instance;
		}
	}

	public override void EnterState(OrcAI _owner)
	{
//		Debug.Log("Entering Second State");
	}

	public override void ExitState(OrcAI _owner)
	{
//		Debug.Log("Exiting Second State");
	}

	public override void UpdateState(OrcAI _owner)
	{
		var deltaX = _owner.transform.localPosition.x - _owner.playerMovement.localPosition.x;
		//Debug.Log(deltaX);
		if (deltaX < -4)
		{
			
			_owner.movement.Move(0.4f,false,0);
		}
		else if (deltaX > 4)
		{
			_owner.movement.Move(-0.4f, false, 0);
		}
		else
		{
			_owner.movement.Move(0, false, 0);
		}
		if (deltaX > 50)
		{
			_owner.stateMachine.ChangeState(WaitState.Instance);
		} 
		else if (deltaX < 4)
		{
			if (_owner.shouldAttack)
			{
				_owner.shouldAttack = false;
				_owner.stateMachine.ChangeState(AttackState.Instance);				
			}
		}
	}
}
