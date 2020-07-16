using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Collision : MonoBehaviour
{
    /// <summary> �������λ�� </summary>
    protected UnityEngine.Vector3 _HitPosition;

    public virtual void ObtainPosition(Collision collision)
    {
        //����λ��
        _HitPosition = new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y + 0.02f, collision.contacts[0].point.z);
    }

    /// <summary>
    /// ��ȡ������ʱ����Ч����ʵ����
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
    /// ��ȡ������ʱ����Ч����ʵ����
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
