using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float maxHealth = 100;
	private Animator anim;
	public float currentHealth;
	static int m_deathStateId;
	static int damageStateId;

	private bool isDead;

	private SimpleHealthBar healthBar;
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		currentHealth = maxHealth;
		isDead = false;
		healthBar = SimpleHealthBar.GetSimpleHealthBar("PlayerHealth");
		m_deathStateId = Animator.StringToHash("Base Layer.Dead");
		damageStateId = Animator.StringToHash("Base Layer.Damage");
	}
	
	// Update is called once per frame
	void Update () {
		

		if(anim.IsInTransition(0) && anim.GetNextAnimatorStateInfo(0).nameHash == m_deathStateId)
			anim.SetBool("Dead", false);
		if(anim.IsInTransition(0) && anim.GetNextAnimatorStateInfo(0).nameHash == damageStateId)
			anim.SetBool ("Damage", false);
	}

	public void TakeDamage(float amount)
	{
		if(currentHealth>0){
			anim.SetBool ("Damage", true);
			currentHealth += amount;
			healthBar.UpdateBar(currentHealth, maxHealth);
			if (currentHealth < 1) {
				anim.SetBool ("Dead", true);
			}
		}
	}
}
