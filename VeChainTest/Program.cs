using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Web3;
using Org.BouncyCastle.Math;
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
            var web3 = new Web3("https://mainnet.infura.io/v3/7238211010344719ad14a89db874158c");

            // return ERC1155 tokens on Ethereum
            // Simple conversion to 721 contracts
            // See http://codegen.nethereum.com/ for generating C# code for solidity contract functions.
            // (choose Smart Contract: Query ERC721 Balance from the samples)
            //
            // Nethereum 721 equivalent:
            //
            /* 
        
        // The ERC721 contract we will be querying
        var erc721TokenContractAddress = "0x6EbeAf8e8E946F0716E6533A6f2cefc83f60e8Ab"; 
        
        // Example 1. Get balance of an account. This is the count of tokens that an account 
        // has from a specified contract (in this case "Gods Unchained").  
        var accountWithSomeTokens = "0x5a4d185c590c5815a070ed62c278e665d137a0d9";
        // You can check the token balance of the above account on etherscan:
        // https://etherscan.io/token/0x6ebeaf8e8e946f0716e6533a6f2cefc83f60e8ab?a=0x5a4d185c590c5815a070ed62c278e665d137a0d9#inventory
        
        // Send query to contract, to find out how many tokens the owner has
        var balanceOfMessage = new BalanceOfFunction() { Owner = holderAddress };
        var queryHandler = web3.Eth.GetContractQueryHandler<BalanceOfFunction>();
        var balance = await queryHandler
            .QueryAsync<BigInteger>(erc721TokenContractAddress, balanceOfMessage)
            .ConfigureAwait(false);
        Console.WriteLine($"Address: {holderAddress} holds: {balance}");
             */

            // Nethereum 1155 equivalent:
            /*
             *                 var contractHandler = web3.Eth.GetContractHandler(tokenAddress);
                            var balanceOfBatchFunction = new BalanceOfBatchFunction();
                            balanceOfBatchFunction.Owners = new List<string>();
                            balanceOfBatchFunction.Ids = new List<BigInteger>();

                            foreach (var user in UserAddresses)
                            {
                                foreach (var tokenDef in TokenDefinitions)
                                {
                                    balanceOfBatchFunction.Owners.Add(user);
                                    balanceOfBatchFunction.Ids.Add(tokenDef.TokenID);
                                }
                            }

                            var balanceOfBatchFunctionReturn = await contractHandler.QueryAsync<BalanceOfBatchFunction, List<BigInteger>>(balanceOfBatchFunction);

             */
            throw new NotImplementedException();
        }

        private static bool VerifyAddressFromSignedMessage(byte[] Message, byte[] Signature, string Address)
        {
            var recoveredAddress = Org.VeChain.Thor.Devkit.Cry.Secp256k1.RecoverPublickey(Message, Signature);
            return recoveredAddress.ToString().ToLowerInvariant() == Address.ToLowerInvariant();
        }
    }

    public partial class BalanceOfBatchFunction : BalanceOfBatchFunctionBase { }

    [Function("balanceOfBatch", "uint256[]")]
    public class BalanceOfBatchFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "_owners", 1)]
        public virtual List<string> Owners { get; set; } = new List<string>();
        [Parameter("uint256[]", "_ids", 2)]
        public virtual List<BigInteger> Ids { get; set; } = new List<BigInteger>();
    }
}
