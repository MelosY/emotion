using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyUnit : MonoBehaviour {

	public healthManager health_manager;
	public expenseManager expense_manager;
	public cardController card_controll;
	public executeManager execute_manager;
	void Awake () {
		health_manager.create("majika",10);
		expense_manager.create("majika",0);
		card_controll.card.createDeck(1);
		card_controll.create1();

	}
	
	void Update () {
		
	}

	public void roundStart()
	{
		execute_manager.enemyRound();

	}

	public void dieEnemy()
	{
		card_controll.card.destroyDeck(1);//等等吧
		//health_manager.health.r
	}
}
