using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

    public GameOver gameOver;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameOver.victoryCondition();
        }
    }
}
