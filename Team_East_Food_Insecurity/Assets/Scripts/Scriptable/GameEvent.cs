using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewGameEvent", menuName ="New Game Event")]
public class GameEvent : ScriptableObject
{
    readonly List<GameEventListener> listeners = new List<GameEventListener>(); 
    public void Invoke(GameObject obj) { for (int i = listeners.Count - 1; i >= 0; i--) listeners[i].OnEventRaised(obj); }
    public void RegisterListener(GameEventListener listener) => listeners.Add(listener);
    public void UnregisterListener(GameEventListener listener) => listeners.Remove(listener);
}
