using System.Collections.Generic;
using System.Linq;
using LegacyCode.AStar;
using Modules.MazeGenerator.Data;
using UnityEngine;

namespace Modules.Pathfinder
{
    public class OpenMapList
    {
        private List<MazePathMarker> _open;

        public void Add(MazePathMarker pathMarker)
        {
            if (_open is null)
            {
                _open = new List<MazePathMarker>();
            }
            _open.Add(pathMarker);
        }
    
        public void Clear()
        {
            if (_open is null)
            {
                return;
            }
            else
            {
                _open.Clear();
            }
        }

        public bool IsOpen(MapLocationStruct intermediatePos)
        {
            foreach (MazePathMarker path in _open)
            {
                //TODO - надо проверить в первоисточниках, не используется ли этот метод
                if (path.location.Equals(intermediatePos))
                    return true;
            }
            return false;
        }

        public void RemoveByPos(Vector3 intermediatePos)
        {
            for (int i = 0; i < _open.Count; i++)
            {
                if (intermediatePos == _open[i].marker.transform.position)
                {
                    _open.RemoveAt(i);
                }
            }
        }

        public bool CheckByUpdate(MapLocationStruct pos, PathScores getScoresDataAStar, MazePathMarker thisNode)
        {
            for (int i = 0; i < _open.Count; i++)
            {
                if (_open[i].location.Equals(pos))
                {
                    _open[i].G = getScoresDataAStar.GScore;
                    _open[i].H = getScoresDataAStar.HScore;
                    _open[i].F = getScoresDataAStar.FScore;
                    _open[i].parent = thisNode;
                    return true;
                }
            }
            return false;
        }

        public MazePathMarker GetBestElement()
        {
            _open = _open.OrderBy(p => p.F).ToList();
            MazePathMarker pathMarker = _open.ElementAt(0);
            return pathMarker;
        }

        public void RemoveFirstElement()
        {
            _open.RemoveAt(0);
        }
    }
}