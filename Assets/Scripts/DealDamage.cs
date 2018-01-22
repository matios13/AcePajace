using System;
using System.Collections;
using System.Collections.Generic;
using Character2D;
using UnityEngine;

public class DealDamage : MonoBehaviour
{

	public float damage = -3;


	public void OnTriggerEnter2D(Collider2D collider)
	{
		var orc = collider.gameObject.GetComponent<Orc>();

		if (orc != null)
		{
			orc.TakeDamage(damage);
		}
	}
}
