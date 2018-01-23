using System.Collections.Generic;
using System.Collections;
using UnityEngine;
//Idamageble interface TODO

public class DestroyByContact : MonoBehaviour
{
    public int Score;
    private IController IController;
    string[] Tags = new string[] { "Player", "Enemy", "Bolt", "BoltCyan", "Boundary"};

    void Start()
    {
        IController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        
    }

    bool CollisionBetweenEnemies(GameObject gameObject, Collider other)
    {
        if (gameObject.CompareTag(Tags[1]) && other.CompareTag(Tags[2])) //Enemy & Bolt
            return true;
        if (gameObject.CompareTag(Tags[2]) && other.CompareTag(Tags[1])) //Bolt & Enemy
            return true;
        if (gameObject.CompareTag(Tags[1]) && other.CompareTag(Tags[1])) //Enemy & Enemy
            return true;
        return false;
    }

    void PlayerCollision(GameObject gameObject)
    {
        if (IController.GetLife() == 0)
        {
            IController.GameOver();
        }
        else
        {
            IController.AddLife(1);
        }
        Destroy(gameObject);
    }

    void EnemyCollision(GameObject gameObject)
    {
        IController.AddScore(Score);
        Destroy(gameObject);
    }

    void GenericCollision(GameObject gameObject)
    {
        Destroy(gameObject);
    }

	void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(Tags[4])) //Check for Boundary
        {
            return;
        }

        if (CollisionBetweenEnemies(this.gameObject, other)) 
		{
			return;
		}
			
		for(int i=0; i<Tags.Length-1; i++)
 	    {
			if (gameObject.CompareTag(Tags[i]))
 	        {
            	switch (i)
         		{
                	case 0:
                    	PlayerCollision(gameObject);
                 		break;
                	case 1:
                    	EnemyCollision(gameObject);
                    	break;
                 	case 2:
                    case 3:
                    	GenericCollision(gameObject);
                    	break;
      		    }
       		}
    	}
    }
}