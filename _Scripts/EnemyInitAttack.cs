using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyInitAttack : MonoBehaviour {

	public bool enemyAttacked;

	public void OnTriggerStay2D(Collider2D col)
	{
		if(col.tag.Equals("Player"))
		{
			//Debug.Log("Attacking Enemy");
			if(enemyAttacked)
			{
				SceneManager.LoadSceneAsync("BattleScene");
				enemyAttacked = false;
			}
		}
	}
}
