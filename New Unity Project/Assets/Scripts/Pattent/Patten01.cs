using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PATTEN01INFO
{
    public float TweenAngle = 0f;
    public float CreateTime = 0.1f;
    public float CreateTimeCount = 0f;

    public List<BasicBullet> listMyBullet = new List<BasicBullet>();
}

public class Patten01 : IPatten
{
    List<PATTEN01INFO> infolist = new List<PATTEN01INFO>();

    private int _waveCount;
    private float _animationTime;
    private float _bulletAnimationTime;
    private float _animationAngle;

    private AnimationCurve _curve_Angle;

    private List<Tweener> _tweener = new List<Tweener>();

    public Patten01(int _waveCount, float _animationTime, float _bulletAnimationTime, float _animationAngle, AnimationCurve _curve_Angle)
    {
        this._waveCount = _waveCount;
        this._animationTime = _animationTime;
        this._bulletAnimationTime = _bulletAnimationTime;
        this._animationAngle = _animationAngle;
        this._curve_Angle = _curve_Angle;
    }

    public void OnStart()
    {
        setPatten1Info(_waveCount);

        for (int i = 0; i < infolist.Count; ++i)
        {
            setTweenAngle(i);
        }
    }

    public void OnUpdate()
    {
        for (int i = 0; i < infolist.Count; ++i)
        {
            infolist[i].CreateTimeCount += Time.deltaTime;
            if (infolist[i].CreateTimeCount >= infolist[i].CreateTime)
            {
                BasicBullet temp = BulletManager.GetInstance().GetBullet();

                temp.OnActive(infolist[i].TweenAngle, 10f, _bulletAnimationTime);

                infolist[i].listMyBullet.Add(temp);
                infolist[i].CreateTimeCount = 0f;
            }

            for (int j = 0; j < infolist[i].listMyBullet.Count; ++j)
            {
                infolist[i].listMyBullet[j].SetBulletAngleInfo(infolist[i].TweenAngle);
            }
        }

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

    void setTweenAngle(int index)
    {
        _tweener.Add(DOTween.To(() => infolist[index].TweenAngle, x => infolist[index].TweenAngle = x, infolist[index].TweenAngle + _animationAngle, _animationTime).SetEase(_curve_Angle).OnComplete(
            () =>
            {
                infolist.Clear();
            }));
    }

    void setPatten1Info(int BulletWaveCount)
    {
        float WaveStartAngle = 360f / BulletWaveCount;
        for (int i = 0; i < BulletWaveCount; ++i)
        {
            PATTEN01INFO info = new PATTEN01INFO();

            info.TweenAngle = WaveStartAngle * (i + 1);
            info.CreateTime = 0.5f;
            infolist.Add(info);
        }
    }

}
