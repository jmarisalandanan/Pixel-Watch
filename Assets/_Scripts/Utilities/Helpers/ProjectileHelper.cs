using UnityEngine;
using System.Collections;

public static class ProjectileHelper
{
    #region CONE_FIRING
    public static Quaternion GetRandomConeRotation(Vector2 pitch, Vector2 yaw)
    {
        Quaternion coneRandomRotation = Quaternion.Euler(Random.Range(pitch.x, pitch.y), Random.Range(yaw.x, yaw.y), Random.Range(pitch.x, pitch.y));
        return coneRandomRotation;
    }
    #endregion

    #region SWARM_FIRING
    public static float SwarmingAngleUpdate(Vector3 origin, Vector3 target, float motionRandomness = 1)
    {
        float perlinRand = Mathf.PerlinNoise(origin.x * motionRandomness, origin.y * motionRandomness);
        //To include z calculation in 3d space, if using 2d, comment out
        perlinRand = Mathf.PerlinNoise(perlinRand, origin.z * motionRandomness);
        float swarmAngle = Mathf.Lerp(perlinRand, -30, 30);
        return swarmAngle;
    }

    #endregion

    #region INTERCEPT_LOB

    public static Vector3 GetInterceptLobVelocity(Vector3 target, Vector3 origin, Vector3 targetVelocity, float projectileSpeed)
    {
        Vector3 interceptPosition = Intercept(origin, Vector3.zero, projectileSpeed, target, targetVelocity);
        return CalculateProjectileVelocity(interceptPosition, origin);
    }

    public static Vector3 CalculateProjectileVelocity(Vector3 target, Vector3 position)
    {
        Vector3 dir = target - position;
        float height = dir.y;
        dir.y = 0;
        float distance = dir.magnitude;
        dir.y = distance;
        distance += height;
        float velocity = Mathf.Sqrt(distance * (Physics.gravity.magnitude));
        return velocity * dir.normalized;
    }

    public static Vector3 Intercept(Vector3 shooterPosition, Vector3 shooterVelocity, float shotSpeed, Vector3 targetPosition, Vector3 targetVelocity)
    {
        Vector3 targetRelativePosition = targetPosition - shooterPosition;
        Vector3 targetRelativeVelocity = targetVelocity - shooterVelocity;
        float t = InterceptTime(shotSpeed, targetRelativePosition, targetRelativeVelocity);
        return targetPosition + t * (targetRelativeVelocity);
    }

    public static float InterceptTime(float shotSpeed, Vector3 targetRelativePosition, Vector3 targetRelativeVelocity)
    {
        float velocitySquared = targetRelativeVelocity.sqrMagnitude;
        if (velocitySquared < 0.001f)
            return 0f;

        float a = velocitySquared - shotSpeed * shotSpeed;

        if (Mathf.Abs(a) < 0.001f)
        {
            float t = -targetRelativePosition.sqrMagnitude / (2f * Vector3.Dot(targetRelativeVelocity, targetRelativePosition));
            return Mathf.Max(t, 0f);
        }

        float b = 2f * Vector3.Dot(targetRelativeVelocity, targetRelativePosition);
        float c = targetRelativePosition.sqrMagnitude;
        float determinant = b * b - 4f * a * c;

        if (determinant > 0f)
        {
            float t1 = (-b + Mathf.Sqrt(determinant)) / (2f * a),
            t2 = (-b - Mathf.Sqrt(determinant)) / (2f * a);
            if (t1 > 0f)
            {
                if (t2 > 0f)
                    return Mathf.Min(t1, t2);
                else
                    return t1;
            }
            else
                return Mathf.Max(t2, 0f);
        }
        else if (determinant < 0f)
            return 0f;
        else
            return Mathf.Max(-b / (2f * a), 0f);
    }

    #endregion
}