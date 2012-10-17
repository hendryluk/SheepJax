using System;
using System.Dynamic;
using System.Linq;
using Castle.DynamicProxy;

namespace SheepJax
{
    public class SheepJaxProxyGenerator
    {
        public static readonly SheepJaxProxyGenerator Instance = new SheepJaxProxyGenerator();
        private readonly ProxyGenerator _generator = new ProxyGenerator(new PersistentProxyBuilder());

        private SheepJaxProxyGenerator()
        {
        }

        public T Create<T>(Action<SheepJaxInvoke> callback)
        {
            return (T) _generator.CreateClassProxy(typeof(SheepJaxInvokable), new[] { typeof(T) }, ProxyGenerationOptions.Default,
                                                             new object[] { callback }, new JsProxyInterceptor());
        }
    }

    public class SheepJaxInvokable: DynamicObject, ISheepJaxInvokable
    {
        private readonly Action<SheepJaxInvoke> _jsInvokes;

        public SheepJaxInvokable(Action<SheepJaxInvoke> jsInvokes)
        {
            _jsInvokes = jsInvokes;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Invoke(binder.Name, args);
            result = this;
            return true;
        }

        public void Invoke(string methodName, params object[] args)
        {
            args = args.Select(arg =>
            {
                var vr = arg as ViewResultBase;
                return vr != null ? new ViewResultWrapper(vr) : arg;
            }).ToArray();
            _jsInvokes(new SheepJaxInvoke(methodName, args));
        }

        public T As<T>()
        {
            return SheepJaxProxyGenerator.Instance.Create<T>(_jsInvokes);
        }

        public dynamic Dynamic { get { return this; } }
    }

    public class JsProxyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.DeclaringType.IsAssignableFrom(typeof(SheepJaxInvokable)))
            {
                invocation.Proceed();
                return;
            }

            ((SheepJaxInvokable) invocation.Proxy).Invoke(invocation.Method.Name, invocation.Arguments);
            if (invocation.Method.ReturnType.IsAssignableFrom(invocation.Proxy.GetType()))
                invocation.ReturnValue = invocation.Proxy;
        }
    }
}