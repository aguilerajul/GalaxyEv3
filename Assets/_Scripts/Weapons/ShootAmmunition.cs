public class ShootAmmunition : Ammunition
{
    protected override void Damage(SpaceShipController ship)
    {
        ship.Damage(base._damage);
    }
}
