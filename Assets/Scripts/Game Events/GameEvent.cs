using UnityEngine;
using System.Collections.Generic;


namespace GameEvents
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void CallEvent()
        {
            foreach (GameEventListener gel in listeners.ToArray())
            {
                gel.OnGameEventCalled.Invoke();
            }
        }

        public void AddListener(GameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void RemoveListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }

        public int ListenersCount()
        {
            return listeners.Count;
        }

    }
}


