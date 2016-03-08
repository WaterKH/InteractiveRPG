using UnityEngine;
using System.Collections;

public class EnemyAttackInBattle : MonoBehaviour {

	public Enemy enemyStats = new Enemy();

	public void setupEnemyStats()
	{
		EnemyInBattle enemy = GetComponent<EnemyInBattle>();

		enemyStats = new Enemy(float.Parse(enemy.enemies[this.name].Split(',')[0]),float.Parse(enemy.enemies[this.name].Split(',')[1]),
			float.Parse(enemy.enemies[this.name].Split(',')[2]),float.Parse(enemy.enemies[this.name].Split(',')[3]),
			float.Parse(enemy.enemies[this.name].Split(',')[4]),float.Parse(enemy.enemies[this.name].Split(',')[5]),
			int.Parse(enemy.enemies[this.name].Split(',')[6]),int.Parse(enemy.enemies[this.name].Split(',')[7]),
			int.Parse(enemy.enemies[this.name].Split(',')[8]));
	}
}
