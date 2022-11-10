using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_Lever : MonoBehaviour
{
    public enum state{
        open,
        closed
    }
    public state barrierState = state.closed;
    public Vector3 positionOffset;

    public void Open(){
        if (barrierState == state.closed)
        {
            barrierState = state.open;
            gameObject.transform.position = gameObject.transform.position + positionOffset;
        }
    }

    public void Close(){
        if (barrierState == state.open)
        {
            barrierState = state.closed;
            gameObject.transform.position = gameObject.transform.position - positionOffset;
        }
    }

    public void Toggle(){
        if(barrierState == state.open)
        {
            Close();
        }
        else 
        {
            Open();
        }
    }
}
