﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardController : MonoBehaviour
{
	public Card card;


	public void init()
	{
		card.initLibrary();
	}
	
	
	public void create0()
	{
	    card.createCard(0,"anger");
		card.createCard(0,"anger");
		card.createCard(0,"anger");
		card.createCard(0,"anger");
		card.createCard(0,"anger");
		card.createCard(0,"unNameFire");
		card.createCard(0,"unNameFire");
		card.createCard(0,"unNameFire");
		card.createCard(0,"unNameFire");
		card.createCard(0,"unNameFire");
		card.createCard(0,"unNameFire");
		card.createCard(0,"anger");
		card.createCard(0,"anger");
		card.createCard(0,"anger");
		card.createCard(0,"anger");
		card.createCard(0,"anger");
		card.createCard(0,"unNameFire");
		card.createCard(0,"unNameFire");
		card.createCard(0,"unNameFire");
		card.createCard(0,"unNameFire");
		card.createCard(0,"unNameFire");
		card.createCard(0,"unNameFire");
		washDeck(0);
	
	}

	public void create1()
	{
		
		card.createCard(1,"anger");
		card.createCard(1,"anger");
		card.createCard(1,"anger");
		card.createCard(1,"anger");
		card.createCard(1,"anger");
		card.createCard(1,"unNameFire");
		card.createCard(1,"unNameFire");
		card.createCard(1,"unNameFire");
		card.createCard(1,"unNameFire");
		card.createCard(1,"unNameFire");
		card.createCard(1,"unNameFire");
		card.createCard(1,"anger");
		card.createCard(1,"anger");
		card.createCard(1,"anger");
		card.createCard(1,"anger");
		card.createCard(1,"anger");
		card.createCard(1,"unNameFire");
		card.createCard(1,"unNameFire");
		card.createCard(1,"unNameFire");
		card.createCard(1,"unNameFire");
		card.createCard(1,"unNameFire");
		card.createCard(1,"unNameFire");
		washDeck(1);

	}

	
	
	
	
	
	public void addCard(int type,string name)
	{
		int temp_type=1;
		card.createCard(type,name);

	
	}







	public void washDeck(int type)
	{
		card.washDeck(type);
	}
	
	
	
	
	
	public void drawCard(int type)
	{
		card.getHandCard(type);
		if (type == 0)
		{
			showCard(0,new Vector3(-3,-2.5f,0), new Vector3(3,-2.5f,0), Quaternion.identity);	
		}
		else
		{
			showCard(1,new Vector3(-3,3,0), new Vector3(3,3,0), Quaternion.identity);
		}
			
	}
	
	public int getLenHand(int type)
	{
		return card.handCards[type].Count;
	}
	public int getLenDeck(int type)
	{
		return card.decks[type].Count;
	}
	    
	public void forwardCard(int index_now,int index_last)
	{
		GameObject playerCard=GameObject.Find("playerDeck");
		playerCard.transform.GetChild(index_now).position=playerCard.transform.GetChild(index_now).position+new Vector3(0,0.5f,0);
		if (index_last >= 0)
		{
			playerCard.transform.GetChild(index_last).position=playerCard.transform.GetChild(index_last).position-new Vector3(0,0.5f,0);
		}
  
	}
	
	
	public void showCard(int type,Vector3 startPosition,Vector3 endPosition,Quaternion createRotation)
	{
		GameObject playerCard=GameObject.Find("playerDeck");
		GameObject enemyCard=GameObject.Find("enemyDeck");
		GameObject tempObject;
		if (type == 0)
		{
			tempObject = playerCard;
		}
		else
		{
			tempObject = enemyCard;
		}
		int childCount = tempObject.transform.childCount;
      
		for (int i = 0; i < childCount; i++)
		{
			Destroy(tempObject.transform.GetChild(i).gameObject);
		}

		Vector3 interval = new Vector3(0.7f,0,0);
		print(interval);
		foreach (var temp in card.handCards[type])
		{
            
			GameObject itemGo = Instantiate(temp.image, startPosition+interval, createRotation);
			print(123321);
			itemGo.transform.SetParent(tempObject.transform);
			startPosition += interval;
			itemGo.GetComponent<objectUnit>().showBack(type);
		}
      
       
	}
}