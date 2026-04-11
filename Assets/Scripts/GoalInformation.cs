using UnityEngine;

public class GoalInformation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool captured;
    public GameObject point1;
    public GameObject point2;
    public Material capturedmat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Renderer>().material = capturedmat;
            captured = true;
        }
    }



   


    //public void OncollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        GetComponent<Renderer>().material = capturedmat;
    //        captured = true;
    //    }
    //}
}
