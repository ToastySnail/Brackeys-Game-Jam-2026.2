using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    [SerializeField] private float xBounds;
    [SerializeField] private float yBounds;
    [SerializeField] private float movementSpeed;
    private NavMeshAgent agent;
    private const float MIN_WANDER_PAUSE_TIME = 5f;
    private const float MAX_WANDER_PAUSE_TIME = 20f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = movementSpeed;

        StartCoroutine(Wander());
    }


    IEnumerator Wander()
    {
        while (true)
        {
            float x = Random.Range(-xBounds, xBounds);
            float y = Random.Range(-yBounds, yBounds);
            Vector3 target = new Vector3(x, y, 0);
            yield return agent.SetDestination(target);
            float time = Random.Range(MIN_WANDER_PAUSE_TIME, MAX_WANDER_PAUSE_TIME);
            yield return new WaitForSeconds(time);
        }
    }
}
