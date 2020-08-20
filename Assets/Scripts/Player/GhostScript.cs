using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public GameObject player;
    public GameObject reviveTimerBar;
    private LineRenderer line;

    public ReviveBar reviveBar;

    [Range(0, 50)]
    private int segments = 50;

    public float radius;
    private float xradius;
    private float yradius;

    public float reviveTime = 6f;
    private float OGReviveTime;
    private int playerCount;

    // Start is called before the first frame update
    void Start()
    {
        OGReviveTime = reviveTime;
        reviveTimerBar.SetActive(false);

        line = gameObject.GetComponent<LineRenderer>();

        reviveBar.SetMaxTime(OGReviveTime);

        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        CreatePoints();
        line.enabled = true;
    }

    void CreatePoints()
    {
        xradius = radius;
        yradius = radius;
        float x;
        float z;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition(i, new Vector3(x, 0, z));

            angle += (360f / segments);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (reviveTime <= 0)
        {
            Destroy(gameObject);
            player.gameObject.SetActive(true);
            player.GetComponent<PlayerStats>().health = 2;
            LevelManager.instance.HealthBars[player.GetComponent<PlayerStats>().playerconfig.SelectedCharacter].SetHealth(2);
            LevelManager.instance.UltimateBars[player.GetComponent<PlayerStats>().playerconfig.SelectedCharacter].SetUltimatePercentage(0);
        }

        UpdateTimer();
    }

    void UpdateTimer()
    {
        reviveBar.SetTime(reviveTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            reviveTimerBar.SetActive(true);
            playerCount++;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            reviveTime -= Time.deltaTime * playerCount;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            reviveTimerBar.SetActive(false);
            playerCount--;
            reviveTime = OGReviveTime;
        }
    }
}
