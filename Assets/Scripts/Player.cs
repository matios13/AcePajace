using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float maxHealth = 100;

	public float currentHealth;

	private bool isDead;

	private SimpleHealthBar healthBar;
	// Use this for initialization
	void Start ()
	{
		currentHealth = maxHealth;
		isDead = false;
		healthBar = SimpleHealthBar.GetSimpleHealthBar("PlayerHealth");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(float amount)
	{
		currentHealth += amount;
		healthBar.UpdateBar(currentHealth, maxHealth);
	}
}
