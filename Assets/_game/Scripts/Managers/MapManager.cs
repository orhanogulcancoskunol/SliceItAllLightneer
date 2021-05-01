using _game.Scripts.Utilities;
using UnityEngine;

namespace _game.Scripts.Managers
{
    public class MapManager : Singleton<MapManager>
    {
        [HideInInspector]
        public GameObject CurrentMap;
        
        public void SpawnMap(GameObject map)
        {
            if(CurrentMap!=null) Destroy(CurrentMap);
            CurrentMap = Instantiate(map);
        }
    }
}
