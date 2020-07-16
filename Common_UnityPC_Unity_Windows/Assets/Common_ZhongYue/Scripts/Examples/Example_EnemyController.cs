using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_EnemyController : MonoBehaviour
{
    [Header("Animation")]
    public EnemyState enemyAnimation = EnemyState.Idle;

    [Header("Enemy Health")]
    public int curHealth = 100;//当前生命值
    private int maxHealth = 100;//最大生命值
    private int minHealth = 0;//最小生命值

    [Header("Clone")]
    public GameObject bullet;//子弹
    public GameObject fireEffect;//枪口火焰
    public GameObject fireAudio;//开枪音效

    [Header("Cool Down")]
    public float attackTime = 7;
    public float _AttackTime;

    /// <summary>
    /// 敌人的生命值控制
    /// </summary>
    /// <param name="value"></param>
    protected virtual void AddjustCurrentHealth(int value)
    {
        curHealth += value;

        if (curHealth > maxHealth) { curHealth = maxHealth; }
        if (curHealth < minHealth) { curHealth = minHealth; }
        if (maxHealth < 1) { maxHealth = 1; }

        if (curHealth == 0)
        {
            gameObject.GetComponent<Animator>().PlayInFixedTime(EnemyState.Die.ToString(), 0, 0);

            Destroy(gameObject.GetComponent<Example_EnemyController>());
        }
    }


    protected virtual void EnemyAttack()
    {
        //生成子弹
        GameObject bulletClone = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation) as GameObject;
        bulletClone.SetActive(true);
        Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(-bullet.transform.forward * 3000);
        DestroyObject(bulletClone, 2.0f);

        //生成枪口火花
        GameObject fireEffectClone = Instantiate(fireEffect, fireEffect.transform.position, fireEffect.transform.rotation) as GameObject;
        fireEffectClone.SetActive(true);
        Destroy(fireEffectClone, 1f);

        //开枪的音效
        GameObject fireAudioClone = Instantiate(fireAudio, gameObject.transform);
        fireAudioClone.GetComponent<AudioSource>().Play();
        Destroy(fireAudioClone, fireAudioClone.GetComponent<AudioSource>().clip.length);
    }
}

public enum EnemyState
{
    Idle, Shoot, Run, Patrol, Die
}
