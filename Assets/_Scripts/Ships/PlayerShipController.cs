using UnityEngine.SceneManagement;

public class PlayerShipController : SpaceShipController
{
    public override void DestroyShip()
    {
        base.DestroyShip();
        SceneManager.LoadScene("GameOver");
    }
}
