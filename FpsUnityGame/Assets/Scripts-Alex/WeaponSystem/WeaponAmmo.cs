using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : MonoBehaviour
{

    public int clipSize;
    public int extraAmmo;
    public int currentAmmo;

    public AudioClip magInSound;
    public AudioClip magOutSound;
    public AudioClip releaseSlideSound;

    private UIManager _uiManager;



    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = clipSize;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }
    private void Update()
    {
        _uiManager.UpdateAmmo(currentAmmo);
        _uiManager.UpdateExtraAmmo(extraAmmo);
    }


    public void Reload()
    {

        if (extraAmmo >= clipSize)
        {
            int ammoToReload = clipSize - currentAmmo;
            extraAmmo -= ammoToReload;
            currentAmmo += ammoToReload;
        }
        else if (extraAmmo > 0)
        {
            if (extraAmmo + currentAmmo > clipSize)
            {
                int leftOverAmmo = extraAmmo + currentAmmo - clipSize;
                extraAmmo = leftOverAmmo;
                currentAmmo = clipSize;
            }

            else
            {
                currentAmmo += extraAmmo;
                extraAmmo = 0;
            }

        }
       
        

    }
}
