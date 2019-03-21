using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    public class Card_
    {
          public GameObject image;
          public string name;
          public int[] types;
          public int[] counts;
    }
    
    List<List<Card_>> decks=new List<List<Card_>> ();
    
    List<List<Card_>> handCards=new List<List<Card_>> ();
    
    
    public void createCard(int type,GameObject image,string name, int[] types,int[] counts)
    {
            Card_ temp =new Card_();
            temp.name = name;
            temp.image = image;
            temp.types = types;
            temp.counts = counts;
            decks[type].Add(temp);
        
    }
    
    
    public Card_ useCard(int type, int x)
    {
            Card_ temp =handCards[type][x];
            destroyCard(type, x);
            return temp;
    }

    
    public void removeCard(int type, int x)
    {
        decks[type].Remove(decks[type][x]);
    }

    
    public void destroyCard(int type, int x)
    {
        handCards[type].Remove((handCards[type][x]));
    }
    
    
    public void createDeck(int type)
    {
        if (type == 0)
        {
            List<Card_> deck=new List<Card_>();
            decks.Add(deck);
            List<Card_> hand=new List<Card_>();
            handCards.Add(hand);
        }
        else
        {
            List<Card_> deck=new List<Card_>();
            decks.Add(deck);
            List<Card_> hand=new List<Card_>();
            handCards.Add(hand);
        }
    }

    
    public void destroyDeck(int type)
    {
            decks.Remove(decks[type]);
             handCards.Remove(handCards[type]);
    }

    
    public void washDeck(int type)
    {
        
    }

    
    public void getHandCard(int type)
    {
       // print(handCards[type].Count);
        Card_ temp = decks[type][0];
        //print(decks[type].Count);
        removeCard(type,0);
        handCards[type].Add(temp);  
    }
    public void showCard(Vector3 startPosition,Vector3 endPosition,Quaternion createRotation)
    {
       // print(handCards[0].Count);
        int childCount = transform.childCount;
        print(childCount);
        for (int i = 0; i < childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
            print(1);
        }

        Vector3 interval = (endPosition - startPosition) / handCards[0].Count;
        
        foreach (var temp in handCards[0])
        {
            print("ss"+handCards[0].Count);
            GameObject itemGo = Instantiate(temp.image, startPosition+interval, createRotation);
            itemGo.transform.SetParent(gameObject.transform);
            startPosition += interval;
        }
      
        //itemPositionList.Add(createPosition);
    }


}

