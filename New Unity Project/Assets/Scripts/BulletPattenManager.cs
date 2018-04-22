using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletPattenManager : MonoBehaviour
{
    List<IPatten> infolist = new List<IPatten>();

    public AnimationCurve curve_Angle;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            IPatten patten = new Patten01(10, 10f, 2f, 360f, curve_Angle);
            patten.OnStart();
            infolist.Add(patten);
        }

        for (int i = infolist.Count - 1; i >= 0; --i)
        {
            // 애니메이션이 실행중인가?
            if (infolist[i].IsTweening())
            {
                infolist[i].OnUpdate();
            }
            else
            {
                infolist[i].OnEnd();
                infolist.Remove(infolist[i]);
            }
        }
    }


}
