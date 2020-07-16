using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZhongYue.Example
{
    public class Example_Audio
    {
        /// <summary> 返回音频剪辑的长度（以秒为单位） </summary>
        public virtual float GetAudioClipLength(UnityEngine.AudioSource audioSource)
        {
            JudgeAudioSource(audioSource);

            float clipLength = audioSource.clip.length;
            return clipLength;
        }

        /// <summary> 控制音频源的音量（0.0到1.0） </summary>
        public virtual void SetAudioSourceVolume(UnityEngine.AudioSource audioSource, float volumeValue)
        {
            JudgeAudioSource(audioSource);

            audioSource.volume = volumeValue;
        }

        /// <summary> 获取音频源的音量（0.0到1.0） </summary>
        public virtual float GetAudioSourceVolume(UnityEngine.AudioSource audioSource)
        {
            JudgeAudioSource(audioSource);

            float volume = audioSource.volume;
            return volume;
        }

        #region Other

        /// <summary> 判断是否挂载 AudioSource </summary>
        public virtual void JudgeAudioSource(UnityEngine.AudioSource audioSource)
        {
            if (audioSource == null)
            {
                Debug.LogError("当前 AudioSource 为空");
                return;
            }
        }

        #endregion
    }
}