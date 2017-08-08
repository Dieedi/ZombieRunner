using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for
        public float distanceStopMove = 200;
        public float minDistanceWalk = 30;
        public float minDistanceRun = 10;


        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
        {
            if (target != null) {
                agent.SetDestination (target.position);
            }

            if (agent.remainingDistance > agent.stoppingDistance) {
                // don't move till player is near
                if (agent.remainingDistance > distanceStopMove) {
                    agent.speed = 0f;
                }else if (agent.remainingDistance < minDistanceRun) {
                    agent.speed = 2;
                } else if (agent.remainingDistance > minDistanceWalk) {
                    agent.speed = 0.8f;
                }

                character.Move (agent.desiredVelocity, false, false);
            } else {
                character.Move (Vector3.zero, false, false);
            }
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
