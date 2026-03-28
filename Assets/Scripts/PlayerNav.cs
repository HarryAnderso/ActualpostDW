using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerNav : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //clicktomove(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            //Debug.Log(Camera.main.ScreenPointToRay(Input.mousePosition));

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);
            clicktomove(hit.point);
        }
    }

    public void clicktomove(Vector3 pos)
    {
        pos.y = 0.5f;
        agent.SetDestination(pos);

    }
}
