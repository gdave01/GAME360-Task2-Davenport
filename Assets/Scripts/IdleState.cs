using UnityEngine;

public class IdleState : PlayerState
{
    public override void EnterState(PlayerController player)
    {
        // Safe animation - only plays if everything is set up
        TryPlayAnimation(player, "Idle");
        player.exhaust.SetActive(false);
        //player.burst.SetActive(false);
    }

    public override void UpdateState(PlayerController player)
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            player.ChangeState(new MovingState());
        }
        if (Input.GetButton("Fire1"))
        {
            player.burst.SetActive(true);
            player.ChangeState(new AttackingState());
            Debug.Log("switching to attack");
        }
       /* if (!Input.GetButton("Fire1"))
        {
            player.burst.SetActive(false);
        }*/

    }

    public override void ExitState(PlayerController player) { }

    public override string GetStateName() => "Idle";

    // Safe animation helper
    private void TryPlayAnimation(PlayerController player, string animName)
    {
        if (player.animator != null &&
            player.animator.runtimeAnimatorController != null &&
            player.animator.isActiveAndEnabled)
        {
            try
            {
                player.animator.Play(animName);
            }
            catch
            {
                // Animation doesn't exist - that's okay, continue without it
            }
        }
    }
}
