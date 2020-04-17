using UnityEngine;
using static Controlls;
using static StateMachineUtil;

public class MonkCrouchState : StateMachineBehaviour
{
    private Animator animator;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.animator = animator;
        MovementController movementController = animator.GetComponent<MovementController>();
        movementController.SetHorizontalMoveDirection(0);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!Input.GetKey(crouchKey))
            animator.SetBool("IsCrouching", false);
        if (Input.GetKeyDown(attackKey))
            animator.SetTrigger("IsPunching");
    }
}
