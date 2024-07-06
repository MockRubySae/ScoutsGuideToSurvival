using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public List<GameObject> pieces;
    public List<GameObject> tempPieces = new List<GameObject>();
    public RayCast move;
    public Camera cam;
    public FollowPlayer followPlayer;
    bool hasTrigered = false;
    private LineRenderer line;
    [SerializeField] int rightPieces = 0;
    bool[] conditionTriggered = new bool[30]; // Array to track which conditions have been triggered
    bool[] conditionTriggeredRotate = new bool[30]; // Array to track which conditions have been triggered
    [SerializeField]int rightRotate = 0;
    public bool youWin = false;
    public GameObject hintButtonUI;
    public GameObject raftTimber;
    public GameObject raftBuilt;

    public WorldCanvasChar charCanvas;

    Vector3 ogCamPos;

    private void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = 4;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.SetVertexCount(4);
        line.SetPosition(0,new Vector3(96.5f, 0.1f, 13.5f));
        line.SetPosition(1, new Vector3(102.5f, 0.1f, 13.5f));
        line.SetPosition(2, new Vector3(102.5f, 0.1f, 8.5f));
        line.SetPosition(3, new Vector3(96.5f, 0.1f, 8.5f));

    }
    public void OnTriggerEnter(Collider other)
    {
        if (!hasTrigered)
        {
            ogCamPos = cam.transform.position;
            hintButtonUI.SetActive(true);
            move.enabled = false;
            followPlayer.enabled = false;
            for (int i = 0; i < 30; i++)
            {
                float x = Random.Range(109.0f, 90.0f);
                float z = Random.Range(5.0f, 10f);
                Vector3 temp = new Vector3(x, 0.25f, z);
                GameObject instantiatedUI = Instantiate(pieces[i], temp, Quaternion.identity);
                tempPieces.Add(instantiatedUI);
            }
            cam.transform.position = new Vector3(100, 10, 10);
            cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x - 32.652f + 90, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
            hasTrigered = true;
        }
      
    }

    private void Update()
    {
        if (tempPieces.Count == 30)
        {
            if (tempPieces[0].transform.position == new Vector3(102, 0, 9) && !conditionTriggered[0])
            {
                rightPieces++;
                conditionTriggered[0] = true;
            }
            else if (tempPieces[1].transform.position == new Vector3(101, 0, 9) && !conditionTriggered[1])
            {
                rightPieces++;
                conditionTriggered[1] = true;
            }
            else if (tempPieces[2].transform.position == new Vector3(100, 0, 9) && !conditionTriggered[2])
            {
                rightPieces++;
                conditionTriggered[2] = true;
            }
            else if (tempPieces[3].transform.position == new Vector3(99, 0, 9) && !conditionTriggered[3])
            {
                rightPieces++;
                conditionTriggered[3] = true;
            }
            else if (tempPieces[4].transform.position == new Vector3(98, 0, 9) && !conditionTriggered[4])
            {
                rightPieces++;
                conditionTriggered[4] = true;
            }
            else if (tempPieces[5].transform.position == new Vector3(97, 0, 9) && !conditionTriggered[5])
            {
                rightPieces++;
                conditionTriggered[5] = true;
            }
            else if (tempPieces[6].transform.position == new Vector3(102, 0, 10) && !conditionTriggered[6])
            {
                rightPieces++;
                conditionTriggered[6] = true;
            }
            else if (tempPieces[7].transform.position == new Vector3(101, 0, 10) && !conditionTriggered[7])
            {
                rightPieces++;
                conditionTriggered[7] = true;
            }
            else if (tempPieces[8].transform.position == new Vector3(100, 0, 10) && !conditionTriggered[8])
            {
                rightPieces++;
                conditionTriggered[8] = true;
            }
            else if (tempPieces[9].transform.position == new Vector3(99, 0, 10) && !conditionTriggered[9])
            {
                rightPieces++;
                conditionTriggered[9] = true;
            }
            else if (tempPieces[10].transform.position == new Vector3(98, 0, 10) && !conditionTriggered[10])
            {
                rightPieces++;
                conditionTriggered[10] = true;
            }
            else if (tempPieces[11].transform.position == new Vector3(97, 0, 10) && !conditionTriggered[11])
            {
                rightPieces++;
                conditionTriggered[11] = true;
            }
            else if (tempPieces[12].transform.position == new Vector3(102, 0, 11) && !conditionTriggered[12])
            {
                rightPieces++;
                conditionTriggered[12] = true;
            }
            else if (tempPieces[13].transform.position == new Vector3(101, 0, 11) && !conditionTriggered[13])
            {
                rightPieces++;
                conditionTriggered[13] = true;
            }
            else if (tempPieces[14].transform.position == new Vector3(100, 0, 11) && !conditionTriggered[14])
            {
                rightPieces++;
                conditionTriggered[14] = true;
            }
            else if (tempPieces[15].transform.position == new Vector3(99, 0, 11) && !conditionTriggered[15])
            {
                rightPieces++;
                conditionTriggered[15] = true;
            }
            else if (tempPieces[16].transform.position == new Vector3(98, 0, 11) && !conditionTriggered[16])
            {
                rightPieces++;
                conditionTriggered[16] = true;
            }
            else if (tempPieces[17].transform.position == new Vector3(97, 0, 11) && !conditionTriggered[17])
            {
                rightPieces++;
                conditionTriggered[17] = true;
            }
            else if (tempPieces[18].transform.position == new Vector3(102, 0, 12) && !conditionTriggered[18])
            {
                rightPieces++;
                conditionTriggered[18] = true;
            }
            else if (tempPieces[19].transform.position == new Vector3(101, 0, 12) && !conditionTriggered[19])
            {
                rightPieces++;
                conditionTriggered[19] = true;
            }
            else if (tempPieces[20].transform.position == new Vector3(100, 0, 12) && !conditionTriggered[20])
            {
                rightPieces++;
                conditionTriggered[20] = true;
            }
            else if (tempPieces[21].transform.position == new Vector3(99, 0, 12) && !conditionTriggered[21])
            {
                rightPieces++;
                conditionTriggered[21] = true;
            }
            else if (tempPieces[22].transform.position == new Vector3(98, 0, 12) && !conditionTriggered[22])
            {
                rightPieces++;
                conditionTriggered[22] = true;
            }
            else if (tempPieces[23].transform.position == new Vector3(97, 0, 12) && !conditionTriggered[23])
            {
                rightPieces++;
                conditionTriggered[23] = true;
            }
            else if (tempPieces[24].transform.position == new Vector3(102, 0, 13) && !conditionTriggered[24])
            {
                rightPieces++;
                conditionTriggered[24] = true;
            }
            else if (tempPieces[25].transform.position == new Vector3(101, 0, 13) && !conditionTriggered[25])
            {
                rightPieces++;
                conditionTriggered[25] = true;
            }
            else if (tempPieces[26].transform.position == new Vector3(100, 0, 13) && !conditionTriggered[26])
            {
                rightPieces++;
                conditionTriggered[26] = true;
            }
            else if (tempPieces[27].transform.position == new Vector3(99, 0, 13) && !conditionTriggered[27])
            {
                rightPieces++;
                conditionTriggered[27] = true;
            }
            else if (tempPieces[28].transform.position == new Vector3(98, 0, 13) && !conditionTriggered[28])
            {
                rightPieces++;
                conditionTriggered[28] = true;
            }
            else if (tempPieces[29].transform.position == new Vector3(97, 0, 13) && !conditionTriggered[29])
            {
                rightPieces++;
                conditionTriggered[29] = true;
            }
        }

        if (rightPieces == 30)
        {
            for (int i = 0; i < rightPieces; i++)
            {
                if (Mathf.Approximately(tempPieces[i].transform.rotation.eulerAngles.y, 180f) && !conditionTriggeredRotate[i])
                {
                    conditionTriggeredRotate[i] = true;
                    rightRotate++;
                }
            }
        }

        if (rightRotate == 30 && !youWin)
        {
            hintButtonUI.SetActive(false);
            youWin = true;
            cam.transform.position = ogCamPos;
            cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x + 32.652f - 90, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
            Destroy(raftTimber);
            raftBuilt.SetActive(true);

            StartCoroutine(IntermissionMinigameEnd());
        }
    }

    IEnumerator IntermissionMinigameEnd()
    {
        yield return new WaitForSeconds(0.5f);
        charCanvas.panel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        charCanvas.charDialogue.text = "Great! This should be ready to take to the river.";
        yield return new WaitForSeconds(5f);
        charCanvas.charDialogue.text = "";
        charCanvas.panel.SetActive(false);

        move.enabled = true;
        followPlayer.enabled = true;
        SceneManager.LoadScene("Endless runner");
    }
}
