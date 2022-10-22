
using UnityEngine;

public sealed class Singleton
{
    private static Singleton _instance = null;
    private static readonly object padlock = new object();
    
    // Adjust parameters here
    // Not important parameters in BaseState.cs
    public readonly Vector2 ApproachingSpeed = new Vector2(2.0f, 0.0f);
    public readonly Vector2 LeavingSpeed = new Vector2(-2.0f, 0.0f);

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