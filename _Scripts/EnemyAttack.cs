using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public bool attackingEnemy;

	public void OnTriggerStay2D(Collider2D col)
	{
		if(col.tag.Equals("Player"))
		{
			//Debug.Log("Attacking Enemy");
			attackingEnemy = true;
		}
	}

	public void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag.Equals("Player"))
		{
			attackingEnemy = false;
		}
	}
}

