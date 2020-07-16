/*
 * 
 * 
 * 备注：碰撞时（被击打时）加载的音效、特效等实例
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_HitReloading : MonoBehaviour
{

    /// <summary> 被击打的位置 </summary>
    private Vector3 _HitPosition;

    /// <summary>
    /// 碰撞时，加载的资源
    /// </summary>
    private void ObtainPosition(Collision collision)
    {
        //击打位置
        _HitPosition = new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y + 0.02f, collision.contacts[0].point.z);
    }

    /// <summary>
    /// 获取被击打的特效，并实例化
    /// </summary>
    protected virtual void ReloadEffects(string effectName, float destroyTime)
    {
        GameObject effect = this.gameObject.transform.Find(effectName).gameObject;

        GameObject effectClone = Instantiate(effect, _HitPosition, Quaternion.identity, effect.transform.parent);
        effectClone.SetActive(true);
        Destroy(effectClone, destroyTime);
    }

    /// <summary>
    /// 获取被击打的音效，并实例化
    /// </summary>
    protected virtual void ReloadAudio(string audioName)
    {
        GameObject audio = this.gameObject.transform.Find(audioName).gameObject;
        GameObject audioClone = Instantiate(audio, audio.transform.parent);
        audioClone.GetComponent<AudioSource>().Play();
        Destroy(audioClone, audioClone.GetComponent<AudioSource>().clip.length + 1);
    }
}
