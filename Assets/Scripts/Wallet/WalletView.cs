using TMPro;
using UnityEngine;

namespace Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _value;
        
        private Wallet _wallet;

        public void Initialize(Wallet wallet)
        {
            _wallet = wallet;
            
            UpdateText(_wallet.GetCurrentCoins());
            
            _wallet.CoinsChanged += UpdateText;
        }

        private void OnDestroy() => _wallet.CoinsChanged -= UpdateText;

        private void UpdateText(int value) => _value.text = value.ToString();
    }
}