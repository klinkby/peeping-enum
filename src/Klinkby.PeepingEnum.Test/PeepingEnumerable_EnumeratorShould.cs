using System.Collections;
using System.Linq;
using Xunit;

namespace Klinkby.PeepingEnum.Test
{
    [Trait("type", "unit")]
    public class PeepingEnumerable_EnumeratorShould
    {
        const int Count = 3;
        [Fact]
        public void AnyBeforeEnum_EnumerateAll()
        {
            var dut = Enumerable.Range(0, Count).Peep();
            Assert.True(dut.Any);
            int j = 0;
            foreach (var i in dut)
            {
                Assert.Equal(j, i);
                j++;
            }
            Assert.Equal(Count, j);
        }

        [Fact]
        public void AnyInBetweenEnum_EnumerateAll()
        {
            var dut = Enumerable.Range(0, Count).Peep();
            int j = 0;
            foreach (var i in dut)
            {
                Assert.Equal(j, i);
                j++;
                Assert.True(dut.Any);
            }
            Assert.Equal(Count, j);
        }

        [Fact]
        public void AnyAfterEnum_EnumerateAll()
        {
            var dut = Enumerable.Range(0, Count).Peep();
            int j = 0;
            foreach (var i in dut)
            {
                Assert.Equal(j, i);
                j++;
            }
            Assert.Equal(Count, j);
            Assert.True(dut.Any);
        }

        [Fact]
        public void NonGeneric_Enumerate()
        {
            var dut = Enumerable.Range(0, Count).Peep();
            int j = 0;
            foreach (object? obj in (IEnumerable)dut)
            {
                Assert.Equal(j, (int)obj);
                j++;
            }
            Assert.Equal(Count, j);
        }
    }
}