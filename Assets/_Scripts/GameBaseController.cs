using UnityEngine;

public static class GameBaseController
{
    public static int DestroyedEnemies { get; private set; }
    public static bool NextWave { get; set; }
    public static Transform DeathPosition { get; set; }

}
