using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIFrames : MonoBehaviour
{
    // private void PlayerIFrames(Collider2D col)
    // {
    //     // If damage is taken
    //     {
    //         col.enabled = false;
    //     }
    // }

    public IEnumerator InvinsibilityFrames(int layer)
    {
        int oGLayer = gameObject.layer;

        gameObject.layer = layer;

        yield return new WaitForSecondsRealtime(2f);

        gameObject.layer = oGLayer;
    }
}
