using System;
using UnityEngine;

namespace GameplayTags
{
    [Serializable]
    public class GameObjectGameplayTagContainer : MonoBehaviour
    {
        public GameplayTagCountContainer GameplayTagContainer => m_GameplayTagContainer;

        public GameplayTagContainer m_PersistentTags;

        private GameplayTagCountContainer m_GameplayTagContainer;

        private void Awake()
        {
            m_GameplayTagContainer = new GameplayTagCountContainer();
            m_GameplayTagContainer.AddTags(m_PersistentTags);
        }

        public static implicit operator GameplayTagCountContainer(GameObjectGameplayTagContainer container)
        {
            return container.GameplayTagContainer;
        }
    }

    public static class GameplayTagContainerBindsHelper
    {
        public static GameplayTagContainerBinds Bind(this GameObject gameObject)
        {
            GameObjectGameplayTagContainer component = gameObject.GetComponent<GameObjectGameplayTagContainer>();
            if (component == null)
            {
                component = gameObject.AddComponent<GameObjectGameplayTagContainer>();
            }

            GameplayTagContainerBinds binds = new GameplayTagContainerBinds(component.GameplayTagContainer);
            return binds;
        }
    }
}