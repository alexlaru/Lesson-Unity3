using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {

            Debug.Log("6");
            player.CurrentPlatform = this;
        }
    }
}
    
    
