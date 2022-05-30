using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class BlockData
    {
        public string _hash { get; private set; }
        public string _previous_hash { get; set; }
        public DateTime _date_time { get; set; }
        public long _proof_of_ownership { get; set; }
        public string _from { get; set; }
        public int _amount { get; set; }
        public string _to { get; set; }

        public BlockData PrepareBlock(DateTime mainTimeStamp, PurchaseData purchaseDatas, long proofOfOwnership, string previousHash)
        {
            BlockData block = new BlockData();
            block._from = purchaseDatas.From;
            block._amount = purchaseDatas.Amount;
            block._to = "E-Bid Auction Hull, UK";
            block._date_time = purchaseDatas.DateTime;
            block._previous_hash = previousHash;
            block._hash = Generate_Hash(block._from, block._amount, mainTimeStamp);
            proofOfOwnership = proofOfOwnership + 1;
            block._proof_of_ownership = proofOfOwnership;
            return block;
            
        }

        public string Generate_Hash(string from, int amount, DateTime mainTimeStamp)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string combined_raw_data = _previous_hash + _date_time + from + amount + _proof_of_ownership + mainTimeStamp;
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined_raw_data));
                return Encoding.Default.GetString(bytes);
            }
        }

        internal string Get_First_Pervious_Hash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                Random rand = new Random();
                int amount = rand.Next(0, 1000);
                string combined_raw_data = "Random" + DateTime.Now + amount;
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined_raw_data));
                return Encoding.Default.GetString(bytes);
            }
        }

        internal bool Validate_Chain(List<BlockData> block_chain)
        {
            Boolean isValid = false;
            for (int i = 0; i < block_chain.Count; i++)
            {
                if (block_chain.Count > 1)
                {
                    if (i + 1 < block_chain.Count && block_chain[i]._hash == block_chain[i + 1]._previous_hash)
                    {
                        isValid = true;
                    } 

                }
                else
                {
                    isValid = true;
                    break;
                   
                }
            }
            return isValid;
        }
        
    }
}
