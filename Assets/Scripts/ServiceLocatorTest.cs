using UnityEngine;

public class ServiceLocatorTest : MonoBehaviour
{
    private IServiceLocator<IService> _serviceLocator;

    private void Awake()
    {
        _serviceLocator = new ServiceLocator<IService>();
    }

    private void Start()
    {
        _serviceLocator.Register(new LocalizationService("Localization Service"));
        _serviceLocator.Register(new PurchaseService("Purchase Service"));
        
        Debug.Log(_serviceLocator.Get<LocalizationService>() == null);
        Debug.Log(_serviceLocator.Get<PurchaseService>() == null);
    }
}
