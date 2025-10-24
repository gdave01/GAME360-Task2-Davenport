using UnityEngine;

public class IdleState : PlayerState
{
    public override void EnterState(PlayerController player)
    {
        // Safe animation - only plays if everything is set up
        TryPlayAnimation(player, "Idle");
        player.exhaust.SetActive(false);
    }

    public override void UpdateState(PlayerController player)
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            player.ChangeState(new MovingState());
        }

        /*float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 velocity = player.rb.linearVelocity;
        velocity.x = horizontal * player.moveSpeed;
        velocity.y = vertical * player.moveSpeed;
        player.rb.linearVelocity = velocity;


        if (horizontal < 0 || horizontal > 0 || vertical < 0 || vertical > 0)
        {
            player.exhaust.SetActive(true);
            player.ChangeState(new MovingState());
            Debug.Log("moving works");
        }

        if (Input.GetButton("Fire1"))
        {
            player.HandleShooting();
            Debug.Log("shooting works");

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
