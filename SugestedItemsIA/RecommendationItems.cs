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
        //private List<Purchase> _items_purchases;

        public RecommendationItems() {
            _items = GenerateItems();
            //_items_purchases = GeneratePurchases();
        }


        public IAItemList GetTopSales(int partyId) {
            IAItemList itemIAs = new IAItemList();

            var Items = _items
                .Take(5)
                .Select(g => {
                    var item = _items.First(i => i.ItemID == g.ItemID);
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
            var Items = __items
                .Take(5)
                .Select(g => {
                    var item = __items.First(i => i.ItemID == g.ItemID);
                    return new ItemIA(item.ItemID, item.Description);
                });
            itemIAs.AddRange(Items);
            return itemIAs;
        }


        private IAItemList GenerateItems() {
            IAItemList itemIAs = new IAItemList();

            itemIAs.Add(new ItemIA("ARROZ001", "Arroz Carolino 1Kg"));
            itemIAs.Add(new ItemIA("ARROZ002", "Arroz Basmati 1Kg"));
            itemIAs.Add(new ItemIA("B7", "Gasóleo Simples"));
            itemIAs.Add(new ItemIA("B7.1", "Gasóleo Aditivado"));
            itemIAs.Add(new ItemIA("B7.2", "Gasóleo Agrícola"));
            itemIAs.Add(new ItemIA("BAT001", "Pilhas alcalinas AAA - 4un."));
            itemIAs.Add(new ItemIA("BAT002", "Pilhas alcalinas AAA - 8un."));
            itemIAs.Add(new ItemIA("BNDL0001", "Salada de fruta fresca - 2Kg"));
            itemIAs.Add(new ItemIA("CONJ001", "Conj001"));
            itemIAs.Add(new ItemIA("E10", "Gasolina Aditivada"));
            itemIAs.Add(new ItemIA("E5", "Gasolina Simples"));
            itemIAs.Add(new ItemIA("ELETR0001", "Comando universal de TV"));
            itemIAs.Add(new ItemIA("EMB0001", "Embalagem de plástico quadrada (10L)"));
            itemIAs.Add(new ItemIA("EQUIP0001", "Micro-ondas 1200W"));
            itemIAs.Add(new ItemIA("ESC0001", "Mochila azul tipo trolley"));
            itemIAs.Add(new ItemIA("ESC0002", "24 Canetas marcadores"));
            itemIAs.Add(new ItemIA("ESC0003", "12 Lápis de cor"));
            itemIAs.Add(new ItemIA("ESC0004", "Lápis de carvão Nº2 - 2Un."));
            itemIAs.Add(new ItemIA("ESC0005", "Caneta azul ponta fina"));
            itemIAs.Add(new ItemIA("ESC0006", "Borracha branca"));
            itemIAs.Add(new ItemIA("ESC0007", "Stick Cola"));
            itemIAs.Add(new ItemIA("FR0001", "Maçã Golden"));
            itemIAs.Add(new ItemIA("FR0002", "Kiwi nacional"));
            itemIAs.Add(new ItemIA("FR0003", "Ananás dos Açores"));
            itemIAs.Add(new ItemIA("FR0004", "Banana da Madeira"));
            itemIAs.Add(new ItemIA("FR0005", "Manga importada"));
            itemIAs.Add(new ItemIA("GPL", "Autogás"));
            itemIAs.Add(new ItemIA("GPL.12", "Garrafa Butano 12 Kg"));
            itemIAs.Add(new ItemIA("H2O33", "Água - 6 x 33 cl"));
            itemIAs.Add(new ItemIA("H2O6L", "Água - Garrafão 6L"));
            itemIAs.Add(new ItemIA("HIG001", "Detergente Lava tudo 2L"));
            itemIAs.Add(new ItemIA("PACK0001", "Pack promocional All in 1"));
            itemIAs.Add(new ItemIA("PAO001", "Pão de forma 800g"));
            itemIAs.Add(new ItemIA("PAO002", "Pão de forma 480g"));
            itemIAs.Add(new ItemIA("SUMO001", "Sumo 100% - Maçã 1L"));
            itemIAs.Add(new ItemIA("SUMO002", "Sumo 100% - Laranja 1L"));
            itemIAs.Add(new ItemIA("SV001", "Avaliação e orçamentação de reparação"));
            itemIAs.Add(new ItemIA("SV002", "Preparação de produtos frescos"));
            itemIAs.Add(new ItemIA("SVC001", "Contrato de manutenção mensal"));
            itemIAs.Add(new ItemIA("SVC002", "Extensão de garantia - 1 ano"));
            itemIAs.Add(new ItemIA("SVC003", "Contrato de manutenção anual"));
            itemIAs.Add(new ItemIA("TSHIRT001", "T-shirt algodão estampada (M)"));
            itemIAs.Add(new ItemIA("TSHIRT002", "T-shirt algodão estampada (F)"));


            return itemIAs;
        }




    }
}
