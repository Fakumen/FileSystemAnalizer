using System;
using System.Linq;

namespace FileSystemAnalyzer.Domain
{
    public class SizeData
    {
        public enum ByteUnit : long
        {
            Byte = 1,
            Kilobyte = Byte << 10,
            Megabyte = Byte << 20,
            Gigabyte = Byte << 30,
            Terabyte = Byte << 40
        }

        public long SizeInBytes { get; }

        public ByteUnit BestFittingUnits { get; }

        public double GetInUnits(ByteUnit units) => (double)SizeInBytes / (long)units;

        public SizeData(long sizeInBytes)
        {
            if (sizeInBytes < 0)
                throw new ArgumentException();
            SizeInBytes = sizeInBytes;
            BestFittingUnits = CalculateBestFittingUnits();
        }

        public override string ToString()
            => $"{GetInUnits(BestFittingUnits):f1} {BestFittingUnits}";

        private ByteUnit CalculateBestFittingUnits()
        {
            if (SizeInBytes == 0)
                return ByteUnit.Byte;
            return new[] { ByteUnit.Byte, ByteUnit.Kilobyte, ByteUnit.Megabyte, ByteUnit.Gigabyte, ByteUnit.Terabyte }
            .Where(byteUnit => SizeInBytes >= (long)byteUnit)
            .Max();
        }
    }
}