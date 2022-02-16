using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Variables/New Vector2 Variable")]
public class Vector2Variable : ScriptableObject 
{
    public UnityAction<Vector2> OnValueChanged;
    [SerializeField] Vector2 currentValue;
    [SerializeField] bool resetOnDisable;
    [SerializeField] Vector2 resetValue;

    void OnDisable()
    {
        if (resetOnDisable)
            currentValue = resetValue;
    }

    public Vector2 Value
    {
        get { return currentValue; }
        set
        {
            this.currentValue = value;
            OnValueChanged?.Invoke(this.currentValue);
        }
    }
}
