/* 
 * 作者：钟樾
 * 时间：2020年2月3日
 * 备注：UnityEngine.AudioSource 的常用方法汇总
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Manager
{
    public static class Manager_Audio
    {
        /// <summary> 返回音频剪辑的长度（以秒为单位） </summary>
        public static float GetAudioClipLength(UnityEngine.AudioSource audioSource)
        {
            JudgeAudioSource(audioSource);

            float clipLength = audioSource.clip.length;
            return clipLength;
        }

        /// <summary> 控制音频源的音量（0.0到1.0） </summary>
        public static void SetAudioSourceVolume(UnityEngine.AudioSource audioSource, float volumeValue)
        {
            JudgeAudioSource(audioSource);

            audioSource.volume = volumeValue;
        }

        /// <summary> 获取音频源的音量（0.0到1.0） </summary>
        public static float GetAudioSourceVolume(UnityEngine.AudioSource audioSource)
        {
            JudgeAudioSource(audioSource);

            float volume = audioSource.volume;
            return volume;
        }

        #region Other

        /// <summary> 判断是否挂载 AudioSource </summary>
        public static void JudgeAudioSource(UnityEngine.AudioSource audioSource)
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