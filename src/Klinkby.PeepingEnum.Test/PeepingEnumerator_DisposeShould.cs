using Moq;
using System.Collections.Generic;
using Xunit;

namespace Klinkby.PeepingEnum.Test
{
    [Trait("type", "unit")]
    public class PeepingEnumerator_DisposeShould
    {
        [Fact]
        public void Call_UnderlyingDispose()
        {
            var tor = new Mock<IEnumerator<int>>();
            tor.Setup(x => x.Dispose()).Verifiable();
            var able = new Mock<IEnumerable<int>>();
            able.Setup(x => x.GetEnumerator()).Returns(tor.Object);
            using (var dut = able.Object.Peep().GetEnumerator())
            { 
                // ILB
            }
            tor.Verify();        
        }
    }
}