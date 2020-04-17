using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Controlls;

public static class AICounterDecider 
{
    public static bool CounterKick(Animator animator)
    {
        float wantedDistanceToPlayer = 0.2f;
        Transform player;
        GameObject playerGameObject = GameObject.FindWithTag("Player");

        if (playerGameObject == null)
            Debug.LogError("No GameObject with the \"Player\" tag found");
        else
        {
            player = playerGameObject.transform;

            Vector3 vectorToPlayer = player.position - animator.transform.position;
            float distanceToPlayer = vectorToPlayer.magnitude;

            if (distanceToPlayer <= wantedDistanceToPlayer &&
                Input.GetKey(attackKey) &&
                !Input.GetKey(crouchKey))
            {
                animator.SetTrigger("ShouldCounter");
                return true;
            }
        }

        return false;
    }
}
