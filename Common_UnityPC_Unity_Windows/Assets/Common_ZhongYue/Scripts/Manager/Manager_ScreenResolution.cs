using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_ScreenResolution : MonoBehaviour
{
    #region ��Ļ�ֱ���

    protected static Resolution[] resolutions;
    protected static int[] currentResolution;

    /// <summary>
    /// ��ʾ��֧�ֵ�����ȫ���ֱ��ʣ�ֻ����
    /// [0]-��,[1]-��
    /// </summary>
    /// <returns></returns>
    public static Resolution[] ReturnAllResolution()
    {
        resolutions = UnityEngine.Screen.resolutions;
        return resolutions;
    }

    /// <summary>
    /// �л���Ļ�ֱ���
    /// </summary>
    public static void SwitchesResolution(int width, int height, bool fullscreen = true, int preferredRefreshRate = 60)
    {
        UnityEngine.Screen.SetResolution(width, height, fullscreen, preferredRefreshRate);
    }

    /// <summary>
    /// ��ǰ��Ļ�ֱ��ʣ�ֻ����
    /// ����������ڴ���ģʽ�����У��򷵻�����ĵ�ǰ�ֱ��ʡ�
    /// ʹ��VR�豸ʱ��Ӧʹ��VRSettings.eyeTextureWidth��VRSettings.eyeTextureHeight���������
    /// </summary>
    public static int[] ReturnCurrentResolution()
    {
        currentResolution = new int[2];
        currentResolution[0] = UnityEngine.Screen.currentResolution.width;
        currentResolution[1] = UnityEngine.Screen.currentResolution.height;
        //Debug.Log(currentResolution[0] + "*" + currentResolution[1]);
        return currentResolution;
    }

    #endregion
}
