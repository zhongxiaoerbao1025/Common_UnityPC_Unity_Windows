/*
 * 时间：
 * 作者：钟樾
 * 备注：敲击后，生产特效及其音效示例
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Example
{
    public class Example_HitReloading : MonoBehaviour
    {
        /// <summary>  </summary>
        private Vector3 _HitPosition;

        /// <summary>  </summary>
        private void ObtainPosition(Collision collision)
        {
            //获取敲击点
            _HitPosition = new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y + 0.02f, collision.contacts[0].point.z);
        }

        /// <summary>  </summary>
        protected virtual void ReloadEffects(string effectName, float destroyTime)
        {
            //生成敲击特效
            GameObject effect = this.gameObject.transform.Find(effectName).gameObject;
            GameObject effectClone = Instantiate(effect, _HitPosition, Quaternion.identity, effect.transform.parent);
            effectClone.SetActive(true);
            //销毁特效
            Destroy(effectClone, destroyTime);
        }

        /// <summary>  </summary>
        protected virtual void ReloadAudio(string audioName)
        {
            //生成敲击音效
            GameObject audio = this.gameObject.transform.Find(audioName).gameObject;
            GameObject audioClone = Instantiate(audio, audio.transform.parent);
            audioClone.GetComponent<AudioSource>().Play();
            //销毁敲击音效
            Destroy(audioClone, audioClone.GetComponent<AudioSource>().clip.length + 1);
        }
    }
}