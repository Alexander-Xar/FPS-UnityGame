using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : ActionBaseState
{
    public override void EnterState(ActionStateManager actions)
    {
       
    }

    public override void UpdateState(ActionStateManager actions)
    {
        actions.rHandAim.weight = Mathf.Lerp(actions.rHandAim.weight, 1, 10 * Time.deltaTime);
        actions.lHandIk.weight = Mathf.Lerp(actions.lHandIk.weight, 1, 10 * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.R) && CanReload(actions))
        {
            actions.SwitchState(actions.Reload);

        }



    }

    bool CanReload (ActionStateManager actions)
    {

        if (actions.ammo.currentAmmo == actions.ammo.clipSize) return false;
        else if (actions.ammo.extraAmmo == 0) return false;
        else return true;


    }
}
