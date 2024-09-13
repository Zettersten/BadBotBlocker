using System.Net;
using System.Net.Sockets;

namespace BadBotBlocker;

internal static class IPAddressExtensions
{
    internal static bool IsInSubnet(this IPAddress address, IPAddress subnetAddress, int prefixLength)
    {
        if (address.AddressFamily != subnetAddress.AddressFamily)
        {
            return false;
        }

        if (prefixLength < 0)
        {
            return false;
        }

        if (address.AddressFamily == AddressFamily.InterNetwork)
        {
            if (prefixLength > 32)
            {
                return false;
            }

            uint mask = uint.MaxValue << (32 - prefixLength);
            uint ipAddr = BitConverter.ToUInt32(address.GetAddressBytes().Reverse().ToArray(), 0);
            uint subnetAddr = BitConverter.ToUInt32(subnetAddress.GetAddressBytes().Reverse().ToArray(), 0);

            return (ipAddr & mask) == (subnetAddr & mask);
        }
        else if (address.AddressFamily == AddressFamily.InterNetworkV6)
        {
            if (prefixLength > 128)
            {
                return false;
            }

            var addressBytes = address.GetAddressBytes();
            var subnetBytes = subnetAddress.GetAddressBytes();

            int fullBytes = prefixLength / 8;
            int remainingBits = prefixLength % 8;

            for (int i = 0; i < fullBytes; i++)
            {
                if (addressBytes[i] != subnetBytes[i])
                {
                    return false;
                }
            }

            if (remainingBits > 0)
            {
                byte mask = (byte)(0xFF << (8 - remainingBits));

                if ((addressBytes[fullBytes] & mask) != (subnetBytes[fullBytes] & mask))
                {
                    return false;
                }
            }

            return true;
        }
        else
        {
            throw new NotSupportedException("Address family not supported");
        }
    }
}
