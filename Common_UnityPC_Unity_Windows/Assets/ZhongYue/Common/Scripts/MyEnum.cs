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

    /// <summary> 场景名字 </summary>
    public enum ScenesName
    {
        Level_A1_Load,
        Level_A2_Error,
        Level_B1_Connect,
        Level_B2_Start,
        Level_B3_Login,
        Level_C1_Main
    }
}
