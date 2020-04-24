using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Controlls;

public static class AICounterDecider 
{
    public static bool CounterKick(Animator animator)
    {
        float wantedDistanceToPlayer = 0.2f;
        bool isPalyerPunching = false;
        Transform player;
        GameObject playerGameObject = GameObject.FindWithTag("Player");
        Animator playerAnimator = null;

        if (playerGameObject == null)
            Debug.LogError("No GameObject with the \"Player\" tag found");
        else
        {
            player = playerGameObject.transform;
            playerAnimator = player.GetComponent<Animator>();

            Vector3 vectorToPlayer = player.position - animator.transform.position;
            float distanceToPlayer = vectorToPlayer.magnitude;


            if (distanceToPlayer <= wantedDistanceToPlayer)
                isPalyerPunching = playerAnimator.GetBool("IsPunching");
        }
        animator.SetBool("ShouldCounter", isPalyerPunching);

        return isPalyerPunching;
    }
}
