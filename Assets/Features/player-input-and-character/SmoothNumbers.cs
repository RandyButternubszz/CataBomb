using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveTowards<T>
{ T MoveTowards(T current, T target, float maxDelta); }
public class FloatMoveTowards : IMoveTowards<float>
{
    public float MoveTowards(float current, float target, float maxDelta) 
        => Mathf.MoveTowards(current, target, maxDelta);
}
public class Vector2MoveTowards : IMoveTowards<Vector2>
{
    public Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDelta) 
        => Vector2.MoveTowards(current, target, maxDelta);
}
public class Vector3MoveTowards : IMoveTowards<Vector3>
{
    public Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDelta) 
        => Vector3.MoveTowards(current, target, maxDelta);
}

public class SmoothNumbers<T>
{
    public T CurrentNum { get; private set; }
    public T DesiredNum { get; set; }

    private float _movementPerSecond;
    private IMoveTowards<T> _moveTowards;

    public Func<float, T> UpdateNum;

    public SmoothNumbers(T numToStart, float speed, IMoveTowards<T> moveTowards)
    {
        CurrentNum = numToStart;
        DesiredNum = numToStart;
        _movementPerSecond = speed;
        _moveTowards = moveTowards;
        UpdateNum = (timeDelta) => CurrentNum = _moveTowards.MoveTowards(CurrentNum, DesiredNum, _movementPerSecond * timeDelta);
    }
}
