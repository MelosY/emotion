using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class effectBase
{
 
    public   consumeManager ConsumeManager ;
    public  cardController CardController;
    
 
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
    public override void func(int type)
    {
        
        ConsumeManager.damage(type,"health",10);
        CardController.addCard(type,"anger");
    }

    public override void bonus(int type, int x)
    {
        ConsumeManager.damage(type,"health",2*x);
    }

    public override void gradeFunc(int type)
    {
        CardController.addCard(type,"anger");
    }
}

public class anger : effectBase
{
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
    public   consumeManager ConsumeManager ;
    public  cardController CardController;
    effectBase EffectBase=new effectBase();

    private void Start()
    {
        EffectBase.CardController = this.CardController;
        EffectBase.ConsumeManager = this.ConsumeManager;
    }
}
