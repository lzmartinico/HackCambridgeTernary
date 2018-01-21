using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour {

    [Range(0,1000)]
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public RectTransform healthBar;                                 // Reference to the UI's health bar.
    private int iframescount;
    public int iframeslen;
    private bool invincible;

    void Start () {
        currentHealth = startingHealth;
        iframescount = 0;
        invincible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (invincible)
        {
            iframescount++;

            if (iframescount >= iframeslen)
            {
                invincible = false;
                iframescount = 0;
            }

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 8 || col.gameObject.layer == 12)
        {
            if (!invincible)
            {
                //Debug.Log("AAAAAGGGGGHHHHHHH");
                var damage = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * col.gameObject.GetComponent<Rigidbody2D>().mass / Time.deltaTime * (col.gameObject.name.Contains("(") ? 2 : 1);
                //Debug.Log(damage);

                currentHealth -= (int)damage;

                if (currentHealth < 0)
                {
                    GetComponent<FixedJoint2D>().enabled = false;
                    GetComponent<Rigidbody2D>().AddForce((transform.position - col.gameObject.transform.position).normalized * col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 300);
                    if (Input.GetKeyDown("r"))
                    {

                    }
                }


                healthBar.sizeDelta = new Vector2((float)currentHealth / (float)startingHealth * 100, healthBar.sizeDelta.y);

                invincible = true;
            }
        }
    }
}
