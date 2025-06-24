using System;

namespace RestSharpAPIAutomation.Utilities
{
    public class RequestBuilder<T> where T : class, new()
    {
        private readonly T _instance;

        public RequestBuilder(T baseData)
        {
            _instance = baseData;
        }

        public RequestBuilder<T> With(Action<T> modifier)
        {
            modifier(_instance);
            return this;
        }

        public T Build() => _instance;
    }
}
