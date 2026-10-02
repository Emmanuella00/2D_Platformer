using UnityEngine;


public class PlayerWaterCheck : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            GameManager.Instance.PlayerFell(transform.position);
        }
    }
}
