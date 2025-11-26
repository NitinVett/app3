using UnityEngine;

public class MeleeWeapons : MonoBehaviour
{
    public Animator attack1;
    public Renderer weaponRenderer;



    public int damage = 50;
    //add cooldwons and speed for each weapon
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }
    public void Attack()
    {
        if(gameObject.name == "Knife"){
            attack1.Play("Stab");
        }
        else if(gameObject.name == "Hockeystick"){
            attack1.Play("SlapSwing");
        }
        else if(gameObject.name == "Axe"){
            attack1.Play("StumpSplitter");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
        }
    }

    public void Upgrade()
    {
        if(gameObject.name == "Knife")
        {
            damage += 50;
        }
        else if(gameObject.name == "Hockeystick")
        {
            damage+= 70;
        }
        else if(gameObject.name == "Axe")
        {
            damage+= damage;
        }
        weaponRenderer.material.color = Color.black;
    }
}
