using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : MonoBehaviour
{
    public static Soundtrack BackgroundInstance;

    private void Awake()
    {
        if (BackgroundInstance != null && BackgroundInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        BackgroundInstance = this;
        DontDestroyOnLoad(this);
    }
}
