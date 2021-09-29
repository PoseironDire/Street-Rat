using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambience : MonoBehaviour
{
    public static Ambience AmbienceInstance;

    private void Awake()
    {
        if (AmbienceInstance != null && AmbienceInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        AmbienceInstance = this;
        DontDestroyOnLoad(this);
    }
}
