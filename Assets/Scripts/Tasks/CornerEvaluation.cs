using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class CornerEvaluation : ActionTask {


		public GameObject player;
		public GameObject[] goals;
		float pdistance;
		float gdistance;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            

					return null;

			
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            foreach (GameObject goal in goals)
            {


                if (goal.GetComponent<GoalInformation>().captured == false)
                {
                    if (pdistance == 0)
                    {
                        pdistance = Vector3.Distance(player.transform.position, goal.transform.position);
                    }
                    else if (Vector3.Distance(player.transform.position, goal.transform.position) < pdistance)
                    {
                        pdistance = Vector3.Distance(player.transform.position, goal.transform.position);
                    }


                    if (gdistance == 0)
                    {
                        gdistance = Vector3.Distance(agent.transform.position, goal.transform.position);
                    }
                    else if (Vector3.Distance(agent.transform.position, goal.transform.position) < gdistance)
                    {
                        gdistance = Vector3.Distance(agent.transform.position, goal.transform.position);
                    }
                }

                if (pdistance < gdistance)
                {
                    Debug.Log(pdistance +"And " +gdistance);
                    EndAction(false);
                }
                else
                {
                    Debug.Log(pdistance + "And " + gdistance);
                    EndAction(true);
                }


            }
            }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}