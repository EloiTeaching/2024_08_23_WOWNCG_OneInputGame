using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public class InputCallContextSplitMono : MonoBehaviour{

    public UnityEvent<bool> m_onIsActiveChanged;

    [Tooltip("Hardware is not perfect, what amount we need to ignore on the float axis")]
    public float m_zeroFloatDeathZone = 0.1f;
    [Header("Debug")]
    public bool m_lastReadValueBoolean;
    public float m_lastReadValueFloat;


    public void PushInToSplit(CallbackContext context) {

        if (context.action.type == UnityEngine.InputSystem.InputActionType.Button)
        {
            bool value = context.action.IsPressed();
            m_lastReadValueBoolean = value;
            m_lastReadValueFloat = m_lastReadValueBoolean?1f:0f;
            m_onIsActiveChanged.Invoke(value);
        }
        else
            if (context.action.type == UnityEngine.InputSystem.InputActionType.Value)
            {
                float value = context.action.ReadValue<float>() ;
                bool valueBool = value < -m_zeroFloatDeathZone || value> m_zeroFloatDeathZone;
                m_lastReadValueBoolean = valueBool;
                m_lastReadValueFloat = value;
                m_onIsActiveChanged.Invoke(valueBool);
            }
        
    }
}