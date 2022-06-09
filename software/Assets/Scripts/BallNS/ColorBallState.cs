using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BallNS
{
    [RequireComponent(typeof (BallStateMachine))]
    public class ColorBallState : MonoBehaviour
    {
        private Color idleColor = Color.gray;

        private Color attractColor = Color.red;

        private Color attachColor = Color.green;

        private Color throwColor = Color.blue;

        private Material _material;

        private BallStateMachine _stateMachine;

        // Start is called before the first frame update
        void Start()
        {
            _material = GetComponent<Renderer>().material;
            _stateMachine = GetComponent<BallStateMachine>();
        }

        // Update is called once per frame
        void Update()
        {
            switch (_stateMachine.GetCurrentGrabState())
            {
                case BallStateMachine.GrabState.Idle:
                    _material.color = idleColor;
                    break;
                case BallStateMachine.GrabState.Attract:
                    _material.color = attractColor;
                    break;
                case BallStateMachine.GrabState.Attach:
                    _material.color = attachColor;
                    break;
                case BallStateMachine.GrabState.Throw:
                    _material.color = throwColor;
                    break;
            }
        }
    }
}
