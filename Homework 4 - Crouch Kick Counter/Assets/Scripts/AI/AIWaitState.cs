using UnityEngine;
using static AICounterDecider;

public class AIWaitState : StateMachineBehaviour {

	private MovementController movementController;
	private Transform player;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		movementController = animator.GetComponent<MovementController>();
		movementController.SetHorizontalMoveDirection(0);
		player = GameObject.FindWithTag("Player").transform;
	}
	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (CounterKick(animator))
			return;

		float directionToPlayer = player.position.x - animator.transform.position.x;
		movementController.TurnTowards(directionToPlayer);
	}
}
