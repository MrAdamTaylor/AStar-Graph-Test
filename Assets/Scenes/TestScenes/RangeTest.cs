using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTest : MonoBehaviour
{
    [Range(0f, 2f)] [SerializeField] private float _alghorythmBehaviour = 1f;
    [Header("1 - 5step, 2 - 10step, 3 - 20step, 4 - 25step, 5 - 50step, 6 - 100step")]
    [Range(1, 6)] [SerializeField] private int _accuracy;

    private string _alghorythmName;
    private string _secondAlghorythmName;
    private float _range;
    private float[] _percentage;

    private void Start()
    {
        BufCreater bufCreater = new BufCreater();
        _range = ChoiseAlghorythm(_alghorythmBehaviour);
        Debug.Log(_range);
        //_percentage = bufCreater.CreateBuf(_range, _accuracy);

    }

    private float ChoiseAlghorythm(float alghorythmBehaviour)
    {
        if (_alghorythmBehaviour.Equals(0f))
        {
            _alghorythmName = "GBFS";
            Debug.Log("Only GBFS");
            return 0f;
        }

        if (_alghorythmBehaviour.Equals(1f))
        {
            _alghorythmName = "AStar";
            Debug.Log("OnlyAStar");
            return 0f;
        }

        if (_alghorythmBehaviour.Equals(2f))
        {
            _alghorythmName = "Djkstra";
            Debug.Log("OnlyDjkstra");
            return 0f;
        }

        if (_alghorythmBehaviour < 1f)
        {
            if (_alghorythmBehaviour > 0.5f)
            {
                _alghorythmName = "AStar";
                _secondAlghorythmName = "GBFS";
                Debug.Log("AStar and GBFS");
                return _alghorythmBehaviour;
            }
            else
            {
                _alghorythmName = "GBFS";
                _secondAlghorythmName = "AStar";
                Debug.Log("GBFS and AStar");
                return _alghorythmBehaviour;
            }
        }
        else
        {
            if (_alghorythmBehaviour > 1.5f)
            {
                _alghorythmName = "Dijkstra";
                _secondAlghorythmName = "AStar";
                Debug.Log("Dijkstra and AStar");
                return _alghorythmBehaviour - 1f;
            }
            else
            {
                _alghorythmName = "AStar";
                _secondAlghorythmName = "Dijkstra";
                Debug.Log("AStar and Dijkstra");
                return _alghorythmBehaviour - 1f;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            MakeStep();
        }
    }

    private void MakeStep()
    {
        throw new System.NotImplementedException();
    }
}
