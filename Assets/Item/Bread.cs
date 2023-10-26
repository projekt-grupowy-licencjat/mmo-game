using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Item
{
    public class Bread : Usable
    {
        public Bread(string addressablePath)
        {
            this.SpritePath = addressablePath;
        }

        public override async void LoadAsset()
        {
            var addressable = Addressables.LoadAssetAsync<Sprite>(this.SpritePath).Task;
            this.ItemAsset = await addressable;
        }
    }
}
