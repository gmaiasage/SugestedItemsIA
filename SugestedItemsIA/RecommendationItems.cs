using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SugestedItemsIA
{
    [ComVisible(true)]
    [Guid("172DFF55-D1CC-43D2-9252-12AEF435FD4F")]
    public interface IRecommendationItems {
        IAItemList GetTopSales(int partyId);
        IAItemList GetItemSugetions(string itemId);
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IRecommendationItems))]
    [ProgId("RecommendationItems")]
    [Guid("0497F8E9-0C23-481C-AE11-446D47114B2E")]
    public class RecommendationItems : IRecommendationItems {
        private IAItemList _items;
        private List<Purchase> _items_purchases;

        public RecommendationItems() {
            _items = GenerateItems();
            _items_purchases = GeneratePurchases();
        }


        public IAItemList GetTopSales(int partyId) {
            IAItemList itemIAs = new IAItemList();

            var Items = _items_purchases
                .Where(p => p.ClientId == partyId)
                .GroupBy(p => p.ItemId)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => {
                    var item = _items.First(i => i.ItemID == g.Key);
                    return new ItemIA(item.ItemID, item.Description);
                });

            itemIAs.AddRange(Items);
             

            return itemIAs;
        }


        public IAItemList GetItemSugetions(string itemId) {
            IAItemList itemIAs = new IAItemList() ;
            var target = _items.FirstOrDefault(i => i.ItemID.Equals(itemId));
            if (target == null) return new IAItemList();
            var __items = _items
               .Where(i => !i.ItemID.Equals(itemId));
            //var ___items = __items
            //   .Select(i => new {
            //       Name = i.Description,
            //       Similarity = CosineSimilarity(GetVector(target.Description), GetVector(i.Description))
            //   });
            var Items = __items
                .Take(5)
                .Select(g => {
                    var item = __items.First(i => i.ItemID == g.ItemID);
                    return new ItemIA(item.ItemID, item.Description);
                });
            itemIAs.AddRange(Items);
            return itemIAs;
        }

        private float[] GetVector(string text) {
            // Simulação simples: conta de letras como vetor
            var vector = new float[26];
            foreach (char c in text.ToLower()) {
                if (char.IsLetter(c))
                    vector[c - 'a']++;
            }
            return vector;
        }

        private double CosineSimilarity(float[] a, float[] b) {
            float dot = 0, normA = 0, normB = 0;
            for (int i = 0; i < a.Length; i++) {
                dot += a[i] * b[i];
                normA += a[i] * a[i];
                normB += b[i] * b[i];
            }
            return dot / (Math.Sqrt(normA) * Math.Sqrt(normB));
        }

        private IAItemList GenerateItems() {
            IAItemList itemIAs = new IAItemList();
            itemIAs.Add(new ItemIA("1", "Caneta azul para escrita suave"));
            itemIAs.Add(new ItemIA("2", "Caneta vermelha para correções"));
            itemIAs.Add(new ItemIA("3", "Lápis preto HB para desenho"));
            itemIAs.Add(new ItemIA("4", "Marcador amarelo fluorescente"));
            itemIAs.Add(new ItemIA("5", "Caderno A4 com capa dura"));
            itemIAs.Add(new ItemIA("6", "Caderno pequeno para anotações"));
            itemIAs.Add(new ItemIA("7", "Borracha branca macia"));

            return itemIAs;
        }

        private List<Purchase> GeneratePurchases() {
            return new List<Purchase>
            {
                new Purchase(1, "1"),
                new Purchase(1, "2"),
                new Purchase(1, "2"),
                new Purchase(1, "3"),
                new Purchase(2, "5"),
                new Purchase(2, "6"),
                new Purchase(2, "5"),
                new Purchase(3, "1"),
                new Purchase(3, "7"),
                new Purchase(3, "1"),
                new Purchase(3, "2"),
            };
        }


    }
}
