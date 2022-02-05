using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	public GameObject enemySpawn;
	public GameObject enemy;
	// Start is called before the first frame update
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			spawnEnemy();
		}
	}

	public void spawnEnemy()
	{
		Instantiate(enemy, enemySpawn.transform.position, Quaternion.identity);
	}
}
