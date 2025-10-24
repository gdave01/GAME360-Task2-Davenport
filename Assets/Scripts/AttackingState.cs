using UnityEngine;

public class AttackingState : PlayerState
{
    public override void EnterState(PlayerController player)
    {
        TryPlayAnimation(player, "Attack");
    }

    public override void UpdateState(PlayerController player)
    {

    }

    public override void ExitState(PlayerController player) { }

    public override string GetStateName() => "Attacking";

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
