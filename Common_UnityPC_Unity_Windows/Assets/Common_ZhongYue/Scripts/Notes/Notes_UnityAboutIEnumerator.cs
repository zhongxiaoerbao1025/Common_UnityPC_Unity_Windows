/// <summary>
///	作者：钟樾
///	时间：#CreatTime#
///	备注：Unity中协程(IEnumerator)的使用方法介绍
///	</summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhongYue
{
    public class Notes_UnityAboutIEnumerator : MonoBehaviour
    {
        /*知识点：协程
         * 1.Unity中的协程，可以通过yield特殊属性，在任何位置、时刻暂停；也可以在指定的事件或事件后继续执行
         * 2.通过StartCoroutine()函数，调用协程函数
         * 3.调用协程的方法：a.StartCoroutine(|这里直接调用方法，添加参数|);b.StartCoroutine(|这里填写“字符串的方法名”,方法参数|)
         * 4.区别：方法1可以调用多个参数的方法；
         *        方法2只能调用不含参数或含一个参数的协程方法；
         *        方法1不能通过StopCoroutine结束协程，只能使用StopAllCoroutines()；
         *        方法2可以通过StopCoroutine(/这里填写”字符串的方法名”/)来结束协程
         * 5.协程在实现过程中，需要注意yield调用的时机，执行较为复杂的计算时，如果在时间上没有严格的先后顺序，可以每帧执行一次循环完成计算，或每帧执行指定次数的循环来防止运行中出现卡顿
         * 6.某个脚本在执行时，将脚本的enable设置为false，协程不会停止，需要将挂载脚本的物体SetActive(false)才会停止；再次设置为true，协程不会再启动
         */

        private AsyncOperation asyncOperation;

        /*
                private IEnumerator YieldReturn()
                {
                    yield return null; // 协程将在下一帧所有脚本的Update执行之后,再继续执行.
                    yield return 0; //下一帧再执行后续代码
                    yield return 6;//(任意数字) 下一帧再执行后续代码
                    yield return asyncOperation;//等异步操作结束后再执行后续代码
                    yield return StartCoroution(某个协程);//等待某个协程执行完毕后再执行后续代码
                    yield return WWW();//等待WWW操作完成后再执行后续代码
                    yield return new WaitForEndOfFrame();//等待帧结束,等待直到所有的摄像机和GUI被渲染完成后，在该帧显示在屏幕之前执行
                    yield return new WaitForSeconds(0.3f);//等待0.3秒，一段指定的时间延迟之后继续执行，在所有的Update函数完成调用的那一帧之后（这里的时间会受到Time.timeScale的影响）;
                    yield return new WaitForSecondsRealtime(0.3f);//等待0.3秒，一段指定的时间延迟之后继续执行，在所有的Update函数完成调用的那一帧之后（这里的时间不受到Time.timeScale的影响）;
                    yield return new WaitForFixedUpdate();//等待下一次FixedUpdate开始时再执行后续代码
                    yield return new WaitUntil();//将协同执行直到 当输入的参数（或者委托）为true的时候....如:yield return new WaitUntil(() => frame >= 10)
                    yield return new WaitWhile();//将协同执行直到 当输入的参数（或者委托）为false的时候.... 如:yield return new WaitWhile(() => frame < 10);
                    yield break; //直接结束该协程的后续操作

                }
                */
    }
}