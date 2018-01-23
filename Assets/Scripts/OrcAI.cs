using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Character2D;
using UnityEngine;

public class OrcAI : MonoBehaviour
{
	public OrcMovement movement;
	private Orc orc;
	public Transform playerMovement;
	public Transform orcTransform;
	public bool switchState = false;
	public bool shouldAttack = true;
	private Transform groundCheck;
	public StateMachine<OrcAI> stateMachine { get; set; }
	public float gameTimer;
	public int seconds = 0;
	public GameObject player;
	
	private void Awake()
	{
		movement = GetComponent<OrcMovement>();
		playerMovement = GameObject.FindGameObjectsWithTag("Player").First().transform;
		orcTransform = GetComponent<Transform>();
		orc = GetComponent<Orc>();
		stateMachine = new StateMachine<OrcAI>(this);
		stateMachine.ChangeState(WaitState.Instance);
		gameTimer = Time.time;
		player = FindPlayer();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{	
		if(Time.time > gameTimer + 1)
		{
			gameTimer = Time.time;
			seconds++;
			if(seconds == 2)
			{
				seconds = 0;
			}
			if (!shouldAttack && seconds == 0)
			{
				Debug.Log("Kopytko");
				shouldAttack = true;
			}
//			Debug.Log(seconds);
		}

		

		stateMachine.Update();
//		movement.Move(1, true, 0);
	}
	
	private GameObject FindPlayer() {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Player");
		return gos.First();
	}
	
	
}
