using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _ammoText;
    [SerializeField]
    private Text _extraAmmoText;
   public void UpdateAmmo(int count)
    {
        _ammoText.text = "Ammo: " + count.ToString();

      
    }

    public void UpdateExtraAmmo(int extra)
    {
        _extraAmmoText.text = extra.ToString();
    }
}
