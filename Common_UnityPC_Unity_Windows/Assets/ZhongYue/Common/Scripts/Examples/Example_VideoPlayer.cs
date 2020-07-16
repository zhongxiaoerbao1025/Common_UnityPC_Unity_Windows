/* 
 * 作者：钟樾
 * 时间：2020年2月3日
 * 备注：UnityEngine.Video.VideoPlayer 的常用方法汇总
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace ZhongYue.Example
{
    public class Example_VideoPlayer
    {
        #region 
        /// <summary> VideoPlayer 切换“VideoClip”后，第一次进行播放 </summary>
        public virtual void VideoPlayStart(UnityEngine.Video.VideoPlayer videoPlayer, UnityEngine.Video.VideoClip videoClip)
        {
            JudgeVideoPlayer(videoPlayer);

            videoPlayer.clip = videoClip;
            videoPlayer.Play();

            //动态切换 VideoClip 后，VideoPlayer 容易丢失 AudioSource，此举是动态赋予 AudioSource
            if (videoPlayer.GetComponent<AudioSource>() == null) { videoPlayer.gameObject.AddComponent<AudioSource>(); }
            videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
            videoPlayer.SetTargetAudioSource(0, videoPlayer.GetComponent<AudioSource>());
        }

        /// <summary> 视频进行暂停（或时间轴改变等）后，再次进行播放 </summary>
        public virtual void VideoPlayAfterPause(UnityEngine.Video.VideoPlayer videoPlayer)
        {
            JudgeVideoPlayer(videoPlayer);

            videoPlayer.Play();
        }

        /// <summary> 暂停视频播放 </summary>
        public virtual void VideoPause(UnityEngine.Video.VideoPlayer videoPlayer)
        {
            JudgeVideoPlayer(videoPlayer);

            if (videoPlayer.isPlaying) { videoPlayer.Pause(); }
        }

        /// <summary> 停止播放视频 </summary>
        public virtual void VideoStop(UnityEngine.Video.VideoPlayer videoPlayer)
        {
            JudgeVideoPlayer(videoPlayer);

            if (videoPlayer.isPlaying) { videoPlayer.Stop(); }
        }


        #endregion

        #region Get
        /// <summary> 获取视频播放的进度时间 </summary>
        public virtual float GetCurrentTime(UnityEngine.Video.VideoPlayer videoPlayer)
        {
            JudgeVideoPlayer(videoPlayer);

            float videoTime = videoPlayer.frame;
            return videoTime;
        }

        /// <summary> 获取当前视频，是否播放完毕 </summary>
        public virtual bool GetVideoDone(UnityEngine.Video.VideoPlayer videoPlayer)
        {
            JudgeVideoPlayer(videoPlayer);

            if (videoPlayer.frame >= videoPlayer.length) { return true; }
            else { return false; }
        }
        #endregion

        #region Other

        /// <summary> 判断是否挂载 VideoPlayer </summary>
        public virtual void JudgeVideoPlayer(UnityEngine.Video.VideoPlayer videoPlayer)
        {
            if (videoPlayer == null)
            {
                Debug.LogError("当前 VideoPlayer 为空");
                return;
            }
        }

        #endregion
    }
}