using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using UnityEngine;







    public class effectBase
    {

        public consumeManager ConsumeManager;
        public cardController CardController;
        public conditionManager ConditionManager;
        public UIController UI;
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
           ConsumeManager.damage(type,"health",1);
        }

        public override void bonus(int type, int x)
        {
            
        }

        public override void gradeFunc(int type)
        {
            CardController.addCard(type,"anger");
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
}
