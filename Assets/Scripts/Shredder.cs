using UnityEngine;

public class Shredder : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        Pin pin = other.GetComponentInParent<Pin>();
        if (pin)
        {
            Destroy(pin.gameObject);
        }
    }
}
