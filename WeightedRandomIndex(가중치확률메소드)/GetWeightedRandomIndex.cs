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

            Debug.Log((index + 1) + "Ƽ�� �����Դϴ� !");
        }
    }

    public static int GetWeightedRandomIndex(params float[] pers)//Ȯ���� ���ʴ��(���� 1�̵Ǵ°��� ����) �־��� �� �ش��ϴ� Ȯ���� �ɸ��� 01234�� ���ʷ� ����.
    {
        int maxLenth = 0;

        if (pers.Length == 1)//�迭���̰� 1�̸� ������ �� ���� ���;������� 0�� �����Ѵ�.
            return 0;

        //1.���� �Ҽ����� �� ������ ã�Ƴ���.
        int lenth;
        decimal total = 0;
        for (int i = 0; i < pers.Length; i++)
        {
            lenth = pers[i].ToString().Substring(pers[i].ToString().IndexOf('.') + 1).Length;

            total += (decimal)pers[i];
            if (maxLenth < lenth)
                maxLenth = lenth;
        }

        int correction = (int)(total * (decimal)Math.Pow(10, maxLenth)); //-> �����ִ� �� 

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
