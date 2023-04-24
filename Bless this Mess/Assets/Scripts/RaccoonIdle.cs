using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaccoonIdle : StateMachineBehaviour
{
    public AudioSource source;
    Transform player;
    Rigidbody2D rb;
    public float WalkRange = 2f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(player.position, rb.position) <= WalkRange)
        {
            animator.SetTrigger("Run");
        }
    }
    override public void OnStateExit(UnityEngine.Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle");
        source.Play();
    }



}
