using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardController : MonoBehaviour
{
	public Card card;
	public GameObject[] Images;

	public void create0()
	{
		int[] temp_type={1};
		int[] temp_counts={2};
		card.createCard(0,Images[0],"attack",temp_type,temp_counts);
		card.createCard(0,Images[1],"attack",temp_type,temp_counts);
		card.createCard(0,Images[0],"attack",temp_type,temp_counts);
		card.createCard(0,Images[1],"attack",temp_type,temp_counts);
		card.createCard(0,Images[0],"attack",temp_type,temp_counts);
		card.createCard(0,Images[1],"attack",temp_type,temp_counts);
		card.createCard(0,Images[0],"attack",temp_type,temp_counts);
		card.createCard(0,Images[1],"attack",temp_type,temp_counts);
		card.createCard(0,Images[0],"attack",temp_type,temp_counts);
		card.createCard(0,Images[1],"attack",temp_type,temp_counts);
		card.createCard(0,Images[0],"attack",temp_type,temp_counts);
		card.createCard(0,Images[1],"attack",temp_type,temp_counts);
		card.createCard(0,Images[0],"attack",temp_type,temp_counts);
		card.createCard(0,Images[1],"attack",temp_type,temp_counts);
		card.createCard(0,Images[0],"attack",temp_type,temp_counts);
		card.createCard(0,Images[1],"attack",temp_type,temp_counts);
	}

	public void create1()
	{
		int[] temp_type={1};
		int[] temp_counts={2};
		card.createCard(1,Images[0],"attack",temp_type,temp_counts);
		card.createCard(1,Images[0],"attack",temp_type,temp_counts);
		card.createCard(1,Images[0],"attack",temp_type,temp_counts);
		card.createCard(1,Images[0],"attack",temp_type,temp_counts);
		card.createCard(1,Images[0],"attack",temp_type,temp_counts);
		card.createCard(1,Images[0],"attack",temp_type,temp_counts);
		card.createCard(1,Images[0],"attack",temp_type,temp_counts);
		card.createCard(1,Images[0],"attack",temp_type,temp_counts);
		card.createCard(1,Images[0],"attack",temp_type,temp_counts);
		card.createCard(1,Images[0],"attack",temp_type,temp_counts);
		card.createCard(1,Images[0],"attack",temp_type,temp_counts);
		card.createCard(1,Images[0],"attack",temp_type,temp_counts);
		card.createCard(1,Images[0],"attack",temp_type,temp_counts);
		card.createCard(1,Images[0],"attack",temp_type,temp_counts);
	}

	public void drawCard(int type)
	{
		card.getHandCard(type);
		if (type == 0)
		{
			card.showCard(0,new Vector3(-3,-2.5f,0), new Vector3(3,-2.5f,0), Quaternion.identity);	
		}
		else
		{
			card.showCard(1,new Vector3(-3,3,0), new Vector3(3,3,0), Quaternion.identity);
		}
			
	}
	
}