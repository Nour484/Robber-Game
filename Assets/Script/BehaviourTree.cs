using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : Node
{



    public override Status Process() { 
    
      return childern[CurrentNode].Process();


    }

    public BehaviourTree() 
    {

        name = "Tree"; 
    }


    public BehaviourTree(string newName)
    {


        name = newName; 



    }



}
