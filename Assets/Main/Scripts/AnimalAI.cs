using UnityEngine;
using UnityEngine.AI;

public class AnimalAI : MonoBehaviour
{
    public float moveRadius = 100f;
    public float waitTime = 3f;

    NavMeshAgent agent;
    float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waitTime)
        {
            SetRandomDestination();
            timer = 0f;
            waitTime = Random.Range(2f, 5f);
        }
    }

    void SetRandomDestination()
    {
        Vector3 randomPos = Random.insideUnitSphere * moveRadius + transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPos, out hit, moveRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}