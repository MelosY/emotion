﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class battleSystem : MonoBehaviour
{
	private int i;
	public playerUnit player;

	public enemyUnit enemy;

	public bool isEnemyRound = false;
	public bool isPlayerRound = true;
	public bool isPlayDraw = true;
	public bool isEnemyDraw = false;

	void Update () {
		if (isPlayerRound)
		{
		   
			//card_controll.card.showCard(1,new Vector3(-3,3,0), new Vector3(3,3,0), Quaternion.identity);	
			if (isPlayDraw)
			{
				for (i = 0; i < 3; i++)
				{
					player.card_controll.drawCard(0);
				}

				isPlayDraw = false;
				isEnemyDraw = true;

			}
			StartCoroutine(playerRound());
		}

		if (isEnemyRound)
		{
			if (isEnemyDraw)
			{
				player.card_controll.card.showCard(0,new Vector3(-3,-2.5f,0), new Vector3(3,-2.5f,0), Quaternion.identity);	
				for (i = 0; i < 3; i++)
				{
					player.card_controll.drawCard(1);
				}

				isPlayDraw = true;
				isEnemyDraw = false;

			}
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
