using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _equip;

    private Weapon _weapon;
    private InventoryView _inventoryView;

    private void OnEnable()
    {
        _equip.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _equip.onClick.RemoveListener(OnButtonClick);
    }

    public void Initialize(Weapon weapon, InventoryView inventoryView)
    {
        _inventoryView = inventoryView;
        _weapon = weapon;
        _name.text = weapon.name;
        _damage.text = weapon.Data.Damage.ToString();
        _icon.sprite = weapon.Data.Icon;
    }

    private void OnButtonClick()
    {
        _inventoryView.Inventory.EquipWeapon(_weapon);
        Destroy(gameObject);
    }
}
