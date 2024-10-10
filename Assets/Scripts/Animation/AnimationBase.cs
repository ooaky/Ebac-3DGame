using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Animation
{
    public enum AnimationType
    {
        NONE,
        IDLE,
        RUN,
        ATTACK,
        DEATH
    }


    public class AnimationBase : MonoBehaviour
    {
        public Animator animator;
        public List<AnimationSettup> animationSettups;

        

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            var settup = animationSettups.Find(i => i.animationType == animationType);

            if (settup != null)
                animator.SetTrigger(settup.trigger);

        }



    }

    [System.Serializable]
    public class AnimationSettup
    {
        public AnimationType animationType;
        public string trigger;





    }
}
