using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Robber : MonoBehaviour
{

    public enum actionState { IDLE , WORKING }; 

    public actionState state  = actionState.IDLE; 

    public Node.Status treeStatus = Node .Status.RUNNING;




    BehaviourTree behaviourTree;
    public GameObject diamond;
    public GameObject van;
     
    public GameObject  backDoor;
    public GameObject frontDoor;

    NavMeshAgent agent;



    void Start()
    {

        agent  = this.GetComponent<NavMeshAgent>();



       behaviourTree =  new BehaviourTree(); 

        Sequence steal = new Sequence("Steal ");



        Selector openDoor = new Selector("openDoor ");

        Leaf goToFrontDoor = new Leaf("goToFrontDoor ", GoToFrontDoor);
        //  Node goToDoor = new Node(" goToDoor ");
        Leaf goToBackDoor = new Leaf("goToBackDoor ", GoToBackDoor);

        Leaf goToDiamond = new Leaf("goToDiamond ", GoToDiamond);
        Leaf goToVan = new Leaf("goToVan ", GoToVan);

        openDoor.AddChild(goToBackDoor);
        openDoor.AddChild(goToFrontDoor);

    


        
        steal.AddChild(openDoor);
       //  steal .AddChild(goToDoor);
        steal.AddChild(goToDiamond);
        steal.AddChild(goToBackDoor);

        steal.AddChild(goToVan);


        behaviourTree.AddChild(steal);



   


    }
    public Node.Status GoToBackDoor()
    {


        //  agent.SetDestination(diamond.transform.position); 

        return GoToLocation(backDoor.transform.position);


    }

    public Node.Status GoToFrontDoor()
    {


        //  agent.SetDestination(diamond.transform.position); 

        return GoToLocation(frontDoor.transform.position);


    }



    public Node.Status GoToDiamond()
    {


      //  agent.SetDestination(diamond.transform.position); 

        return  GoToLocation(diamond.transform.position);


    }


    public Node.Status GoToVan()
    {

        return GoToLocation(van.transform.position);


        //agent.SetDestination(van.transform.position);

        //return Node.Status.SUCCESS;


    }



    public Node.Status GoToLocation(  Vector3 destination  ) {

         
        float distanceToTarget = Vector3.Distance(destination , this.transform.position );

        if (state == actionState.IDLE)
        {

            agent.SetDestination(destination);

            state = actionState.WORKING;

        }


        else if (Vector3.Distance(agent.pathEndPosition, destination
            ) >= 2) {
         state = actionState.IDLE;
            return Node.Status.FAILURE;


        }

        else if ( distanceToTarget < 2 ) 
        {
            state = actionState.IDLE; 
            return Node.Status.SUCCESS;
        } 


         
        return Node.Status.RUNNING;

    }













    void Update()
    {

        if (  treeStatus == Node.Status.RUNNING   ) {
             
            treeStatus = behaviourTree.Process(); 




        }
        
    }
}
