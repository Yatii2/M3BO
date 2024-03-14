using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveUfo : MonoBehaviour
{
    [SerializeField] GameObject Pos1;
    [SerializeField] GameObject Pos2;
    [SerializeField] GameObject Pos3;
    [SerializeField] GameObject Pos4;
    [SerializeField] GameObject PosEind;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float speed = 1.0f;

    private List<GameObject> Targets = new List<GameObject>();
    private int CurrentTarget = 0;
    
    void Start()
    {
        Targets.Add(Pos1);
        Targets.Add(Pos2);
        Targets.Add(Pos3);
        Targets.Add(Pos4);
        Targets.Add(PosEind);

        transform.rotation = Quaternion.Euler(0f, 146.563f, 0f);
        transform.position = Targets[CurrentTarget].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Targets[CurrentTarget].transform.position) < 0.1f)
        {
            if (CurrentTarget < Targets.Count - 1)
            {
                CurrentTarget++;
            }

           

        }

        if (CurrentTarget == 3)
        {
          
            float rotationSpeed = 20f; 
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.rotation *= Quaternion.Euler(0f, rotationAmount, 0f);
        }


        Vector3 direction = (Targets[CurrentTarget].transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;



    }
}
