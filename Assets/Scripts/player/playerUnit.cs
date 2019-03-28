using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerUnit : MonoBehaviour
{

	public healthManager health_manager;
	public cardController card_controll;
	public executeManager execute_manager;
	void Awake () {
		health_manager.create("player",100);
		card_controll.card.createDeck(0);
		card_controll.create0();
	}

	public void roundStart()
	{
		execute_manager.playerRound();

	}
}
