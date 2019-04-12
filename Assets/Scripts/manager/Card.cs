using System.Collections;
using System.Collections.Generic;
using System.Xml.Xsl;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    
    //1是红色，2是

    public GameObject[] Images;
    public effect Effect;
    public class Card_
    {
          public GameObject image;
          public string name;
          public int color;
          public int pay;
          public int grade;
          public effectBase Base=new effectBase();
    }
    
    public List<List<Card_>> decks=new List<List<Card_>> ();
    
    public List<List<Card_>> handCards=new List<List<Card_>> ();
    
    public List<Card_> library=new List<Card_> ();


    public void initLibrary()
    {
        //Effect.init();
        Card_ unNameFire=new Card_();
        unNameFire.name = "unNameFire";
        unNameFire.image = Images[0];
        unNameFire.color = 1;
        unNameFire.pay = 0;
        unNameFire.grade = 3;
        unNameFire.Base = new unNameFire();
        library.Add(unNameFire);
        
        //无名火
        Card_ anger=new Card_();
        anger.name = "anger";
        anger.image = Images[1];
        anger.color = 1;
        anger.pay = 0;
        anger.grade = 5;
        anger.Base=new anger();
        library.Add(anger);
    }
    
    
 
    
    
    public void createCard(int type,string name)
    {
            Card_ temp =new Card_();

        foreach (var i in library)
        {
            
            if (i.name==name)
            {
                temp = i;
                break;
                
                ;
            }
        }
            decks[type].Add(temp);
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
        for (int i = 15; i >= 0; i--)
        {
            int index1 = Random.Range(0, decks[type].Count);
            int index2 = Random.Range(0, decks[type].Count);
            Card_ temp = decks[type][index1];
            decks[type][index1] = decks[type][index2];
            decks[type][index2] = temp;
        }
    
    }

    
    
    public void getHandCard(int type)
    {
        Card_ temp = decks[type][0];
        removeCard(type,0);
        handCards[type].Add(temp);   
    }
    
 
    public Card_ useCard(int type, int x)
    {
        Card_ temp =handCards[type][x];
        if (type == 0)
        {
            GameObject playerCard=GameObject.Find("playerDeck");
            playerCard.transform.GetChild(x).position=new Vector3(1.5f,1f,0);
        }
        else
        {
            GameObject playerCard=GameObject.Find("enemyDeck");
            playerCard.transform.GetChild(x).position=new Vector3(1.5f,1f,0);
        }
        destroyCard(type, x);
    
        return temp;
    }
}

