
using UnityEngine;

public sealed class Singleton
{
    private static Singleton _instance = null;
    private static readonly object padlock = new object();
    
    // Adjust parameters here
    // Not important parameters in BaseState.cs
    
    // Speed
    public readonly Vector2 ApproachingSpeed = new Vector2(2.0f, 0.0f);
    public readonly Vector2 LeavingSpeed = new Vector2(-2.0f, 0.0f);
    public readonly Vector2 EscapingSpeed = new Vector2(-6.0f, 0f);
    
    // Time
    public readonly float timeTakingCandy = 1.0f;
    public readonly float timeLeaving = 3.0f;
    
    // Shaking effects
    public readonly Quaternion turnRight = Quaternion.Euler(Vector3.forward * -10);
    public readonly Quaternion turnLeft = Quaternion.Euler(Vector3.forward * 10);
    public readonly float timeToShakeAppraoching = 0.5f;
    public readonly float timeToShakeLeaving = 0.5f;
    public readonly float[] timeIntervalShakeTaking1 = new[] { 0.4f, 0.5f };
    public readonly int[] shakeDirectionsTaking1 = new[] { 1, 0 }; // 1 is turn right, -1 is left, 0 is back normal
    public readonly float[] timeIntervalShakeTakingMore = new[] { 0.4f, 0.5f, 0.6f, 0.7f };
    public readonly int[] shakeDirectionsTakingMore = new[] { 1, 0, 1, 0 };

    private Singleton()
    {
    }

    public static Singleton Instance
    {
        get
        {
            lock (padlock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }

                return _instance;
            }
        }
    }
}