using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{public Selector(string n) { 
    
    name = n;
     
    }




    public override Node.Status Process()
    {

        Status childState = childern[CurrentNode].Process();


        if (childState == Node.Status.RUNNING)
        {
            return Node.Status.RUNNING;
        }
        if (childState == Node.Status.SUCCESS)
        {

            CurrentNode = 0;
            return Node.Status.SUCCESS;
        }


        CurrentNode++;  


        if (
            CurrentNode >= childern.Count   

            ) {
            CurrentNode = 0;

            return Node.Status.FAILURE; }










        return Node.Status.RUNNING;



    }

    }
