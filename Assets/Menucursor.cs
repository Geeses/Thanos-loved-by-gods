using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;

public class Menucursor : MonoBehaviour
{
    private int playerID = 0;
    private Player player;
    private Rigidbody2D rbb;
    private Vector2 moveCursor;
    private MenuManager mangae;
    public GameObject Pausenmenü;
    public MainMenuScritable menu;
	public Sprite[] sprites;
/*	public GameObject waldg;
	public GameObject tempelg;
	public GameObject bergg;
	public GameObject bogeng;
	public GameObject gebaeudeg;
	public GameObject bogeng1;
	private SpriteRenderer wald;
	private SpriteRenderer tempel;
	private SpriteRenderer berg;
	private SpriteRenderer bogen;
	private SpriteRenderer gebeaude;
	private SpriteRenderer bogen1;
*/

    public float cursorSpeed;
    // Use this for initialization
    void Start()
    {
	/*	wald = waldg.GetComponent<SpriteRenderer> ();
		tempel = tempelg.GetComponent<SpriteRenderer> ();
		berg = bergg.GetComponent<SpriteRenderer> ();
		bogen = bogeng.GetComponent<SpriteRenderer> ();
		gebeaude = gebaeudeg.GetComponent<SpriteRenderer> ();
		bogen1 = bogeng1.GetComponent<SpriteRenderer> ();
*/
		player = ReInput.players.GetPlayer(playerID);
        rbb = GetComponent<Rigidbody2D>();
        mangae = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
		
        cursorSpeed = menu.cursorspeed;
                    if (Pausenmenü.activeInHierarchy == false)
        {
            Eventclick();
            moveCursor.x = player.GetAxis("CursorHorizontal");
            moveCursor.y = player.GetAxis("CursorVertical");
            MoveCursor();
        }
    }
    private void MoveCursor()
    {
        rbb.velocity = new Vector2(moveCursor.x * cursorSpeed, moveCursor.y * cursorSpeed); // Geschwindigkeit auf RB übertragen
    }
    
    public void Eventclick()
    {
		if (player.GetButtonDown ("selectMenuPoint")) {
        
            

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
            Debug.DrawRay(transform.position, Vector2.zero, Color.green);


			switch (hit.collider.tag){

		case "NewGame":
			
				NewGame();
			
			//	gebeaude.sprite = wald.sprite;
				Debug.Log("NewGame");

				break;
			case "Options":
				Debug.Log("op");
				Settings();
				break;
			case "Exit":
				Debug.Log("exit");
				ExitGame();
				break;
			case "TempleLevel":
				SceneManager.LoadScene(1);
				break;
			case "WaldLevel":
				SceneManager.LoadScene(1);
				break;
			case "SchneeLevel":
				SceneManager.LoadScene(1);
				break;
			default:
				break;
		}
	}
		}

        
    


    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {

        Pausenmenü.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    
}
    

   
