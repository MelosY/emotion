//using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.SocialPlatforms;


public class effectBase
    {

        public consumeManager ConsumeManager;
        public cardController CardController;
        public conditionManager ConditionManager;
        public UIController UI;
        
        public int transive;
        
        public effectBase()
        {
           
        }
        
        public virtual void func(int type)
        {
            
        }

        public virtual void bonus(int type,int x)
        {
            
        }

        public virtual void gradeFunc(int type)
        {
            
        }
    }


            //红色卡牌效果
    public class unNameFire : effectBase
    {
        public unNameFire(consumeManager temp1,cardController temp2,conditionManager temp3,UIController temp4)
        {
            ConsumeManager = temp1;
            CardController = temp2;
            ConditionManager = temp3;
            UI = temp4;
        }
        
        public override void func(int type )
        {
        
            ConsumeManager.damage(type,"health",10);
            CardController.addCard(type,"anger");
            ConditionManager.set(type,"dizzy",2);
        }

        public override void bonus(int type, int x)
        {
            ConsumeManager.damage(type,"health",2*x);
            UI.showBonus(2*x);
        }

        public override void gradeFunc(int type)
        {
            CardController.addCard(type,"anger");
            UI.showGrade("加入怒火到牌库");
        }
    }



    public class anger : effectBase
         {
             
             public anger(consumeManager temp1,cardController temp2,conditionManager temp3,UIController temp4)
             {
                 ConsumeManager = temp1;
                 CardController = temp2;
                 ConditionManager = temp3;
                 UI = temp4;
             }
             public override void func(int type)
             {
                 ConsumeManager.damage(type,"health",10);
             }
     
             public override void bonus(int type, int x)
             {
                 
             }
     
             public override void gradeFunc(int type)
             {
                 CardController.addCard(1-type,"anger");
             }
         }

     
    public class execute : effectBase
         {
             
             public execute(consumeManager temp1,cardController temp2,conditionManager temp3,UIController temp4)
             {
                 ConsumeManager = temp1;
                 CardController = temp2;
                 ConditionManager = temp3;
                 UI = temp4;
             }
             public override void func(int type)
             {
                 ConsumeManager.damage(type,"health",50);
                 if (ConsumeManager.show(type, "health") <= 0)
                 {
                     CardController.addCard(1-type,"execute");
                 }
        
             }
     
             public override void bonus(int type, int x)
             {
                 ConsumeManager.damage(type,"health",8*x);
                 transive = x;
                 UI.showBonus(8*x);
             }
     
             public override void gradeFunc(int type)
             {
                 ConsumeManager.damage(type,"health",2*transive);
                 UI.showBonus(2*transive);
             }
         }

     public class rage : effectBase
     {
             
         public rage(consumeManager temp1,cardController temp2,conditionManager temp3,UIController temp4)
         {
             ConsumeManager = temp1;
             CardController = temp2;
             ConditionManager = temp3;
             UI = temp4;
         }
         public override void func(int type)
         {
             ConsumeManager.damage(type,"health",15);
             ConsumeManager.damage(type,"health",15);
         }
     
         public override void bonus(int type, int x)
         {
             ConsumeManager.damage(type,"health",2*x);
             UI.showBonus(2*x);
         }
     
         public override void gradeFunc(int type)
         {
             ConsumeManager.damage(type,"health",15);
         }
     }



      public class provoke : effectBase
      {
             
          public provoke(consumeManager temp1,cardController temp2,conditionManager temp3,UIController temp4)
          {
              ConsumeManager = temp1;
              CardController = temp2;
              ConditionManager = temp3;
              UI = temp4;
          }
          public override void func(int type)
          {
              ConditionManager.set(1-type,"provoke",1);
          }
     
          public override void bonus(int type, int x)
          {
              
          }
     
          public override void gradeFunc(int type)
          {
              ConsumeManager.damage(1-type,"expense",-1);
          }
      }

     public class fury : effectBase
     {
             
         public fury(consumeManager temp1,cardController temp2,conditionManager temp3,UIController temp4)
         {
             ConsumeManager = temp1;
             CardController = temp2;
             ConditionManager = temp3;
             UI = temp4;
         }
         public override void func(int type)
         {
             
             int num = Random.Range(2, 6);
             for (int i = 0; i < num && i<CardController.getLenHand(type); i++)
             {
                 int count = Random.Range(0, CardController.getLenHand(1-type)); 
                 CardController.destroyCard(1-type,count);
                 ConsumeManager.damage(type,"health",40);
             }

             transive = num;
         }
     
         public override void bonus(int type, int x)
         {
             ConsumeManager.damage(type,"health",2*x);
             UI.showBonus(2*x);
         }
     
         public override void gradeFunc(int type)
         {
             for (int i = 0; i < transive; i++)
             {
                 CardController.addCard(1-type,"anger");
             }
         }
     }






       public class recover : effectBase
       {
           public recover(consumeManager temp1,cardController temp2,conditionManager temp3,UIController temp4)
           {
               ConsumeManager = temp1;
               CardController = temp2;
               ConditionManager = temp3;
               UI = temp4;
           }
        
           public override void func(int type )
           {
        
               ConsumeManager.recover(1-type,"health",10);
        
           }

           public override void bonus(int type, int x)
           {
               ConsumeManager.recover(1-type,"health",2*x);
               UI.showBonus(2*x);
           }

           public override void gradeFunc(int type)
           {
               ConsumeManager.recover(1-type,"health",2*CardController.numOfBonus(type,2));
        
           }
       }


public class effect : MonoBehaviour
{
    public consumeManager temp1;
    public cardController temp2;
    public conditionManager temp3;
    public UIController temp4;

    
    
    
    public unNameFire returnUnameFire()
    {
        return new unNameFire(temp1,temp2,temp3,temp4);
    }
    
    public anger ReturnAnger()
    {
        return new anger(temp1,temp2,temp3,temp4);
    }

    public recover ReturnRecover()
    {
        return new recover(temp1,temp2,temp3,temp4);
    }
    public rage ReturnRage()
    {
        return new rage(temp1,temp2,temp3,temp4);
    }
    
    public execute ReturnExecute()
    {
        return new execute(temp1,temp2,temp3,temp4);
    }
    
    public provoke ReturnProvoke()
    {
        return new provoke(temp1,temp2,temp3,temp4);
    }
    
    public fury ReturnFury()
    {
        return new fury(temp1,temp2,temp3,temp4);
    }
}
