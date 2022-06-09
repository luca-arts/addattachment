using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BallNS
{
    public class HighlightBallTarget : MonoBehaviour
    {
        /// <summary>
        /// The goal of this class is to highlight the next player which will be the target of the ball
        /// The other players should have their directional light dimmed of course
        /// </summary>
        private BallTarget _ballTarget;

        public GameObject attentionRing;

        private GameObject _attentionRingInstance;

        // Update is called once per frame
        void Start()
        {
            _ballTarget = GetComponent<BallTarget>();
            _attentionRingInstance =
                Instantiate(attentionRing,
                new Vector3(0, 0, 0),
                Quaternion.identity);
            _attentionRingInstance.SetActive(false);
        }

        public void UpdateLights()
        {
            Debug.Log("update lights");
            var currentTarget = _ballTarget.GetNextTarget();
            SetLightIntensity(currentTarget, 100.0f);
            var others = _ballTarget.GetNonTargets();
            foreach (var other in others)
            {
                SetLightIntensity(other, -13.0f);
            }
        }

        private void SetLightIntensity(GameObject target, float intensity)
        {
            var emissionLight =
                GameObject
                    .Find(target.name + "/Platform")
                    .GetComponent<Renderer>()
                    .material;
            emissionLight
                .SetColor("_EmissionColor",
                target.GetComponent<Player>().color * intensity);
        }

        public void UpdateAttentionRing()
        {
            var currentTarget = _ballTarget.GetNextTarget();

            _attentionRingInstance.transform.position = currentTarget.transform.position;
            _attentionRingInstance.SetActive(true);
        }
    }
}
