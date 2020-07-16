/*
 * 
 * 
 * ��ע����ײʱ��������ʱ�����ص���Ч����Ч��ʵ��
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_HitReloading : MonoBehaviour
{

    /// <summary> �������λ�� </summary>
    private Vector3 _HitPosition;

    /// <summary>
    /// ��ײʱ�����ص���Դ
    /// </summary>
    private void ObtainPosition(Collision collision)
    {
        //����λ��
        _HitPosition = new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y + 0.02f, collision.contacts[0].point.z);
    }

    /// <summary>
    /// ��ȡ���������Ч����ʵ����
    /// </summary>
    protected virtual void ReloadEffects(string effectName, float destroyTime)
    {
        GameObject effect = this.gameObject.transform.Find(effectName).gameObject;

        GameObject effectClone = Instantiate(effect, _HitPosition, Quaternion.identity, effect.transform.parent);
        effectClone.SetActive(true);
        Destroy(effectClone, destroyTime);
    }

    /// <summary>
    /// ��ȡ���������Ч����ʵ����
    /// </summary>
    protected virtual void ReloadAudio(string audioName)
    {
        GameObject audio = this.gameObject.transform.Find(audioName).gameObject;
        GameObject audioClone = Instantiate(audio, audio.transform.parent);
        audioClone.GetComponent<AudioSource>().Play();
        Destroy(audioClone, audioClone.GetComponent<AudioSource>().clip.length + 1);
    }
}
