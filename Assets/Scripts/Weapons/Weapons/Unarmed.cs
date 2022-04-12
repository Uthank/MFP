public class Unarmed : Weapon
{
    private void Awake()
    {
        _type = WeaponTypes.None;
        _damage = 10;
    }
}
