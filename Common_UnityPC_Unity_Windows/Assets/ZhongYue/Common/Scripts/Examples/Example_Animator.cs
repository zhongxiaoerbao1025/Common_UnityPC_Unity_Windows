using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Example
{
    public class Example_Animator
    {
        #region 
        /// <summary>  </summary>
        public virtual void SetBool(Animator animator)
        {
            JudgeAnimator(animator);
        }

        /// <summary>  </summary>
        public virtual void SetFloat(Animator animator)
        {
            JudgeAnimator(animator);
        }



        /// <summary> 动画的 开始播放 </summary>
        public virtual void AnimationPlay(Animator animator, string animationName, int layer = 0, int fixedTime = 0)
        {
            JudgeAnimator(animator);

            animator.PlayInFixedTime(animationName, layer, fixedTime);
        }

        /// <summary> 动画的 播放与暂停 </summary>
        public virtual void PlayAndPause(Animator animator)
        {
            JudgeAnimator(animator);

            if (animator.speed == 1) { animator.speed = 0; }
            else { animator.speed = 1; }
        }

        /// <summary> 改变当前动画播放的 速度 </summary>
        /// <param name="animator"></param>
        public virtual void SetAnimationSpeed(Animator animator, float speed)
        {
            JudgeAnimator(animator);

            animator.speed = speed;
        }
        #endregion

        /*==============================================================================================================================*/

        #region Get

        /// <summary> 判断当前动画是否为所需要的 动画片段 </summary>
        public virtual bool JudgeAnimationClip(Animator animator, string animationName, int layerIndex = 0)
        {
            JudgeAnimator(animator);

            if (animator.GetCurrentAnimatorStateInfo(layerIndex).IsName(animationName)) { return true; }
            else { return false; }
        }

        /// <summary> 获取当前动画，已播放的时间 </summary>
        public virtual float GetAnimationTime(Animator animator, int layerIndex = 0)
        {
            JudgeAnimator(animator);

            float normalizedTime = animator.GetCurrentAnimatorStateInfo(layerIndex).normalizedTime;
            return normalizedTime;
        }

        /// <summary> 获取当前动画的 播放速度 </summary>
        public virtual float GetAnimationSpeed(Animator animator)
        {
            JudgeAnimator(animator);

            float speed = animator.speed;
            return speed;
        }

        #endregion

        /*==============================================================================================================================*/

        #region 其他

        /// <summary> 判定当前“Animator”是否为空 </summary>
        protected virtual void JudgeAnimator(Animator animator)
        {
            if (animator == null)
            {
                Debug.LogError("当前 Animator 为空！");
                return;
            }
        }

        #endregion
    }
}