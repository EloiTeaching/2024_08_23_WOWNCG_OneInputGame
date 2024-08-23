using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ListenToKeyboardKeyMono : MonoBehaviour
{

    public KeyCode m_keyToObserver;
    public UnityEvent<bool> m_onKeyActiveChanged;
    public UnityEvent m_onKeyTrue;
    public UnityEvent m_onKeyFalse;



    public bool m_currentValue = false;
    public bool m_previousValue = false;

    void Update()
    {

        m_currentValue= Input.GetKeyDown(m_keyToObserver);

        if (m_currentValue != m_previousValue)
        {
            m_onKeyActiveChanged.Invoke(m_currentValue);
            if (m_currentValue == true)
            {
                m_onKeyTrue.Invoke();
            }
            if (m_currentValue == false)
            {
                m_onKeyFalse.Invoke();
            }
            m_previousValue = m_currentValue;
        }

    }
}
