using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ListenToScreenTouchMono : MonoBehaviour
{
    public UnityEvent<bool> m_onScreenTouchChanged;
    public UnityEvent m_onTouchTrue;
    public UnityEvent m_onTouchFalse;



    public bool m_currentValue = false;
    public bool m_previousValue = false;

    void Update()
    {

        m_currentValue = Input.touchCount > 0 || Input.GetMouseButton(0);

        if (m_currentValue != m_previousValue)
        {
            m_onScreenTouchChanged.Invoke(m_currentValue);
            if (m_currentValue == true)
            {
                m_onTouchTrue.Invoke();
            }
            if (m_currentValue == false)
            {
                m_onTouchFalse.Invoke();
            }
            m_previousValue = m_currentValue;
        }

    }
}
