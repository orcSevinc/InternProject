using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class DestroyByContact : MonoBehaviour
{
    public int Score;
    private IController IController;
    string[] Tags = new string[] { "Player", "Enemy", "Bolt", "Boundary"};

    void Awake()
    {
        IController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        
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

        if (other.CompareTag(Tags[3]))
        {
            return;
        }
			
		for(int i=0; i<3; i++)
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
                    	GenericCollision(gameObject);
                    	break;
      		    }
       		}
    	}
    }
}