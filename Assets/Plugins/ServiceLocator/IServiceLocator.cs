namespace Plugins.ServiceLocator
{
    public interface IServiceLocator<T>
    {
        public TS Register<TS>(TS service) where TS : T;

        public void Unregister<TS>(TS service) where TS : T;

        public TS Get<TS>() where TS : T;

        public bool TryGet<TS>(out TS service) where TS : T;
    }
}