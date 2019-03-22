using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class executeManager : MonoBehaviour
{

	public cardController card_controll;
	public healthManager health_manager;

	public int last_position = -1;
	public int now_position = -1;

	// Use this for initialization
	void Start ()
	{
		int i;
		for(i=0;i<8;i++)
			card_controll.drawCard(0);
		card_controll.card.showCard(new Vector3(-3,-2,0), new Vector3(3,-2,0), Quaternion.identity);	
	}

	void Update ()
	{
		if (Input.GetKeyUp("d"))
		{
			StartCoroutine(move());

		}
		if (Input.GetKeyUp("k"))
		{
			execute(0,now_position);
			card_controll.card.showCard(new Vector3(-3,-2,0), new Vector3(3,-2,0), Quaternion.identity);
			last_position = -1;
			now_position = -1;
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

	public IEnumerator move()
	{
		yield return new  WaitForSeconds(0.1f);
		print(233);
		now_position = (now_position + 1) % (card_controll.card.getLenHand());
		card_controll.card.forwardCard(now_position,last_position);
		yield return new  WaitForSeconds(0.1f);
		last_position = now_position;
		print(12);
	}
	

}
