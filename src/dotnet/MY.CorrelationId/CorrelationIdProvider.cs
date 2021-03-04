using System;

namespace MY.CorrelationId
{
    public class CorrelationIdProvider : ICorrelationIdProvider
    {
        private readonly string _correlationId;

        public CorrelationIdProvider()
        {
            _correlationId = Guid.NewGuid().ToString();
        }

        public string GetCorrelationId()
        {
            return _correlationId;
        }
    }
}
