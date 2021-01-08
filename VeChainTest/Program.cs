using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeChainTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (VerifyAddressFromSignedMessage(new byte[1], new byte[1], "0x00000"))
            {
                // Signature verification OK
            }

            string tokenAddress = "";
            string holderAddress = "";

            var tokens = GetHeldTokensForAddress(tokenAddress, holderAddress);

            string recipientAddress = "";
            var mintedToken = MintTokenForAddress(tokenAddress, recipientAddress);


        }

        private static object MintTokenForAddress(string tokenAddress, string recipientAddress)
        {
            throw new NotImplementedException();
        }

        private static List<string> GetHeldTokensForAddress(string tokenAddress, string holderAddress)
        {
            throw new NotImplementedException();
        }

        private static bool VerifyAddressFromSignedMessage(byte[] Message, byte[] Signature, string Address)
        {
            var recoveredAddress = Org.VeChain.Thor.Devkit.Cry.Secp256k1.RecoverPublickey(Message, Signature);
            return recoveredAddress.ToString().ToLowerInvariant()==Address.ToLowerInvariant();
        }
    }
}
