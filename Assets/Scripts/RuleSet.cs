using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class RuleSet
{
    public int index = 0;

    public RuleSet(int index)
    {
        this.index = index;
    }

    public MatterSettings MergeRuleCal(Matter a, Matter b)
    {
        Debug.Log("using merge rule: " + index);

        MatterSettings result;
        switch (index)
        {
            default:
                result = MergeRule_default(a, b);
                break;
            case 1:
                result = MergeRule_01(a, b);
                break;
            case 2:
                result = MergeRule_02(a, b);
                break;
        }
        return result;
    }

    #region default
    public MatterSettings MergeRule_default(Matter a, Matter b)
    {
        return new MatterSettings(MatterType.E, MatterPhase.Circle);
    }
    #endregion

    // tim prototype
    #region custom 1
    public MatterSettings MergeRule_01(Matter a, Matter b)
    {
        var valA = (int)a.type + 1;
        var valB = (int)b.type + 1;

        var newVal = valA + valB;
        
        if (newVal - 1 > GetLastTypeEnum()) return null;

        return new MatterSettings((MatterType)(newVal - 1), a.phase);
    }
    #endregion

    // same merge rule
    #region custom 2
    public MatterSettings MergeRule_02(Matter a, Matter b)
    {
        if (a.type != b.type) return null;

        var result = (int)a.type + 1;

        if (result > GetLastTypeEnum()) return null;


        return new MatterSettings((MatterType)result, a.phase);
    }
    #endregion

    public int GetLastTypeEnum()
    {
        return (int)Enum.GetValues(typeof(MatterType)).Cast<MatterType>().Last();
    }
}
