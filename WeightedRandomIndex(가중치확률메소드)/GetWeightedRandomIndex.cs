using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeightedRandomIndex : MonoBehaviour
{
    public void Awake()
    {
        for (int i = 0; i < 10000; i++)
        {
            int index = GetWeightedRandomIndex(0.15f, 0.2f, 0.35f, 0.25f, 0.05f);

            Debug.Log((index + 1) + "티어 유닛입니다 !");
        }
    }

    public static int GetWeightedRandomIndex(params float[] pers)//확률을 차례대로(합이 1이되는것을 권장) 넣었을 때 해당하는 확률이 걸리면 01234가 차례로 나옴.
    {
        int maxLenth = 0;

        if (pers.Length == 1)//배열길이가 1이면 무조건 그 값이 나와야함으로 0을 리턴한다.
            return 0;

        //1.가장 소숫점이 긴 변수를 찾아낸다.
        int lenth;
        decimal total = 0;
        for (int i = 0; i < pers.Length; i++)
        {
            lenth = pers[i].ToString().Substring(pers[i].ToString().IndexOf('.') + 1).Length;

            total += (decimal)pers[i];
            if (maxLenth < lenth)
                maxLenth = lenth;
        }

        int correction = (int)(total * (decimal)Math.Pow(10, maxLenth)); //-> 곱해주는 수 

        int randomNumber = UnityEngine.Random.Range(1, correction + 1);
        int tempNum = 0;
        int num = 0;
        for (int i = 0; i < pers.Length; i++)
        {
            num = (int)(correction * (decimal)pers[i]);
            if (num + tempNum >= randomNumber)
            {
                //Debug.Log(num + tempNum + ">=" + randomNumber);
                return i;
            }
            tempNum += num;
        }
        return 0;
    }
}
