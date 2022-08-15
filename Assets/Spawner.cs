using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject Prefab;
    [SerializeField] private Vector3 position;
    [SerializeField] private Transform Transform;
    [SerializeField] private float timer;
    [SerializeField] public float min;
    [SerializeField] public float max;
    [SerializeField] private float radius;
    [SerializeField] private float antiRadius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            SetTimer();
            float x = Random.Range(-radius, radius);
            float y = Random.Range(-radius, radius);
            if (x < 0)
                x -= antiRadius;
            else
                x += antiRadius;
            if (y < 0)
                y -= antiRadius;
            else
                y += antiRadius;
            position = new Vector2(x, y);
            Instantiate(Prefab, position + transform.position, Quaternion.identity);
            
        }
        else
            timer -= Time.deltaTime;

    }

    void SetTimer()
    {
        timer = Random.Range(min, max);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Transform.position, radius);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(Transform.position, radius + antiRadius);

    }
}
