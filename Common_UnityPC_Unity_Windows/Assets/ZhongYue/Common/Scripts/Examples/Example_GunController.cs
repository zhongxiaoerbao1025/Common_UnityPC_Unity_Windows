/*
 * 时间：
 * 作者：
 * 备注：
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Example
{
    public class Example_GunController : MonoBehaviour
    {
        [Header("Bullet")]
        public int m_BulletIndex = 7;//子弹数
        public int m_MagazineIndex = 0;//弹匣数
        private GameObject m_Bullet;//子弹
        private float _BulletSpeed = 8000;//子弹速度
        private float _BulletLife = 5f;//子弹生命周期
        private bool _IsReload = false;//是否在换弹

        [Header("UI")]
        public UnityEngine.UI.Image _ResetBulletSlider;//更换弹匣的滑动UI

        private GameObject _BulletHitEffects;//子弹击中特效

        [Header("Audio Source")]
        public AudioClip[] _AudioClips;
        private AudioSource _AudioSource;


        private GameObject _Bullet;
        private GameObject _FireEffect;
        private GameObject _FireAudio;


        protected virtual IEnumerator FireBullet()
        {
            //如果当前子弹数大于0，实例化子弹并发射出去
            if (m_BulletIndex != 0)
            {
                //实例化火花并显示
                GameObject fireEffectClone = Instantiate(_FireEffect, _FireEffect.transform.position, _FireEffect.transform.rotation) as GameObject;
                fireEffectClone.SetActive(true);
                Destroy(fireEffectClone, 1.0f);

                //实例化开枪音效并播放
                _FireAudio.GetComponent<AudioSource>().clip = _AudioClips[0];
                GameObject fireAudioClone = Instantiate(_FireAudio, gameObject.transform) as GameObject;
                fireAudioClone.GetComponent<AudioSource>().Play();
                Destroy(fireAudioClone, fireAudioClone.GetComponent<AudioSource>().clip.length);

                //减少子弹
                m_BulletIndex--;

                //实例化子弹并显示
                GameObject bulletClone = Instantiate(m_Bullet, m_Bullet.transform.position, m_Bullet.transform.rotation) as GameObject;
                bulletClone.SetActive(true);
                //取消子弹重力
                Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
                rb.useGravity = false;
                //发射子弹
                rb.AddForce(-m_Bullet.transform.forward * _BulletSpeed);
                //销毁子弹
                Destroy(bulletClone, _BulletLife);
            }
            //当前子弹为0时，开枪触发空枪音效，并触发换弹夹动画，不可开枪
            else
            {
                //空枪音效
                _FireAudio.GetComponent<AudioSource>().clip = _AudioClips[1];
                GameObject fireAudioClone = Instantiate(_FireAudio, gameObject.transform) as GameObject;
                fireAudioClone.GetComponent<AudioSource>().Play();
                Destroy(fireAudioClone, fireAudioClone.GetComponent<AudioSource>().clip.length);

                yield return new WaitForSeconds(_AudioSource.clip.length);
                _IsReload = true;
                _ResetBulletSlider.fillAmount = 0;
                _ResetBulletSlider.transform.parent.gameObject.SetActive(true);
                gameObject.transform.Find("gun/sta_pistol02").GetComponent<Animator>().Play("Take 001");
                //换弹音效
                _AudioSource.clip = _AudioClips[2];
                _AudioSource.Play();


                yield return new WaitForEndOfFrame();
                yield return new WaitForEndOfFrame();
                while (gameObject.transform.Find("gun/sta_pistol02").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 0.99f)
                {
                    yield return new WaitForEndOfFrame();
                }

                _IsReload = false;
                m_BulletIndex = 6;
                m_MagazineIndex++;
                _ResetBulletSlider.transform.parent.gameObject.SetActive(false);

            }
        }
    }
}