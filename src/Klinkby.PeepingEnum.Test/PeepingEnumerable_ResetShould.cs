using System.Linq;
using Xunit;

namespace Klinkby.PeepingEnum.Test
{
    [Trait("type", "unit")]
    public class PeepingEnumerable_ResetShould
    {
        const int Count = 3;
        [Fact]
        public void Repeat_EnumerateAll()
        {
            var peeper = Enumerable.Range(0, Count).ToArray().Peep();
            var dut = peeper.GetEnumerator();
            Assert.True(peeper.Any);
            Assert.True(dut.MoveNext());
            dut.Reset();
            Assert.True(dut.MoveNext());
            Assert.Equal(0, dut.Current);
            Assert.True(dut.MoveNext());
            Assert.True(dut.MoveNext());
            Assert.False(dut.MoveNext());
        }
    }
}