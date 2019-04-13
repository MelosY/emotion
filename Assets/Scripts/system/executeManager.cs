using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class executeManager : MonoBehaviour
{

	public cardController card_controll;
	public consumeManager ConsumeManager;//这里多了一个冗余（暂不处理）
	public int last_position = -1;
	public int now_position = -1;
	public bool timeEnemy = true;


	public void startRound ()
	{
		int i;
		for (i = 0; i < 6; i++)
		{
			card_controll.drawCard(0);
			card_controll.drawCard(1);
		}
			
		card_controll.showCard(0,new Vector3(-3,-2.5f,0), new Vector3(3,-2.5f,0), Quaternion.identity);	
		card_controll.showCard(1,new Vector3(-3,3,0), new Vector3(3,3,0), Quaternion.identity);	
	}

	public  void playerRound ()
	{
		if (Input.GetKeyUp("d"))
		{
			StartCoroutine(move());

		}
		if (Input.GetKeyUp("k") && decidePlayer())
		{
			execute(0,now_position);
			StartCoroutine(waitPlayer(0.2f));
			now_position = -1;
			last_position = -1;
		}	   
	}

	public void enemyRound()
	{
		if (decideEnemy())
		{
			StartCoroutine(waitEnemy(1f));
		}
		
	}
	public void execute(int type,int x)
	{
		Card.Card_ temp=card_controll.card.useCard(type, x);
		temp.Base.func(1-type);
		temp.Base.bonus(1-type,card_controll.numOfBonus(type,temp.color));
		if (card_controll.isGrade(type,temp.color,temp.name))
		{
			temp.Base.gradeFunc(type);
		}
		
	    
	}

	
	public IEnumerator move()
	{
		yield return new  WaitForSeconds(0.1f);
		now_position = (now_position + 1) % (card_controll.getLenHand(0));
		card_controll.forwardCard(now_position,last_position);
		yield return new  WaitForSeconds(0.1f);
		last_position = now_position;
	
	}

	public IEnumerator waitPlayer(float x)
	{
		yield return new WaitForSeconds(x);
		card_controll.showCard(0,new Vector3(-3,-2.5f,0), new Vector3(3,-2.5f,0), Quaternion.identity);	
	}

	public IEnumerator waitEnemy(float x)
	{
		execute(1,0);
		timeEnemy = false;
		yield return new WaitForSeconds(x);
		card_controll.showCard(1,new Vector3(-3,3,0), new Vector3(3,3,0), Quaternion.identity);
		yield return new WaitForSeconds(0.2f);
		timeEnemy = true;
	}

	public bool decidePlayer()
	{
		if (card_controll.getLenHand(0) > 0 && ConsumeManager.show(0,"expense") > 0)
		{
			return true;
		}

		return false;
	}
	
	public bool decideEnemy()
	{
		if (card_controll.getLenHand(1) > 0 && ConsumeManager.show(1,"expense") > 0 && timeEnemy)
		{
			return true;
		}

		return false;
	}

	public bool isEnemyDie()
	{
		if (ConsumeManager.show(1, "health") > 0)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

}
