using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTest : MonoBehaviour
{
    [Range(0f, 2f)] [SerializeField] private float _alghorythmBehaviour = 1f;
    [Header("1 - 5step, 2 - 10step, 3 - 20step, 4 - 25step, 5 - 50step, 6 - 100step")]
    [Range(1, 6)] [SerializeField] private int _accuracy = 1;

    private string _alghorythmName;
    private string _secondAlghorythmName;

    private string[] _alghorythms;

    private float _range;
    private int[] _percentage;

    private int pointOne = 0;
    private int pointTwo = 0;

    private ProbabilityBufCalculater _probability;

    private void Start()
    {
        _alghorythms = new string[2];
        BufCreater bufCreater = new BufCreater();
        _range = ChoiseAlghorythm(_alghorythmBehaviour);
        Debug.Log("Alghorythm Range: " + _range);
        _percentage = bufCreater.CreateBuf(_range, AccuracyInterpretator(_accuracy));
        for (int i = 0; i < _percentage.Length; i++)
        {
            Debug.Log($"Buf{i+1} - {_percentage[i]}");
        }
        _probability = new ProbabilityBufCalculater();
        _probability.Construct(_percentage.ToFloat());
    }

    private int AccuracyInterpretator(int range)
    {
        int value = 0;
        switch (range)
        {
            case 1:
                value = 5;
                break;
            case 2:
                value = 10;
                break;
            case 3:
                value = 20;
                break;
            case 4:
                value = 25;
                break;
            case 5:
                value = 50;
                break;
            case 6:
                value = 100;
                break;
        }
        return value;
    }

    private float ChoiseAlghorythm(float alghorythmBehaviour)
    {
        if (_alghorythmBehaviour.Equals(0f))
        {
            _alghorythmName = "Dijkstra";
            Debug.Log("Only Dijkstra");
            _alghorythms[0] = _alghorythmName; 
            return 0f;
        }

        if (_alghorythmBehaviour.Equals(1f))
        {
            _alghorythmName = "AStar";
            Debug.Log("OnlyAStar");
            _alghorythms[0] = _alghorythmName; 
            return 0f;
        }

        if (_alghorythmBehaviour.Equals(2f))
        {
            _alghorythmName = "GBFS";
            Debug.Log("OnlyGBFS");
            _alghorythms[0] = _alghorythmName; 
            return 0f;
        }

        if (_alghorythmBehaviour < 1f)
        {
            if (_alghorythmBehaviour > 0.5f)
            {
                _alghorythmName = "AStar";
                _secondAlghorythmName = "Dijkstra";
                Debug.Log("AStar and Dijkstra");
                _alghorythms[0] = _alghorythmName; 
                _alghorythms[1] = _secondAlghorythmName; 
                return _alghorythmBehaviour;
            }
            else
            {
                _alghorythmName = "Dijkstra";
                _secondAlghorythmName = "AStar";
                Debug.Log("Dijkstra and AStar");
                _alghorythms[0] = _alghorythmName; 
                _alghorythms[1] = _secondAlghorythmName; 
                return _alghorythmBehaviour;
            }
        }
        else
        {
            if (_alghorythmBehaviour > 1.5f)
            {
                _alghorythmName = "GBFS";
                _secondAlghorythmName = "AStar";
                Debug.Log("GBFS and AStar");
                _alghorythms[0] = _alghorythmName; 
                _alghorythms[1] = _secondAlghorythmName; 
                return _alghorythmBehaviour - 1f;
            }
            else
            {
                _alghorythmName = "GBFS";
                _secondAlghorythmName = "AStar";
                Debug.Log("AStar and GBFS");
                _alghorythms[0] = _alghorythmName; 
                _alghorythms[1] = _secondAlghorythmName; 
                return _alghorythmBehaviour - 1;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(_alghorythms[1] != null)
                MakeProbabilityStep();
            else
            {
                MakeUsualStep();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log($"Очки: Главный алгоритм: Очки: {pointOne} Название: {_alghorythms[0]} и второстепенный алгоритм Очки: {pointTwo} Название: {_alghorythms[1]}");
        }
    }

    private void MakeUsualStep()
    {
        Debug.Log(_alghorythms[0]);
    }

    private void MakeProbabilityStep()
    {
        int value = _probability.GetRandomValue(_alghorythms);
        Debug.Log(_alghorythms[value]);

        if (value == 0)
        {
            pointOne++;
        }

        if (value == 1)
        {
            pointTwo++;
        }
    }
}


