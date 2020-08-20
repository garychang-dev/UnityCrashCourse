using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject door;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == Constants.PLAYER_TAG)
        {
            door.GetComponent<TranslateToTarget>().enabled = true;
        }
    }
}
