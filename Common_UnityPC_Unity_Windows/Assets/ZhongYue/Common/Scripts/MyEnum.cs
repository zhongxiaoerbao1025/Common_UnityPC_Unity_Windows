/*
 * 作者：钟樾
 * 时间：2020年2月3日
 * 备注：枚举
 */

public class MyEnum
{
    /// <summary> 敌人的状态 </summary>
    public enum EnemyState
    {
        Idle, Shoot, Run, Patrol, Die
    }

    /// <summary> 场景类型 </summary>
    public enum ScenesType
    {
        Loading, Error, Connect, Start, Login,
        None
    }
}
