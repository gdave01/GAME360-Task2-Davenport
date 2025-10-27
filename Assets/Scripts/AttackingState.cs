using UnityEngine;
public class AttackingState : PlayerState
{
    public override void EnterState(PlayerController player)
    {
        TryPlayAnimation(player, "Attack");
    }
    public override void UpdateState(PlayerController player)
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            player.ChangeState(new MovingState());
        }

        if (!Input.GetButton("Fire1"))
        {
            player.burst.SetActive(false);
        }
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