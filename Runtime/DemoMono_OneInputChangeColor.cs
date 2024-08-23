using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoMono_OneInputChangeColor : MonoBehaviour
{


    public Renderer m_rendererToAffect;


    [ContextMenu("Change Color")]
    public void ChangeColor() {

        if (m_rendererToAffect != null)
            m_rendererToAffect.material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.value , UnityEngine.Random.value , UnityEngine.Random.value );
    }
}
