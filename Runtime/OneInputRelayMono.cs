using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OneInputRelayMono : MonoBehaviour
{

    public UnityEvent<bool> m_onIsActiveEvent;
    public UnityEvent m_onIsActiveTrue;
    public UnityEvent m_onIsActiveFalse;

    public bool m_currentValue;


    public void SetWithoutNotificationValue(bool value)
        { m_currentValue = value; }

    [ContextMenu("Push Inspector Value")]

    public void ForcePushInspectorValue() {

        m_onIsActiveEvent.Invoke(m_currentValue);
        if (m_currentValue)
            m_onIsActiveTrue.Invoke();
        if (!m_currentValue)
            m_onIsActiveFalse.Invoke();
    }

    [ContextMenu("Press and release")]
    public void PushPressAndReleaseIn() {

        PushInIsActive(true);
        PushInIsActive(false);
    }

    public void PushInIsActive(bool isActive)
    {

        if (m_currentValue != isActive)
        {
            

                m_onIsActiveEvent.Invoke(isActive);
                if (isActive)
                    m_onIsActiveTrue.Invoke();
                if (!isActive)
                    m_onIsActiveFalse.Invoke();

            
        }

    }
}
