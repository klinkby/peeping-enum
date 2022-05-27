using System.Linq;
using Xunit;

namespace Klinkby.PeepingEnum.Test
{
    [Trait("type", "unit")]
    public class PeepingEnumerable_EventsShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void Enumeration_RaiseStartEnd(int count)
        {
            var dut = Enumerable.Range(0, count).Peep();
            var started = false;
            var ended = false;
            dut.StartOfEnumeration += (sender, e) =>
            {
                started = true;
                Assert.Equal(count != 0, e.Any);
                Assert.False(ended);
            };
            dut.EndOfEnumeration += (sender, e) =>
            {
                ended = true;
                Assert.True(started);
            };
            foreach (var x in dut)
            {
                Assert.True(started);
                Assert.False(ended);
            }
            Assert.True(ended);
        }
    }
}