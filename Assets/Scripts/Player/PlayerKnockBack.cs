using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockBack : MonoBehaviour
{
    // private void PlayerIFrames(Collider2D col)
    // {
    //     // If damage is taken
    //     {
    //         col.enabled = false;
    //     }
    // }

    public IEnumerator PlayerIFrames(Collider2D col)
    {
        col.enabled = false;

        yield return new WaitForSecondsRealtime(2f);

        col.enabled = true;
    }

    public void KnockBack(Rigidbody2D rb)
    {
        rb.AddForce(Vector2.right * 2, ForceMode2D.Impulse);
    }
}
