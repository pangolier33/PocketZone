using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.UI
{
    public class LoadScene : MonoBehaviour
    {
        [SerializeField] private GameObject LoadingScreen;
        [SerializeField] private int _scene = 0;

        public void Loading()
        {
            LoadingScreen.SetActive(true);
            StartCoroutine(LoadAsync());
        }

        private IEnumerator LoadAsync()
        {
            AsyncOperation loadAsync = SceneManager.LoadSceneAsync(_scene);
            loadAsync.allowSceneActivation = false;

            while (!loadAsync.isDone)
            {
                if (loadAsync.progress >= 0.9f && !loadAsync.allowSceneActivation)
                {
                    yield return new WaitForSeconds(2f);
                    loadAsync.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}
