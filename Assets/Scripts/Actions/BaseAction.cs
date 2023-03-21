using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abstract: does not let create an instance of this specific class
public abstract class BaseAction : MonoBehaviour
{

    protected Unit unit;
    protected bool isActive;
    protected Action onActionComplete;

    // virtual: Awake can be overrided by other Actions
    // protected: Awake can be accessed by other Actions
    protected virtual void Awake()
    {
        unit = GetComponent<Unit>();
    }

    // abstract: subclasses must override this method,
    // without abstract you must implement this method from here
    public abstract string GetActionName();

    // abstract: to enforce other classes to implement this method
    public abstract void TakeAction(GridPosition gridPosition, Action onActionComplete);

    // virtual: in case someone want to change how this works
    public virtual bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList = GetValidActionGridPositionList();
        return validGridPositionList.Contains(gridPosition);
    }

    // abstract: to enforce other classes to implement this method
    public abstract List<GridPosition> GetValidActionGridPositionList();

}
