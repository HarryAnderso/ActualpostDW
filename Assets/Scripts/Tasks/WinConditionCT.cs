using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Text.RegularExpressions;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class WinConditionCT : ConditionTask {

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise

		public GameObject c1;
		public GameObject c2;
		public GameObject c3;
		public GameObject c4;

	

		public bool b1;
		public bool b2;
		public bool b3;
		public bool b4;
		protected override string OnInit(){
           
            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
			

        }

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
            b1 = c1.GetComponent<GoalInformation>().captured;
            b2 = c2.GetComponent<GoalInformation>().captured;
            b3 = c3.GetComponent<GoalInformation>().captured;
            b4 = c4.GetComponent<GoalInformation>().captured;

            if (b1 && b2 && b3 && b4)
            {
                agent.GetComponent<Destroyer>().go = true;
                return false;
            }

			else
			{
				return true;
			}
        }
	}
}