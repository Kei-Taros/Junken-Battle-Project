using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToTitle : MonoBehaviour
{
    public void PushThisButton()
    {
        SceneManager.LoadScene("Title");
    }


}