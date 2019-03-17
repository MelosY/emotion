using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardController : MonoBehaviour
{
	public Card card;
	

	public void create0()
	{
		int[] temp_type={1};
		int[] temp_counts={2};
		card.createCard(0,"attack",temp_type,temp_counts);
		card.createCard(0,"attack",temp_type,temp_counts);
	}

	public void create1()
	{
		int[] temp_type={1};
		int[] temp_counts={2};
		card.createCard(1,"attack",temp_type,temp_counts);
		card.createCard(1,"attack",temp_type,temp_counts);
	}

	
}