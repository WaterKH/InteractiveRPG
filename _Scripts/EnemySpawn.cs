using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {

	public List<GameObject> enemies = new List<GameObject>();

	public Vector3 finalPos;
	public bool firstPass = true;
	public int randNumb = 1;

	bool finished = true;

	public void SpawnEnemy()
	{
		int randomSpawn = Random.Range(1, 7);

		for(int i = 0; i < randomSpawn; ++i)
		{
			GameObject enemy = Instantiate(Resources.Load("Enemy") as GameObject);
			enemies.Add(enemy);
		}
	}

	public void DeSpawnEnemy(GameObject enemy)
	{
		enemies.Remove(enemy);
		Destroy(enemy);

		//SpawnEnemy();
	}

	// Update is called once per frame
	void Update () 
	{
		if(finished)
		{
			finished = false;
			for(int i = 0; i < enemies.Count; ++i)
			{
				charMovement(enemies[i].transform, 2.5f, 2);
			}
			finished = true;
		}
	}

	public void resetFirstPass()
	{
		randNumb = Random.Range(1, 9);
		firstPass = true;
	}

	public void charMovement(Transform currPos, float moveByHowMuch, int howFast)
	{
		float heading = 0f;
		
		switch(randNumb)
		{
		case 1: // Right
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x + moveByHowMuch, currPos.position.y, currPos.position.z);
				firstPass = false;
			}
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(-1, 0);
			break;
		case 2: // Up
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x, currPos.position.y + moveByHowMuch, currPos.position.z);
				firstPass = false;
			}
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(0, 1);
			break;
		case 3: // Left
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x - moveByHowMuch, currPos.position.y, currPos.position.z);
				firstPass = false;
			}
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(1, 0);
			break;
		case 4: // Down
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x, currPos.position.y - moveByHowMuch, currPos.position.z);
				firstPass = false;
			}
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(0, -1);
			break;
		case 5: // Up & Right
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x + moveByHowMuch, currPos.position.y + moveByHowMuch, currPos.position.z);
				firstPass = false;
			}
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(-1, 1);
			break;
		case 6: // Up & Left
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x - moveByHowMuch, currPos.position.y + moveByHowMuch, currPos.position.z);
				firstPass = false;
			}
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(1, 1);
			break;
		case 7: // Down & Right
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x + moveByHowMuch, currPos.position.y - moveByHowMuch, currPos.position.z);
				firstPass = false;
			}
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(-1, -1);
			break;
		case 8: // Down & Left
			if(firstPass)
			{
				finalPos = new Vector3(currPos.position.x - moveByHowMuch, currPos.position.y - moveByHowMuch, currPos.position.z);
				firstPass = false;
			}	
			currPos.position = Vector3.Lerp(currPos.position, finalPos, Time.deltaTime * howFast);
			heading = Mathf.Atan2(1, -1);
			break;
		default:
			break;
		}

		if(Mathf.Abs(finalPos.x - currPos.position.x) <= 0.1f && Mathf.Abs(finalPos.y - currPos.position.y) <= 0.1f)
		{
//			Debug.Log("Reached");
			resetFirstPass();
		}
		currPos.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);
	}

	public void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Enemy")
		{
			Debug.Log("Despawning Enemy");
			DeSpawnEnemy(col.gameObject);
		}
	}
}
