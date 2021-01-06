using UnityEngine;
using UnityEngine.UI;

public class IdleReactov : Singleton<IdleReactov>
{
    //public Text PowerText;
    public double power;


   // public Text PowerPerSecText;

    public double PowerPerSecond;


    //Production  variables
    public double [] productionUpgradeCost = new double [6];
    public double [] productionUpgradePower = new double [6];
    public int [] productionUpgradeLevel = new int [6];
    public Text [] productionUpgradeText = new Text [6];
    public Text [] productionInfo = new Text [6];
    public Text [] BuyInfo = new Text [6];
    //Cooling variables
    public double[] coolingUpgradeCost = new double[4];
    public double[] coolingUpgradePower = new double[4];
    public int[] coolingUpgradeLevel = new int[4];
    public Text[] coolingUpgradeText = new Text[4];
    public Text[] coolingInfo = new Text[4];
    public Text[] coolingBuyInfo = new Text[4];



    // Map size
    public int x_size = 10;
    public int y_size = 10;
    // Tick time
    public float tickTime = 0.1F;

    // Use conduit systems
    public bool useConduits = false;
    // Use conductor systems
    public bool useConductor = true;

    // Grid power statisctics
    private double [] PowerGeneratedOverLastSecond = new double[5];     // 0=T1, 1=T2, 2=T3, 3=T4, 4=T5                 DO NOT TOUCH, CALCULATIONS ONLY
    private double [] PowerGeneratedPerSecond = new double[6];           // 0=T1, 1=T2, 2=T3, 3=T4, 4=T5, 5=SumOfAll     TOUCH ME!!!


    
    public void Start()
    {
        Load();//Load save

        InvokeRepeating("TrackGridPower", 0, 1.0F);

    }

    public void Load() //Loading sesion
    {
        
        power = double.Parse(PlayerPrefs.GetString("power", "0"));
        productionUpgradeCost[0] = double.Parse(PlayerPrefs.GetString("productionUpgradeCost[0]", "25"));
        productionUpgradeCost[1] = double.Parse(PlayerPrefs.GetString("productionUpgradeCost[1]", "250"));
        productionUpgradeCost[2] = double.Parse(PlayerPrefs.GetString("productionUpgradeCost[2]", "3750"));
        productionUpgradeCost[3] = double.Parse(PlayerPrefs.GetString("productionUpgradeCost[3]", "75000"));
        productionUpgradeCost[4] = double.Parse(PlayerPrefs.GetString("productionUpgradeCost[4]", "150000"));
        productionUpgradePower[0] = double.Parse(PlayerPrefs.GetString("productionUpgradePower[0]", "1"));
        productionUpgradePower[1] = double.Parse(PlayerPrefs.GetString("productionUpgradePower[1]", "5"));
        productionUpgradePower[2] = double.Parse(PlayerPrefs.GetString("productionUpgradePower[2]", "50"));
        productionUpgradePower[3] = double.Parse(PlayerPrefs.GetString("productionUpgradePower[3]", "100"));
        productionUpgradePower[4] = double.Parse(PlayerPrefs.GetString("productionUpgradePower[4]", "250"));
        coolingUpgradeCost[0] = double.Parse(PlayerPrefs.GetString("coolingUpgradeCost[0]", "1000"));
        coolingUpgradeCost[1] = double.Parse(PlayerPrefs.GetString("coolingUpgradeCost[1]", "4000"));
        coolingUpgradeCost[2] = double.Parse(PlayerPrefs.GetString("coolingUpgradeCost[2]", "16000"));
        coolingUpgradeCost[3] = double.Parse(PlayerPrefs.GetString("coolingUpgradeCost[3]", "64000"));
        coolingUpgradePower[0] = double.Parse(PlayerPrefs.GetString("coolingUpgradePower[0]", "2"));
        coolingUpgradePower[1] = double.Parse(PlayerPrefs.GetString("coolingUpgradePower[1]", "8"));
        coolingUpgradePower[2] = double.Parse(PlayerPrefs.GetString("coolingUpgradePower[2]", "32"));
        coolingUpgradePower[3] = double.Parse(PlayerPrefs.GetString("coolingUpgradePower[3]", "128"));


        //Upgrades load
        productionUpgradeLevel[0] = PlayerPrefs.GetInt("productionUpgradeLevel[0]", 0);
        productionUpgradeLevel[1] = PlayerPrefs.GetInt("productionUpgradeLevel[1]", 0);
        productionUpgradeLevel[2] = PlayerPrefs.GetInt("productionUpgradeLevel[2]", 0);
        productionUpgradeLevel[3] = PlayerPrefs.GetInt("productionUpgradeLevel[3]", 0);
        productionUpgradeLevel[4] = PlayerPrefs.GetInt("productionUpgradeLevel[4]", 0);
        coolingUpgradeLevel[0] = PlayerPrefs.GetInt("coolingUpgradeLevel[0]", 0);
        coolingUpgradeLevel[1] = PlayerPrefs.GetInt("coolingUpgradeLevel[1]", 0);
        coolingUpgradeLevel[2] = PlayerPrefs.GetInt("coolingUpgradeLevel[2]", 0);
        coolingUpgradeLevel[3] = PlayerPrefs.GetInt("coolingUpgradeLevel[3]", 0);
        
    }

    public void Save() //Saving sesion
    {
        PlayerPrefs.SetString("BuildingsTileList.Instance.GetPlacedBuildings()", BuildingsTileList.Instance.GetPlacedBuildings().ToString());
        PlayerPrefs.SetString("power", power.ToString());
        PlayerPrefs.SetString("productionUpgradeCost[0]", productionUpgradeCost[0].ToString());
        PlayerPrefs.SetString("productionUpgradeCost[1]", productionUpgradeCost[1].ToString());
        PlayerPrefs.SetString("productionUpgradeCost[2]", productionUpgradeCost[2].ToString());
        PlayerPrefs.SetString("productionUpgradeCost[3]", productionUpgradeCost[3].ToString());
        PlayerPrefs.SetString("productionUpgradeCost[4]", productionUpgradeCost[4].ToString());
        PlayerPrefs.SetString("productionUpgradePower[0]", productionUpgradePower[0].ToString());
        PlayerPrefs.SetString("productionUpgradePower[1]", productionUpgradePower[1].ToString());
        PlayerPrefs.SetString("productionUpgradePower[2]", productionUpgradePower[2].ToString());
        PlayerPrefs.SetString("productionUpgradePower[3]", productionUpgradePower[3].ToString());
        PlayerPrefs.SetString("productionUpgradePower[4]", productionUpgradePower[4].ToString());


        PlayerPrefs.SetInt("productionUpgradeLevel[0]", productionUpgradeLevel[0]);
        PlayerPrefs.SetInt("productionUpgradeLevel[1]", productionUpgradeLevel[1]);
        PlayerPrefs.SetInt("productionUpgradeLevel[2]", productionUpgradeLevel[2]);
        PlayerPrefs.SetInt("productionUpgradeLevel[3]", productionUpgradeLevel[3]);
        PlayerPrefs.SetInt("productionUpgradeLevel[4]", productionUpgradeLevel[4]);

    }

    public void Update() //Main void
    {

       

        //Power per second
        PowerPerSecond = PowerGeneratedPerSecond[5];

        //Converting numbers in to shorter type of writing
        

        /*
        if (power > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(power))));
            var mantissa = (power / System.Math.Pow(10, exponent)); 
            PowerText.text = "Power: " + mantissa.ToString("F2") + "e" + exponent;
        }
        else
            PowerText.text = "Power: " + power.ToString("F0");

        if (PowerPerSecond > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(PowerPerSecond))));
            var mantissa = (PowerPerSecond / System.Math.Pow(10, exponent));
            PowerPerSecText.text = "Power/s: " + mantissa.ToString("F2") + "e" + exponent;
        }
        else
            PowerPerSecText.text = "Power/s: " + PowerPerSecond.ToString("F0");
            */

        
        string[] productionUpgradeCostString = new string [6];
        for (int x = 0;x<5; x++)
        {
            if (productionUpgradeCost[x] > 1000)
            {
                var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(productionUpgradeCost[x]))));
                var mantissa = (productionUpgradeCost[x] / System.Math.Pow(10, exponent));
                productionUpgradeCostString[x] = mantissa.ToString("F2") + "e" + exponent;
            }
            else
                productionUpgradeCostString[x] = productionUpgradeCost[x].ToString("F0");
        }
        string[] coolingUpgradeCostString = new string[4];
        for (int x = 0; x < 4; x++)
        {
            if (coolingUpgradeCost[x] > 1000)
            {
                var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(coolingUpgradeCost[x]))));
                var mantissa = (coolingUpgradeCost[x] / System.Math.Pow(10, exponent));
                coolingUpgradeCostString[x] = mantissa.ToString("F2") + "e" + exponent;
            }
            else
                coolingUpgradeCostString[x] = coolingUpgradeCost[x].ToString("F0");
        }



        //Increase of power (money)
        power += PowerPerSecond * Time.deltaTime;
        //Save of session
        Save();
    }

    //Reset everything for Prestige





    //Buttons to Upgrade things

    public void BuyProductionUpgrade(int x)
    {
        if (power >= productionUpgradeCost[x])
        {
            productionUpgradeLevel[x]++;
            power -= productionUpgradeCost[x];
            productionUpgradeCost[x] *= (1.50+(x*0.1));
            
        }
    }
    public void BuyCoolingUpgrade(int x)
    {
        if (power >= coolingUpgradeCost[x])
        {
            coolingUpgradeLevel[x]++;
            power -= coolingUpgradeCost[x];
            coolingUpgradeCost[x] *= (1.50 + (x * 0.1));

        }
    }

    public void AddPower(double gain, int tier)
    {
        power += gain;
        PowerGeneratedOverLastSecond[tier] += gain;
    }

    private void TrackGridPower()
    {
        PowerGeneratedPerSecond[5] = 0;
        for (int i=0; i<5; i++)
        {
            PowerGeneratedPerSecond[i] = PowerGeneratedOverLastSecond[i];
            PowerGeneratedOverLastSecond[i] = 0;
            PowerGeneratedPerSecond[5] += PowerGeneratedPerSecond[i];
        }
    }

    public bool CheckIfYouAreBroke(double price)                    //Checks if you can afford to buy building
    {
        if (power > price)
        {
            power -= price;
            return true;
        }
        return false;
    }
}
