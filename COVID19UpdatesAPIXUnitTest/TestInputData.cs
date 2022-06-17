using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace COVID19UpdatesAPIXUnitTest
{
    class TestInputData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "Canada", String.Empty, default(DateTime) };
            yield return new object[] { "US", String.Empty, default(DateTime) };
            yield return new object[] { "Brazil", String.Empty, default(DateTime) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
