using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Security.Policy;
using UnityEngine;






public class condition : MonoBehaviour
{
    public class conditionBase
    {
        public string name;

        public bool isActivate;

        public conditionBase(string name)
        {
            this.name = name;
            isActivate = false;
        }

        public void setActivate()
        {
            isActivate = true;
        }

        public void deactivate()
        {
            isActivate = false;
        }
    
 
    }


    
  

    public class round
   {

       public string name;
       public int roundPre;
      
       public int roundLast;

       public round(string name, int x=0, int y=0)
       {
           this.name = name;
           roundPre = x;
           roundLast = 0;
       }
       
   }
    
    public List<List<conditionBase>> ConditionList=new List<List<conditionBase>> ();
    
    public List<List<round>>  RoundList =new List<List<round>> ();


    public void init()
    {
        List<conditionBase> playerBases=new List<conditionBase>();
        List<conditionBase> enemyBases=new List<conditionBase>();
        List<round> playerRounds=new List<round>();
        List<round> enemyRounds=new List<round>();
        ConditionList.Add(playerBases);
        ConditionList.Add(enemyBases);
        RoundList.Add(playerRounds);
        RoundList.Add(enemyRounds);
        
        //眩晕
        conditionBase dizzy0=new conditionBase("dizzy");
        round  dizzyRound0=new round("dizzy");
        conditionBase dizzy1=new conditionBase("dizzy");
        round  dizzyRound1=new round("dizzy");
        ConditionList[0].Add(dizzy0);
        RoundList[0].Add(dizzyRound0);
        ConditionList[1].Add(dizzy1);
        RoundList[1].Add(dizzyRound1);
        
        //挑衅
        conditionBase provoke0=new conditionBase("provoke");
        round  provokeRound0=new round("provoke");
        conditionBase provoke1=new conditionBase("provoke");
        round  provokeRound1=new round("provoke");
        ConditionList[0].Add(provoke0);
        RoundList[0].Add(provokeRound0);
        ConditionList[1].Add(provoke1);
        RoundList[1].Add(provokeRound1);
        
        
        
         
    }
    
    
    
}
