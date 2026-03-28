using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class CornerEvaluation : ActionTask {

		//public GameObject goal1;
		//public GameObject goal2;
		//public GameObject goal3;
		//public GameObject goal4;
		public GameObject player;
		public GameObject[] goals;
		float pdistance;
		float gdistance;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            foreach (GameObject goal in goals)
            {
                //GameObject tempgameobj = goal.GetComponent<GoalInformation>();
                //goal.GetComponent<GoalInformation>();
                //goal.GetComponent<GoalInformation>().captured = false;

                if (goal.GetComponent<GoalInformation>().captured == false)
                {

                }

            }

            return null;

			
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
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