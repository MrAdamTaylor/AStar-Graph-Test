using System.Collections.Generic;

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
}