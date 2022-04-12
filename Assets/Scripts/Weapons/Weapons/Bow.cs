public class Bow : Weapon
{
    private void Awake()
    {
        _type = WeaponTypes.Bow;
        _damage = 40;
    }
}
