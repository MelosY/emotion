using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using System.Xml.Xsl;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

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

        public Card_()
        {
            
        }
        public Card_(GameObject temp1, string name, int color, int pay, int grade, effectBase temp2)
        {
            this.image = temp1;
            this.name = name;
            this.color = color;
            this.pay = pay;
            this.grade = grade;
            this.Base = temp2;

        }
          
    }
    
    public List<List<Card_>> decks=new List<List<Card_>> ();
    
    public List<List<Card_>> handCards=new List<List<Card_>> ();
    
    public List<Card_> library=new List<Card_> ();


    public void initLibrary()
    {
        Card_ unNameFire=new Card_(Images[0],"unNameFire",1,0,3,Effect.returnUnameFire());
        library.Add(unNameFire);
        
        //无名火
        Card_ anger=new Card_(Images[0],"anger",1,0,5,Effect.ReturnAnger());
        library.Add(anger);
        
        //激怒
        Card_ rage=new Card_(Images[0],"rage",1,1,5,Effect.ReturnRage());
        library.Add(rage);
        
        //处决
        Card_ execute=new Card_(Images[0],"execute",1,2,3,Effect.ReturnExecute());
        library.Add(execute);
        
        //挑衅
        Card_ provoke=new Card_(Images[0],"provoke",1,3,4,Effect.ReturnProvoke());
        library.Add(provoke);
        
        //狂暴
        Card_ fury=new Card_(Images[0],"fury",1,3,5,Effect.ReturnFury());
        library.Add(fury);
        
        
        Card_ recover=new Card_();
        recover.name = "recover";
        recover.image = Images[1];
        recover.color = 2;
        recover.pay = 1;
        recover.grade = 5;
        recover.Base=Effect.ReturnRecover();
        library.Add(recover);
        
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
    
 
   
}

