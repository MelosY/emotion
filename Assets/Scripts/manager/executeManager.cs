using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class executeManager : MonoBehaviour
{

	public cardController card_controll;
	public healthManager health_manager;
	public expenseManager expense_manager;
	public int last_position = -1;
	public int now_position = -1;
	public bool timeEnemy = true;


	void Start ()
	{
		int i;
		for (i = 0; i < 6; i++)
		{
			card_controll.drawCard(0);
			card_controll.drawCard(1);
		}
			
		card_controll.card.showCard(0,new Vector3(-3,-2.5f,0), new Vector3(3,-2.5f,0), Quaternion.identity);	
		card_controll.card.showCard(1,new Vector3(-3,3,0), new Vector3(3,3,0), Quaternion.identity);	
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
			//card_controll.card.showCard(0,new Vector3(-3,-2.5f,0), new Vector3(3,-2.5f,0), Quaternion.identity);	
			last_position = -1;
			now_position = -1;
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
		if (type == 0)
		{
			expense_manager.damage("player",1);
			if (temp.types[0] == 1)
			{
				health_manager.damage("majika",temp.counts[0]);
			}

		}
		if (type == 1)
		{
			expense_manager.damage("majika",1);
			if (temp.types[0] == 1)
			{
				health_manager.damage("player",temp.counts[0]);
			}

		}	
	}

	public IEnumerator move()
	{
		yield return new  WaitForSeconds(0.1f);
		print(233);
		now_position = (now_position + 1) % (card_controll.card.getLenHand(0));
		card_controll.card.forwardCard(now_position,last_position);
		yield return new  WaitForSeconds(0.1f);
		last_position = now_position;
	
	}

	public IEnumerator waitPlayer(float x)
	{
		yield return new WaitForSeconds(x);
		card_controll.card.showCard(0,new Vector3(-3,-2.5f,0), new Vector3(3,-2.5f,0), Quaternion.identity);	
	}

	public IEnumerator waitEnemy(float x)
	{
		//yield return new WaitForSeconds(x);
		execute(1,0);
		timeEnemy = false;
		yield return new WaitForSeconds(x);
		card_controll.card.showCard(1,new Vector3(-3,3,0), new Vector3(3,3,0), Quaternion.identity);
		yield return new WaitForSeconds(0.2f);
		timeEnemy = true;
	}

	public bool decidePlayer()
	{
		if (card_controll.card.getLenHand(0) > 0 && expense_manager.expense.ShowExpense("player") > 0)
		{
			return true;
		}

		return false;
	}
	
	public bool decideEnemy()
	{
		if (card_controll.card.getLenHand(1) > 0 && expense_manager.expense.ShowExpense("majika") > 0 && timeEnemy)
		{
			return true;
		}

		return false;
	}

}
