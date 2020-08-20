using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject door;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            door.GetComponent<TranslateToTarget>().enabled = true;
        }
    }
}
