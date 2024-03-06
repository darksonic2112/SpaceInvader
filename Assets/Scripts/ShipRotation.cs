using UnityEngine;

public class ShipRotation : MonoBehaviour
{
    public Transform spriteTransform;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            spriteTransform.rotation = Quaternion.Euler(0, 45, 180);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            spriteTransform.rotation = Quaternion.Euler(0, -45, 180);
        }
        else
        {
            spriteTransform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}