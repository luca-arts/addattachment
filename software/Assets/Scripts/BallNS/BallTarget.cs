using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts; //TODO: set namespaces correctly
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.BallNS
{
    public class BallTarget : MonoBehaviour
    {
        private TrialList _trialList;

        private Trial _currentTrial;

        private bool _isGoodTrial;

        private List<GameObject> _targets;

        private GameObject _child;

        //nextTarget is the player
        private GameObject nextTarget;

        //nextAimTarget is the hand of the player
        private GameObject nextAimTarget;

        [SerializeField]
        private UnityEvent OnTargetChanged;

        public void SetTargets(GameObject[] players, GameObject child)
        {
            _trialList =
                GameObject.Find("trialListPrefab").GetComponent<TrialList>();

            //wait for the trial list to be filled
            _currentTrial = _trialList.GetCurrentTrial();
            _isGoodTrial = _currentTrial.IsGoodTrial();
            _targets = new List<GameObject>();
            _targets.AddRange (players);
            _targets.Add (child);
            _child = child;
        }

        /// <summary>
        /// NextTarget is a function being called to decide who should be the next target to throw the ball to
        /// /// </summary>
        /// <param name="currentOwner"></param>
        /// <returns></returns>
        private void NextTarget(GameObject currentOwner)
        {
            //we first update the isGoodTrial boolean to check to whom we can throw the ball
            _isGoodTrial = _trialList.GetCurrentTrial().IsGoodTrial();
            List<GameObject> _tempTargets = new List<GameObject>(_targets);
            _tempTargets.Remove (currentOwner);
            if (_isGoodTrial)
            {
                var random = new System.Random();
                int index = random.Next(_tempTargets.Count);
                Debug.Log("next is " + _tempTargets[index].name);
                nextTarget = _tempTargets[index];
            }
            else
            {
                // if it's not a good trial, we'll remove the child of the options and return a value of the remaining options
                _tempTargets.Remove (_child);
                var random = new System.Random();
                int index = random.Next(_tempTargets.Count);
                Debug.Log("next is " + _tempTargets[index].name);
                nextTarget = _tempTargets[index];
            }
        }
        /// <summary>
        /// Gets the BallCatcher object from within the next Target
        /// </summary>
        private void SetNextBallCatcher()
        {
            GameObject[] ballCatchers =
                GameObject.FindGameObjectsWithTag("BallCatcher");
            foreach (GameObject ballCatcher in ballCatchers)
            {
                if (ballCatcher.transform.IsChildOf(nextTarget.transform))
                {
                    nextAimTarget = ballCatcher;
                }
            }
        }

        /// <summary>
        /// Updates the next target and the next aim target (Ball Catcher), based on the current ballOwner and the trialtype
        /// </summary>
        /// <param name="currentOwner"></param>
        public void SetNextTarget(GameObject currentOwner)
        {
            NextTarget (currentOwner);
            OnTargetChanged?.Invoke();
        }
        /// <summary>
        /// returns a list of all the possible targets which are currently NOT targeted
        /// </summary>
        /// <returns></returns>
        public List<GameObject> GetNonTargets()
        {
            List<GameObject> _tempTargets = new List<GameObject>(_targets);
            _tempTargets.Remove (nextTarget);
            return _tempTargets;
        }

        
        /// <summary>
        /// returns the parent object to which we'll throw the next ball
        /// </summary>
        /// <returns></returns>
        public GameObject GetNextTarget()
        {
            return nextTarget;
        }
        /// <summary>
        /// returns the gameObject itself to which we'll aim the ball
        /// </summary>
        /// <returns></returns>
        public GameObject GetNextBallCatcher()
        {
            SetNextBallCatcher();
            return nextAimTarget;
        }
    }
}
