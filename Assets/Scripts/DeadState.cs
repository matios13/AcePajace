using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeadState : State<OrcAI>
{
	private static DeadState _instance;

	private DeadState()
	{
		if(_instance != null)
		{
			return;
		}

		_instance = this;
	}

	public static DeadState Instance
	{
		get
		{
			if(_instance == null)
			{
				new DeadState();
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
		
		_owner.movement.Die ();
	}
}
