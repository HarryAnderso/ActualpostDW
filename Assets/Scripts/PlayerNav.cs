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
            //the raycast will be used to get the point on the ground where the player clicked
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);
            clicktomove(hit.point);
        }
    }

    public void clicktomove(Vector3 pos)
    {
        //y value is set to 0.5f to prevent the player from sinking into the ground or rising above the floor
        pos.y = 0.5f;
        agent.SetDestination(pos);

    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
