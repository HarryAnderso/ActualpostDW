using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class GuardChaseAT : ActionTask {
		NavMeshAgent Navi;
		public GameObject player;
		protected override string OnInit() {

			Navi = agent.GetComponent<NavMeshAgent>();

            return null;
		}
		protected override void OnExecute() {
			
		}
		protected override void OnUpdate() {
			if (player == null || Vector3.Distance(player.transform.position, agent.transform.position) >10)
			{
				EndAction(false);
            }
            else
            {
				Navi.SetDestination(player.transform.position);
            }
        }
		protected override void OnStop() {
			
		}
		protected override void OnPause() {
			
		}
	}
}