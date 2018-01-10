using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public int Score;
	GameController gameController;
	
	void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if (gameController == null)
        {
            Debug.Log ("Cannot find 'GameController' script");
        }
    }
	
	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
		if (other.tag == "Player" || tag == "Player")
        {
            if (gameController.Life == 0) 
			{
				gameController.GameOver ();
			} else 
			{
				gameController.SubtractLife (1);
			}
			
        }
		if (gameController.Life >= 0 && other.tag == "Player") 
		{

		} else 
			{
				Destroy(other.gameObject);
			}

		if (gameController.Life >= 0 && tag == "Player") 
		{

		} else 
			{
				Destroy(gameObject);
			}
		gameController.AddScore(Score);
    }
}