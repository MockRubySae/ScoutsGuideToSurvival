
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlashBang : MonoBehaviour
{
    public GameObject flashbang;

    public void Flash()
    {
        flashbang.SetActive(true);
    }
    public void MainFlashBang(int level)
    {
        SceneManager.LoadScene(level);
    }
}
