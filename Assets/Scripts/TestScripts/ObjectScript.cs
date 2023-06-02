using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : Person
{
    // How to Declare an Enum
    public enum WeaponType
    {
        Mellee = 2,
        Axe = 12,
        Sword = 22,
        Gun = 32,
        BowAndArrow = 42
    }
    // Start is called before the first frame update
    void Start()
    {
        PersonDetails();   
    }

    // Update is called once per frame
    public override void Drive()
    {
        base.Drive(); //Example of Polymorphism
    }
    void Update()
    {
        
    }
    void PersonDetails()
    {
        Person personalPerson = new Person();  // This is an Object. It defines a new person from Person

        // Example of a constructor
        personalPerson.name = "Peter";
        personalPerson.age = 24;
        personalPerson.address = "4560 Belmont ave";

        //personalPerson.();
        Debug.Log($"{personalPerson.name} is  {personalPerson.age} years old and lives at {personalPerson.address}");
    }
}


