using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string firstname = "";
    // score is the score gathered in a round
    public int score = 0;
    public Color color = Color.red;
    // totalscore is the cumulative of all scores in the different rounds
    public int totalScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Adds the score obtained in a trial to the player's total score
    /// </summary>
    public void UpdateScore()
    {
        totalScore += score;
    }
}
