using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace GameEvents
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent gameEvent;
        public UnityEvent OnGameEventCalled;

        private void OnEnable()
        {
            gameEvent.AddListener(this);
        }

        private void OnDisable()
        {
            gameEvent.RemoveListener(this);
        }
    }
}

