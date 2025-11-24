using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    public int holdingSlot;
    public GameObject knife;
    public GameObject hockeystick;
    public GameObject axe;
    public int money;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = 0;
        holdingSlot = 1;
        slot1 = knife;
        slot2 = null;
        knife.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
