using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hit = 3;
    public int points = 100;
    [SerializeField] private Vector3 rotator;
    [SerializeField] private Material hitMaterial;
    [SerializeField] private Material OnehitMaterial;

    Material orginalMaterial;
    Renderer renderering;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(rotator * (transform.position.x + transform.position.y)*0.1f);
        renderering = GetComponent<Renderer>();
        orginalMaterial = renderering.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotator * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        hit--;
        //score points
        if (hit <= 0)
        {
            renderering.sharedMaterial = hitMaterial;
            Destroy(gameObject);
        }
        if (hit == 1)
        {
            renderering.sharedMaterial = OnehitMaterial;
        }
        if (hit > 1)
        {
            renderering.sharedMaterial = hitMaterial;
            Invoke("BacktOrgMaterial", 0.05f);
        }
       

    }
    void BacktOrgMaterial()
    {
        renderering.sharedMaterial = orginalMaterial;
    }
}