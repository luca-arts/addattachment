using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scoreboard : MonoBehaviour
{
    public List<Player> players;

    // Start is called before the first frame update
    void Start()
    {
        players = new List<Player>();
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")){
            players.Add(player.GetComponent<Player>());
        }
    }


    public void UpdateScoreboard()
    {
        foreach (Player player in players)
        {
            player.UpdateScore();
            player.score = 0;
        }
    }
}
