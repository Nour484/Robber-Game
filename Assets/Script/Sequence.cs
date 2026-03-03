using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node 
{


    public Sequence(string n) { 
    
    
    name = n;
    }



    public override Node.Status Process() { 



         Status   childState  = childern[CurrentNode].Process();


        if (childState == Status.RUNNING ) return Node.Status.RUNNING;
        if (childState == Status.FAILURE)  return childern[CurrentNode].Process();

        CurrentNode++;

        if (CurrentNode >= childern.Count) {



            CurrentNode =0;


            return Node.Status.SUCCESS;

        }


          return Node.Status.RUNNING;












    



    }










}
