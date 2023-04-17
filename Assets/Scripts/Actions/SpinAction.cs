using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{
    // delegate: is a function that can be called from outside
    //public delegate void SpinCompleteDelegate();
    //private SpinCompleteDelegate onSpinComplete;
    //private Action onActionComplete; //moved on BaseAction

    private float totalSpinAmount;

    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        float spinAddAmount = 360f * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, spinAddAmount, 0);

        totalSpinAmount += spinAddAmount;
        if (totalSpinAmount >= 360f)
        {
            ActionComplete();
        }
    }

    /* Another way to implement this without having useless parameters, is this:
     * 
     * public class BaseParameters { }
     * public class SpinBaseParameters : BaseParameters { }
     * 
     * public override void TakeAction(BaseParameters baseParameters, Action onActionComplete)
     * {
     *      SpinBaseParameters spinBaseParameters = (SpinBaseParameters) baseParameters;
     *      ...
     * }
     */

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        totalSpinAmount = 0f;

        ActionStart(onActionComplete);
    }

    public override string GetActionName()
    {
        return "Spin";
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        GridPosition unitGridPosition = unit.GetGridPosition();

        return new List<GridPosition> { unitGridPosition };
    }

    public override int GetActionPointsCost()
    {
        return 2;
    }

}
