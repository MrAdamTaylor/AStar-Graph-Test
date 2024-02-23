using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}

public class BufCreater
{
    public float[] CreateBuf(float range, int accuracy)
    {
        throw new System.NotImplementedException();
    }
}


public static class ProbabilityConstants
{
    public const float MinRange = 0f;
    public const float ManRange = 1f;
}


