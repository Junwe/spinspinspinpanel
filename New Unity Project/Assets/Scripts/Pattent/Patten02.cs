using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Patten02 : IPatten
{

    private List<Tweener> _tweener = new List<Tweener>();

    public void OnStart()
    {
    }

    public void OnUpdate()
    {
    }

    public void OnEnd()
    {
    }

    public bool IsTweening()
    {
        for (int i = 0; i < _tweener.Count; ++i)
        {
            if (_tweener[i].IsPlaying())
                return true;
        }
        return false;
    }
}
