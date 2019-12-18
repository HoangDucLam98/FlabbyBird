using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeHolder;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(Spawner());
        GameObject pipe = Instantiate(pipeHolder);
        pipe.transform.position = transform.position + new Vector3(pipe.transform.position.x, Random.Range(-2.4f, 2.4f), 0);
        Destroy(pipe, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if( timer > 2 ) {
            GameObject pipe = Instantiate(pipeHolder);
            pipe.transform.position = transform.position + new Vector3(pipe.transform.position.x, Random.Range(-2.3f, 2.3f), 0);
            Destroy(pipe, 5);
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    // IEnumerator Spawner()
    // {
    //     Vector3 temp = pipeHolder.transform.position;
    //     temp.y = Random.Range(-2.4f, 2.4f);
    //     Instantiate(pipeHolder, temp, Quaternion.identity);
    //     Destroy(pipeHolder, 5);
    //     yield return new WaitForSeconds(2f);
    //     StartCoroutine(Spawner());
    // }
}
