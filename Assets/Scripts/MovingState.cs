using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MovingState : PlayerState
{
    public override void EnterState(PlayerController player)
    {
        TryPlayAnimation(player, "Fly");

        
    }

    public override void UpdateState(PlayerController player)
    {
        float horizontal = Input.GetAxis("Horizontal");
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
        else
        {
            player.ChangeState(new IdleState());
        }

    }

    public override void ExitState(PlayerController player) { }

    public override string GetStateName() => "Moving";

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
                // Animation doesn't exist - continue without it
            }
        }
    }
}
