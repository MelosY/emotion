using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class battleSystem : MonoBehaviour
{
	private int i;

	public peopleUnit people;

	public bool isEnemyRound = false;
	public bool isPlayerRound = true;
	public bool isPlayDraw = true;
	public bool isEnemyDraw = false;
	public bool isend = false;
	private void Start()
	{
		people.startRound();
	}

	void Update () {
		if (isPlayerRound)
		{
		   
			//card_controll.card.showCard(1,new Vector3(-3,3,0), new Vector3(3,3,0), Quaternion.identity);	
			if (isPlayDraw)
			{
				i = 0;
				while (people.card_controll.getLenHand(0) <=15 && people.card_controll.getLenDeck(0) > 0 && i<3 )
				{
					people.card_controll.drawCard(0);
					i++;
				}
					
				
				people.recover(1,"expense",5);
				isPlayDraw = false;
				isEnemyDraw = true;

			}
			people.roundStartPlayer();
			if (Input.GetKeyUp("z"))
			{
				people.execute_manager.last_position = -1;
				people.execute_manager.now_position = -1;
				people.recover(0,"expense",5);
				isEnemyRound = true;
				isPlayerRound = false;
			}
			
		}

		if (isEnemyRound)
		{
			if (isEnemyDraw)
			{
				people.card_controll.showCard(0,new Vector3(-3,-2.5f,0), new Vector3(3,-2.5f,0), Quaternion.identity);	
				i = 0;
				while (people.card_controll.getLenHand(1) <=15 && people.card_controll.getLenDeck(1) > 0 && i<3 )
				{
					people.card_controll.drawCard(1);
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
		people.roundStartEnemy();
		yield return new WaitForSeconds(5f);
		
		isEnemyRound = false;
		isPlayerRound = true;
	}
}
