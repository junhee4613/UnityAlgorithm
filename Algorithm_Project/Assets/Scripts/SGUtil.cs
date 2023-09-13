using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SGUtil
{
    public static readonly Vector3 VECTOT3_ZERO = Vector3.zero;
    public static readonly Vector3 VECTOT3_ONE = Vector3.one;
    public static readonly Vector3 HALF = new Vector3(0.5f, 0.5f, 0.5f);

    public static readonly Vector3 VECTOR2_ZERO = Vector2.zero;
    public static readonly Vector2 VECTOR2_ONE = Vector2.one;
    public static readonly Vector2 VECTOR2_HALF = new Vector2(0.5f, 0.5f);

    public static readonly Quaternion QUATERNION_IDENTITY = Quaternion.identity;

    public enum AXIS
    {
        X_AXIS_Y,
        X_AXIS_Z,
    }

    public enum TIME
    {
        DELTA_TIME,
        UNSCALED_DELTA_TIME,
        FIXED_DELTA_TIME,
    }

    public static float GetAngleFromTwoPosition(Transform fromTrans, Transform toTrans, AXIS axisMove)
    {
        switch (axisMove)
        {
            case AXIS.X_AXIS_Y:
                return 0;   //GetZangleFromTwoPosition(fromTrans, toTrans);
            case AXIS.X_AXIS_Z:
                return 0;   //GetYangleFromTwoPosition(fromTrans, toTrans);
            default:
                return 0;
        }
    }
    private static float GetZangleFromTwoPosition(Transform fromTrans, Transform toTrans)
    {
        if(fromTrans == null || toTrans == null)
        {
            return 0;
        }
        float xDistance = toTrans.position.x - fromTrans.position.x;                    //X축 거리
        float yDistance = toTrans.position.y - fromTrans.position.y;                    //Y축 거리
        float angle = (Mathf.Atan2(yDistance, xDistance) * Mathf.Rad2Deg) - 90.0f;      //두 Transform의 각도
        angle = GEtNormalizedAngle(angle);
        return angle;
    }
    private static float GetYangleFromTwoPosition(Transform fromTrans, Transform toTrans)
    {
        if (fromTrans == null || toTrans == null)
        {
            return 0;
        }
        float xDistance = toTrans.position.x - fromTrans.position.x;                    //X축 거리
        float yDistance = toTrans.position.y - fromTrans.position.y;                    //Y축 거리
        float angle = (Mathf.Atan2(yDistance, xDistance) * Mathf.Rad2Deg) - 90.0f;      //두 Transform의 각도
        angle = GEtNormalizedAngle(angle);
        return angle;
    }

    public static float GEtNormalizedAngle(float angle)
    {
        while(angle < 0f)
        {
            angle += 360f;
        }
        while (360f < angle)
        {
            angle -= 360f;
        }
        return angle;


    }

}
