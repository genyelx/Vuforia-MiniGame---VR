using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidade = 20f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * velocidade * -1, ForceMode.Impulse);
    }


    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("WallDestroy"))
        {
            Destroy(gameObject);
            CanvasManager.points += 1;
        }
    }
}
