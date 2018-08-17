using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AttackController : MonoBehaviour {

    public List<UnityEvent> AttackMethods;
   

    //Liste mit Attacken über Inspector
    public List<Attack_ScriptableObject> Attacks;

    //Prefab für das CoolDown-/AttackSymbol
    public GameObject AttackSymbolPref;
    public GameObject PanelToAttachTheSymbols;

    public GameObject Collector;
    
    private List<GameObject> Symbols;
    private List<IAttack> IAttacks;


    //Einschub für Stamina
    public Image StaminaBar;
    private float maxStamina = 100f;
    private float currStamina = 0f;
    private float delta;
    private float elsedelta;
    private bool UsingStamina =false;

    private Color EndColor = new Color(0, 0, 0, 196);
    private Color StartColor = new Color(129, 21, 21, 196);
    private Color StaminaColor = new Color(20, 100, 240, 190);



    public void Start()
    {
        //Dictionary<string, Attack_I> Attack_D = new Dictionary<string, Attack_I>();
        delta = Time.fixedTime;
        elsedelta = delta;

        Symbols = new List<GameObject>();
        IAttacks = new List<IAttack>();

        Image[] images;
        int i = 0;
        float padding = 0;
        
        foreach (var Attack in Attacks)
        {
            
            var tempTransform = PanelToAttachTheSymbols.transform.Find("AttackTransform"+(i+1)).transform;
            GameObject AttackSymbol = Instantiate(AttackSymbolPref, tempTransform, false);
            Symbols.Add(AttackSymbol);
            

            var IAtt = new IAttack(Attack);
            IAtt.SetAttackSymbol(AttackSymbol);
            IAttacks.Add(IAtt);
            
            images = Symbols[i].GetComponentsInChildren<Image>();

            foreach (var Image in images)
            {
                //für jedes Image wird das Sprite geändert
                Image.sprite = IAtt.GetSprite();


                //das CDSFill wird letztlich als Symbol abgelegt 
                if (Image.name == "CDSFill") IAtt.SetImage(Image);
            }
            
            i++;padding += 100;
        }
        //Attacks.Clear();

    }
    public void DoAttack(string AttackMethodName)
    {
        bool A = IAttacks.Exists((IAttack att) => att.MethodName == AttackMethodName);
        bool B = AttackMethods.Exists((UnityEvent e) => e.GetPersistentMethodName(0) == AttackMethodName);
        
        if (A & B)
        {
            var Att = IAttacks.Find((IAttack att) => att.MethodName == AttackMethodName);
            
            if (Att.IsCooledDown()&&Att.IsAchieved())
            {
                if (StaminaBar)
                {
                    if (currStamina > 0f)
                    {
                        //mache Attacke
                        StartCooldown(Att);
                        AttackMethods.Find((UnityEvent e) => e.GetPersistentMethodName(0) == AttackMethodName).Invoke();

                        delta = Time.fixedTime - delta;

                        if (delta > 1f)
                        {
                            DecreaseStamina(Att.GetStaminaUsage());

                        }
                    }
                }
                else
                {
                    StartCooldown(Att);
                    AttackMethods.Find((UnityEvent e) => e.GetPersistentMethodName(0) == AttackMethodName).Invoke();
                }
                
                
            }

        }


        else Debug.Log("Method not found " + "Scriptable exists: " + A + "Method exists: " + B);

    }

    public bool SearchAttack(string AttackMethodName)
    {
        return IAttacks.Exists((IAttack att) => att.MethodName == AttackMethodName);

    }

    public IAttack GetAttack(string AttackMethodName)
    {
        IAttack retVal = null;

        bool A = IAttacks.Exists((IAttack att) => att.MethodName == AttackMethodName);
        bool B = AttackMethods.Exists((UnityEvent e) => e.GetPersistentMethodName(0) == AttackMethodName);

        if (A & B)
        {
            retVal = IAttacks.Find((IAttack att) => att.MethodName == AttackMethodName);
        }

        return retVal;
    }

    void FixedUpdate()
    {
        int AchievementScore = (int)Collector.GetComponent<Collect>().GetActualScore();
       
        //für jede Attacke

        foreach (var IAttack in IAttacks)
        {   //wenn aus dem jeweilige Attack_Scriptable started=true, dann beginne bei dem jeweiligen symbol mit overlay 
            GreyOut(IAttack, !IAttack.IsAchieved());

            if (IAttack.IsStarted()) SetOverlay(IAttack);

            if (AchievementScore >= IAttack.GetAchievementLevel()) IAttack.SetAchieved(true);

            IAttack.UpdateMethod();
        }

        if (StaminaBar)
        {
            if(!UsingStamina) IncreaseStaminaPerSecond();
            
            SetStaminaBar();
        }
        

    }

    public float GetCurrentStamina()
    {
        return currStamina;
    }

    public void SetUsingStamina(bool b)
    {
        UsingStamina = b;
    } 

    void IncreaseStaminaPerSecond()
    {
        elsedelta = Time.fixedTime - elsedelta;

        if ((currStamina < 100f) && elsedelta > 1f)
        {
            IncreaseStamina(0.5f/*StaminaIncreaseAmountPerSecond*/);
            
        }
    }

    public void DecreaseStamina(float amount)
    {
        currStamina -= amount;
        currStamina = (currStamina < 0f) ? 0f : currStamina;
        
    }

    public void IncreaseStamina(float amount)
    {
        currStamina += amount;
        currStamina = (currStamina > 100f) ? 100f : currStamina;
        
    }

    void SetStaminaBar()
    {

        StaminaBar.fillAmount = currStamina / maxStamina;

        float lerp = StaminaBar.fillAmount * 0.05f;

        StaminaBar.color = Color.Lerp(EndColor, StaminaColor, lerp);
    }

    public void GreyOut(IAttack att, bool b)
    {
        if (b)
        {

            att.GetAttackSymbol().SetActive(false);
        }
        else
        {
            att.GetAttackSymbol().SetActive(true);
            //das SperrImage ausblenden
            att.GetAttackSymbol().transform.parent.Find("Default").gameObject.SetActive(false);

        }
    }

    public void StartCooldown(IAttack att)
    {
        StartRecharge(att);
        att.SetStarted(true);
        att.SetCooledDown(false);
    }

    public void StopCooldown(IAttack att)
    {
        att.SetStarted(false);
        att.SetCooledDown(true);
        EndRecharge(att);
    }


    public void StartRecharge(IAttack att)
    {
        att.SetRechargeEnd(Time.time + att.GetCooldown());
        att.GetSymbol().fillAmount = 1.0f;
    }

    public void SetOverlay(IAttack att)
    {
        att.GetSymbol().fillAmount = (att.GetRechargeEnd() - Time.time) / att.GetCooldown();
        float lerp = (1 - att.GetSymbol().fillAmount)*0.02f;
      
        att.GetSymbol().color = Color.Lerp(EndColor, StartColor, lerp);

        if (att.GetRechargeEnd() <= Time.time) StopCooldown(att);

    }

    public void EndRecharge(IAttack att)
    {
        att.GetSymbol().fillAmount = 0.0f;

    }

    

    public class IAttack {

        private Attack_ScriptableObject Att = null;
        public string MethodName;
        private float CD;
        private float DMG;
        private float DMGDelay;
        private Sprite Sprite;
        private bool started;
        private bool isCooledDown;
        private Image Symbol;
        private float rechargeEnd;
        private bool achieved;
        private float AchievementLevel;
        private GameObject AttackSymbol = null;
        private float StaminaUsage;

        public IAttack(Attack_ScriptableObject att)
        {
            this.Att = att;
            this.achieved = att.achieved;
            this.MethodName = att.AttackMethodName;
            this.CD = att.CooldownTime;
            this.DMG = att.Damage;
            this.DMGDelay = att.DelayTilDamage;
            this.Sprite = att.AttackSprite;
            this.started = false;
            this.isCooledDown = true;
            this.AchievementLevel = att.AchievementLevel;
            this.StaminaUsage = att.StaminaUsage;
        }

        public void UpdateMethod()
        {
            this.CD = Att.CooldownTime;
            this.DMG = Att.Damage;
            this.DMGDelay = Att.DelayTilDamage;
        }

        public void SetAttackSymbol(GameObject attacksymbol)
        {
            AttackSymbol = attacksymbol;
        }

        public GameObject GetAttackSymbol()
        {
            return AttackSymbol;
        }

        public float GetAchievementLevel()
        {
            return AchievementLevel;
        }

        public bool IsAchieved()
        {
            return achieved;
        }

        public void SetAchieved(bool a) {
            achieved = a;
        }

        public string GetMethodName()
        {

            return MethodName;
        }

        public float GetCooldown()
        {
            return CD;
        }

        public float GetDamage()
        {
            return DMG;
        }

        public float GetDamageDelay()
        {
            return DMGDelay;
        }

        public Sprite GetSprite()
        {
            return Sprite;
        }

        public void SetSprite(Sprite sprite)
        {
            this.Sprite = sprite;
        }

        public float GetRechargeEnd()
        {
            return rechargeEnd;
        }

        public void SetRechargeEnd(float f)
        {
            rechargeEnd = f;
        }

        public bool IsCooledDown()
        {
            return isCooledDown;
        }

        public void SetCooledDown(bool b)
        {
            isCooledDown = b;
        }

        public bool IsStarted()
        {
            return started;
        }

        public void SetStarted(bool b)
        {
            started = b;
        }

        public Image GetSymbol()
        {
            return Symbol;
        }

        public void SetImage(Image img)
        {
            Symbol = img;
        }

        public float GetStaminaUsage()
        {
            return StaminaUsage;
        }

    }

    
}
