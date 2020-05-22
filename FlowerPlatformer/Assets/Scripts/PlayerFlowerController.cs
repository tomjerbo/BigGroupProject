using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toolkit;
public class PlayerFlowerController : MonoBehaviour
{
    public static PlayerFlowerController instance;
    //[SerializeField] GameObject[] Flowers = default;
    [SerializeField] GameObject Flower = default;
    [SerializeField] GameObject Ladder = default;
    [SerializeField] GameObject fakeSeedBall = default;
    [SerializeField] GameObject seedBallPrefab = default;
    [SerializeField] GameObject fakeLadderBall = default;
    [SerializeField] GameObject seedLadderPrefab = default;
    [SerializeField] private float throwForce = 10f;
    [SerializeField] private float reloadCD = 1f;
    private float flowerReload = 0;
    private float ladderReload = 0;

    public GameObject oldFlower = null;
    public GameObject oldLadder = null;

    private void Awake()
    {
        instance = this;
    }
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
                if (oldFlower != null) oldFlower.GetComponent<FlowerGrow>().RemoveOld();
                GameObject ball = Instantiate(seedBallPrefab, fakeSeedBall.transform.position, fakeSeedBall.transform.rotation);
                ball.GetComponent<Rigidbody>().AddForce(GetComponentInChildren<Camera>().transform.forward * throwForce, ForceMode.Impulse);
                ball.GetComponent<FlowerPlanter>().SetFlowerToPlant(Flower);
                Destroy(ball, 2f);
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
                if (oldLadder != null) oldLadder.GetComponent<LadderGrow>().RemoveOld();
                GameObject ball = Instantiate(seedLadderPrefab, fakeLadderBall.transform.position, fakeLadderBall.transform.rotation);
                ball.GetComponent<Rigidbody>().AddForce(GetComponentInChildren<Camera>().transform.forward * throwForce, ForceMode.Impulse);
                ball.GetComponent<LadderPlacer>().SetFlowerToPlant(Ladder);
                Destroy(ball, 2f);
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
