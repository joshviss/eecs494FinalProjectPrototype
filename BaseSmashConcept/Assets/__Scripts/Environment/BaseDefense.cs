using UnityEngine;
using System.Collections;

public class BaseDefense : MonoBehaviour
{

    public int initialHealth = 3;
    private int health;

    // Use this for initialization
    void Start()
    {
        health = initialHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        GameObject collidedWith = other.gameObject;

        if (collidedWith.tag == "Sword")
        {
            Debug.Log("Damaged");
            health -= 1;
            if (health == 0)
            {
                this.gameObject.SetActive(false);
                resetHealth(); //might not be needed
            }
        }
    }

    public void resetHealth()
    {
        health = initialHealth;
    }

}
