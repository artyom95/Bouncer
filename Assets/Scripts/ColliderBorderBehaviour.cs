using System;
using UnityEngine;

public class ColliderBorderBehaviour : MonoBehaviour
{
    public static Action OffSiteCube;

    public static Action SetColor;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(GlobalConstant.PLAYER_TAG))
        {
            SetColor?.Invoke();
            Destroy(collision.gameObject);
           OffSiteCube?.Invoke();
        }
    }
}
