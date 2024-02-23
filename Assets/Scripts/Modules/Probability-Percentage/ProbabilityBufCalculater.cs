using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProbabilityBufCalculater
{
    private float[] _percentageBuf;
    private float _total;
    
    public void Construct(float[] percentagesValuesBuf)
    {
        _percentageBuf = percentagesValuesBuf;
        GetTotalPercentage(_percentageBuf);
    }

    private void GetTotalPercentage(float[] percentageBuf)
    {
        for (int i = 0; i < percentageBuf.Length; i++)
        {
            _total += percentageBuf[i];
        }
    }

    public int GetRandomValue(int[] objects)
    {
        if (!CheckBuffs(objects))
            throw new Exception("Размер буфера процентов не соответствует размеру массива элементов");
        
        float random = Random.Range(ProbabilityConstants.MinRange, ProbabilityConstants.MaxRange);
        float numForAdding = 0;
        
        for (int i = 0; i < objects.Length; i++)
        {
            if (_percentageBuf[i] / _total + numForAdding >= random)
            {
                return i;
            }
            else
            {
                numForAdding += _percentageBuf[i]/ _total;
            }
        }
        return 0;
    }
    
    public int GetRandomValue(string[] objects)
    {
        if (!CheckBuffs(objects))
            throw new Exception("Размер буфера процентов не соответствует размеру массива элементов");
        
        float random = Random.Range(ProbabilityConstants.MinRange, ProbabilityConstants.MaxRange);
        float numForAdding = 0;
        
        for (int i = 0; i < objects.Length; i++)
        {
            if (_percentageBuf[i] / _total + numForAdding >= random)
            {
                return i;
            }
            else
            {
                numForAdding += _percentageBuf[i]/ _total;
            }
        }
        return 0;
    }

    private bool CheckBuffs(int[] objects)
    {
        if (objects.Length == _percentageBuf.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private bool CheckBuffs(string[] objects)
    {
        if (objects.Length == _percentageBuf.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

public class BufCreater
{
    public int[] CreateBuf(float range, int accuracy, int count=2)
    {
        int[] buf = new int[count];

        for (int i = 0; i < buf.Length; i++)
        {
            if (i == 1)
            {
                float temp = (1 - range) * accuracy;
                //buf[i] = 
                //Mathf.CeilToInt(buf[i]);

                buf[i] = Mathf.CeilToInt(temp);
            }
            else
            {
                //buf[i] = range * accuracy;
                float temp = range * accuracy;
                buf[i] = Mathf.CeilToInt(temp);

            }
        }
        return buf;
    }
}