using System;
using UnityEngine;
using UnityEngine.Purchasing;


public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager instance;

    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    //Products
    private string buyExtraLives = "buy_extra_lives";
    private string buyMoreSouls = "buy_more_souls";
    private string buyTower1 = "buy_tower1";

    [SerializeField] IntVariable purchasedHearts;
    [SerializeField] IntVariable purchasedSouls;
    [SerializeField] BoolVariable tower1Purchased;

    //************************** Adjust these methods **************************************
    public void InitializePurchasing()
    {
        if (IsInitialized()) { return; }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Step 2 choose if your product is a consumable or non consumable
        builder.AddProduct(buyExtraLives, ProductType.Consumable);
        builder.AddProduct(buyMoreSouls, ProductType.NonConsumable);
        builder.AddProduct(buyTower1, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    //Step 3 Create methods
    public void BuyExtraLives()
    {
        BuyProductID(buyExtraLives);
    }
    public void BuyMoreSouls()
    {
        BuyProductID(buyMoreSouls);
    }
    public void BuyTower1()
    {
        BuyProductID(buyTower1);
    }



    //Step 4 modify purchasing
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, buyExtraLives, StringComparison.Ordinal))
        {
            purchasedHearts.Value += 10;
            Debug.Log("purchase extra lives successful");
            Debug.Log("total hearts = " + purchasedHearts.Value);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, buyMoreSouls, StringComparison.Ordinal))
        {
            purchasedSouls.Value += 2;
            Debug.Log("purchase more souls successful");
            Debug.Log("total purchased souls = " + purchasedSouls.Value);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, buyTower1, StringComparison.Ordinal))
        {
            tower1Purchased.Value = true;
            Debug.Log("purchase new tower 1 successful");
            Debug.Log("tower1purchased = " + tower1Purchased.Value);
        }
        else
        {
            Debug.Log("Purchase Failed");
        }
        return PurchaseProcessingResult.Complete;
    }










    //**************************** Dont worry about these methods ***********************************
    private void Awake()
    {
        TestSingleton();
    }

    void Start()
    {
        if (m_StoreController == null) { InitializePurchasing(); }
    }

    private void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) => {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}