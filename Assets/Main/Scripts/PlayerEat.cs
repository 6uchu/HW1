using UnityEngine;
using UnityEngine.SceneManagement; // 추가

public class PlayerEat : MonoBehaviour
{
    public float size = 1f;
    public float growAmount = 0.05f;

    void OnTriggerEnter(Collider other)
    {
        Animal animal = other.GetComponent<Animal>();

        if (animal == null) return;

        if (size >= animal.size)
        {
            Eat(animal);
        }
    }

    void Eat(Animal animal)
    {
        size += growAmount * animal.size;
        transform.localScale = Vector3.one * size;

        // 이름 체크
        if (animal.gameObject.name == "DuckWhite")
        {
            SceneManager.LoadScene("Ending");
        }

        Destroy(animal.gameObject);
    }
}