using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Respawns a player if they leave the level bounds
public class LevelBounds : MonoBehaviour
{
    //REFERENCES//
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //If a player goes out of bounds, call the method to lose their life depending on which player fell out of bounds.
    //1 = Player 1 
    //2 = Player 2 
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name + " has lost a life.");
            if(other.gameObject.name == "Player1")
            {
                gm.LoseLife(1);

            }

            else if(other.gameObject.name == "Player2")
            {
                gm.LoseLife(2);
            }
        }
    }
}
