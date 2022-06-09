using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class BallCatcher : MonoBehaviour
    {
        private GameObject ball;
        private Ball ballScript;
        public GameObject NPC;
        // Use this for initialization
        void Start()
        {
            ball = GameObject.FindWithTag("Ball");
            ballScript = ball.GetComponent<Ball>();
        }


        /// <summary>
        /// when the ball collides with the player or child, we want to create a joint between the ball and the player or child
        /// also, we want to put the lookat constraint on inactive until we toss the ball
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == ball)
            {
                Debug.Log(collision.gameObject.name);

                if (ball.transform.parent == null)
                {
                   
                    ballScript.SetParent(transform);


                    //we put the isTossed variable of the other players to false, so they can attract the ball
                    NPC.GetComponentInChildren<PlayBall>().isTossed = false;
                }
            }
        }
    }
}