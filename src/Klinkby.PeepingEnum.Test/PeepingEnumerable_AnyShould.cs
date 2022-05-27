using System.Linq;
using Xunit;

namespace Klinkby.PeepingEnum.Test
{
    [Trait("type", "unit")]
    public class PeepingEnumerable_AnyShould
    {
        const int Count = 0;
        [Fact]
        public void EnumEmpty_ReturnFalse()
        {
            var dut = Enumerable.Range(0, Count).Peep();
            Assert.False(dut.Any);
            int j = 0;
            foreach (var i in dut)
            {
                j++;
            }
            Assert.False(dut.Any);
            Assert.Equal(Count, j);
        }
    }
}