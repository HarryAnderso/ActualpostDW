using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {


	public class ChooseCorner : ActionTask {

        public GameObject player;
        public GameObject[] goals;
        float pdistance;
        float gdistance;
		 float score;
		private Blackboard bb;
        bool captured;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			bb = agent.GetComponent<Blackboard>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{

			foreach (GameObject goal in goals)
			{
                captured = goal.GetComponent<GoalInformation>().captured;
                if (!captured)
				{
                    if (score == 0)
                    {
                        pdistance = Vector3.Distance(player.transform.position, goal.transform.position);
                        gdistance = Vector3.Distance(agent.transform.position, goal.transform.position);
                        //Debug.Log(pdistance + "And " + gdistance);
                        score = (pdistance - gdistance);
                        //Debug.Log(score);
                        bb.SetVariableValue("ChosenCorner", goal);
                    }

                    else
                    {
                        pdistance = Vector3.Distance(player.transform.position, goal.transform.position);
                        gdistance = Vector3.Distance(agent.transform.position, goal.transform.position);
                        if ((pdistance - gdistance) > score)
                        {
                            score = (pdistance - gdistance);
                            //Debug.Log(score);
                            bb.SetVariableValue("ChosenCorner", goal);
                        }

                        else
                        {
                            //Debug.Log("irrelevent");
                        }

                    }
                }
                else
                {
                    Debug.Log("captured");
                }
			}
			EndAction(true);
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