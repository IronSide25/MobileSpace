using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starship : MonoBehaviour
{
    public float health = 100;
    public Mesh mesh;

    public GameObject explosionPrefab;
    public int explosionRangeMin;
    public int explosionRangeMax;
    public GameObject firePrefab;
    public int fireRangeMin;
    public int fireRangeMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    private void OnParticleCollision(GameObject other)
    {
        if(health > 0)
        {
            health -= 25;
            Debug.Log(other.name);
            if (health <= 0)
                OnStarshipDestroy();
        }       
    }

    private void OnStarshipDestroy()
    {
        //int explosionCount = Random.Range(explosionRangeMin, explosionRangeMax);
        int fireCount = Random.Range(fireRangeMin, fireRangeMax);
        StartCoroutine(ExplosionCoroutine(explosionPrefab, 5));
        /*
        for (int i = 0; i < explosionCount; i++)
        {
            Vector3 vertex = mesh.vertices[Random.Range(0, mesh.vertices.Length)];
            GameObject go = Instantiate(explosionPrefab, transform.TransformPoint(vertex), Random.rotation);
            float randomScale = Random.Range(2f, 4f);
            go.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        }*/
        for (int j = 0; j < fireCount; j++)
        {
            
            int rand = Random.Range(0, mesh.vertices.Length);
            Vector3 vertex = mesh.vertices[rand];
            GameObject go = Instantiate(firePrefab, transform.TransformPoint(vertex), Quaternion.identity);
            ParticleSystem ps = go.GetComponent<ParticleSystem>();
            /*
            ParticleSystem.VelocityOverLifetimeModule velocityModule = ps.velocityOverLifetime;
            velocityModule.x = 5;
            go.transform.LookAt(transform.TransformPoint(vertex) + mesh.vertices[rand]);
            Debug.DrawRay(transform.TransformPoint(vertex), mesh.vertices[rand]);
            Debug.Break();*/
        }
    }

    public IEnumerator ExplosionCoroutine(GameObject prefab, int count)
    {
        int explosionCount = Random.Range(explosionRangeMin, explosionRangeMax);
        int fireCount = Random.Range(fireRangeMin, fireRangeMax);

        for (int i = 0; i < explosionCount; i++)
        {
            Vector3 vertex = mesh.vertices[Random.Range(0, mesh.vertices.Length)];
            GameObject go = Instantiate(explosionPrefab, transform.TransformPoint(vertex), Random.rotation);
            float randomScale = Random.Range(2f, 4f);
            go.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.6f));
        }
    }
}
