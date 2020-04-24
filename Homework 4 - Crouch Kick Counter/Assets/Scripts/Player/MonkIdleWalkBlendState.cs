﻿using UnityEngine;
using static Controlls;
using static StateMachineUtil;

public class MonkIdleWalkBlendState : StateMachineBehaviour
{

	private Animator animator;
	private MovementController movementController;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		this.animator = animator;
		movementController = animator.GetComponent<MovementController>();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		DoMove(animator, movementController);

		if (Input.GetKeyDown(attackKey))
			animator.SetBool("IsPunching", true);

		if (Input.GetKeyDown(jumpKey))
		{
			animator.SetBool("IsJumping", true);
			movementController.Jump();
		}
		if (Input.GetKeyDown(crouchKey))
			animator.SetBool("IsCrouching", true);
	}
}