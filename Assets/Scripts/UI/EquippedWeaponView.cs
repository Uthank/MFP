using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquippedWeaponView : MonoBehaviour
{
    [SerializeField] private InventoryView _inventoryView;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _unequip;
    [SerializeField] private GameObject _defaultWeapon;

    private Weapon _weapon;

    private void OnEnable()
    {
        _unequip.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _unequip.onClick.RemoveListener(OnButtonClick);
    }

    public void Set(Weapon weapon)
    {
        _weapon = weapon;
        _name.text = weapon.name;
        _damage.text = weapon.Data.Damage.ToString();
        _icon.sprite = weapon.Data.Icon;

        if (weapon == _defaultWeapon.GetComponent<Weapon>())
        {
            _unequip.gameObject.SetActive(false);
        }
        else
        {
            _unequip.gameObject.SetActive(true);
        }
    }

    private void OnButtonClick()
    {
        _inventoryView.Inventory.UnequipWeapon();
    }
}
