using UnityEngine;

public class ShipRotation : MonoBehaviour
{
    public Transform spriteTransform;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            spriteTransform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            spriteTransform.rotation = Quaternion.Euler(0, -45, 0);
        }
        else
        {
            spriteTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}