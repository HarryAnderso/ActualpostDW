using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;
using Unity.AI.Navigation.Editor;


namespace NodeCanvas.Tasks.Actions {

	public class SprintAT : ActionTask {
		NavMeshAgent navi;
		public float stanima;
		public Material alt1;
		public Material alt2;
		public bool alt;
		public float change = 0;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
            navi = agent.GetComponent<NavMeshAgent>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			stanima = 5;
			navi.speed = navi.speed * 2f;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			stanima -= Time.deltaTime;
			Material current = agent.GetComponent<Renderer>().material;

			change += Time.deltaTime;

			if (change > .5)
			{
				if(alt)
				{
                    agent.GetComponent<Renderer>().material = alt1;
					change = 0;
					alt = false;
                }
				else
				{
                    agent.GetComponent<Renderer>().material = alt2;
					change = 0;
					alt = true;
                }
			}

            if (stanima < 0)
			{
                agent.GetComponent<Renderer>().material = alt1;
                stanima = 0;
				navi.speed = 3f;
				alt = false;
                EndAction(true);
            }

			

        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}