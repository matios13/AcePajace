using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{

	public float maxHealth = 100;

	public float currentHealth;

	public float maxPatience = 10;

	public float currentPatience;

	private bool isAngry;

	private bool isDead;

	private SimpleHealthBar healthBar;

	private SimpleHealthBar patienceBar;
	// Use this for initialization
	void Start ()
	{
		currentHealth = maxHealth;
		currentPatience = maxPatience;
		isAngry = false;
		isDead = false;
		healthBar = SimpleHealthBar.GetSimpleHealthBar("OrcHealth");
		patienceBar = SimpleHealthBar.GetSimpleHealthBar("OrcPatience");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(float amount)
	{
		if (!isAngry)
		{
			currentPatience += amount;
			if (currentPatience <= 0)
			{
				currentPatience = 0;
				isAngry = true;
			}
			patienceBar.UpdateBar(currentPatience, maxPatience);
		}
		else
		{
			currentHealth += amount;
			healthBar.UpdateBar(currentHealth, maxHealth);
		}
	}
}
