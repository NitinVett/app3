using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    public int holdingSlot;
    public GameObject knife;
    public GameObject hockeystick;
    public GameObject axe;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slot1 = knife;
        knife.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
