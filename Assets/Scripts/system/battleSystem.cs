using System.Collections;
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
				i = 0;
				while (player.card_controll.card.getLenHand(0) <=15 && player.card_controll.card.getLenDeck(0) > 0 && i<3 )
				{
					player.card_controll.drawCard(0);
					i++;
				}
					
				
				player.expense_manager.recover("majika",5);
				isPlayDraw = false;
				isEnemyDraw = true;

			}
			player.roundStart();
			if (Input.GetKeyUp("z"))
			{
				enemy.execute_manager.last_position = -1;
				enemy.execute_manager.now_position = -1;
				player.expense_manager.recover("player",5);
				isEnemyRound = true;
				isPlayerRound = false;
			}
			
		}

		if (isEnemyRound)
		{
			if (isEnemyDraw)
			{
				player.card_controll.card.showCard(0,new Vector3(-3,-2.5f,0), new Vector3(3,-2.5f,0), Quaternion.identity);	
				i = 0;
				while (player.card_controll.card.getLenHand(1) <=15 && player.card_controll.card.getLenDeck(1) > 0 && i<3 )
				{
					player.card_controll.drawCard(1);
					i++;
				}
                 
				isPlayDraw = true;
				isEnemyDraw = false;

			}
			StartCoroutine(enemyRound());
		}
	}


	
	public IEnumerator enemyRound()
	{
		enemy.roundStart();
		yield return new WaitForSeconds(5f);
		
		isEnemyRound = false;
		isPlayerRound = true;
	}
}
