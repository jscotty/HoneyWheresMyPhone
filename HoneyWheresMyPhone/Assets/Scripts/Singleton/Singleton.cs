﻿using UnityEngine;

/// <summary>
/// All information can be found at http://wiki.unity3d.com/index.php/Singleton
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    private static object _lock = new object();

    /// <summary>
    /// finds the singleton or creates a singleton if it's not there
    /// </summary>
    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                return null;
            }

            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        return _instance;
                    }

                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = "(singleton) " + typeof(T).ToString();

                        DontDestroyOnLoad(singleton);
                    }
                }
                return _instance;
            }
        }
    }

    private static bool applicationIsQuitting = false;

    public void OnDestroy()
    {
        applicationIsQuitting = true;
    }
}