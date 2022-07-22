using DG.Tweening;
using UnityEngine;

public class UndergroundCollision : MonoBehaviour
{
    // [SerializeField] public Image progressFillImage;
    public void OnTriggerEnter(Collider other)
    {
        if (!Game.isGameover)
        {
            string tag = other.tag;

            if (tag.Equals("Object"))
            {
                Level.Instance.objectsInScene--;
                UIManager.Instance.UpdateLevelProgress();

                Magnet.Instance.RemoveFromMagnetField(other.attachedRigidbody);

                Destroy(other.gameObject);

                // check if win
                if (Level.Instance.objectsInScene == 0)
                // no more objects to collect
                {
                    UIManager.Instance.ShowLevelCompleteUi();
                    Level.Instance.PlayWinFx();
                    Invoke("NextLevel", 2f);
                }
            }
            if (tag.Equals("Obstacle"))
            {
                Game.isGameover = true;
                Camera.main.transform
                    .DOShakePosition(1f, 2f, 20, 90)
                    .OnComplete(() =>
                    {
                        Level.Instance.RestartLevel();
                    });
            }
        }

    }

    public void NextLevel()
    {
        Level.Instance.LoadNextLevel();
    }

}
