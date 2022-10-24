
using UnityEngine;

public sealed class Singleton
{
    private static Singleton _instance = null;
    private static readonly object Padlock = new object();
    
    // Adjust parameters here
    // Not important parameters in BaseState.cs
    
    // Num of characters
    public readonly int NumCharacters = 52;
    
    // Algorithm on new kids coming
    public readonly float NewKidProb = 0.6f; // old kid prob: 1-newKidProb

    public readonly float MultiCandyProb = 0.5f;

    public readonly int MaxCandy = 6;
    // Speed
    public readonly Vector2 ApproachingSpeed = new Vector2(10.0f, 0.0f);
    public readonly Vector2 LeavingSpeed = new Vector2(-10.0f, 0.0f);
    public readonly Vector2 EscapingSpeed = new Vector2(-20.0f, 0f);
    
    // Time
    public readonly float TimeTakingCandy = 1.0f;
    public readonly float TimeLeaving = 3.0f;
    
    // Shaking effects
    public readonly Quaternion TurnRight = Quaternion.Euler(Vector3.forward * -10);
    public readonly Quaternion TurnLeft = Quaternion.Euler(Vector3.forward * 10);
    public readonly float TimeToShakeAppraoching = 0.5f;
    public readonly float TimeToShakeLeaving = 0.5f;
    public readonly float[] TimeIntervalShakeTaking1 = new[] { 0.4f, 0.5f };
    public readonly int[] ShakeDirectionsTaking1 = new[] { 1, 0 }; // 1 is turn right, -1 is left, 0 is back normal
    public readonly float[] TimeIntervalShakeTakingMore = new[] { 0.4f, 0.5f, 0.6f, 0.7f };
    public readonly int[] ShakeDirectionsTakingMore = new[] { 1, 0, 1, 0 };

    private Singleton()
    {
    }

    public static Singleton Instance
    {
        get
        {
            lock (Padlock)
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