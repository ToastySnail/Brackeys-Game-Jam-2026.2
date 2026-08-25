using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField] private float xBounds;
    [SerializeField] private float yBounds;
    [SerializeField] private float movementSpeed;
    private TMP_Text interactText;
    private GameObject player;
    private NavMeshAgent agent;
    private const float MIN_WANDER_PAUSE_TIME = 5f;
    private const float MAX_WANDER_PAUSE_TIME = 20f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = movementSpeed;

        interactText = GetComponentInChildren<TMP_Text>();
        interactText.text = "Talk: [E]";
        interactText.CrossFadeAlpha(0.0f, 0.0f, true);

        player = GameObject.FindWithTag("Player");


        StartCoroutine(Wander());
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 4.0f)
        {
            interactText.CrossFadeAlpha(1.0f, 0.2f, true);
        }
        else
        {
            interactText.CrossFadeAlpha(0.0f, 0.2f, true);
        }
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
