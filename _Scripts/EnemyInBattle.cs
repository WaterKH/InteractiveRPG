using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyInBattle : MonoBehaviour {

	public Transform[] spawnLocations = new Transform[4];
	public static int numberOfEnemies = 10;
	public static int numberOfAttacks = 3;
	public string[] enemyNames = new string[numberOfEnemies]; 
	public string[] enemyStats = new string[numberOfAttacks];
	public TextAsset enemyNamesFromFile;
	public TextAsset enemyStatsFromFile;
	public Dictionary<string, string> enemies = new Dictionary<string, string>();

	void Awake()
	{
		enemyNames = enemyNamesFromFile.text.Split(',');
		enemyStats = enemyStatsFromFile.text.Split('\n');

		for(int i = 0; i < enemyNames.Length; ++i)
		{
			enemies.Add(enemyNames[i], enemyStats[i]);
		}	
	}

	public void SpawnEnemy()
	{
		int randomInt = Random.Range(1, 5);

		for(int i = 0; i < randomInt; ++i)
		{
			Debug.Log("Spawn Enemy");
			GameObject enemy = Instantiate(Resources.Load("EnemyInBattle") as GameObject);
			enemy.transform.position = spawnLocations[i].position;

			int enemyRandInt = Random.Range(0, enemyNames.Length - 1);
			enemy.name = enemyNames[enemyRandInt];
		}
	}
}
