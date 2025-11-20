using UnityEngine;

public class MeleeWeapons : MonoBehaviour
{
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
        if(gameObject.name == "knife"){
            //play anim
        }
        else if(gameObject.name == "hockeystick"){
            //play anim
        }
        else if(gameObject.name == "axe"){
            //play anim
        }
    }
    
    
}
