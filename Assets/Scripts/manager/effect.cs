using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using UnityEngine;







    public class effectBase
    {

        public consumeManager ConsumeManager;
        public cardController CardController;
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
        public unNameFire(consumeManager temp1,cardController temp2,UIController temp3)
        {
            ConsumeManager = temp1;
            CardController = temp2;
            UI = temp3;
        }
        
        public override void func(int type )
        {
        
            ConsumeManager.damage(type,"health",10);
            CardController.addCard(type,"anger");
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
        
        public anger(consumeManager temp1,cardController temp2,UIController temp3)
        {
            ConsumeManager = temp1;
            CardController = temp2;
            UI = temp3;
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
            CardController.addCard(type,"anger");
        }
    }

public class effect : MonoBehaviour
{
    public consumeManager temp1;
    public cardController temp2;
    public UIController temp3;
    public unNameFire returnUnameFire()
    {
        return new unNameFire(temp1,temp2,temp3);
    }
    
    public anger ReturnAnger()
    {
        return new anger(temp1,temp2,temp3);
    }

    
}
