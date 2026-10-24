using UnityEngine;

namespace AyutthayaSimulator.Animation
{
    public interface ISomchaiIKTarget
    {
        bool TryGetIKTarget(AvatarIKGoal goal, out Transform target, out float weight);
    }

    [RequireComponent(typeof(Animator))]
    public sealed class SomchaiIKController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private MonoBehaviour targetProvider;
        [Range(0f, 1f)] [SerializeField] private float bodyWeight = 0.25f;

        private void Awake() { if (animator == null) animator = GetComponent<Animator>(); }
        private void OnAnimatorIK(int layerIndex)
        {
            if (animator == null || targetProvider is not ISomchaiIKTarget provider) return;
            AvatarIKGoal[] goals = { AvatarIKGoal.LeftHand, AvatarIKGoal.RightHand, AvatarIKGoal.LeftFoot, AvatarIKGoal.RightFoot };
            for (int i = 0; i < goals.Length; i++)
            {
                AvatarIKGoal goal = goals[i];
                if (provider.TryGetIKTarget(goal, out Transform target, out float weight) && target != null)
                {
                    animator.SetIKPositionWeight(goal, weight);
                    animator.SetIKRotationWeight(goal, weight);
                    animator.SetIKPosition(goal, target.position);
                    animator.SetIKRotation(goal, target.rotation);
                }
                else
                {
                    animator.SetIKPositionWeight(goal, 0f);
                    animator.SetIKRotationWeight(goal, 0f);
                }
            }
            animator.bodyPosition = Vector3.Lerp(animator.bodyPosition, animator.bodyPosition, bodyWeight);
        }
    }
}
