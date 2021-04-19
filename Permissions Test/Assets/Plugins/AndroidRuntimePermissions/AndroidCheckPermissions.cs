using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidCheckPermissions : MonoBehaviour
{
    Action <bool> permissionSuccess;

    public void RequestPermissions()
    {
        RequestPermissions((response) => {

            Debug.LogError("Permission Accepted" + response);
        });
    }

    public void RequestPermissions(Action<bool> actionToDo)
    {
        this.permissionSuccess = actionToDo;

        AndroidRuntimePermissions.Permission result = AndroidRuntimePermissions.RequestPermission("android.permission.WRITE_EXTERNAL_STORAGE");

        if (result == AndroidRuntimePermissions.Permission.Granted) 
        {
            Debug.LogError("We have permission to access external storage!");
            permissionSuccess?.Invoke(true);
        }
        else
        {
            Debug.LogError("Permission state: " + result);
            permissionSuccess?.Invoke(false);
        }
    }
}
