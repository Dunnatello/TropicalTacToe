namespace Dunnatello.AI {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "New Bot Manager", menuName = "Dunnatello/AI/Bot Manager", order = 0)]
    [System.Serializable]
    public class BotManager : ScriptableObject {

        public List<Bot> bots;
        
    }

}