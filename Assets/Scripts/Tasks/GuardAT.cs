using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class GuardAT : ActionTask {
        private Blackboard bb;
		NavMeshAgent guardnav;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            bb = agent.GetComponent<Blackboard>();
			guardnav = agent.GetComponent<NavMeshAgent>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() 
		{
            //GameObject firstpoint = bb.GetVariableValue<GameObject>("Point1");
            //GameObject secondpoint = bb.GetVariableValue<GameObject>("Point2");

            GameObject goal = bb.GetVariableValue<GameObject>("ChosenCorner");
			GameObject firstpoint = goal.GetComponent<GoalInformation>().point1;
			GameObject secondpoint = goal.GetComponent<GoalInformation>().point2;

            if (Vector3.Distance(agent.transform.position, firstpoint.transform.position) < Vector3.Distance(agent.transform.position, secondpoint.transform.position))
			{
				guardnav.SetDestination(firstpoint.transform.position);
			}

			else
			{
				guardnav.SetDestination(secondpoint.transform.position);
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