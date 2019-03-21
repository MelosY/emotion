using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyUnit : MonoBehaviour {

	public healthManager health_manager;
	public cardController card_controll;
	
	void Awake () {
		health_manager.create("majika",100);
		card_controll.card.createDeck(1);
		card_controll.create1();

	}
	
	void Update () {
		
	}
}
