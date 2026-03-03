using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{

    public enum Status { SUCCESS, RUNNING, FAILURE };


    public Status status;

    public List<Node> childern = new List<Node>();


    public string name;

    public int CurrentNode = 0;


    public Node()
    {


   
    }


    public virtual Status Process() {
    
   return childern[CurrentNode].Process();

    }
  





    public Node(string n)
    {


        name = n;
    }


    public void AddChild(Node child)
    {
        childern.Add(child);


    }
}