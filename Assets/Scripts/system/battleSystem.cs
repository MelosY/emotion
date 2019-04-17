using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class battleSystem : MonoBehaviour
{
	private int i;

	public peopleUnit people;

	public bool isEnemyRound;
	public bool isPlayerRound;
	public bool isPlayDraw;
	public bool isEnemyDraw;
	public bool isend;
	public int roundCount;
	
	private void Start()
	{
		roundCount = 0;
		people.init();
		people.startRound();
		isEnemyRound = false;
        isPlayerRound = true;
	    isPlayDraw = true;
	    isEnemyDraw = false;
	    isend = false;
		
	}

	void Update () {
		if (isPlayerRound)
		{
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

			if (!people.ConditionManager.search(0,"dizzy"))
			{
				people.roundStartPlayer();
				if (Input.GetKeyUp("z"))
				{
					people.execute_manager.last_position = -1;
					people.execute_manager.now_position = -1;
					people.recover(0,"expense",5);
					roundCount++;
					isEnemyRound = true;
					isPlayerRound = false;
				}
			}
			else
			{
				people.recover(0,"expense",5);
				roundCount++;
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

			if (!people.ConditionManager.search(1, "dizzy"))
			{
				StartCoroutine(enemyRound());
			}
			else
			{
				roundCount++;
				isEnemyRound = false;
				isPlayerRound = true;
			}

		}
	}


	
	public IEnumerator enemyRound()
	{
		people.roundStartEnemy();
		yield return new WaitForSeconds(5f);
		roundCount++;
		isEnemyRound = false;
		isPlayerRound = true;
	}
}
