using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conditionManager : MonoBehaviour
{
    public condition Condition;
    public battleSystem BattleSystem;
    public void set(int type,string name,int count)
    {
        int i;
        for (i = 0; i < Condition.ConditionList[type].Count; i++)
        {
            if (Condition.ConditionList[type][i].name == name)
            {
                break;
            }
        }
        
        Condition.ConditionList[type][i].setActivate();
        Condition.RoundList[type][i].roundPre = BattleSystem.roundCount;
        Condition.RoundList[type][i].roundLast = count;
    }


    public void init()
    {
        Condition.init();
    }

    public bool search(int type,string name)
    {
        int i;
        for (i = 0; i < Condition.ConditionList[type].Count; i++)
        {
            if (Condition.ConditionList[type][i].name == name)
            {
                break;
            }
        }

        return Condition.ConditionList[type][i].isActivate;
    }


}
