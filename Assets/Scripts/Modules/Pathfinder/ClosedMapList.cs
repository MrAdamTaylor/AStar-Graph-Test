using System.Collections.Generic;
using LegacyCode.AStar;
using Modules.MazeGenerator.Data;

namespace Modules.Pathfinder
{
    public class ClosedMapList
    {
        private List<MazePathMarker> _closed;

        public void Add(MazePathMarker pathMarker)
        {
            if (_closed is null)
            {
                _closed = new List<MazePathMarker>();
            }
            _closed.Add(pathMarker);
        }

        public void Clear()
        {
            if (_closed is null)
            {
                return;
            }
            else
            {
                _closed.Clear();
            }
        }

        public bool IsClodes(MapLocationStruct marker)
        {
            if (_closed == null)
            {
                return false;
            }

            /*if (_closed == null)
        {
            _closed = new List<MazePathMarker>();
        }*/

            foreach (MazePathMarker path in _closed)
            {
                //TODO - надо проверить в первоисточниках, не используется ли этот метод
                if (path.location.Equals(marker))
                    return true;
            }
            return false;
        }
    
    }
}