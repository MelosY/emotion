using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peopleUnit : MonoBehaviour
{

	public consumeManager ConsumeManager;
	public cardController card_controll;
	public executeManager execute_manager;
	void Awake () {
	    card_controll.init();
		ConsumeManager.init();
		ConsumeManager.create(0,"health",100);
		ConsumeManager.create(0,"expense",5);
		card_controll.card.createDeck(0);
		card_controll.create0();
		
		ConsumeManager.create(1,"health",100);
		ConsumeManager.create(1,"expense",0);
		card_controll.card.createDeck(1);
		card_controll.create1();
	}

	public void startRound()
	{
		execute_manager.startRound();
	}
	public void roundStartPlayer()
	{
		execute_manager.playerRound();
	}
	public void roundStartEnemy()
	{
		execute_manager.enemyRound();

	}

	public void dieEnemy()
	{
		card_controll.card.destroyDeck(1);//等等吧
		//health_manager.health.r
	}

	public void drawCard(int type)
	{
		card_controll.drawCard(type);
	}

	public void recoverExpense(int type, int count)
	{
		ConsumeManager.recover(type,"expense",count);
	}

	public void recover(int type, string name, int count)
	{
		ConsumeManager.recover(type,name,count);
	}
}
