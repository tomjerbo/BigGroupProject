using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlowerController : MonoBehaviour
{
    [SerializeField] GameObject[] Flowers = default;
    [SerializeField] GameObject Ladder = default;
    [SerializeField] GameObject fakeSeedBall = default;
    [SerializeField] GameObject seedBallPrefab = default;
    [SerializeField] GameObject fakeLadderBall = default;
    [SerializeField] GameObject seedLadderPrefab = default;
    [SerializeField] private float throwForce;
    [SerializeField] private float reloadCD;
    private float flowerReload;
    private float ladderReload;
    void Update()
    {
        ThrowSeedBall();
        ThrowLadderBall();
    }

    private void ThrowSeedBall()
    {
        if (flowerReload <= 0)
        {
            fakeSeedBall.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                GameObject ball = Instantiate(seedBallPrefab, fakeSeedBall.transform.position, fakeSeedBall.transform.rotation);
                ball.GetComponent<Rigidbody>().AddForce(GetComponentInChildren<Camera>().transform.forward * throwForce, ForceMode.Impulse);
                ball.GetComponent<FlowerPlanter>().SetFlowerToPlant(Flowers[Random.Range(0, Flowers.Length)]);
                flowerReload = reloadCD;
                fakeSeedBall.SetActive(false);
            }
        }
        else
        {
            flowerReload -= Time.deltaTime;
        }
    }

    private void ThrowLadderBall()
    {
        if (ladderReload <= 0)
        {
            fakeLadderBall.SetActive(true);
            if (Input.GetMouseButtonDown(1))
            {
                GameObject ball = Instantiate(seedLadderPrefab, fakeLadderBall.transform.position, fakeLadderBall.transform.rotation);
                ball.GetComponent<Rigidbody>().AddForce(GetComponentInChildren<Camera>().transform.forward * throwForce, ForceMode.Impulse);
                ball.GetComponent<FlowerPlanter>().SetFlowerToPlant(Ladder);
                ladderReload = reloadCD;
                fakeLadderBall.SetActive(false);
            }
        }
        else
        {
            ladderReload -= Time.deltaTime;
        }
    }
}
