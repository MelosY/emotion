using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleSystem : MonoBehaviour
{

	public playerUnit player;

	public enemyUnit enemy;

	public bool isEnemyRound = false;
	public bool isPlayerRound = true;

	void Update () {
		if (isPlayerRound)
		{
			StartCoroutine(playerRound());
		}

		if (isEnemyRound)
		{
			StartCoroutine(enemyRound());
		}
	}

	public IEnumerator playerRound()
	{
		player.roundStart();
		yield return new WaitForSeconds(10.0f);
		isEnemyRound = true;
		isPlayerRound = false;
	}
	public IEnumerator enemyRound()
	{
		enemy.roundStart();
		yield return new WaitForSeconds(10.0f);
		isEnemyRound = false;
		isPlayerRound = true;
	}
}
