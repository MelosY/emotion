using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class executeManager : MonoBehaviour
{

	public cardController card_controll;
	public healthManager health_manager;
	// Use this for initialization
	void Start ()
	{
		int i;
		for(i=0;i<8;i++)
			card_controll.drawCard(0);
		card_controll.card.showCard(new Vector3(-3,-2,0), new Vector3(3,-2,0), Quaternion.identity);	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("k"))
		{
			card_controll.drawCard(0);
			card_controll.card.showCard(new Vector3(-3,0,0), new Vector3(3,0,0), Quaternion.identity);
			//	execute(1,0);
		}
		if (Input.GetKey("k"))
		{
			//execute(0,0);
		
	      //execute(1,0);
		}
		
	}
	
	public void execute(int type,int x)
	{
		Card.Card_ temp=card_controll.card.useCard(type, x);
		if (type == 0)
		{
			if (temp.types[0] == 1)
			{
				health_manager.damage("majika",temp.counts[0]);
			}

		}
		if (type == 1)
		{
			if (temp.types[0] == 1)
			{
				health_manager.damage("player",temp.counts[0]);
			}

		}
		
	}
	

}
