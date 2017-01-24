using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class LoadSceneOnClick : MonoBehaviour
{

    public Image whitePanel;
    public void LoadByIndex(int sceneIndex)
    {
        StartCoroutine(LoadScene(sceneIndex));
        
    }

    public IEnumerator LoadScene(int index)
    {
        whitePanel.transform.DOScale(0, 0);
        whitePanel.transform.DOScale(1, 0.7f);
        whitePanel.DOFade(1, 0.7f);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit ();
        #endif
    }
}
