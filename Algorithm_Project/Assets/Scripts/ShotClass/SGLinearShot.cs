using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGLinearShot : SGBaseShot
{
    public float angle = 180.0f;
    public float betweenDelay = 0.1f;
    private int nowIndex;
    private float delayTimer;
    public override void Shot()
    {
        if (projectileNum <= 0 || projectileSpeed <= 0)     //옵션값검사
        {
            return;
        }
        if (_shooting)
        {
            return;
        }
        _shooting = true;
        nowIndex = 0;
        delayTimer = 0;
    }
    protected virtual void Update()
    {
        if (_shooting == false)
        {
            return;
        }
        delayTimer -= SGTimer.Instance.deltaTime;
        while (delayTimer < 0)             //총알 딜레이가 다 될경우
        {
            SGProjectile projectile = GetProjectile(transform.position);
            if (projectile == null)
            {
                break;
            }



            ShotProjectile(projectile, projectileSpeed, angle);

            projectile.UpdateMove(-delayTimer);
            nowIndex++;

            if (nowIndex >= projectileNum)
            {
                FinishedShot();
                return;
            }
            delayTimer += betweenDelay;
        }


        
    }
    public float GetShiftedAngle(int wayIndex, float baseAngle, float betweenAngle)
    {
        float angle = wayIndex % 2 == 0 ?
            baseAngle - (betweenAngle * (float)wayIndex / 2f) :
            baseAngle + (betweenAngle * Mathf.Ceil((float)wayIndex / 2f));

        return angle;
    }
}
