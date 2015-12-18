using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

    private float cooldown = 1.5f;
    private float atkAnim = 0.5f;
    private float cdCount = 0.0f;
    private Collider blade;

    void Start()
    {
        blade = transform.FindChild("Blade").GetComponent<Collider>();
        blade.enabled = false;
    }

    void Update()
    {
        if(cdCount > 0.0f)
        {
            cdCount -= Time.deltaTime;
            if(cdCount <= cooldown - atkAnim)
            {
                blade.enabled = false;
            }
        }
    }

    public void strike()
	{
        if (cdCount <= 0.0f)
        {
            GetComponent<Animator>().SetTrigger("StartStrike");
            blade.enabled = true;
            cdCount = cooldown;
        }
	}
        
}
