using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerIntro : MonoBehaviour
{
    [SerializeField] AnimationClip openingAnimClip;
    [SerializeField] float crawlSpeed;

    [SerializeField] GameObject BG_01;
    [SerializeField] GameObject BG_02;
    [SerializeField] GameObject BG_03;

    InputAction crawl;
    Animator animator;

    float timer = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        crawl = InputSystem.actions.FindAction("move");
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;



        if (timer > openingAnimClip.length)
        {
            float xinput = crawl.ReadValue<Vector2>().normalized.x;
            Vector3 direction = Vector3.zero;
            direction.x = xinput;

            Debug.Log(direction.x);

            if(transform.position.x > -8.64f || direction.x > 0.0f)
            {
                animator.SetBool("crawl", direction.magnitude > 0.0f);
                transform.Translate(direction * crawlSpeed * Time.deltaTime);
                BG_01.transform.Translate(direction * -crawlSpeed / 4  * Time.deltaTime);
                BG_02.transform.Translate(direction * -crawlSpeed / 8  * Time.deltaTime);
                BG_03.transform.Translate(direction * -crawlSpeed / 16 * Time.deltaTime);
            }
            else
            {
                animator.SetBool("crawl", false);
            }

            if (transform.position.x > 8.34f)
                SceneManager.LoadScene(9);

        }


    }
}
