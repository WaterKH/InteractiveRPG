using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {

	public List<GameObject> enemies = new List<GameObject>();

	public Vector3 finalPos;
	public bool firstPass = true;
	public int randNumb = 1;
	public int spawnLimit = 7;
	public Transform[] spawnLocations;
	public List<Vector3> positionToGo = new List<Vector3>();
	public bool finished = true;
	public GameObject enemyParent;
	public float speed = 1.5f;

	public Camera mainCamera;

	public GameObject player;

	void Awake()
	{
		for(int i = 0; i < spawnLimit + 1; ++i)
		{
			SpawnEnemy(i);
		}
	}

	public void SpawnEnemy(int counter)
	{
		int randomSpawnLocation = Random.Range(0, spawnLocations.Length - 1);
		GameObject enemy = Instantiate(Resources.Load("Enemy") as GameObject);

		enemies.Add(enemy);
		enemy.transform.position = spawnLocations[randomSpawnLocation].position;
		enemy.transform.SetParent(enemyParent.transform);
		enemy.name += "-" + counter;

		positionToGo.Add(enemy.transform.position);
	}

	public void DeSpawnEnemy(GameObject enemy, Vector3 pos)
	{
		enemies.Remove(enemy);
		Destroy(enemy);
		int counter = positionToGo.IndexOf(pos);
		positionToGo.Remove(pos);

		SpawnEnemy(counter);
	}

	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < enemies.Count; ++i)
		{
			if(enemies[i].transform.position == positionToGo[i])
			{	
				float screenX = Random.Range(0.0f, mainCamera.pixelWidth);
 				float screenY = Random.Range(0.0f, mainCamera.pixelHeight);
				Vector3 point = mainCamera.ScreenToWorldPoint(new Vector3(screenX, screenY, 0.0f));

				positionToGo.Insert(i, point);
			}
			else if(PlayerMovement.move.x != 0 || PlayerMovement.move.y != 0)
			{
				if(enemies[i].GetComponent<EnemyAttack>().attackingEnemy)
				{
					enemies[i].transform.position = Vector3.Lerp(enemies[i].transform.position, player.transform.position, Time.deltaTime * 2);
				}
				else
				{
					enemies[i].transform.position = Vector3.Lerp(enemies[i].transform.position, positionToGo[i], Time.deltaTime * speed);
				}
			}
		}
	}

	public void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Enemy")
		{
			//Debug.Log("Despawning Enemy");
			DeSpawnEnemy(col.gameObject, positionToGo[int.Parse(col.name.Split('-')[1])]);
		}
	}
}
