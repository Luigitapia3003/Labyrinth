using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollower : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform TransformToFollow;
    [SerializeField] Vector3 SizeOfView;
    [SerializeField] LayerMask whatIsCharacter;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        FindCharacterToFollow();
        if (TransformToFollow == null)
        {
            return;
        }
        agent.SetDestination(TransformToFollow.position);
    }

    void FindCharacterToFollow()
    {
        if (TransformToFollow != null)
        {
            return;
        }

        var characters = Physics.OverlapBox(transform.position, SizeOfView, Quaternion.identity, whatIsCharacter);
        if (characters.Length > 0)
        {
            TransformToFollow = characters[0].transform;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, SizeOfView);
    }
}
