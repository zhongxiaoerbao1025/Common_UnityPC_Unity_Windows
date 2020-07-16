using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Collision : MonoBehaviour
{
    /// <summary> 被击打的位置 </summary>
    protected UnityEngine.Vector3 _HitPosition;

    public virtual void ObtainPosition(Collision collision)
    {
        //击打位置
        _HitPosition = new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y + 0.02f, collision.contacts[0].point.z);
    }

    /// <summary>
    /// 获取被击打时的特效，并实例化
    /// </summary>
    /// <param name="effectName"></param>
    /// <param name="destroyTime"></param>
    public virtual void ReloadEffects(string effectName, float destroyTime)
    {
        GameObject effect = this.gameObject.transform.Find(effectName).gameObject;

        GameObject effectClone = Instantiate(effect, _HitPosition, Quaternion.identity, effect.transform.parent);
        effectClone.SetActive(true);

        Destroy(effectClone, destroyTime);
    }

    /// <summary>
    /// 获取被击打时的音效，并实例化
    /// </summary>
    /// <param name="audioName"></param>
    public virtual void ReloadAudio(string audioName)
    {
        GameObject audio = this.gameObject.transform.Find(audioName).gameObject;
        GameObject audioClone = Instantiate(audio, audio.transform.parent);
        audioClone.GetComponent<AudioSource>().Play();

        Destroy(audioClone, audioClone.GetComponent<AudioSource>().clip.length + 1);
    }

    #region Collision
    protected virtual void OnCollisionEnter(Collision collision) { }

    protected virtual void OnCollisionStay(Collision collision) { }

    protected virtual void OnCollisionExit(Collision collision){ }

    protected virtual void OnParticleCollision(GameObject other) { }

    protected virtual void OnCollisionEnter2D(Collision2D collision) { }

    protected virtual void OnCollisionStay2D(Collision2D collision) { }

    protected virtual void OnCollisionExit2D(Collision2D collision) { }

    protected virtual void OnControllerColliderHit(ControllerColliderHit hit) { }
    #endregion

}
