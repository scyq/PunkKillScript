using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Utils
{
    public static Color GetRandomLightColor()
    {
        float[] RGB = new float[3];
        int zeroIndex = Random.Range(0, 3);
        int maxIndex = zeroIndex;
        while (maxIndex != zeroIndex)
            maxIndex = Random.Range(0, 3);
        RGB[zeroIndex] = 0;
        RGB[maxIndex] = 1;
        
        // 位运算，得到剩下随机的那一位
        int nowCondition = 1 << zeroIndex | 1 << maxIndex;
        int lastCondition = nowCondition ^ 7;

        int randomIndex = -1;
        while (lastCondition > 0)
        {
            lastCondition = lastCondition >> 1;
            randomIndex++;
        }

        RGB[randomIndex] = Random.Range(0f, 1f);
        
        Color color = new Color(RGB[0], RGB[1], RGB[2]);
        // Debug.Log(color);
        
        return color;
    }
}
