using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    public GameObject EggBroken;
    private HearthBar _hearthBar;

    void Awake()
    {
        _hearthBar = GameObject.Find("HearthBar").GetComponent<HearthBar>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Ground"))
        {
            Instantiate(EggBroken, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (col.gameObject.name.Equals("Egg"))
        {
            Instantiate(EggBroken, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (col.gameObject.name.Equals("Farmer"))
        {
            Instantiate(EggBroken, transform.position, Quaternion.identity);
            Destroy(gameObject);

            // Update the hearth bar
            _hearthBar.TakeDamage(1);
        }
    }
}
